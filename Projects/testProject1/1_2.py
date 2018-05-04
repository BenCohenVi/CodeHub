-`1
+`1`from Connections import *
-`2
+`2`from socket import *
-`3
+`3`import thread
-`4
+`4`import threading
-`5
+`5`import Display
-`6
+`6`import API
-`7
+`7`#import random
-`8
+`8`
-`9
+`9`def handler(clientsock):
-`10
+`10`    print "Hi"
-`11
+`11`
-`12
+`12`#questions = ["questions1.txt", "questions2.txt", "questions3.txt"]
-`13
+`13`#questionire = random.choice(questions)
-`14
+`14`q = open("questions1.txt", "r")
-`15
+`15`root = Tk()
-`16
+`16`app = Display.Server_Display(root)
-`17
+`17`s_socket = Server_Socket()
-`18
+`18`q = open("questions1.txt", "r")
-`19
+`19`clients = set()
-`20
+`20`clients_lock = threading.Lock()
-`21
+`21`clients_counter = 0
-`22
+`22`while clients_counter < 3:
-`23
+`23`    c_sock = s_socket.wait_for_connection()
-`24
+`24`    clients_counter = clients_counter + 1
-`25
+`25`    with clients_lock:
-`26
+`26`        clients.add(c_sock)
-`27
+`27`app.show_question(q)
-`28
+`28`while clients_lock:
-`29
+`29`    for c in clients:
-`30
+`30`        c.sendall("we start")
-`31
+`31`        thread.start_new_thread(handler, (c))
-`32
+`32`root.mainloop()
-`33
+`33`
-`34
-`35
-`36
-`37
-`38
-`39
-`40
-`41
-`42
-`43
-`44
-`45
-`46
-`47
-`48
-`49
-`50
-`51
-`52
-`53
-`54
-`55
-`56
-`57
-`58
-`59
-`60
