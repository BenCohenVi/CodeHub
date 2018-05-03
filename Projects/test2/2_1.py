from socket import *
from Tkinter import *


def close_program():
    #a function that closes the GUI and stop running
    root.destroy()


def print_input():
    try:
        data = input_entry.get()
        input_entry.delete(0, END)    #clears the entry box
        input_output_list.insert(END, ">" + data)    #adding the input into the listbox
        input_output_list.itemconfig(END, bg='#4382b3')
        tcpCliSock.send(data)
        output = tcpCliSock.recv(BUFSIZ)
        if output[:19] == "The File Contains: ":
            reading_listbox.insert(END,output[19:])    #adding the recived information into a diffrent listbox
            reading_listbox.itemconfig(END, bg='#4382b3')
            output = "File added to the Read List"
        input_output_list.insert(END, output)
        input_output_list.itemconfig(END, bg='#ffd94a')
        input_output_list.see(END)    #allways seeing the end of the list
        if data == "exit":
            print output
            close_program()
        if output == "The Server is Closing":
            print output
            close_program()
    except:
        print "Server is closed"
        close_program()



free_port = raw_input("Please enter the Port of the server: ")
connected = False 
while not connected:
    try:
        HOST = '127.0.0.1'
        PORT = int(free_port)
        BUFSIZ = 1024
        ADDR = (HOST, PORT)
        tcpCliSock = socket(AF_INET, SOCK_STREAM)    #creating a socket for the client
        tcpCliSock.connect(ADDR)    #connecting into the server
        print "connected"
        connected = True
    except:
        print "Can't connect to server, please try again"
        free_port = raw_input("Please aenter the Port of the server: ")

root = Tk()
root.configure(background = '#22496a')
root.title("Inputs and Outputs")
root.geometry("1150x500")
root.resizable(width=FALSE, height=FALSE)

reading_input_output_frame = Frame(root)
scrollbar1 = Scrollbar(root, orient=VERTICAL)
scrollbar1.pack(in_=reading_input_output_frame, side=RIGHT, fill=Y)
reading_listbox = Listbox(root, width=40, height = 15,font='Ariel 14' ,bg='#1e2933',yscrollcommand=scrollbar1.set)
reading_listbox.pack(in_=reading_input_output_frame)
scrollbar1.config(command=reading_listbox.yview)
reading_input_output_frame.grid(row=3, column=1, sticky=E, padx=20)

input_output_frame = Frame(root)
scrollbar = Scrollbar(root, orient=VERTICAL)
scrollbar.pack(in_=input_output_frame, side=RIGHT, fill=Y)
input_output_list = Listbox(root, width=50, height=15, font='Ariel 16' ,bg='#1e2933',yscrollcommand=scrollbar.set)
input_output_list.pack(in_=input_output_frame)
scrollbar.config(command=input_output_list.yview)
input_output_frame.grid(row=3, column=0, sticky=W)

input_entry = Entry(root, font='Ariel 18', fg='#129e13', bg='#1e2933', width = 30)
input_entry.grid(row=0, column=0, sticky=W)
send_data_btn = Button(root, text="SEND DATA", font='Ariel 12', bg='#3776ab', width=12, command=print_input)
send_data_btn.grid(row=0, column=1, pady=15, padx=5)
reading_listbox.select_set(0)
root.mainloop()
