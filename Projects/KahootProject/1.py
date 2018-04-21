from Tkinter import *
from Connections import *
from socket import *
import thread
import threading
import Display
import API
#import random

def handler(clientsock):
    print "Hi"

#questions = ["questions1.txt", "questions2.txt", "questions3.txt"]
#questionire = random.choice(questions)
q = open("questions1.txt", "r")
root = Tk()
app = Display.Server_Display(root)
s_socket = Server_Socket()
q = open("questions1.txt", "r")
clients = set()
clients_lock = threading.Lock()
clients_counter = 0
while clients_counter < 3:
    c_sock = s_socket.wait_for_connection()
    clients_counter = clients_counter + 1
    with clients_lock:
        clients.add(c_sock)
app.show_question(q)
while clients_lock:
    for c in clients:
        c.sendall("we start")
        thread.start_new_thread(handler, (c))
root.mainloop()
