-`0
+`0`from socket import *
-`1
+`1`from Tkinter import *
-`2
+`2`import thread
-`6
+`6`def get_free_port():
-`7
+`7`    s = socket(AF_INET, SOCK_STREAM)
-`8
+`8`    s.bind(("", 0))
-`9
+`9`    s.listen(1)
-`10
+`10`    port = s.getsockname()[1]
+`11`    s.close()
+`12`    return port
+`13`
+`14`def handler(clientsock, serversock, addr, app):
+`15`    q = open("questions1.txt", "r")
+`16`    app.show_question(q)
+`17`
+`18`
+`19`class Server_Socket:
+`20`    BUFSIZ = 1024
+`21`    Client_List = []
+`22`    def __init__ (self):
+`23`        self.ip = 'localhost'
+`24`        self.port = get_free_port()
+`25`        API.update("Ben", self.ip, self.port)
+`26`        self.ADDR = (self.ip, self.port)
+`27`        self.serversock = socket(AF_INET, SOCK_STREAM)
+`28`        self.serversock.bind(self.ADDR)
+`29`        self.serversock.listen(4)
+`30`
+`31`    def wait_for_connection(self):
+`32`        self.clientsock, self.addr = self.serversock.accept()
+`33`        self.c_username = self.clientsock.recv(Server_Socket.BUFSIZ)
+`34`        Server_Socket.Client_List.append([self.clientsock, self.c_username, 0])
+`35`        return self.clientsock
+`36`
+`37`
+`38`class Client_Sock:
+`39`    BUFSIZ = 1024
+`40`    def __init__(self):
+`41`        self.info = API.get_details("Ben")
+`42`        self.HOST = self.info["result"]["ipaddr"]
+`43`        self.PORT = self.info["result"]["port"]
+`44`        self.ADDR = (self.HOST, self.PORT)
+`45`        self.tcpCliSock = socket(AF_INET, SOCK_STREAM)
+`46`        self.tcpCliSock.connect(self.ADDR)
+`47`        self.username = raw_input("Enter a username: ")
+`48`        self.tcpCliSock.send(self.username)
+`49`        print "connected"
+`50`
