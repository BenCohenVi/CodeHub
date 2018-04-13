-`0
+`0`-`0
+`1`+`0`from socket import *
+`2`+`1`from Tkinter import *
+`3`+`2`
+`4`+`3`
+`5`+`4`def close_program():
+`6`+`5`    root.destroy()
+`7`+`6`
+`8`+`7`
+`9`+`8`def print_input():
+`10`+`9`    data = input_entry.get()
+`11`+`10`    input_entry.delete(0, END)
+`12`+`11`    listbox.insert(END, ">" + data)
+`13`+`12`    print "works"
+`14`+`13`    if not data or data == "exit":
+`15`+`14`        close_program()
+`16`+`15`    tcpCliSock.send(data)
+`17`+`16`    output = tcpCliSock.recv(BUFSIZ)
+`18`+`17`    listbox.insert(END, output)
+`19`+`18`    listbox.see(END)
+`20`+`19`
+`21`+`20`
+`22`+`21`server_ip = raw_input("Please enter the IP address of the server: ")
+`23`+`22`free_port = raw_input("Please enter the Port of the server: ")
+`24`+`23`
+`25`+`24`HOST = str(server_ip)
+`26`+`25`PORT = int(free_port)
+`27`+`26`BUFSIZ = 1024
+`28`+`27`ADDR = (HOST, PORT)
+`29`+`28`tcpCliSock = socket(AF_INET, SOCK_STREAM)
+`30`+`29`tcpCliSock.connect(ADDR)
+`31`+`30`print "connected"
+`32`+`31`
+`33`+`32`root = Tk()
+`34`+`33`root.title("Inputs and Outputs")
+`35`+`34`root.geometry("500x350")
+`36`+`35`root.resizable(width=FALSE, height=FALSE)
+`37`+`36`frame = Frame(root)
+`38`+`37`scrollbar = Scrollbar(root, orient=VERTICAL)
+`39`+`38`scrollbar.pack(in_=frame, side=RIGHT, fill=Y)
+`40`+`39`listbox = Listbox(root, yscrollcommand=scrollbar.set)
+`41`+`40`listbox.pack(in_=frame)
+`42`+`41`scrollbar.config(command=listbox.yview)
+`43`+`42`frame.grid(row=3, column=0, sticky=W)
+`44`+`43`input_entry = Entry(root)
+`45`+`44`input_entry.grid(row=0, column=0, sticky=W)
+`46`+`45`send_data_btn = Button(root, text="SEND DATA", command=print_input)
+`47`+`46`send_data_btn.grid(row=0, column=1)
+`48`+`47`root.mainloop()
+`49`+`48`
+`50`+`49`
+`51`
