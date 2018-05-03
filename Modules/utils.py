from socket import *
from difflib import *
import os, sys, ast, string


def get_local_host():
    #Returns the local computer IP
    return gethostbyname(gethostname())


def get_open_port():
    #Returns an open port
    s = socket(AF_INET, SOCK_STREAM)
    s.bind(("", 0))
    s.listen(1)
    port = s.getsockname()[1]
    s.close()
    return port


def get_path():
    #Returns the path that "Server.py" is being ran from
    path = os.path.abspath(__file__)
    directory = os.path.dirname(path).split("\\")
    del directory[-1]
    return "\\".join(directory)


def get_branches(proPath):
    """Gets the branches in a project.

    The function gets a path to a project folder,
    then for each file in the folder checks if it is a branch,
    if it is adds it to the "branches string",
    the function formats the string so instead of "2.1, 2.2, ... 2.n" it will be "2.1-2.n".
    """
    proVers = os.listdir(proPath)
    branches = ""
    lastBranch = ""
    lastBranchFull = ""
    for ver in proVers:
        if '_' in ver:
            if ver.split('.')[0].split('_')[0] == lastBranch:
                branches = string.replace(branches, lastBranchFull,
                                          ver.split('.')[0])
                lastBranchFull = ver.split('.')[0]
                lastBranch = ver.split('.')[0].split('_')[0]
            else:
                branches = branches + "," + ver.split('.')[0]
                lastBranchFull = ver.split('.')[0]
                lastBranch = ver.split('.')[0].split('_')[0]
    branches = branches[1:]
    if len(branches) > 0:
        branches = branches + ",0_0"
    return branches


def get_type(clientsock, PATH):
    """Sends the file type of a specific file.

    The function gets a socket that is connect to the client and the main path,
    then gets a project and version from the client by the socket,
    the function finds the version file and sends the type of the file to the client.
    """
    proInfo = clientsock.recv(1024)
    proName = proInfo.split("^")[0]
    proVer = proInfo.split("^")[1]
    proPath = PATH + "\\Projects" + "\\" + proName + "\\"
    filesInDir = os.listdir(proPath)
    filesInDir.sort()
    proVer = proVer.replace(".", "_").replace(" ", "")
    for file in filesInDir:
        if file.split(".")[0] == proVer:
            proName = file
            break
    clientsock.send(proName.split(".")[1])


def get_delta(main_file, new_file, isTxt):
    """Returns the changes between two texts.

    The function gets 2 strings and bool if the file content is from ".txt",
    then the function compares each line in the strings to the equal line index in the other string,
    if not the same adds it to the changes string, in the ends returns this string.
    """
    if isTxt == True:
        extension = "\r\n"
    else:
        extension = "\n"
    old_lines = main_file.split('\n')
    new_lines = new_file.split('\n')
    changes = ""
    if len(new_lines) >= len(old_lines):
        for x in range(0, len(old_lines)):
            if old_lines[x] != new_lines[x]:
                changes += "-`" + str(x) + extension
                changes += "+`" + str(x) + "`" + new_lines[x] + extension
        for i in range(len(old_lines), len(new_lines)):
            changes += "+`" + str(i) + "`" + new_lines[i] + extension
    else:
        for x in range(0, len(new_lines)):
            if old_lines[x] != new_lines[x]:
                changes += "-`" + str(x) + extension
                changes += "+`" + str(x) + "`" + new_lines[x] + extension
        for i in range(len(new_lines), len(old_lines)):
            changes += "-`" + str(i) + extension
    return changes


def restore_delta(oldFile, changes, isTxt):
    """Returns the first text from a text and the changes.

    The function gets 2 string and bool if the file content is from ".txt",
    the function checks every line in the changes string and acts accordingly,
    if the line has a "+" adding the line to the old string (by index),
    if the line has a "-" removes a line from the old string (by index),
    in the end we are left with the original text there was.
    """
    if changes != "":
        if isTxt == True:
            extension = "\r\n"
        else:
            extension = "\n"
        newFile = ""
        oldLines = oldFile.split('\n')
        lineIndex = 0
        lastRemoved = False
        for line in changes.split('\n'):
            if line.split('`')[0] == "-":
                #In Case Of Removing
                if lastRemoved == False:
                    lineNumber = int(line.split('`')[1])
                    oldLines[lineNumber] = ""
                    for x in range(lineIndex, lineNumber):
                        newFile += oldLines[x] + extension
                        lineIndex += 1
                    lastRemoved = True
                else:
                    newFile = newFile[:newFile.rfind('\n')]
                    break
            elif line.split('`')[0] == "+":
                #In Case Of Adding
                if lastRemoved == True:
                    newFile += line.split('`')[2]
                else:
                    newFile += extension + line.split('`')[2]
                lastRemoved = False
        return newFile
    else:
        return oldFile
