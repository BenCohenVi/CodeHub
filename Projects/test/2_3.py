-`0
+`0`-`0
-`1
+`1`+`0`from socket import *
-`2
+`2`-`1
-`3
+`3`+`1`from Tkinter import *
-`4
+`4`-`2
-`5
+`5`+`2`
-`6
+`6`-`3
-`7
+`7`+`3`
-`8
+`8`-`4
-`9
+`9`+`4`def close_program():
-`10
+`10`-`5
-`11
+`11`+`5`    #a function that closes the GUI and stop running
-`12
+`12`-`6
-`13
+`13`+`6`    root.destroy()
-`14
+`14`-`7
-`15
+`15`+`7`
-`16
+`16`-`8
-`17
+`17`+`8`
-`18
+`18`-`9
-`19
+`19`+`9`def print_input():
-`20
+`20`-`10
-`21
+`21`+`10`    try:
-`22
+`22`-`11
-`23
+`23`+`11`        data = input_entry.get()
-`24
+`24`-`12
-`25
+`25`+`12`        input_entry.delete(0, END)    #clears the entry box
-`26
+`26`-`13
-`27
+`27`+`13`        input_output_list.insert(END, ">" + data)    #adding the input into the listbox
-`28
+`28`-`14
-`29
+`29`+`14`        input_output_list.itemconfig(END, bg='#4382b3')
-`30
+`30`-`15
-`31
+`31`+`15`        tcpCliSock.send(data)
-`32
+`32`-`16
-`33
+`33`+`16`        output = tcpCliSock.recv(BUFSIZ)
-`34
+`34`-`17
-`35
+`35`+`17`        if output[:19] == "The File Contains: ":
-`36
+`36`-`18
-`37
+`37`+`18`            reading_listbox.insert(END,output[19:])    #adding the recived information into a diffrent listbox
-`38
+`38`-`19
-`39
+`39`+`19`            reading_listbox.itemconfig(END, bg='#4382b3')
-`40
+`40`-`20
-`41
+`41`+`20`            output = "File added to the Read List"
-`42
+`42`-`21
-`43
+`43`+`21`        input_output_list.insert(END, output)
-`44
+`44`-`22
-`45
+`45`+`22`        input_output_list.itemconfig(END, bg='#ffd94a')
-`46
+`46`-`23
-`47
+`47`+`23`        input_output_list.see(END)    #allways seeing the end of the list
-`48
+`48`-`24
-`49
+`49`+`24`        if data == "exit":
-`50
+`50`-`25
-`51
+`51`+`25`            print output
+`52`-`26
+`53`+`26`            close_program()
+`54`-`27
+`55`+`27`        if output == "The Server is Closing":
+`56`-`28
+`57`+`28`            print output
+`58`-`29
+`59`+`29`            close_program()
+`60`-`30
+`61`+`30`    except:
+`62`-`31
+`63`+`31`        print "Server is closed"
+`64`-`32
+`65`+`32`        close_program()
+`66`-`33
+`67`+`33`
+`68`-`34
+`69`+`34`
+`70`-`35
+`71`+`35`
+`72`-`36
+`73`+`36`free_port = raw_input("Please enter the Port of the server: ")
+`74`-`37
+`75`+`37`connected = False 
+`76`-`38
+`77`+`38`while not connected:
+`78`-`39
+`79`+`39`    try:
+`80`-`40
+`81`+`40`        HOST = '127.0.0.1'
+`82`-`41
+`83`+`41`        PORT = int(free_port)
+`84`-`42
+`85`+`42`        BUFSIZ = 1024
+`86`-`43
+`87`+`43`        ADDR = (HOST, PORT)
+`88`-`44
+`89`+`44`        tcpCliSock = socket(AF_INET, SOCK_STREAM)    #creating a socket for the client
+`90`-`45
+`91`+`45`        tcpCliSock.connect(ADDR)    #connecting into the server
+`92`-`46
+`93`+`46`        print "connected"
+`94`-`47
+`95`+`47`        connected = True
+`96`-`48
+`97`+`48`    except:
+`98`-`49
+`99`+`49`        print "Can't connect to server, please try again"
+`100`+`50`        free_port = raw_input("Please aenter the Port of the server: ")
+`101`+`51`
+`102`+`52`root = Tk()
+`103`+`53`root.configure(background = '#22496a')
+`104`+`54`root.title("Inputs and Outputs")
+`105`+`55`root.geometry("1150x500")
+`106`+`56`root.resizable(width=FALSE, height=FALSE)
+`107`+`57`
+`108`+`58`reading_input_output_frame = Frame(root)
+`109`+`59`scrollbar1 = Scrollbar(root, orient=VERTICAL)
+`110`+`60`scrollbar1.pack(in_=reading_input_output_frame, side=RIGHT, fill=Y)
+`111`+`61`reading_listbox = Listbox(root, width=40, height = 15,font='Ariel 14' ,bg='#1e2933',yscrollcommand=scrollbar1.set)
+`112`+`62`reading_listbox.pack(in_=reading_input_output_frame)
+`113`+`63`scrollbar1.config(command=reading_listbox.yview)
+`114`+`64`reading_input_output_frame.grid(row=3, column=1, sticky=E, padx=20)
+`115`+`65`
+`116`+`66`input_output_frame = Frame(root)
+`117`+`67`scrollbar = Scrollbar(root, orient=VERTICAL)
+`118`+`68`scrollbar.pack(in_=input_output_frame, side=RIGHT, fill=Y)
+`119`+`69`input_output_list = Listbox(root, width=50, height=15, font='Ariel 16' ,bg='#1e2933',yscrollcommand=scrollbar.set)
+`120`+`70`input_output_list.pack(in_=input_output_frame)
+`121`+`71`scrollbar.config(command=input_output_list.yview)
+`122`+`72`input_output_frame.grid(row=3, column=0, sticky=W)
+`123`+`73`
+`124`+`74`input_entry = Entry(root, font='Ariel 18', fg='#129e13', bg='#1e2933', width = 30)
+`125`+`75`input_entry.grid(row=0, column=0, sticky=W)
+`126`+`76`send_data_btn = Button(root, text="SEND DATA", font='Ariel 12', bg='#3776ab', width=12, command=print_input)
+`127`+`77`send_data_btn.grid(row=0, column=1, pady=15, padx=5)
+`128`+`78`reading_listbox.select_set(0)
+`129`+`79`root.mainloop()
+`130`+`80`
+`131`
