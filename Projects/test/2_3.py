-`0
+`0`#Blackjack game by Ben Cohen
-`1
+`1`from Tkinter import *
-`2
+`2`import tkFont
-`3
+`3`import random
-`4
+`4`import sqlite3 as lite
-`5
+`5`import datetime
-`6
+`6`def end_program():
-`7
+`7`	"""
-`8
+`8`	A function that stops the SQL connection and closes to program (Tkinter and python)
-`9
+`9`	arg: none
-`10
+`10`	ret: none
-`11
+`11`	"""
-`12
+`12`	conn.close()				#closing the SQL connection
-`13
+`13`	root.destroy()				#stops the tkinter and the python
-`14
+`14`def save_score():
-`15
+`15`	"""
-`16
+`16`	A function that saves the user score into the SQL table and adds it in the listbox
-`17
+`17`	arg: none
-`18
+`18`	ret: nome
-`19
+`19`	"""
-`20
+`20`	today_date=str(now.day)+"."+str(now.month)			#gets the computer month and day and sets them toghter
-`21
+`21`	cursor.execute("INSERT INTO blackjack_users VALUES(%s,%d,%d)"%(today_date,won,lost))     #adding the parameters to the SQL table
-`22
+`22`	conn.commit()
-`23
+`23`	scoreList.delete(0,END)
-`24
+`24`	scoreList.insert(END,template.format("Date","Player","Computer"))
-`25
+`25`	scoreList.insert(END,"------------------------------------------------")
-`26
+`26`	cursor.execute("SELECT Date,Player Score,Computer Score FROM blackjack_users")			#getting the information from the SQL table to print in the listbox
-`27
+`27`	for row in cursor:
-`28
+`28`		scoreList.insert(END,template1.format(row[0],row[1],row[2]))
-`29
+`29`def new_game():
-`30
+`30`	"""
-`31
+`31`	A function that starts a new game, resets the game parameters
-`32
+`32`	arg: none
-`33
+`33`	ret: none
-`34
+`34`	"""
-`35
+`35`	global player_hand
-`36
+`36`	global Comp_hand
-`37
+`37`	global Player_counter
-`38
+`38`	global Comp_counter
-`39
+`39`	global compIsPass
-`40
+`40`	global lost
-`41
+`41`	global won
-`42
+`42`	cardsList.delete(0, END)			#erases the game listbox to prepare for the new game
-`43
+`43`	cards = ["A","A","A","A",2,2,2,2,3,3,3,3,4,4,4,4,5,5,5,5,6,6,6,6,7,7,7,7,8,8,8,8,9,9,9,9,10,10,10,10,"J","J","J","J","Q","Q","Q","Q","K","K","K","K"]
-`44
+`44`	points = {"A":1,2:2,3:3,4:4,5:5,6:6,7:7,8:8,9:9,10:10,"J":10,"Q":10,"K":10}
-`45
+`45`	player_hand = []
-`46
+`46`	Comp_hand = []
-`47
+`47`	Player_counter = 0
-`48
+`48`	Comp_counter = 0 
-`49
+`49`	compIsPass=False
-`50
+`50`	playerIsPass=False
-`51
+`51`	for x in range(0,2):					#gives the player 2 random cards at the start of a game
-`52
+`52`		Player_card = random.choice(cards)
-`53
+`53`		cards.remove(Player_card)
-`54
+`54`		player_hand.append(Player_card)
-`55
+`55`		Player_counter = Player_counter+points[Player_card]
-`56
+`56`	comp_card = random.choice(cards)			#gives a computer a random card at the start of a game
-`57
+`57`	cards.remove(comp_card)
-`58
+`58`	Comp_hand.append(comp_card)
-`59
+`59`	Comp_counter = Comp_counter + points[comp_card]
-`60
+`60`	hit_btn["state"]=NORMAL
-`61
+`61`	pass_btn["state"]=NORMAL
-`62
+`62`	cardsList.insert(END,"Computer's hand: "+str(Comp_hand))			#prints the player and computer hands in the listbox
-`63
+`63`	cardsList.insert(END,"Player's hand: "+str(player_hand))
-`64
+`64`	stats["text"]="Player's Score: %d  Computer's Score: %d  Balance:%d:%d"%(won,lost,Player_counter,Comp_counter)
-`65
+`65`	newgame_btn["state"]=DISABLED
-`66
+`66`def pass_bj():
-`67
+`67`	"""
-`68
+`68`	A function that both makes the player pass, checking the computer pass state and declaring a winner
-`69
+`69`	arg: none
-`70
+`70`	ret: none
-`71
+`71`	"""
-`72
+`72`	global won
-`73
+`73`	global lost
-`74
+`74`	global compIsPass
-`75
+`75`	global Comp_counter
-`76
+`76`	playerIsPass = True
-`77
+`77`	hit_btn["state"]=DISABLED				#disables the game buttons(pass in the end)
-`78
+`78`	if (compIsPass==False):			#checks if the computer has'nt passed yet he passes/get cards
-`79
+`79`		if Comp_counter > player_hand:
-`80
+`80`			compIsPass=True
+`81`		while compIsPass==False and Comp_counter<Player_counter:
+`82`			comp_card=random.choice(cards)
+`83`			cards.remove(comp_card)
+`84`			Comp_hand.append(comp_card)
+`85`			Comp_counter = Comp_counter + points[comp_card]
+`86`			cardsList.insert(END,"Computer's hand: "+str(Comp_hand))
+`87`			cardsList.insert(END,"Player's hand: "+str(player_hand))
+`88`			stats["text"]="Player's Score: %d  Computer's Score: %d  Balance:%d:%d"%(won,lost,Player_counter,Comp_counter)
+`89`	if (Player_counter <=21 and Comp_counter<= 21):			#checks who won the game
+`90`		if Player_counter > Comp_counter:
+`91`			cardsList.insert(END,"You Won")
+`92`			won = won + 1
+`93`			stats["text"]="Player's Score: %d  Computer's Score: %d  Balance:%d:%d"%(won,lost,Player_counter,Comp_counter)			#updates the stats label
+`94`		else:
+`95`			cardsList.insert(END,"You Lost")
+`96`			lost = lost + 1
+`97`			stats["text"]="Player's Score: %d  Computer's Score: %d  Balance:%d:%d"%(won,lost,Player_counter,Comp_counter)
+`98`	if (Player_counter > 21 and Comp_counter > 21):
+`99`		cardsList.insert(END,"It's a tie!")
+`100`	else:
+`101`		if Player_counter > 21:
+`102`			cardsList.insert(END,"You Lost")
+`103`			lost = lost + 1
+`104`			stats["text"]="Player's Score: %d  Computer's Score: %d  Balance:%d:%d"%(won,lost,Player_counter,Comp_counter)
+`105`		if Comp_counter > 21:
+`106`			cardsList.insert(END,"You Won")
+`107`			won = won + 1
+`108`			stats["text"]="Player's Score: %d  Computer's Score: %d  Balance:%d:%d"%(won,lost,Player_counter,Comp_counter)
+`109`	pass_btn["state"]=DISABLED				
+`110`	newgame_btn["state"]=NORMAL				#returns the new game button to have the abillity to to start a new game
+`111`def hit():
+`112`	"""
+`113`	A function that adds a random card to the player/computer/both depending the situation
+`114`	arg:none
+`115`	ret:none
+`116`	"""
+`117`	global Player_counter
+`118`	global Comp_counter
+`119`	global compIsPass
+`120`	global lost
+`121`	global won
+`122`	if (Comp_counter >= 15 and Comp_counter>Player_counter):			#checks if the computer needs to pass
+`123`		compIsPass=True
+`124`	if compIsPass == False:			#if the computer hasn't passed gives both the player and the computer a ranom cad
+`125`		Player_card = random.choice(cards)
+`126`		comp_card = random.choice(cards)
+`127`		cards.remove(Player_card)
+`128`		cards.remove(comp_card)
+`129`		player_hand.append(Player_card)
+`130`		Comp_hand.append(comp_card)
+`131`		Player_counter = Player_counter + points[Player_card]
+`132`		Comp_counter = Comp_counter + points[comp_card]
+`133`		stats["text"]="Player's Score: %d  Computer's Score: %d  Balance:%d:%d"%(won,lost,Player_counter,Comp_counter)
+`134`		cardsList.insert(END,"Computer's hand: "+str(Comp_hand))
+`135`		cardsList.insert(END,"Player's hand: "+str(player_hand))
+`136`	if compIsPass==True:			#if the computer passed gives only the player a random card
+`137`		Player_card = random.choice(cards)
+`138`		cards.remove(Player_card)
+`139`		player_hand.append(Player_card)
+`140`		Player_counter = Player_counter+points[Player_card]
+`141`		stats["text"]="Player's Score: %d  Computer's Score: %d  Balance:%d:%d"%(won,lost,Player_counter,Comp_counter)
+`142`		cardsList.insert(END,"Computer's hand: "+str(Comp_hand))
+`143`		cardsList.insert(END,"Player's hand: "+str(player_hand))
+`144`	if Player_counter > 21:			#if the player cards equals above 21 automaticly passing him
+`145`		pass_bj()
+`146`		hit_btn["state"]=DISABLED
+`147`root = Tk()
+`148`root.configure(background="light sky blue")
+`149`x = (root.winfo_screenwidth() - root.winfo_reqwidth()) / 2			#finding the center of the screen
+`150`y = (root.winfo_screenheight() - root.winfo_reqheight()) / 2
+`151`root.geometry("855x375+%d+%d" % (x-350, y-100))				#placing the window in the middle of the screen
+`152`root.title("Python Blackjack")				#changes the tkinter window title
+`153`root.resizable(width=FALSE, height=FALSE)				#makes the tkinter window not resizable
+`154`fnt = tkFont.Font(size=15)
+`155`now = datetime.datetime.now()			#connecting into the computer time
+`156`file_name="C:\\Python26\\blackjack.db"
+`157`conn=lite.connect(file_name)			#connecting into the SQL
+`158`cursor=conn.cursor()
+`159`cursor.execute("CREATE TABLE IF NOT EXISTS blackjack_users(Date INTEGER,Player Score INTEGER,Computer Score INTEGER)")				#creating an SQL database if not exists
+`160`Scores_Frame=Frame(root)				#a frame for the score listbox and scrollbar
+`161`scrollbar1=Scrollbar(root,orient=VERTICAL)
+`162`scrollbar1.pack(in_=Scores_Frame,side=RIGHT,fill=Y)
+`163`scoreList=Listbox(root,width=30,bg="pale green",bd=3,font=fnt,yscrollcommand=scrollbar1.set)
+`164`scoreList.pack(in_=Scores_Frame)
+`165`scrollbar1.config(command=scoreList.yview)				#sets the scroll bar to verticaly move the listbox
+`166`Scores_Frame.grid(row=1,column=1)
+`167`template = "{0:^6}|{1:^15}|{2:^18}"				#templates for the SQL score listbox and printing it
+`168`template1="{0:^6}|{1:^18}|{2:^18}"
+`169`scoreList.insert(END,template.format("Date","Player","Computer"))
+`170`scoreList.insert(END,"------------------------------------------------")
+`171`cursor.execute("SELECT Date,Player Score,Computer Score FROM blackjack_users")
+`172`for row in cursor:
+`173`	scoreList.insert(END,template1.format(row[0],row[1],row[2]))
+`174`intro = Label(root,text="WELCOME TO PYTHON BLACKJACK",font=fnt,bg="light sky blue")
+`175`intro.grid(row=0,column=0,sticky=W)
+`176`name = Label(root,text="Name: Ben Cohen",font=fnt,bg="light sky blue")
+`177`name.grid(row=0,column=1,sticky=E)
+`178`Game_Frame = Frame(root)
+`179`scrollbar=Scrollbar(root,orient=VERTICAL)
+`180`scrollbar.pack(side=RIGHT,fill=Y,in_=Game_Frame)
+`181`cardsList=Listbox(root,width=35,bg="pale green",bd=3,font=fnt,yscrollcommand=scrollbar.set)
+`182`cardsList.pack(in_=Game_Frame)
+`183`scrollbar.config(command=cardsList.yview)
+`184`Game_Frame.grid(row=1,column=0)
+`185`Button_Frame=Frame(root)				#creates a frame for the buttons to create the same spaces and fit them in the program
+`186`newgame_btn = Button(root,text="New Game",command=new_game,font=fnt,bg="light sky blue")
+`187`newgame_btn.pack(in_=Button_Frame,side=LEFT,pady=15,padx=10)
+`188`hit_btn = Button(root,text="Hit",command=hit,font=fnt,state=DISABLED,bg="light sky blue")
+`189`hit_btn.pack(in_=Button_Frame,side=LEFT,pady=15,padx=10)
+`190`pass_btn = Button(root,text="Pass",command=pass_bj,font=fnt,state=DISABLED,bg="light sky blue")
+`191`pass_btn.pack(in_=Button_Frame,side=LEFT,pady=15,padx=10)
+`192`save_btn = Button(root,text="Save",command=save_score,font=fnt,bg="light sky blue")
+`193`save_btn.pack(in_=Button_Frame,side=LEFT,pady=15,padx=10)
+`194`exit_btn = Button(root,text="Exit",command=end_program,font=fnt,bg="light sky blue")
+`195`exit_btn.pack(in_=Button_Frame,side=LEFT,pady=15,padx=10)
+`196`Button_Frame.configure(background="light sky blue")
+`197`Button_Frame.grid(row=3,column=0,columnspan=4)
+`198`cards = ["A","A","A","A",2,2,2,2,3,3,3,3,4,4,4,4,5,5,5,5,6,6,6,6,7,7,7,7,8,8,8,8,9,9,9,9,10,10,10,10,"J","J","J","J","Q","Q","Q","Q","K","K","K","K"]
+`199`points = {"A":1,2:2,3:3,4:4,5:5,6:6,7:7,8:8,9:9,10:10,"J":10,"Q":10,"K":10}
+`200`player_hand = []
+`201`Comp_hand = []
+`202`playerIsPass = False
+`203`compIsPass = False
+`204`Player_counter = 0
+`205`Comp_counter = 0 
+`206`won=0
+`207`lost=0
+`208`stats=Label(root,text="Player's Score: %d  Computer's Score: %d  Balance:%d:%d"%(won,lost,Player_counter,Comp_counter),font=fnt,bg="light sky blue")
+`209`stats.grid(row=2,column=0,sticky=E)
+`210`root.mainloop()				#starts the tkinter loop
