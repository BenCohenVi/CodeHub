-`0
+`0`from socket import *
-`1
+`1`from Tkinter import *
-`2
+`2`
-`3
+`3`
-`4
+`4`def close_program():
-`5
+`5`    #a function that closes the GUI and stop running
-`6
+`6`    root.destroy()
-`7
+`7`
-`8
+`8`
-`9
+`9`def print_input():
-`10
+`10`    try:
-`11
+`11`        data = input_entry.get()
-`12
+`12`        input_entry.delete(0, END)    #clears the entry box
-`13
+`13`        input_output_list.insert(END, ">" + data)    #adding the input into the listbox
-`14
+`14`        input_output_list.itemconfig(END, bg='#4382b3')
-`15
+`15`        tcpCliSock.send(data)
-`16
+`16`        output = tcpCliSock.recv(BUFSIZ)
-`17
+`17`        if output[:19] == "The File Contains: ":
-`18
+`18`            reading_listbox.insert(END,output[19:])    #adding the recived information into a diffrent listbox
-`19
+`19`            reading_listbox.itemconfig(END, bg='#4382b3')
-`20
+`20`            output = "File added to the Read List"
-`21
+`21`        input_output_list.insert(END, output)
-`22
+`22`        input_output_list.itemconfig(END, bg='#ffd94a')
-`23
+`23`        input_output_list.see(END)    #allways seeing the end of the list
-`24
+`24`        if data == "exit":
-`25
+`25`            print output
-`26
+`26`            close_program()
-`27
+`27`        if output == "The Server is Closing":
-`28
+`28`            print output
-`29
+`29`            close_program()
-`30
+`30`    except:
-`31
+`31`        print "Server is closed"
-`32
+`32`        close_program()
-`33
+`33`
-`34
+`34`
-`35
+`35`
-`36
+`36`free_port = raw_input("Please enter the Port of the server: ")
-`37
+`37`connected = False 
-`38
+`38`while not connected:
-`39
+`39`    try:
-`40
+`40`        HOST = '127.0.0.1'
-`41
+`41`        PORT = int(free_port)
-`42
+`42`        BUFSIZ = 1024
-`43
+`43`        ADDR = (HOST, PORT)
-`44
+`44`        tcpCliSock = socket(AF_INET, SOCK_STREAM)    #creating a socket for the client
-`45
+`45`        tcpCliSock.connect(ADDR)    #connecting into the server
-`46
+`46`        print "connected"
-`47
+`47`        connected = True
-`48
+`48`    except:
-`49
+`49`        print "Can't connect to server, please try again"
+`50`        free_port = raw_input("Please aenter the Port of the server: ")
+`51`
+`52`root = Tk()
+`53`root.configure(background = '#22496a')
+`54`root.title("Inputs and Outputs")
+`55`root.geometry("1150x500")
+`56`root.resizable(width=FALSE, height=FALSE)
+`57`
+`58`reading_input_output_frame = Frame(root)
+`59`scrollbar1 = Scrollbar(root, orient=VERTICAL)
+`60`scrollbar1.pack(in_=reading_input_output_frame, side=RIGHT, fill=Y)
+`61`reading_listbox = Listbox(root, width=40, height = 15,font='Ariel 14' ,bg='#1e2933',yscrollcommand=scrollbar1.set)
+`62`reading_listbox.pack(in_=reading_input_output_frame)
+`63`scrollbar1.config(command=reading_listbox.yview)
+`64`reading_input_output_frame.grid(row=3, column=1, sticky=E, padx=20)
+`65`
+`66`input_output_frame = Frame(root)
+`67`scrollbar = Scrollbar(root, orient=VERTICAL)
+`68`scrollbar.pack(in_=input_output_frame, side=RIGHT, fill=Y)
+`69`input_output_list = Listbox(root, width=50, height=15, font='Ariel 16' ,bg='#1e2933',yscrollcommand=scrollbar.set)
+`70`input_output_list.pack(in_=input_output_frame)
+`71`scrollbar.config(command=input_output_list.yview)
+`72`input_output_frame.grid(row=3, column=0, sticky=W)
+`73`
+`74`input_entry = Entry(root, font='Ariel 18', fg='#129e13', bg='#1e2933', width = 30)
+`75`input_entry.grid(row=0, column=0, sticky=W)
+`76`send_data_btn = Button(root, text="SEND DATA", font='Ariel 12', bg='#3776ab', width=12, command=print_input)
+`77`send_data_btn.grid(row=0, column=1, pady=15, padx=5)
+`78`reading_listbox.select_set(0)
+`79`root.mainloop()
+`80`
