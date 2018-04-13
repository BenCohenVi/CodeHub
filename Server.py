from Modules import utils, usract, cliresponse
from socket import *
import thread
import threading
import sqlite3


def search_user(clientsock, c, conn, username):
    userSearch = clientsock.recv(BUFSIZ)
    c.execute("SELECT * FROM UsersDB WHERE username=:data",
              {'data': userSearch})
    if c.fetchone() == None:
        clientsock.send("NO")
    elif userSearch == username:
        clientsock.send("NO1")
    else:
        c.execute("SELECT name FROM " + userSearch)
        clientsock.send(str(c.fetchall()))


def send_projects(clientsock, c, conn, username):
    clientsock.recv(BUFSIZ)
    c.execute("SELECT name FROM " + username)
    projectsAll = c.fetchall()
    clientsock.send(str(projectsAll))


def send_versions(clientsock, c, conn, username):
    proName = clientsock.recv(BUFSIZ)
    c.execute("SELECT version FROM " + username + " WHERE name=:data",
              {'data': proName})
    projectVersions = c.fetchall()
    clientsock.send(str(projectVersions))


def send_branches(clientsock, c, conn):
    proName = clientsock.recv(BUFSIZ)
    proPath = PATH + "\\Projects\\" + proName + "\\"
    proBranches = utils.get_branches(proPath)
    if proBranches != "":
        clientsock.send(proBranches)
    else:
        clientsock.send("None")


def send_UVersions(clientsock, c, conn):
    proInfo = clientsock.recv(BUFSIZ)
    proName = proInfo.split("^")[0]
    uName = proInfo.split("^")[1]
    c.execute("SELECT version FROM " + uName + " WHERE name=:data",
              {'data': proName})
    projectVersions = c.fetchall()
    clientsock.send(str(projectVersions))



def handler(clientsock, serversock, addr):
    # try:
    conn = sqlite3.connect(PATH + '\\ProjectsInfo.db')
    c = conn.cursor()
    connected = False
    uact = usract.Useract(c, conn)
    while not connected:
        action = clientsock.recv(BUFSIZ)
        clientsock.send("OK")
        if action == "Login":
            data = clientsock.recv(BUFSIZ)
            act = uact.check_login(data)
            if act == True:
                clientsock.send("true")
                connected = True
                username = data.split(',')[0]
            else:
                clientsock.send("false")
        else:
            data = clientsock.recv(BUFSIZ)
            return_data = uact.register(data)
            if return_data != "NO":
                clientsock.send("OK")
            else:
                clientsock.send("NO")
    del uact
    c.execute("UPDATE " + username + " SET version=? WHERE name=?",
              [5, "George"])
    conn.commit()
    clientsock.recv(BUFSIZ)
    c.execute("SELECT name FROM " + username)
    clientsock.send(str(c.fetchall()))
    clientResponse = cliresponse.Useresponse(clientsock, c, conn, PATH,
                                             username)
    while 1:
        data = clientsock.recv(BUFSIZ)
        clientsock.send("OK")
        if data == "New.":
            clientResponse.new_project()
        elif data == "Delete.":
            clientResponse.delete_project()
        elif data == "Download.":
            clientResponse.download_project()
        elif data == "Share.":
            clientResponse.share_project()
        elif data == "Branch.":
            clientResponse.new_branch()
        elif data == "Update.":
            clientResponse.update_project()
        elif data == "BranchU.":
            clientResponse.update_branch()
        elif data == "Preview.":
            clientResponse.send_preview()
        elif data == "Comment.":
            clientResponse.comment()
        elif data == "GetComments.":
            clientResponse.get_comments()
        elif data == "Projects.":
            send_projects(clientsock, c, conn, username)
        elif data == "Versions.":
            send_versions(clientsock, c, conn, username)
        elif data == "Branches.":
            send_branches(clientsock, c, conn)
        elif data == "Search.":
            search_user(clientsock, c, conn, username)
        elif data == "UVersions.":
            send_UVersions(clientsock, c, conn)
        elif data == "GetType.":
            utils.get_type(clientsock, PATH)
        else:
            clientsock.close()
            conn.close()
    # except:
    # clientsock.close()
    # conn.close()


PATH = utils.get_path()
conn = sqlite3.connect(PATH + "\\ProjectsInfo.db")
c = conn.cursor()
c.execute("CREATE TABLE IF NOT EXISTS UsersDB(username TEXT, password TEXT)")
BUFSIZ = 1024
HOST = utils.get_local_host()
PORT = utils.get_open_port()
ADDR = (HOST, PORT)
serversock = socket(AF_INET, SOCK_STREAM)
serversock.bind(ADDR)
serversock.listen(5)
print "ip: ", HOST
print "port: ", PORT
while 1:
    clientsock, addr = serversock.accept()
    print "... connected from: ", addr
    thread.start_new_thread(handler, (clientsock, serversock, addr))
c.close()
