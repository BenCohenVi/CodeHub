-`5
+`5`    root.destroy()
-`6
+`6`
-`8
+`8`def print_input():
-`9
+`9`    data = input_entry.get()
-`10
+`10`    input_entry.delete(0, END)
-`11
+`11`    listbox.insert(END, ">" + data)
-`12
+`12`    print "works"
-`13
+`13`    if not data or data == "exit":
-`14
+`14`        close_program()
-`15
+`15`    tcpCliSock.send(data)
-`16
+`16`    output = tcpCliSock.recv(BUFSIZ)
-`17
+`17`    listbox.insert(END, output)
-`18
+`18`    listbox.see(END)
-`19
+`19`
-`20
+`20`
-`21
+`21`server_ip = raw_input("Please enter the IP address of the server: ")
-`22
+`22`free_port = raw_input("Please enter the Port of the server: ")
-`23
+`23`
-`24
+`24`HOST = str(server_ip)
-`25
+`25`PORT = int(free_port)
-`26
+`26`BUFSIZ = 1024
-`27
+`27`ADDR = (HOST, PORT)
-`28
+`28`tcpCliSock = socket(AF_INET, SOCK_STREAM)
-`29
+`29`tcpCliSock.connect(ADDR)
-`30
+`30`print "connected"
-`31
+`31`
-`32
+`32`root = Tk()
-`33
+`33`root.title("Inputs and Outputs")
-`34
+`34`root.geometry("500x350")
-`35
+`35`root.resizable(width=FALSE, height=FALSE)
-`36
+`36`frame = Frame(root)
-`37
+`37`scrollbar = Scrollbar(root, orient=VERTICAL)
-`38
+`38`scrollbar.pack(in_=frame, side=RIGHT, fill=Y)
-`39
+`39`listbox = Listbox(root, yscrollcommand=scrollbar.set)
-`40
+`40`listbox.pack(in_=frame)
-`41
+`41`scrollbar.config(command=listbox.yview)
-`42
+`42`frame.grid(row=3, column=0, sticky=W)
-`43
+`43`input_entry = Entry(root)
-`44
+`44`input_entry.grid(row=0, column=0, sticky=W)
-`45
+`45`send_data_btn = Button(root, text="SEND DATA", command=print_input)
-`46
+`46`send_data_btn.grid(row=0, column=1)
-`47
+`47`root.mainloop()
-`48
+`48`
-`49
+`49`
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
-`61
-`62
-`63
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
