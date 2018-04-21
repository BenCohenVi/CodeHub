from Tkinter import *
from Connections import *
from socket import *
import Display
import API

root = Tk()
c_socket = Client_Sock()
app = Display.Client_Display(root)
root.mainloop()
