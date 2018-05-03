from socket import *
import utils
import sqlite3
import io
import os
import shutil
import base64
import time


class Useresponse:
    """This class contains all of the main response to the client commands.

    It contains 6 variables,
    "BUFSIZ" is the main recv size,
    "clientsock" is the socket between the server and the user,
    "c" & "conn" is for managing the Database,
    "PATH" is the path that "Server.py" is being ran from,
    "username" is the current client username.
    """

    def __init__(self, clisock, c, conn, path, username):
        #Setting the variables of the class
        self.BUFSIZ = 1024
        self.clientsock = clisock
        self.c = c
        self.conn = conn
        self.PATH = path
        self.username = username

    def new_project(self):
        """Creating a new project.

        The function gets the project name, the first version content and type from the client,
        after doing some checks (like if project already exists),
        creating a new folder with the name of the project,
        adds the first version to the folder,
        adds the project to the user Database.
        """
        size = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("Size Gotten")
        proInfo = self.clientsock.recv(1024)
        proName = proInfo.split(".")[0]
        proType = proInfo.split(".")[1]
        dirs = os.listdir(self.PATH + "\\Projects")
        for directory in dirs:
            if directory == proName:
                self.clientsock.send("NO")
                return
        self.clientsock.send("Info Gotten")
        size = int(size)
        current_Size = 0
        buffer = b""
        while current_Size < size:
            data = self.clientsock.recv(1024)
            if not data:
                break
            if len(data) + current_Size > size:
                data = data[:size - current_Size]
            buffer += data
            current_Size += len(data)
        self.clientsock.send("File Gotten")
        proPath = self.PATH + "\\Projects" + "\\" + proName
        if not os.path.exists(proPath):
            os.makedirs(proPath)
        commentsFile = open(proPath + "\\comments.txt", "w")
        commentsFile.close()
        proPath = proPath + "\\1." + proType
        with io.FileIO(proPath, "w") as file:
            file.write(buffer)
            file.close()
        self.c.execute("INSERT INTO " + self.username + " VALUES (?, 1, ?, ?)",
                       (proName, "NoOne", "NoOne"))
        self.conn.commit()

    def delete_project(self):
        """Deltes a project.

        The function gets a project name from the client,
        after doing some checks (like if the project is shared),
        delets the project folder and removes the project from the Database.
        """
        proName = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("OK")
        self.c.execute(
            "SELECT sharing FROM " + self.username + " WHERE name=:data",
            {'data': proName})
        sharing = str(self.c.fetchone())
        sharing = sharing.replace("(u'", "").replace("',)", "")
        if sharing != "Admin":
            proPath = self.PATH + "\\Projects\\" + proName + "\\"
            if "^" in sharing:
                users = sharing.split("^")
                for user in users:
                    self.c.execute("DELETE FROM " + user + " WHERE name=:data",
                                   {'data': proName})
                    self.conn.commit()
            elif sharing != "NoOne":
                self.c.execute("DELETE FROM " + sharing + " WHERE name=:data",
                               {'data': proName})
                self.conn.commit()
            shutil.rmtree(proPath)
        self.c.execute(
            "SELECT shared FROM " + self.username + " WHERE name=:data",
            {'data': proName})
        shared = str(self.c.fetchone())
        shared = shared.replace("(u'", "").replace("',)", "")
        if shared != "NoOne":
            self.c.execute(
                "SELECT sharing FROM " + shared + " WHERE name=:data",
                {'data': proName})
            new_sharing = str(self.c.fetchone())
            if "^" in new_sharing:
                new_sharing = new_sharing.replace("(u'", "").replace(
                    "',)", "").replace(self.username + "^", "").replace(
                        "^" + self.username, "")
            else:
                new_sharing = new_sharing.replace("(u'", "").replace(
                    "',)", "").replace(self.username, "")
            if new_sharing == "":
                new_sharing = "NoOne"
            self.c.execute("UPDATE " + shared + " SET sharing=? WHERE name=?",
                           [new_sharing, proName])
            self.conn.commit()
        self.c.execute("DELETE FROM " + self.username + " WHERE name=:data",
                       {'data': proName})
        self.conn.commit()

    def download_project(self):
        """Downloading Version That Isn't A Branch.

        The function gets a project name and a version from that project from the client,
        then searches the version in the project folder,
        gets the first content of the version (delta is being saved),
        sends the client the content and the type of the version file.
        """
        isPng = False
        isTxt = False
        proInfo = self.clientsock.recv(self.BUFSIZ)
        proName = proInfo.split(",")[0]
        proVer = proInfo.split(",")[1]
        if '.' in proVer:
            self.download_branch(proInfo)
            return
        proPath = self.PATH + "\\Projects" + "\\" + proName + "\\"
        filesInDir = os.listdir(proPath)
        filesInDir.sort()
        proVer = proVer.replace(".", "_").replace(" ", "")
        oldVerContent = ""
        for file in filesInDir:
            if file.split('.')[0] == proVer:
                if file.split('.')[1] == "png":
                    isPng = True
        if isPng == False:
            for file in filesInDir:
                if '_' not in file:
                    if file.split('.')[0] == "1":
                        verName = file
                        with open(proPath + file, 'r') as verOneFile:
                            oldVerContent = verOneFile.read()
                    if file.split('.')[1] == "png" and int(
                            file.split('.')[0]) <= int(proVer):
                        isPng = True
            if proVer != "1":
                for x in range(2, int(proVer) + 1):
                    for file in filesInDir:
                        if '_' not in file:
                            if file.split('.')[0] == str(x):
                                verName = file
                                with open(proPath + file, 'r') as verXFile:
                                    oldVerContent = utils.restore_delta(
                                        oldVerContent, verXFile.read(), isTxt)
                                if file.split('.')[1] == "png":
                                    isPng = True
                            if file.split('.')[1] == "txt" and file.split('.')[0] == proVer:
                                    isTxt = True
            if isPng == False:
                time.sleep(0.1)
                self.clientsock.send(str(len(oldVerContent.encode('utf-8'))))
                self.clientsock.recv(self.BUFSIZ)
                self.clientsock.send(
                    str(oldVerContent) + "`~`" + verName.split('.')[1])
                self.clientsock.recv(self.BUFSIZ)
            else:
                time.sleep(0.1)
                for file in filesInDir:
                    if file.split('.')[0] == proVer:
                        verName = file
                with open(proPath + verName, 'rb') as verFile:
                    verContent = verFile.read()
                self.clientsock.send(str(len(verContent.encode('utf-8'))))
                self.clientsock.recv(self.BUFSIZ)
                self.clientsock.send(
                    str(verContent) + "`~`" + verName.split('.')[1])
                self.clientsock.recv(self.BUFSIZ)
        else:
            time.sleep(0.1)
            for file in filesInDir:
                if file.split('.')[0] == proVer:
                    verName = file
                    break
            with open(proPath + verName, 'rb') as verPic:
                verContent = verPic.read()
            imageStr = base64.b64encode(verContent)
            self.clientsock.send(str(len(imageStr) * 10))
            self.clientsock.recv(self.BUFSIZ)
            time.sleep(0.1)
            self.clientsock.send(imageStr + "`~`" + verName.split('.')[1])
            self.clientsock.recv(self.BUFSIZ)
        time.sleep(0.1)

    def download_branch(self, proInfo):
        """Downloading A Branch Version.

        This function is called when the function "download_project" gets a branch version to download,
        it gets the project name and the branch version, the function gets the orginal file (from delta),
        then it sends the content and the information about the file to the client.
        """
        isPng = False
        isTxt = False
        proName = proInfo.split(",")[0]
        branchVer = proInfo.split(",")[1].replace(' ', '')
        proPath = self.PATH + "\\Projects" + "\\" + proName + "\\"
        filesInDir = os.listdir(proPath)
        filesInDir.sort()
        oldBranchContent = ""
        for file in filesInDir:
            if file.split('.')[0].replace(
                    '_', '.') == branchVer.split('.')[0] + ".1":
                with open(proPath + file, 'rb') as firstBranchFile:
                    oldBranchContent = firstBranchFile.read()
                if file.split('.')[1] == "png":
                    isPng = True
            if file.split('.')[0].replace('_', '.') == branchVer:
                if file.split('.')[1] == "png":
                    isPng = True
        if isPng == False and branchVer.split('.')[1] != "1":
            for x in range(2, int(branchVer.split('.')[1]) + 1):
                for file in filesInDir:
                    if file.split('.')[
                            0] == branchVer.split('.')[0] + "_" + str(x):
                        verName = file
                        with open(proPath + file, 'r') as verXFile:
                            oldBranchContent = utils.restore_delta(
                                oldBranchContent, verXFile.read(), isTxt)
                            if file.split('.')[1] == "png":
                                isPng = True
                    if file.split('.')[1] == "txt" and file.split('.')[0].replace('_', '.') == branchVer.split('.'):
                                isTxt = True
            if isPng == False:
                time.sleep(0.1)
                self.clientsock.send(
                    str(len(oldBranchContent.encode('utf-8'))))
                self.clientsock.recv(self.BUFSIZ)
                self.clientsock.send(
                    str(oldBranchContent) + "`~`" + verName.split('.')[1])
                self.clientsock.recv(self.BUFSIZ)
            else:
                time.sleep(0.1)
                for file in filesInDir:
                    if file.split('.')[0].replace('_', '.') == branchVer:
                        branchName = file
                        break
                with open(proPath + branchName, 'rb') as branchFile:
                    branchContent = branchFile.read()
                self.clientsock.send(str(len(branchContent.encode('utf-8'))))
                self.clientsock.recv(self.BUFSIZ)
                time.sleep(0.1)
                self.clientsock.send(
                    branchContent + "`~`" + branchName.split('.')[1])
                self.clientsock.recv(self.BUFSIZ)
        else:
            time.sleep(0.1)
            if branchVer.split('.')[1] != "1":
                for file in filesInDir:
                    if file.split('.')[0].replace('_', '.') == branchVer:
                        branchName = file
                        break
                with open(proPath + branchName, 'rb') as branchFile:
                    branchContent = branchFile.read()
                imageStr = base64.b64encode(branchContent)
                self.clientsock.send(str(len(imageStr) * 10))
                self.clientsock.recv(self.BUFSIZ)
                time.sleep(0.1)
                self.clientsock.send(
                    imageStr + "`~`" + branchName.split('.')[1])
                self.clientsock.recv(self.BUFSIZ)
            else:
                for file in filesInDir:
                    if file.split('.')[0].replace('_', '.') == branchVer:
                        branchName = file
                        break
                with open(proPath + branchName, 'rb') as branchFile:
                    branchContent = branchFile.read()
                self.clientsock.send(str(len(branchContent.encode('utf-8'))))
                self.clientsock.recv(self.BUFSIZ)
                time.sleep(0.1)
                self.clientsock.send(
                    branchContent + "`~`" + branchName.split('.')[1])
                self.clientsock.recv(self.BUFSIZ)
        time.sleep(0.1)

    def share_project(self):
        """Sharing a project with a new user.

        This function gets the project name, its versions, username to share with from the client,
        after doing checks (for example if no such user), the function adds the project and versions to the user Database.
        """
        shareInfo = self.clientsock.recv(self.BUFSIZ)
        proName = shareInfo.split("^")[0]
        proVers = shareInfo.split("^")[1]
        uName = shareInfo.split("^")[2]
        self.c.execute("SELECT * FROM UsersDB WHERE username=:data",
                       {'data': uName})
        if self.c.fetchone() == None:
            self.clientsock.send("NO")
            return
        self.c.execute(
            "SELECT sharing FROM " + self.username + " WHERE name=:data",
            {'data': proName})
        isSharing = str(self.c.fetchone())
        isSharing = isSharing.replace("(u'", "").replace("',)", "")
        if isSharing == "Admin":
            self.clientsock.send("NO1")
            return
        if "^" in isSharing:
            for user in isSharing.split("^"):
                if user == uName:
                    self.clientsock.send("NO2")
                    return
        if isSharing == uName:
            self.clientsock.send("NO2")
            return
        if self.username == uName:
            self.clientsock.send("NO3")
            return
        self.clientsock.send("OK")
        self.c.execute("SELECT * FROM " + uName + " WHERE name=:data",
                       {'data': proName})
        if self.c.fetchone() == None:
            self.c.execute(
                "SELECT sharing FROM " + self.username + " WHERE name=:data",
                {'data': proName})
            sharing = str(self.c.fetchone())
            sharing = sharing.replace("(u'", "").replace("',)", "")
            self.c.execute("INSERT INTO " + uName + " VALUES (?,?,?,?)",
                           (proName, proVers, self.username, "Admin"))
            self.conn.commit()
            if sharing == "NoOne":
                self.c.execute(
                    "UPDATE " + self.username + " SET sharing=? WHERE name=?",
                    [uName, proName])
                self.conn.commit()
            else:
                sharing = sharing + "^" + uName
                self.c.execute(
                    "UPDATE " + self.username + " SET sharing=? WHERE name=?",
                    [sharing, proName])
                self.conn.commit()

    def new_branch(self):
        """Creating a new branch.

        The function gets a project, branch version, and file content and type from the client,
        the function creates a new branch and saves it in the project folder.
        """
        size = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("Size Gotten")
        proInfo = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("Info Gotten")
        proName = proInfo.split("^")[0]
        branchVer = proInfo.split("^")[1]
        branchVer = branchVer.replace(" ", "")
        extension = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("Extension Gotten")
        size = int(size)
        current_Size = 0
        buffer = b""
        while current_Size < size:
            data = self.clientsock.recv(1024)
            if not data:
                break
            if len(data) + current_Size > size:
                data = data[:size - current_Size]
            buffer += data
            current_Size += len(data)
        self.clientsock.send("Content Gotten")
        branchPath = self.PATH + "\\Projects\\" + proName + "\\" + branchVer + "_1." + extension
        with io.FileIO(branchPath, "w") as f:
            f.write(buffer)
            f.close()
        time.sleep(0.1)

    def update_project(self):
        """Updating a non-branch version.

        This function gets a project name, version, content and file type from the client,
        then its getting the delta for the new version,
        saving the delta in the project folder and updating the Database (also with sharing).
        """
        isPng = False
        proName = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("OK")
        size = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("Size Gotten")
        self.c.execute("SELECT * FROM " + self.username + " WHERE name=:data",
                       {'data': proName})
        pro = str(self.c.fetchone())
        isSharing = pro.split(',')[2]
        isSharing = isSharing.replace(" u'", "").replace("'", "")
        sharing = pro.split(',')[3]
        sharing = sharing.replace(" u'", "").replace("')", "")
        pro = pro.split(',')[1]
        pro = pro[1:2]
        pro = str(int(pro) + 1)
        self.c.execute(
            "UPDATE " + self.username + " SET version=? WHERE name=?",
            [int(pro), proName])
        self.conn.commit()
        if isSharing != "NoOne":
            self.c.execute(
                "UPDATE " + isSharing + " SET version=? WHERE name=?",
                [int(pro), proName])
            self.conn.commit()
            self.c.execute(
                "SELECT sharing FROM " + isSharing + " WHERE name=:data",
                {'data': proName})
            users = str(self.c.fetchall())
            users = users.replace("[(u'", "").replace("',)]", "")
            if "^" in users:
                users = users.split("^")
                for user in users:
                    self.c.execute(
                        "UPDATE " + user + " SET version=? WHERE name=?",
                        [int(pro), proName])
                    self.conn.commit()
        if sharing != "NoOne":
            if "^" in sharing:
                users = sharing.split("^")
                for user in users:
                    self.c.execute(
                        "UPDATE " + user + " SET version=? WHERE name=?",
                        [int(pro), proName])
                    self.conn.commit()
        fileInfo = self.clientsock.recv(self.BUFSIZ)
        if fileInfo == "png":
            isPng = True
        if fileInfo == "txt":
            isTxt = True
        else:
            isTxt = False
        self.clientsock.send("Info Gotten")
        size = int(size)
        current_Size = 0
        buffer = b""
        while current_Size < size:
            data = self.clientsock.recv(1024)
            if not data:
                break
            if len(data) + current_Size > size:
                data = data[:size - current_Size]
            buffer += data
            current_Size += len(data)
        self.clientsock.send("File Gotten")
        proPath = self.PATH + "\\Projects\\" + proName + "\\"
        filesInDir = os.listdir(proPath)
        filesInDir.sort()
        for file in filesInDir:
            if file.split('.')[1] == "png":
                isPng = True
                break
        if isPng == False:
            oldVerContent = ""
            for file in filesInDir:
                if file.split('.')[0] == "1":
                    with open(proPath + file, 'r') as verOneFile:
                        oldVerContent = verOneFile.read()
            for x in range(2, int(pro)):
                for file in filesInDir:
                    if file.split('.')[0] == str(x):
                        with open(proPath + file, 'r') as verXFile:
                            oldVerContent = utils.restore_delta(
                                oldVerContent, verXFile.read(), isTxt)
            delta = utils.get_delta(oldVerContent, str(buffer), isTxt)
            proPath = self.PATH + "\\Projects\\" + proName + "\\" + pro + "." + fileInfo
            with io.FileIO(proPath, "w") as f:
                f.write(delta)
                f.close()
        else:
            proPath = self.PATH + "\\Projects\\" + proName + "\\" + pro + "." + fileInfo
            with io.FileIO(proPath, "w") as f:
                f.write(buffer)
                f.close()
        time.sleep(0.1)

    def update_branch(self):
        """Updating a branch in a project.

        This function gets project name, the branch we updating, file content and type from the client,
        then getting the delta for the new version, saving the delta to a new file in the project folder.
        """
        isTxt = False
        isPng = False
        size = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("Size Gotten")
        proInfo = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("Info Gotten")
        extension = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("Extension Gotten")
        size = int(size)
        current_Size = 0
        buffer = b""
        while current_Size < size:
            data = self.clientsock.recv(1024)
            if not data:
                break
            if len(data) + current_Size > size:
                data = data[:size - current_Size]
            buffer += data
            current_Size += len(data)
        self.clientsock.send("Content Gotten")
        proName = proInfo.split('^')[0]
        branchVer = proInfo.split('^')[1]
        proPath = self.PATH + "\\Projects" + "\\" + proName + "\\"
        filesInDir = os.listdir(proPath)
        filesInDir.sort()
        if extension == "png":
            isPng = True
        oldVerContent = ""
        for file in filesInDir:
            if file.split('.')[0] == branchVer.split('.')[0] + "_1":
                with open(proPath + file, 'rb') as branchFile:
                    oldVerContent = branchFile.read()
                if file.split('.')[1] == "txt":
                    isTxt = True
                if file.split('.')[1] == "png":
                    isPng = True
        if isPng == False:
            for x in range(2, int(branchVer.split('.')[1]) + 1):
                for file in filesInDir:
                    if file.split('.')[
                            0] == branchVer.split('.')[0] + "_" + str(x):
                        with open(proPath + file, 'rb') as oldBranchFile:
                            oldVerContent = utils.restore_delta(
                                oldVerContent, oldBranchFile.read(), isTxt)
                        if file.split('.')[1] == "txt":
                            isTxt = True
                        if file.split('.')[1] == "png":
                            isPng = True
            if extension == "txt":
                isTxt = True
            if isPng == False:
                newBranchContent = utils.get_delta(oldVerContent, str(buffer),
                                                   isTxt)
                branchVer = branchVer.split('.')[0] + "_" + str(
                    int(branchVer.split('.')[1]) + 1)
                proPath = self.PATH + "\\Projects\\" + proName + "\\" + branchVer + "." + extension
                with io.FileIO(proPath, "w") as f:
                    f.write(newBranchContent)
                    f.close()
            else:
                branchVer = branchVer.split('.')[0] + "_" + str(
                    int(branchVer.split('.')[1]) + 1)
                proPath = self.PATH + "\\Projects\\" + proName + "\\" + branchVer + "." + extension
                with io.FileIO(proPath, "w") as f:
                    f.write(buffer)
                    f.close()
        else:
            branchVer = branchVer.split('.')[0] + "_" + str(
                int(branchVer.split('.')[1]) + 1)
            proPath = self.PATH + "\\Projects\\" + proName + "\\" + branchVer + "." + extension
            with io.FileIO(proPath, "w") as f:
                f.write(buffer)
                f.close()
        time.sleep(0.1)

    def send_preview(self):
        """Sends a preiew of a non-branch version to the client.

        This function gets a project and a version in the project, 
        it finds the request version and restoring it from delta (if needed),
        then sends its content and type to the client.
        """
        isPng = False
        isTxt = True
        proInfo = self.clientsock.recv(self.BUFSIZ)
        proName = proInfo.split("^")[0]
        proVer = proInfo.split("^")[1]
        if '.' in proVer:
            self.send_previewB(proInfo)
            return
        proPath = self.PATH + "\\Projects" + "\\" + proName + "\\"
        filesInDir = os.listdir(proPath)
        filesInDir.sort()
        proVer = proVer.replace('.', '_').replace(' ', '')
        oldVerContent = ""
        for file in filesInDir:
            if file.split('.')[0] == proVer:
                if file.split('.')[1] == "png":
                    isPng = True
                    break
        if isPng == False:
            for file in filesInDir:
                if '_' not in file:
                    if file.split('.')[0] == "1":
                        verName = file
                        with open(proPath + file, 'r') as verOneFile:
                            oldVerContent = verOneFile.read()
                    if file.split('.')[1] == "png" and int(
                            file.split('.')[0]) <= int(proVer):
                        isPng = True
            if proVer == "1":
                time.sleep(0.1)
                self.clientsock.send(str(len(oldVerContent.replace("\n", "\r\n").encode('utf-8'))))
                self.clientsock.recv(self.BUFSIZ)
                self.clientsock.send(str(oldVerContent.replace("\n", "\r\n")))
                self.clientsock.recv(self.BUFSIZ)
            if proVer != "1":
                for x in range(2, int(proVer) + 1):
                    for file in filesInDir:
                        if '_' not in file:
                            if file.split('.')[0] == str(x):
                                verName = file
                                with open(proPath + file, 'r') as verXFile:
                                    oldVerContent = utils.restore_delta(
                                        oldVerContent, verXFile.read(), isTxt)
                                if file.split('.')[1] == "png":
                                    isPng = True
            if isPng == False:
                time.sleep(0.1)
                self.clientsock.send(str(len(oldVerContent.encode('utf-8'))))
                self.clientsock.recv(self.BUFSIZ)
                self.clientsock.send(str(oldVerContent))
                self.clientsock.recv(self.BUFSIZ)
            else:
                time.sleep(0.1)
                for file in filesInDir:
                    if file.split('.')[0] == proVer:
                        verName = file
                with open(proPath + verName, 'rb') as verFile:
                    verContent = verFile.read()
                self.clientsock.send(str(len(verContent.encode('utf-8'))))
                self.clientsock.recv(self.BUFSIZ)
                self.clientsock.send(str(verContent))
                self.clientsock.recv(self.BUFSIZ)
        else:
            time.sleep(0.1)
            for file in filesInDir:
                if file.split('.')[0] == proVer:
                    verName = file
                    break
            with open(proPath + verName, 'rb') as verPic:
                verContent = verPic.read()
            imageStr = base64.b64encode(verContent)
            self.clientsock.send(str(len(imageStr) * 10))
            self.clientsock.recv(self.BUFSIZ)
            time.sleep(0.1)
            self.clientsock.send(imageStr)
            self.clientsock.recv(self.BUFSIZ)
        time.sleep(0.1)

    def send_previewB(self, proInfo):
        """Sending a branch version content to the client.

        This function is being called from the function "send_preview" if it finds that a branch version is request,
        this function gets a project name and a branch version, it finds the version file and restoring it from delta (if needed),
        then it sends the content and type to the client.
        """
        isPng = False
        isTxt = True
        proName = proInfo.split("^")[0]
        branchVer = proInfo.split("^")[1].replace(' ', '')
        proPath = self.PATH + "\\Projects" + "\\" + proName + "\\"
        filesInDir = os.listdir(proPath)
        filesInDir.sort()
        oldBranchContent = ""
        for file in filesInDir:
            if file.split('.')[0].replace(
                    '_', '.') == branchVer.split('.')[0] + ".1":
                with open(proPath + file, 'rb') as firstBranchFile:
                    oldBranchContent = firstBranchFile.read()
                if file.split('.')[1] == "png":
                    isPng = True
            if file.split('.')[0].replace('_', '.') == branchVer:
                if file.split('.')[1] == "png":
                    isPng = True
        if isPng == False and branchVer.split('.')[1] != "1":
            for x in range(2, int(branchVer.split('.')[1]) + 1):
                for file in filesInDir:
                    if file.split('.')[
                            0] == branchVer.split('.')[0] + "_" + str(x):
                        verName = file
                        with open(proPath + file, 'r') as verXFile:
                            oldBranchContent = utils.restore_delta(
                                oldBranchContent, verXFile.read(), isTxt)
                        if file.split('.')[1] == "png":
                            isPng = True
            if isPng == False:
                time.sleep(0.1)
                self.clientsock.send(
                    str(len(oldBranchContent.encode('utf-8'))))
                self.clientsock.recv(self.BUFSIZ)
                self.clientsock.send(str(oldBranchContent))
                self.clientsock.recv(self.BUFSIZ)
            else:
                time.sleep(0.1)
                for file in filesInDir:
                    if file.split('.')[0].replace('_', '.') == branchVer:
                        branchName = file
                        break
                with open(proPath + branchName, 'rb') as branchFile:
                    branchContent = branchFile.read()
                self.clientsock.send(str(len(branchContent.encode('utf-8'))))
                self.clientsock.recv(self.BUFSIZ)
                time.sleep(0.1)
                self.clientsock.send(branchContent)
                self.clientsock.recv(self.BUFSIZ)
        else:
            time.sleep(0.1)
            if branchVer.split('.')[1] != "1":
                for file in filesInDir:
                    if file.split('.')[0].replace('_', '.') == branchVer:
                        branchName = file
                        break
                with open(proPath + branchName, 'rb') as branchFile:
                    branchContent = branchFile.read()
                imageStr = base64.b64encode(branchContent)
                self.clientsock.send(str(len(imageStr) * 10))
                self.clientsock.recv(self.BUFSIZ)
                time.sleep(0.1)
                self.clientsock.send(imageStr)
                self.clientsock.recv(self.BUFSIZ)
            else:
                for file in filesInDir:
                    if file.split('.')[0].replace('_', '.') == branchVer:
                        branchName = file
                        break
                with open(proPath + branchName, 'rb') as branchFile:
                    branchContent = branchFile.read()
                self.clientsock.send(str(len(branchContent.encode('utf-8'))))
                self.clientsock.recv(self.BUFSIZ)
                time.sleep(0.1)
                self.clientsock.send(branchContent)
                self.clientsock.recv(self.BUFSIZ)
        time.sleep(0.1)

    def comment(self):
        """Adds a new comment.

        This function gets a project, comment content, version from the client,
        it saves the information to the commtents file in the project folder.
        """
        commentInfo = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("OK")
        proName = commentInfo.split("^")[0]
        commentContent = commentInfo.split("^")[1]
        commentVersion = commentInfo.split("^")[2]
        commentsPath = self.PATH + "\\Projects" + "\\" + proName + "\\" + "comments.txt"
        with open(commentsPath, "a") as commentsFile:
            commentsFile.write(commentVersion + "^" + self.username + ":^" +
                               commentContent + "\n")

    def get_comments(self):
        """Sending a project comments to the user.

        This function gets a project name from the client,
        it gets all of the comments of the project and ordering it in lowering order,
        then it sends it to the client.
        """
        proName = self.clientsock.recv(self.BUFSIZ)
        commentsPath = self.PATH + "\\Projects" + "\\" + proName + "\\" + "comments.txt"
        with open(commentsPath, "r") as commentsFile:
            Comments = commentsFile.read()
            if Comments != "":
                newComments = '\n'.join(
                    sorted(
                        Comments.split('\n'),
                        key=lambda x: x[:1] if '.' not in x else x[:3]))
                self.clientsock.send(newComments)
            else:
                self.clientsock.send("No Comments Yet\n Be The First One")