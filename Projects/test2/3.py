-`7
+`7`
-`8
+`8`
-`9
+`9`def get_open_port():
-`15
+`15`    return port
-`16
+`16`
-`17
+`17`
-`18
+`18`def save_information(serversock):
-`19
+`19`    import socket
-`20
+`20`    f = open("C:\\Users\Ben\Desktop\Details.txt", "w")
-`21
+`21`    f.write("pass123"+"\n"+str(PORT)+"\n"+get_ip())
-`22
+`22`
-`23
+`23`
-`24
+`24`def set_timer():
-`25
+`25`    clientsock.send("How much time in seconds? ")
-`26
+`26`    data = clientsock.recv(BUFSIZ)
-`27
+`27`    try:
-`28
+`28`        time.sleep(int(data))
-`29
+`29`        return"Timer Done"
-`30
+`30`    except:
-`31
+`31`        return "Invalid Input, Going back for the echo function"
-`32
+`32`
-`33
+`33`
-`34
+`34`def handler(clientsock, addr):
-`35
+`35`    while 1:
-`36
+`36`        data = clientsock.recv(BUFSIZ)
-`37
+`37`        print data
-`38
+`38`        if not data: break
-`39
+`39`        if data == "exit": break
-`40
+`40`        if data == "Current Time":
-`41
+`41`            data = "current time (of the server PC): " + str(datetime.datetime.now())
-`42
+`42`        if data == "Set a Timer":
-`43
+`43`                data = Set_A_Timer()
-`44
+`44`        clientsock.send(data)
-`45
+`45`    print "ending communication with",addr
-`46
+`46`    clientsock.close()
-`47
+`47`
-`48
+`48`BUFSIZ = 1024
-`49
+`49`HOST = get_ip()
-`50
+`50`PORT = get_open_port()
-`51
+`51`ADDR = (HOST, PORT)
-`52
+`52`serversock = socket(AF_INET, SOCK_STREAM)
-`53
+`53`serversock.bind(ADDR)
-`54
+`54`serversock.listen(2)
-`55
+`55`save_information(serversock)
-`56
+`56`print "Type This into the Client:\n IP = "+str(get_ip())+"\n PORT = "+str(PORT)
-`57
+`57`
-`58
+`58`while 1:
-`59
+`59`    print 'waiting for connection...'
-`60
+`60`    clientsock, addr = serversock.accept()
-`61
+`61`    print '...connected from:', addr
-`62
+`62`    thread.start_new_thread(handler, (clientsock, addr))
-`63
+`63`
-`64
-`65
-`66
-`67
-`68
-`69
-`70
-`71
-`72
-`73
-`74
-`75
-`76
-`77
-`78
-`79
-`80
-`81
-`82
-`83
-`84
-`85
-`86
-`87
-`88
-`89
-`90
-`91
-`92
-`93
-`94
-`95
-`96
-`97
-`98
-`99
-`100
-`101
-`102
-`103
-`104
-`105
-`106
-`107
-`108
-`109
-`110
-`111
-`112
-`113
-`114
-`115
-`116
-`117
-`118
-`119
-`120
-`121
-`122
-`123
-`124
-`125
-`126
-`127
-`128
-`129
-`130
-`131
-`132
