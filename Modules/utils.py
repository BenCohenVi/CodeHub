from socket import *
from difflib import *
import os, sys, ast, string


def get_local_host():
    return gethostbyname(gethostname())


def get_open_port():
    s = socket(AF_INET, SOCK_STREAM)
    s.bind(("", 0))
    s.listen(1)
    port = s.getsockname()[1]
    s.close()
    return port


def get_path():
    path = os.path.abspath(__file__)
    directory = os.path.dirname(path).split("\\")
    del directory[-1]
    return "\\".join(directory)


def get_delta(main_file, new_file, isTxt):
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


def get_branches(proPath):
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


def restore_delta(oldFile, changes, isTxt):
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
                        newFile += oldLines[x] + "\r\n"
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
                    newFile += "\r\n" + line.split('`')[2]
                lastRemoved = False
        return newFile
    else:
        return oldFile
