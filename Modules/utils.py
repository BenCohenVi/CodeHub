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


def get_delta(main_file, new_file):
    old_lines = main_file.split('\n')
    new_lines = new_file.split('\n')
    print old_lines
    print new_lines
    old_lines_set = set(old_lines)
    new_lines_set = set(new_lines)
    old_added = old_lines_set - new_lines_set
    old_removed = new_lines_set - old_lines_set
    data = ""
    index = 0
    for line in old_lines:
        if line in old_added:
            data += str(index) + '-' + line.strip()+'\n'
        elif line in old_removed:
            data += str(index) + '+' + line.strip()+'\n'
        index += 1
    index = 0
    for line in new_lines:
        if line in old_added:
            data +=str(index) + '-' + line.strip()+'\n'
        elif line in old_removed:
            data += str(index) + '+' + line.strip()+'\n'
        index += 1
    print data
    return data


def restore_delta(delta):
    return ''.join(restore(ast.literal_eval(delta), 2))


def get_branches(proPath):
    proVers = os.listdir(proPath)
    branches = ""
    lastBranch = ""
    lastBranchFull = ""
    for ver in proVers:
        if '_' in ver:
            if ver.split('.')[0].split('_')[0] == lastBranch:
                branches = string.replace(branches, lastBranchFull, ver.split('.')[0])
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
    print proInfo
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
    print proName
    clientsock.send(proName.split(".")[1])

    