from socket import *
import utils, sqlite3, io, os, shutil, base64, time


class Useresponse:
    def __init__(self, clisock, c, conn, path, username):
        self.BUFSIZ = 1024
        self.clientsock = clisock
        self.c = c
        self.conn = conn
        self.PATH = path
        self.username = username


    def new_project(self):
        fileBuffSize = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("Size Gotten")
        Content = self.clientsock.recv(int(fileBuffSize)+100)
        self.clientsock.send("File Gotten")
        proInfo = self.clientsock.recv(self.BUFSIZ)
        proName = proInfo.split(".")[0]
        proType = proInfo.split(".")[1]
        dirs = os.listdir(self.PATH+"\\Projects")
        for directory in dirs:
            if directory == proName:
                self.clientsock.send("NO")
                return
        self.clientsock.send("Info Gotten")
        proPath = self.PATH+"\\Projects" +"\\"+ proName
        if not os.path.exists(proPath):
            os.makedirs(proPath)
        commentsFile = open(proPath+"\\comments.txt", "w")
        commentsFile.close()
        proPath = proPath + "\\1."+ proType
        with io.FileIO(proPath, "w") as file:
            file.write(Content)
            file.close()
        self.c.execute("INSERT INTO "+self.username+" VALUES (?, 1, ?, ?)", (proName,"NoOne", "NoOne"))
        self.conn.commit()


    def delete_project(self):
        proName = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("OK")
        self.c.execute("SELECT sharing FROM "+self.username+" WHERE name=:data", {'data':proName})
        sharing = str(self.c.fetchone())
        sharing = sharing.replace("(u'","").replace("',)","")
        if sharing != "Admin":
            proPath = self.PATH+"\\Projects\\"+proName+"\\"
            if "^" in sharing:
                users = sharing.split("^")
                for user in users:
                    self.c.execute("DELETE FROM "+user+" WHERE name=:data", {'data':proName})
                    self.conn.commit()
            else:
                self.c.execute("DELETE FROM "+sharing+" WHERE name=:data", {'data':proName})
                self.conn.commit()
            shutil.rmtree(proPath)
        self.c.execute("SELECT shared FROM "+self.username+" WHERE name=:data", {'data':proName})
        shared = str(self.c.fetchone())
        shared = shared.replace("(u'","").replace("',)","")
        if shared != "NoOne":
            self.c.execute("SELECT sharing FROM "+shared+" WHERE name=:data", {'data':proName})
            new_sharing = str(self.c.fetchone())
            if "^" in new_sharing:
                new_sharing = new_sharing.replace("(u'","").replace("',)","").replace(self.username+"^", "").replace("^"+self.username, "")
            else:
                new_sharing = new_sharing.replace("(u'","").replace("',)","").replace(self.username, "")
            if new_sharing == "":
                new_sharing = "NoOne"
            self.c.execute("UPDATE "+shared+" SET sharing=? WHERE name=?", [new_sharing, proName])
            self.conn.commit()
        self.c.execute("DELETE FROM "+self.username+" WHERE name=:data", {'data':proName})
        self.conn.commit()
        

    def download_project(self):
        proInfo = self.clientsock.recv(self.BUFSIZ)
        proName = proInfo.split(",")[0]
        proVer = proInfo.split(",")[1]
        proPath = self.PATH+"\\Projects"+"\\"+proName+"\\"
        filesInDir = os.listdir(proPath)
        filesInDir.sort()
        proVer = proVer.replace(".", "_").replace(" ","")
        for file in filesInDir:
            if file.split(".")[0] == proVer:
                proName = file
                break
        proPath = proPath + proName
        verFile = open(proPath, "rb")
        if proName.split(".")[1] != "png":
            self.clientsock.send(str(os.path.getsize(proPath)))
            self.clientsock.recv(self.BUFSIZ)
            try:
                Content = utils.restore_delta(verFile.read())
            except:
                verFile = open(proPath, "rb")
                Content = verFile.read()
            self.clientsock.send(str(Content)+"`~`"+proName.split('.')[1])
            self.clientsock.recv(self.BUFSIZ)
            verFile.close()
        else:
            imageStr = base64.b64encode(verFile.read())
            self.clientsock.send(str(len(imageStr)*10))
            self.clientsock.recv(self.BUFSIZ)
            time.sleep(0.1)
            self.clientsock.send(imageStr +"`~`"+ proName.split('.')[1])
            self.clientsock.recv(self.BUFSIZ)
            verFile.close()


    def share_project(self):
        shareInfo = self.clientsock.recv(self.BUFSIZ)
        proName = shareInfo.split("^")[0]
        proVers = shareInfo.split("^")[1]
        uName = shareInfo.split("^")[2]
        self.c.execute("SELECT * FROM UsersDB WHERE username=:data", {'data':uName})
        if self.c.fetchone() == None:
            self.clientsock.send("NO")
            return
        self.c.execute("SELECT sharing FROM "+self.username+" WHERE name=:data", {'data':proName})
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
            print "user shares himself"
            self.clientsock.send("NO3")
            return
        self.clientsock.send("OK")
        self.c.execute("SELECT * FROM "+uName+" WHERE name=:data", {'data':proName})
        if self.c.fetchone() == None:
            self.c.execute("SELECT sharing FROM "+self.username+" WHERE name=:data" , {'data':proName})
            sharing = str(self.c.fetchone())
            sharing = sharing.replace("(u'", "").replace("',)", "")
            self.c.execute("INSERT INTO "+uName+" VALUES (?,?,?,?)", (proName, proVers, self.username,"Admin"))
            self.conn.commit()
            if sharing == "NoOne":
                self.c.execute("UPDATE "+self.username+" SET sharing=? WHERE name=?", [uName, proName])
                self.conn.commit()
            else:
                sharing = sharing+"^"+uName
                self.c.execute("UPDATE "+self.username+" SET sharing=? WHERE name=?", [sharing, proName])
                self.conn.commit()


    def new_branch(self):
        fileBuffSize = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("Size Gotten")
        proInfo = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("Info Gotten")
        proName = proInfo.split("^")[0]
        branchVer = proInfo.split("^")[1]
        branchVer = branchVer.replace(" ", "")
        Content = self.clientsock.recv(int(fileBuffSize)+100)
        self.clientsock.send("Content Gotten")
        extension = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("Extension Gotten")
        branchPath = self.PATH+"\\Projects\\"+proName+"\\"+branchVer+"_1."+extension
        with io.FileIO(branchPath, "w") as f:
            f.write(Content)
            f.close()


    def update_project(self):
        data = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("OK")
        fileBuffSize = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("Size Gotten")
        self.c.execute("SELECT * FROM "+self.username+" WHERE name=:data", {'data':data})
        pro = str(self.c.fetchone())
        isSharing = pro.split(',')[2]
        isSharing = isSharing.replace(" u'","").replace("'","")
        sharing = pro.split(',')[3]
        sharing = sharing.replace(" u'","").replace("')","")
        pro = pro.split(',')[1]
        pro = pro[1:2]
        pro = str(int(pro)+1)
        self.c.execute("UPDATE "+self.username+" SET version=? WHERE name=?", [int(pro), data])
        self.conn.commit()
        if isSharing != "NoOne":
            self.c.execute("UPDATE "+isSharing+" SET version=? WHERE name=?", [int(pro), data])
            self.conn.commit()
            self.c.execute("SELECT sharing FROM "+isSharing+" WHERE name=:data", {'data':data})
            users = str(self.c.fetchall())
            users = users.replace("[(u'", "").replace("',)]", "")
            if "^" in users:
                users = users.split("^")
                for user in users:
                    self.c.execute("UPDATE "+user+" SET version=? WHERE name=?", [int(pro), data])
                    self.conn.commit()
        if sharing != "NoOne":
            if "^" in sharing:
                users = sharing.split("^")
                for user in users:
                    self.c.execute("UPDATE "+user+" SET version=? WHERE name=?", [int(pro), data])
                    self.conn.commit()
        fileInfo = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("Info Gotten")
        NewVerContent = self.clientsock.recv(int(fileBuffSize)+100)
        self.clientsock.send("File Gotten")
        if fileInfo != "png":
            proPath = self.PATH+"\\Projects\\"+data+"\\"
            filesInDir = os.listdir(proPath)
            filesInDir.sort()
            done = False
            i = 2
            while not done:
                if not '_' in filesInDir[int(pro)-i]:
                    proName =  filesInDir[int(pro)-i]
                    done = True
                i = i + 1
            info = self.PATH+"\\Projects\\"+data+"\\"+proName
            lastVer = open(info, "r")
            try:
                lastData= utils.restore_delta(lastVer.read())
            except:
                lastData = lastVer.read()
            delta = utils.get_delta(lastData, NewVerContent)
            proPath = self.PATH+"\\Projects\\"+data+"\\"+pro+"."+fileInfo
            with io.FileIO(proPath, "w") as f:
                f.write(str(delta))
                f.close()
        else:
            proPath = self.PATH+"\\Projects\\"+data+"\\"+pro+"."+fileInfo
            with io.FileIO(proPath, "w") as f:
                f.write(NewVerContent)
                f.close()


    def update_branch(self):
        fileBuffSize = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("Size Gotten")
        proInfo = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("Info Gotten")
        proName = proInfo.split("^")[0]
        branchVer = proInfo.split("^")[1]
        Content = self.clientsock.recv(int(fileBuffSize)+100)
        self.clientsock.send(("Content Gotten"))
        extension = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("Extension Gotten")
        branchPath = self.PATH+"\\Projects\\"+proName+"\\"
        filesInDir = os.listdir(branchPath)
        bStart = int(branchVer.split(".")[0]) + int(branchVer.split(".")[1])
        branchName =  filesInDir[bStart-1]
        preBranch = self.PATH+"\\Projects\\"+proName+"\\"+branchName
        lastBranch = open(preBranch, "r")
        try:
            lastData = utils.restore_delta(lastBranch.read())
        except:
            lastBranch = open(preBranch, "r")
            lastData = lastBranch.read()
        delta = utils.get_delta(lastData, Content)
        branchPath = self.PATH+"\\Projects\\"+proName+"\\"+branchVer.split(".")[0]+"_"+str(int(branchVer.split(".")[1])+1)+"."+extension
        if extension != "png":
            with io.FileIO(branchPath, "w") as f:
                f.write(str(delta))
                f.close()
        else:
            with io.FileIO(branchPath, "w") as f:
                f.write(str(Content))
                f.close()


    def send_preview(self):
        proInfo = self.clientsock.recv(self.BUFSIZ)
        proName = proInfo.split("^")[0]
        Version = proInfo.split("^")[1]
        proPath = self.PATH+"\\Projects"+"\\"+proName+"\\"
        filesInDir = os.listdir(proPath)
        filesInDir.sort()
        Version = Version.replace(".", "_").replace(" ","")
        for file in filesInDir:
            if file.split(".")[0] == Version:
                proName = file
                break
        proPath = proPath + proName
        verFile = open(proPath, "rb")
        if proName.split(".")[1] != "png":
            self.clientsock.send(str(os.path.getsize(proPath)))
            self.clientsock.recv(self.BUFSIZ)
            try:
                Content = utils.restore_delta(verFile.read())
            except:
                verFile = open(proPath, "rb")
                Content = verFile.read()
            self.clientsock.send(str(Content))
            verFile.close()
        else:
            self.clientsock.send("10025")
            self.clientsock.recv(self.BUFSIZ)
            self.clientsock.send("Unable To Preview")
            verFile.close()


    def comment(self):
        commentInfo = self.clientsock.recv(self.BUFSIZ)
        self.clientsock.send("OK")
        proName = commentInfo.split("^")[0]
        commentContent = commentInfo.split("^")[1]
        commentsPath = self.PATH+"\\Projects"+"\\"+proName+"\\"+"comments.txt"
        with open(commentsPath, "a") as commentsFile:
            commentsFile.write(self.username+":\n"+commentContent+"\n")


    def get_comments(self):
        proName = self.clientsock.recv(self.BUFSIZ)
        commentsPath = self.PATH+"\\Projects"+"\\"+proName+"\\"+"comments.txt"
        with open(commentsPath, "r") as commentsFile:
            Comments = commentsFile.read()
            if Comments != "":
                self.clientsock.send(Comments)
            else:
                self.clientsock.send("No Comments Yet\n Be The First One")