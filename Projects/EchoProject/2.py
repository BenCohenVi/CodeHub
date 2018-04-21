-`0
+`0`from Tkinter import *
-`1
+`1`import Connections
-`2
+`2`#import random
-`3
+`3`
-`4
+`4`class Client_Display:
-`5
+`5`
-`6
+`6`    def __init__(self, root): #tcpCliSock):
-`7
+`7`        self.root = root
-`8
+`8`        self.root.title("Kahoot Client")
-`9
+`9`        self.wait = Label(self.root, text="Game Will Start Soon...", font="Arial 20")
-`10
+`10`        self.wait.grid(row=1, column=1)
-`11
+`11`        #self.request_username = Label(self.root, text="Enter a username: ", font="Arial 14")
-`12
+`12`        #self.request_username.grid(row=1, column=1, sticky="WS")
-`13
+`13`        #self.username = Entry(self.root, font="Arial 14")
-`14
+`14`        #self.username.grid(row=2,column=1, sticky="W")
-`15
+`15`        #self.send_user = Button(self.root, text="Join the game!", font="Arial 14", command=Connections.Client_Sock.send_username(self.username.get()))
-`16
+`16`        #self.send_user.grid(row=3,column=2, sticky="E")
-`17
+`17`
-`18
+`18`    def Answers_Screen(self):
-`19
+`19`        self.root.geometry("900x472")
-`20
+`20`        self.Answer1=Button(self.root, text="1", height=10, width=40, font="Arial 14", bg="red", commands = answer_1)
-`21
+`21`        self.Answer1.grid(row=1, column=1, sticky="W")
-`22
+`22`        self.Answer2=Button(self.root, text="2", height=10, width=40, font="Arial 14", bg="blue", commands = answer_2)
-`23
+`23`        self.Answer2.grid(row=1, column=2, sticky="E")
-`24
+`24`        self.Answer3=Button(self.root, text="3", height=10, width=40,  font="Arial 14", bg="orange", command=answer_3)
-`25
+`25`        self.Answer3.grid(row=2, column=1, sticky="W")
-`26
+`26`        self.Answer4=Button(self.root, text="4", height=10, width=40,  font="Arial 14", bg="green", command=answer_4)
-`27
+`27`        self.Answer4.grid(row=2, column=2, sticky="E")
-`28
+`28`
-`29
+`29`class Server_Display:
-`30
+`30`
-`31
+`31`    def __init__(self, root):
-`32
+`32`        self.root = root
-`33
+`33`        self.root.title("Kahoot Server")
-`34
+`34`        self.current_users = Label(self.root, text="Current Users: ", font="Arial 14")
-`35
+`35`        self.current_users.grid(row=1, column=1, sticky="W")
-`36
+`36`
-`37
+`37`    def show_question(self, q):
-`38
+`38`        self.root.geometry("975x533")
-`39
+`39`        #questions = ["questions1.txt", "questions2.txt", "questions3.txt"]
-`40
+`40`        #questionire = random.choice(questions)
-`41
+`41`        #q = open("questions1.txt", "r")
-`42
+`42`        self.current_users.grid_forget()
-`43
+`43`        ques = q.readline()
-`44
+`44`        self.Question = Label(self.root, text = ques, font="Arial 22")
-`45
+`45`        self.Question.grid(row=1, column=1, sticky="E")
-`46
+`46`        ans1 = q.readline()
-`47
+`47`        self.Option1 = Label(self.root, text = ans1, height=7, width=30, font="Arial 20", bg="red")
-`48
+`48`        self.Option1.grid(row=2, column=1, sticky="W")
-`49
+`49`        ans2 = q.readline()
+`50`        self.Option2 = Label(self.root, text = ans2, height=7, width=30, font="Arial 20", bg="blue")
+`51`        self.Option2.grid(row=2, column=2, sticky="E")
+`52`        ans3 = q.readline()
+`53`        self.Option3 = Label(self.root, text = ans3, height=7, width=30, font="Arial 20", bg="orange")
+`54`        self.Option3.grid(row=3, column=1, sticky="W")
+`55`        ans4 = q.readline()
+`56`        self.Option4 = Label(self.root, text = ans4, height=7, width=30, font="Arial 20", bg="green")
+`57`        self.Option4.grid(row=3, column=2, sticky="E")
+`58`        currect = q.readline()
+`59`        return currect
+`60`
