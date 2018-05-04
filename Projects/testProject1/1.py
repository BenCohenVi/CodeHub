from socket import *
from Tkinter import *


def close_program():
    root.destroy()


def print_input():
    data = input_entry.get()
    input_entry.delete(0, END)
    listbox.insert(END, ">" + data)
    print "works"
    if not data or data == "exit":
        close_program()
    tcpCliSock.send(data)
    output = tcpCliSock.recv(BUFSIZ)
    listbox.insert(END, output)
    listbox.see(END)


server_ip = raw_input("Please enter the IP address of the server: ")
free_port = raw_input("Please enter the Port of the server: ")

HOST = str(server_ip)
PORT = int(free_port)
BUFSIZ = 1024
ADDR = (HOST, PORT)
tcpCliSock = socket(AF_INET, SOCK_STREAM)
tcpCliSock.connect(ADDR)
print "connected"

root = Tk()
root.title("Inputs and Outputs")
root.geometry("500x350")
root.resizable(width=FALSE, height=FALSE)
frame = Frame(root)
scrollbar = Scrollbar(root, orient=VERTICAL)
scrollbar.pack(in_=frame, side=RIGHT, fill=Y)
listbox = Listbox(root, yscrollcommand=scrollbar.set)
listbox.pack(in_=frame)
scrollbar.config(command=listbox.yview)
frame.grid(row=3, column=0, sticky=W)
input_entry = Entry(root)
input_entry.grid(row=0, column=0, sticky=W)
send_data_btn = Button(root, text="SEND DATA", command=print_input)
send_data_btn.grid(row=0, column=1)
root.mainloop()
