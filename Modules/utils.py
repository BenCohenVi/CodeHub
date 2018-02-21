from socket import *
from difflib import *
import os, sys, ast, string


def get_local_host():
    return gethostbyname(gethostname())
    

def get_open_port():
    s = socket(AF_INET, SOCK_STREAM)
    s.bind(("",0))
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
    diff = ndiff(main_file, new_file)
    return list(diff)


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
                branches = branches + ","+ ver.split('.')[0]
                lastBranchFull = ver.split('.')[0]
                lastBranch = ver.split('.')[0].split('_')[0]
    branches = branches[1:]
    if len(branches) > 0:
        branches = branches + ",0_0"
    return branches