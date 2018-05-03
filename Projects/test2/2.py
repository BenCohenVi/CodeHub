-`0
+`0`from socket import *
-`1
+`1`import thread
-`2
+`2`import threading
-`3
+`3`import time
-`4
+`4`import sys
-`5
+`5`
-`6
+`6`
-`7
+`7`def get_open_port():
-`8
+`8`    #a function that finds an open port and writes it in a file
-`9
+`9`    global password
-`10
+`10`    s = socket(AF_INET, SOCK_STREAM)
-`11
+`11`    s.bind(("", 0))
-`12
+`12`    s.listen(1)
-`13
+`13`    port = s.getsockname() [1]
-`14
+`14`    s.close()
-`15
+`15`    save_port = open("Details.txt", "w")
-`16
+`16`    save_port.write(str(port)+","+password)
-`17
+`17`    save_port.close()
-`18
+`18`    return port
-`19
+`19`
-`20
+`20`
-`21
+`21`def read_file():
-`22
+`22`    #a function that reads the requested file
-`23
+`23`    clientsock.send("Please enter the file you want to open (With path): ")
-`24
+`24`    data = clientsock.recv(BUFSIZ)
-`25
+`25`    try:
-`26
+`26`        reader = open(data)    #opens the file 
-`27
+`27`        return "The File Contains: " + reader.read()   #reading the whole file and returning it
-`28
+`28`    except:
-`29
+`29`        return "Can't open the file, going back for the echo function"
-`30
+`30`
-`31
+`31`
-`32
+`32`def set_timer():
-`33
+`33`    #a function that sets a timer according to the client request
-`34
+`34`    clientsock.send("How much time in seconds? ")
-`35
+`35`    data = clientsock.recv(BUFSIZ)
-`36
+`36`    try:
-`37
+`37`        time.sleep(int(data))    #makes the program waiting for "data" seconds
-`38
+`38`        return "Timer Done"
-`39
+`39`    except:
-`40
+`40`        return "Invalid Input, Going back to the echo function"
-`41
+`41`
-`42
+`42`
-`43
+`43`def Change_Password(clientsock, addr, f):
-`44
+`44`    #a function that changes the server's password
-`45
+`45`    clientsock.send("Which new password do you want?")
-`46
+`46`    password = clientsock.recv(BUFSIZ)
-`47
+`47`    f.seek(0)    #changing the cursor to the start
-`48
+`48`    f.truncate()    #erasing everything
-`49
+`49`    f.write(str(PORT)+","+password)
-`50
+`50`    f.close()
-`51
+`51`    f = open("Details.txt", "a+")
-`52
+`52`    password = f.read().split(",")[1]
-`53
+`53`    return "password changed", password
-`54
+`54`
-`55
+`55`
-`56
+`56`def stop_run():
-`57
+`57`    #a function that creates a fake client connection to close the server
-`58
+`58`    try:
-`59
+`59`        HOST = '127.0.0.1'
-`60
+`60`        PORT = int(open("Details.txt", "r").read().split(",")[0])     #getting the port from the file
-`61
+`61`        ADDR = (HOST, PORT)
-`62
+`62`        tcpCliSock = socket(AF_INET, SOCK_STREAM)    #(fake)creating a connection for the serve
-`63
+`63`        tcpCliSock.connect(ADDR)    #(fake) connecting into the server
-`64
+`64`        print "server closed"
-`65
+`65`    except:
-`66
+`66`        print "cant fake connection"
-`67
+`67`
-`68
+`68`
-`69
+`69`def handler(clientsock, serversock, addr, f):
-`70
+`70`    #the main function that handles the clients
-`71
+`71`    global is_open
-`72
+`72`    global password
-`73
+`73`    try:
-`74
+`74`        with clients_lock:
-`75
+`75`            clients.add(clientsock)
-`76
+`76`        while is_open == True:
-`77
+`77`            data = clientsock.recv(BUFSIZ)    #gets information from the clients
-`78
+`78`            print data
-`79
+`79`            if data[:4]=="read":
-`80
+`80`                data = read_file()
-`81
+`81`            if data == "Set a Timer":
-`82
+`82`                data = set_timer()
-`83
+`83`            if data == "Change Password":
-`84
+`84`                data, password = Change_Password(clientsock, addr, f)
-`85
+`85`            if data == "exit":
-`86
+`86`                break
-`87
+`87`            if data == password:
-`88
+`88`                print "Server is Closing"
-`89
+`89`                with clients_lock:
-`90
+`90`                    for c in clients:
-`91
+`91`                        c.sendall("The Server is Closing")
-`92
+`92`                clientsock.close()
-`93
+`93`                is_open = False
-`94
+`94`                serversock.close()
-`95
+`95`                stop_run()
-`96
+`96`                thread.exit()
-`97
+`97`                raise SystemExit    #killing all threads
-`98
+`98`            clientsock.send(data)    #sends the information for the client
-`99
+`99`        print password
-`100
+`100`        print "ending communication with",addr
-`101
+`101`        clientsock.send("Thank you for using my Program!")
-`102
+`102`        clientsock.close()
-`103
+`103`    except:
-`104
+`104`        clientsock.close()
-`105
+`105`        thread.exit()
-`106
+`106`
-`107
+`107`
-`108
+`108`is_open = Truet
-`109
+`109`password = open("Details.txt", "r").read().split(",")[1]    #getting the password out of the file
-`110
+`110`BUFSIZ = 1024
-`111
+`111`HOST = "127.0.0.1"
-`112
+`112`PORT = get_open_port()
-`113
+`113`ADDR = (HOST, PORT)    #creates an address for the server
-`114
+`114`serversock = socket(AF_INET, SOCK_STREAM)    #creates a socket for the server
-`115
+`115`serversock.bind(ADDR)    #connecting the server into his adress
-`116
+`116`serversock.listen(2)    
-`117
+`117`f = open("Details.txt", "r+")
-`118
+`118`print "Type This into the Client's PORT = "+str(PORT)
-`119
+`119`clients = set()
-`120
+`120`clients_lock = threading.Lock()
-`121
+`121`
-`122
+`122`
-`123
+`123`while 1:
-`124
+`124`    try:
-`125
+`125`        print 'waiting for connection...'
-`126
+`126`        clientsock, addr = serversock.accept()
-`127
+`127`        print '...connected from:', addr
-`128
+`128`        if is_open == True:
-`129
+`129`            thread.start_new_thread(handler, (clientsock, serversock, addr, f))    #creates a new thread to handle to client
-`130
+`130`    except:
-`131
+`131`        break1
-`132
+`132`
-`133
-`134
-`135
-`136
-`137
-`138
-`139
-`140
-`141
-`142
-`143
-`144
-`145
-`146
-`147
-`148
-`149
-`150
-`151
-`152
-`153
-`154
-`155
-`156
-`157
-`158
-`159
-`160
-`161
-`162
-`163
-`164
-`165
-`166
-`167
-`168
-`169
-`170
-`171
-`172
-`173
-`174
-`175
-`176
-`177
-`178
-`179
-`180
-`181
-`182
-`183
-`184
-`185
-`186
-`187
-`188
-`189
-`190
-`191
-`192
-`193
-`194
-`195
-`196
-`197
-`198
-`199
-`200
-`201
-`202
-`203
-`204
-`205
-`206
-`207
-`208
-`209
-`210
