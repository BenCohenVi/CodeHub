#Blackjack game by Ben Cohen
from Tkinter import *
import tkFont
import random
import sqlite3 as lite
import datetime
def end_program():
	"""
	A function that stops the SQL connection and closes to program (Tkinter and python)
	arg: none
	ret: none
	"""
	conn.close()				#closing the SQL connection
	root.destroy()				#stops the tkinter and the python
def save_score():
	"""
	A function that saves the user score into the SQL table and adds it in the listbox
	arg: none
	ret: nome
	"""
	today_date=str(now.day)+"."+str(now.month)			#gets the computer month and day and sets them toghter
	cursor.execute("INSERT INTO blackjack_users VALUES(%s,%d,%d)"%(today_date,won,lost))     #adding the parameters to the SQL table
	conn.commit()
	scoreList.delete(0,END)
	scoreList.insert(END,template.format("Date","Player","Computer"))
	scoreList.insert(END,"------------------------------------------------")
	cursor.execute("SELECT Date,Player Score,Computer Score FROM blackjack_users")			#getting the information from the SQL table to print in the listbox
	for row in cursor:
		scoreList.insert(END,template1.format(row[0],row[1],row[2]))
def new_game():
	"""
	A function that starts a new game, resets the game parameters
	arg: none
	ret: none
	"""
	global player_hand
	global Comp_hand
	global Player_counter
	global Comp_counter
	global compIsPass
	global lost
	global won
	cardsList.delete(0, END)			#erases the game listbox to prepare for the new game
	cards = ["A","A","A","A",2,2,2,2,3,3,3,3,4,4,4,4,5,5,5,5,6,6,6,6,7,7,7,7,8,8,8,8,9,9,9,9,10,10,10,10,"J","J","J","J","Q","Q","Q","Q","K","K","K","K"]
	points = {"A":1,2:2,3:3,4:4,5:5,6:6,7:7,8:8,9:9,10:10,"J":10,"Q":10,"K":10}
	player_hand = []
	Comp_hand = []
	Player_counter = 0
	Comp_counter = 0 
	compIsPass=False
	playerIsPass=False
	for x in range(0,2):					#gives the player 2 random cards at the start of a game
		Player_card = random.choice(cards)
		cards.remove(Player_card)
		player_hand.append(Player_card)
		Player_counter = Player_counter+points[Player_card]
	comp_card = random.choice(cards)			#gives a computer a random card at the start of a game
	cards.remove(comp_card)
	Comp_hand.append(comp_card)
	Comp_counter = Comp_counter + points[comp_card]
	hit_btn["state"]=NORMAL
	pass_btn["state"]=NORMAL
	cardsList.insert(END,"Computer's hand: "+str(Comp_hand))			#prints the player and computer hands in the listbox
	cardsList.insert(END,"Player's hand: "+str(player_hand))
	stats["text"]="Player's Score: %d  Computer's Score: %d  Balance:%d:%d"%(won,lost,Player_counter,Comp_counter)
	newgame_btn["state"]=DISABLED
def pass_bj():
	"""
	A function that both makes the player pass, checking the computer pass state and declaring a winner
	arg: none
	ret: none
	"""
	global won
	global lost
	global compIsPass
	global Comp_counter
	playerIsPass = True
	hit_btn["state"]=DISABLED				#disables the game buttons(pass in the end)
	if (compIsPass==False):			#checks if the computer has'nt passed yet he passes/get cards
		if Comp_counter > player_hand:
			compIsPass=True
		while compIsPass==False and Comp_counter<Player_counter:
			comp_card=random.choice(cards)
			cards.remove(comp_card)
			Comp_hand.append(comp_card)
			Comp_counter = Comp_counter + points[comp_card]
			cardsList.insert(END,"Computer's hand: "+str(Comp_hand))
			cardsList.insert(END,"Player's hand: "+str(player_hand))
			stats["text"]="Player's Score: %d  Computer's Score: %d  Balance:%d:%d"%(won,lost,Player_counter,Comp_counter)
	if (Player_counter <=21 and Comp_counter<= 21):			#checks who won the game
		if Player_counter > Comp_counter:
			cardsList.insert(END,"You Won")
			won = won + 1
			stats["text"]="Player's Score: %d  Computer's Score: %d  Balance:%d:%d"%(won,lost,Player_counter,Comp_counter)			#updates the stats label
		else:
			cardsList.insert(END,"You Lost")
			lost = lost + 1
			stats["text"]="Player's Score: %d  Computer's Score: %d  Balance:%d:%d"%(won,lost,Player_counter,Comp_counter)
	if (Player_counter > 21 and Comp_counter > 21):
		cardsList.insert(END,"It's a tie!")
	else:
		if Player_counter > 21:
			cardsList.insert(END,"You Lost")
			lost = lost + 1
			stats["text"]="Player's Score: %d  Computer's Score: %d  Balance:%d:%d"%(won,lost,Player_counter,Comp_counter)
		if Comp_counter > 21:
			cardsList.insert(END,"You Won")
			won = won + 1
			stats["text"]="Player's Score: %d  Computer's Score: %d  Balance:%d:%d"%(won,lost,Player_counter,Comp_counter)
	pass_btn["state"]=DISABLED				
	newgame_btn["state"]=NORMAL				#returns the new game button to have the abillity to to start a new game
def hit():
	"""
	A function that adds a random card to the player/computer/both depending the situation
	arg:none
	ret:none
	"""
	global Player_counter
	global Comp_counter
	global compIsPass
	global lost
	global won
	if (Comp_counter >= 15 and Comp_counter>Player_counter):			#checks if the computer needs to pass
		compIsPass=True
	if compIsPass == False:			#if the computer hasn't passed gives both the player and the computer a ranom cad
		Player_card = random.choice(cards)
		comp_card = random.choice(cards)
		cards.remove(Player_card)
		cards.remove(comp_card)
		player_hand.append(Player_card)
		Comp_hand.append(comp_card)
		Player_counter = Player_counter + points[Player_card]
		Comp_counter = Comp_counter + points[comp_card]
		stats["text"]="Player's Score: %d  Computer's Score: %d  Balance:%d:%d"%(won,lost,Player_counter,Comp_counter)
		cardsList.insert(END,"Computer's hand: "+str(Comp_hand))
		cardsList.insert(END,"Player's hand: "+str(player_hand))
	if compIsPass==True:			#if the computer passed gives only the player a random card
		Player_card = random.choice(cards)
		cards.remove(Player_card)
		player_hand.append(Player_card)
		Player_counter = Player_counter+points[Player_card]
		stats["text"]="Player's Score: %d  Computer's Score: %d  Balance:%d:%d"%(won,lost,Player_counter,Comp_counter)
		cardsList.insert(END,"Computer's hand: "+str(Comp_hand))
		cardsList.insert(END,"Player's hand: "+str(player_hand))
	if Player_counter > 21:			#if the player cards equals above 21 automaticly passing him
		pass_bj()
		hit_btn["state"]=DISABLED
root = Tk()
root.configure(background="light sky blue")
x = (root.winfo_screenwidth() - root.winfo_reqwidth()) / 2			#finding the center of the screen
y = (root.winfo_screenheight() - root.winfo_reqheight()) / 2
root.geometry("855x375+%d+%d" % (x-350, y-100))				#placing the window in the middle of the screen
root.title("Python Blackjack")				#changes the tkinter window title
root.resizable(width=FALSE, height=FALSE)				#makes the tkinter window not resizable
fnt = tkFont.Font(size=15)
now = datetime.datetime.now()			#connecting into the computer time
file_name="C:\\Python26\\blackjack.db"
conn=lite.connect(file_name)			#connecting into the SQL
cursor=conn.cursor()
cursor.execute("CREATE TABLE IF NOT EXISTS blackjack_users(Date INTEGER,Player Score INTEGER,Computer Score INTEGER)")				#creating an SQL database if not exists
Scores_Frame=Frame(root)				#a frame for the score listbox and scrollbar
scrollbar1=Scrollbar(root,orient=VERTICAL)
scrollbar1.pack(in_=Scores_Frame,side=RIGHT,fill=Y)
scoreList=Listbox(root,width=30,bg="pale green",bd=3,font=fnt,yscrollcommand=scrollbar1.set)
scoreList.pack(in_=Scores_Frame)
scrollbar1.config(command=scoreList.yview)				#sets the scroll bar to verticaly move the listbox
Scores_Frame.grid(row=1,column=1)
template = "{0:^6}|{1:^15}|{2:^18}"				#templates for the SQL score listbox and printing it
template1="{0:^6}|{1:^18}|{2:^18}"
scoreList.insert(END,template.format("Date","Player","Computer"))
scoreList.insert(END,"------------------------------------------------")
cursor.execute("SELECT Date,Player Score,Computer Score FROM blackjack_users")
for row in cursor:
	scoreList.insert(END,template1.format(row[0],row[1],row[2]))
intro = Label(root,text="WELCOME TO PYTHON BLACKJACK",font=fnt,bg="light sky blue")
intro.grid(row=0,column=0,sticky=W)
name = Label(root,text="Name: Ben Cohen",font=fnt,bg="light sky blue")
name.grid(row=0,column=1,sticky=E)
Game_Frame = Frame(root)
scrollbar=Scrollbar(root,orient=VERTICAL)
scrollbar.pack(side=RIGHT,fill=Y,in_=Game_Frame)
cardsList=Listbox(root,width=35,bg="pale green",bd=3,font=fnt,yscrollcommand=scrollbar.set)
cardsList.pack(in_=Game_Frame)
scrollbar.config(command=cardsList.yview)
Game_Frame.grid(row=1,column=0)
Button_Frame=Frame(root)				#creates a frame for the buttons to create the same spaces and fit them in the program
newgame_btn = Button(root,text="New Game",command=new_game,font=fnt,bg="light sky blue")
newgame_btn.pack(in_=Button_Frame,side=LEFT,pady=15,padx=10)
hit_btn = Button(root,text="Hit",command=hit,font=fnt,state=DISABLED,bg="light sky blue")
hit_btn.pack(in_=Button_Frame,side=LEFT,pady=15,padx=10)
pass_btn = Button(root,text="Pass",command=pass_bj,font=fnt,state=DISABLED,bg="light sky blue")
pass_btn.pack(in_=Button_Frame,side=LEFT,pady=15,padx=10)
save_btn = Button(root,text="Save",command=save_score,font=fnt,bg="light sky blue")
save_btn.pack(in_=Button_Frame,side=LEFT,pady=15,padx=10)
exit_btn = Button(root,text="Exit",command=end_program,font=fnt,bg="light sky blue")
exit_btn.pack(in_=Button_Frame,side=LEFT,pady=15,padx=10)
Button_Frame.configure(background="light sky blue")
Button_Frame.grid(row=3,column=0,columnspan=4)
cards = ["A","A","A","A",2,2,2,2,3,3,3,3,4,4,4,4,5,5,5,5,6,6,6,6,7,7,7,7,8,8,8,8,9,9,9,9,10,10,10,10,"J","J","J","J","Q","Q","Q","Q","K","K","K","K"]
points = {"A":1,2:2,3:3,4:4,5:5,6:6,7:7,8:8,9:9,10:10,"J":10,"Q":10,"K":10}
player_hand = []
Comp_hand = []
playerIsPass = False
compIsPass = False
Player_counter = 0
Comp_counter = 0 
won=0
lost=0
stats=Label(root,text="Player's Score: %d  Computer's Score: %d  Balance:%d:%d"%(won,lost,Player_counter,Comp_counter),font=fnt,bg="light sky blue")
stats.grid(row=2,column=0,sticky=E)
root.mainloop()				#starts the tkinter loop