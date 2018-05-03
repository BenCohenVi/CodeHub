import sqlite3


class Useract:
    """Manages login/register of users.

    The class has 2 variables to connect to the users Database,
    it manages the register and login of users by using the Database.
    """

    def __init__(self, c, conn):
        #Setting the class variables
        self.c = c
        self.conn = conn

    def check_login(self, data):
        """Checks the login information of a user.

        The function gets a username and a password,
        it checks if the information is valiable,
        if yes returns True, else returns False.
        """
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
        """Registering a new user.

        The function gets a username and password,
        checks if already exists a user with the same username in the Database,
        if no adds the user and returns "OK",
        else it does nothing and returns "NO".
        """
        self.c.execute("SELECT * FROM UsersDB WHERE username=:data",
                       {'data': data.split(',')[0]})
        if self.c.fetchone() == None:
            self.c.execute("INSERT INTO UsersDB VALUES (?,?)",
                           (data.split(',')[0], data.split(',')[1]))
            self.conn.commit()
            self.c.execute(
                "CREATE TABLE IF NOT EXISTS " + data.split(',')[0] +
                "(name TEXT, version INTEGER, shared TEXT, sharing TEXT)")
            return "OK"
        else:
            return "NO"
