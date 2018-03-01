from Modules import utils
from Modules import usract
from Modules import cliresponse
from socket import *
import thread, threading, sqlite3


def send_projects(clientsock, c, conn, username):
    clientsock.recv(BUFSIZ)
    c.execute("SELECT name FROM "+username)
    projectsAll = c.fetchall()
    clientsock.send(str(projectsAll))


def send_versions(clientsock, c, conn, username):
    proName = clientsock.recv(BUFSIZ)
    c.execute("SELECT version FROM "+username+" WHERE name=:data", {'data':proName})
    projectVersions = c.fetchall()
    clientsock.send(str(projectVersions))


def send_branches(clientsock, c, conn):
    proName = clientsock.recv(BUFSIZ)
    proPath = PATH+"\\Projects\\"+proName+"\\"
    proBranches = utils.get_branches(proPath)
    if proBranches != "":
        clientsock.send(proBranches)
    else:
        clientsock.send("None")


def handler(clientsock, serversock, addr):
    #try:
        conn = sqlite3.connect(PATH+'\\ProjectsInfo.db')
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
        c.execute("UPDATE "+username+" SET version=? WHERE name=?", [5, "George"])
        conn.commit()
        clientsock.recv(BUFSIZ)
        c.execute("SELECT name FROM "+username)
        clientsock.send(str(c.fetchall()))
        clientResponse = cliresponse.Useresponse(clientsock, c, conn, PATH, username)
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
                #send_test(clientsock)
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
            else:
                clientsock.close()
                conn.close()
    #except:    
        #clientsock.close()
        #conn.close()


PATH = utils.get_path()
conn = sqlite3.connect(PATH+"\\ProjectsInfo.db")
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
    print "... connected from: ",addr
    thread.start_new_thread(handler, (clientsock, serversock, addr))
c.close()