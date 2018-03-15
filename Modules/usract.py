import sqlite3


class Useract:
    def __init__(self, c, conn):
        self.c = c
        self.conn = conn

    def check_login(self, data):
        self.c.execute("SELECT * FROM UsersDB WHERE username=:data",
                       {'data': data.split(',')[0]})
        log = str(self.c.fetchone())
        if log != "None":
            password = log.split(',')[1].replace(" u'", "").replace("')", "")
            if password == data.split(',')[1]:
                return True
            else:
                return False
        else:
            return False

    def register(self, data):
        self.c.execute("SELECT * FROM UsersDB WHERE username=:data",
                       {'data': data.split(',')[0]})
        if self.c.fetchone() == None:
            self.c.execute("INSERT INTO UsersDB VALUES (?,?)",
                           (data.split(',')[0], data.split(',')[1]))
            self.conn.commit()
            self.c.execute("CREATE TABLE IF NOT EXISTS "+data.split(',')
                           [0]+"(name TEXT, version INTEGER, shared TEXT, sharing TEXT)")
            return "OK"
        else:
            return "NO"
