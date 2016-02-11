__author__ = 'Julien Heck'

import logging
import psycopg2


class Postgres:
    """
    Class with methods to access database
    """

    def __init__(self, database=None, user=None, password=None):
        """
        Constructor, gets information to connect to the database
        :param database: string, database name
        :param user: string, user name
        :param password: string, user password
        :return:
        """
        self.database = database
        self.user = user
        self.password = password
        self._ready = False
        self.cursor = None
        self.conn = None

    def connect(self):
        """
        Connect to the database. Initialize conn and cursor properties
        :return:
        """
        try:
            self.conn = psycopg2.connect(dbname=self.database,
                                         user=self.user,
                                         host="/var/run/postgresql/",
                                         password=self.password)
            self.cursor = self.conn.cursor()
            self._ready = True
        except:
            self._ready = False

        return self._ready

    def executeCommand(self, command=None):
        """
        Execute command passed as parameter
        :param command: string, command to execute in DB
        :return:
        """
        if not self._ready:
            logging.info("DB NOT READY")
            return

        logging.info(command)
        try:
            self.cursor.execute(command)
            self.conn.commit()
        except:
            self.conn.rollback()

    def createTable(self, table_name=None, table_list=[]):
        """
        Create table in DB
        :param table_name: string, table name
        :param table_list: list of tuples (x,y), x=variable name, y=data type
        :return:
        """
        if not self._ready or table_name is None or len(table_list) == 0:
            return

        table_string = """CREATE TABLE {0} (""".format(table_name)
        for x, y in table_list:
            table_string += "{0} {1},".format(x, y)

        table_string = table_string[:-1]
        table_string += ");"
        self.executeCommand(table_string)

    def insertData(self, table_name=None, values=None):
        """
        Insert data in table
        :param table_name: string, target table name
        :param values: tuple with values to add
        :return:
        """
        if table_name is None or not self._ready:
            return

        insert_string = """INSERT INTO {0} VALUES ('{1}', {2} )""".format(table_name, values[0], values[1])
        self.executeCommand(insert_string)
        return

    def queryAllData(self, table_name=None):
        if not self._ready or table_name is None:
            return

        table_string = """SELECT * FROM {0}""".format(table_name)
        self.executeCommand(table_string)
        if self.cursor.rowcount:
            return self.cursor.fetchall()
        else:
            logging.error("Failed to query all data from {0}".format(table_name))
            return None

    def querySpecificData(self, table_name=None, query_data=None):
        if not self._ready or table_name is None or query_data is None:
            return

        table_string = """SELECT * FROM {0} WHERE {1}""".format(table_name, query_data)
        print(table_string)
        self.executeCommand(table_string)
        if self.cursor.rowcount:
            return self.cursor.fetchall()
        else:
            logging.error("Failed to query {1} data from {0}".format(table_name, query_data))
            return None



