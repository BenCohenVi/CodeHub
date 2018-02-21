from socket import *
import thread
import threading
import time
import sys


def get_open_port():
    #a function that finds an open port and writes it in a file
    global password
    s = socket(AF_INET, SOCK_STREAM)
    s.bind(("", 0))
    s.listen(1)
    port = s.getsockname() [1]
    s.close()
    save_port = open("Details.txt", "w")
    save_port.write(str(port)+","+password)
    save_port.close()
    return port


def read_file():
    #a function that reads the requested file
    clientsock.send("Please enter the file you want to open (With path): ")
    data = clientsock.recv(BUFSIZ)
    try:
        reader = open(data)    #opens the file 
        return "The File Contains: " + reader.read()   #reading the whole file and returning it
    except:
        return "Can't open the file, going back for the echo function"


def set_timer():
    #a function that sets a timer according to the client request
    clientsock.send("How much time in seconds? ")
    data = clientsock.recv(BUFSIZ)
    try:
        time.sleep(int(data))    #makes the program waiting for "data" seconds
        return "Timer Done"
    except:
        return "Invalid Input, Going back to the echo function"


def Change_Password(clientsock, addr, f):
    #a function that changes the server's password
    clientsock.send("Which new password do you want?")
    password = clientsock.recv(BUFSIZ)
    f.seek(0)    #changing the cursor to the start
    f.truncate()    #erasing everything
    f.write(str(PORT)+","+password)
    f.close()
    f = open("Details.txt", "a+")
    password = f.read().split(",")[1]
    return "password changed", password


def stop_run():
    #a function that creates a fake client connection to close the server
    try:
        HOST = '127.0.0.1'
        PORT = int(open("Details.txt", "r").read().split(",")[0])     #getting the port from the file
        ADDR = (HOST, PORT)
        tcpCliSock = socket(AF_INET, SOCK_STREAM)    #(fake)creating a connection for the serve
        tcpCliSock.connect(ADDR)    #(fake) connecting into the server
        print "server closed"
    except:
        print "cant fake connection"


def handler(clientsock, serversock, addr, f):
    #the main function that handles the clients
    global is_open
    global password
    try:
        with clients_lock:
            clients.add(clientsock)
        while is_open == True:
            data = clientsock.recv(BUFSIZ)    #gets information from the clients
            print data
            if data[:4]=="read":
                data = read_file()
            if data == "Set a Timer":
                data = set_timer()
            if data == "Change Password":
                data, password = Change_Password(clientsock, addr, f)
            if data == "exit":
                break
            if data == password:
                print "Server is Closing"
                with clients_lock:
                    for c in clients:
                        c.sendall("The Server is Closing")
                clientsock.close()
                is_open = False
                serversock.close()
                stop_run()
                thread.exit()
                raise SystemExit    #killing all threads
            clientsock.send(data)    #sends the information for the client
        print password
        print "ending communication with",addr
        clientsock.send("Thank you for using my Program!")
        clientsock.close()
    except:
        clientsock.close()
        thread.exit()


is_open = True
password = open("Details.txt", "r").read().split(",")[1]    #getting the password out of the file
BUFSIZ = 1024
HOST = "127.0.0.1"
PORT = get_open_port()
ADDR = (HOST, PORT)    #creates an address for the server
serversock = socket(AF_INET, SOCK_STREAM)    #creates a socket for the server
serversock.bind(ADDR)    #connecting the server into his adress
serversock.listen(2)    
f = open("Details.txt", "r+")
print "Type This into the Client's PORT = "+str(PORT)
clients = set()
clients_lock = threading.Lock()


while 1:
    try:
        print 'waiting for connection...'
        clientsock, addr = serversock.accept()
        print '...connected from:', addr
        if is_open == True:
            thread.start_new_thread(handler, (clientsock, serversock, addr, f))    #creates a new thread to handle to client
    except:
        break