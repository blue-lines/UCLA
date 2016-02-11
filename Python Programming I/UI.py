__author__ = 'Julien Heck'

"""
UI.py
Main UI class
"""

import logging
import configparser
import time
import os
import datetime
from PyQt4 import QtCore
from PyQt4 import QtGui
import requests
import bs4
import UI_about
import UI_central
import GoogleFinance
import Postgres

class UI(QtGui.QMainWindow):

    def __init__(self, configuration=None, parent=None):
        super(UI, self).__init__(parent)

        # Setup configuration file
        self.configuration = configuration

        # Setup Menu bar items
        menubar = self.menuBar()
        fileMenu = menubar.addMenu('&File')
        helpMenu = menubar.addMenu('&Help')

        # Setup Exit action
        exitAction = QtGui.QAction('&Exit', self)
        exitAction.setShortcut('Ctrl+Q')
        exitAction.setStatusTip('Exit Application')
        exitAction.triggered.connect(QtGui.qApp.quit)
        fileMenu.addAction(exitAction)

        # Setup About action
        aboutAction = QtGui.QAction('&About', self)
        aboutAction.setShortcut('Ctrl+A')
        aboutAction.setStatusTip('About')
        aboutAction.triggered.connect(self.aboutAction)
        helpMenu.addAction(aboutAction)

        # Setup Tool bar
        self.toolbar = self.addToolBar('Exit')
        self.toolbar.addAction(exitAction)
        self.toolbar.addAction(aboutAction)

        # Setup central widget
        self.central = UI_central.UI_central()
        self.connect(self.central.button, QtCore.SIGNAL("clicked()"), self.addButtonClicked)
        self.setCentralWidget(self.central)

        # Connect to DB
        password = os.getenv('PASSWORD')
        self.db = Postgres.Postgres('postgres', 'postgres', password)

        if not self.db.connect():
            logging.error("Database connection failed")
            return

        # Create know_stocks table
        self.db.createTable('know_stocks', [('SYMBOL', 'text'), ('SHARES', 'integer')])

        # Populate combo box with known stocks from database
        self.connect(self.central.button2, QtCore.SIGNAL("clicked()"), self.stock_button_clicked)
        self.know_stocks = []
        self.know_stocks = self.db.queryAllData("know_stocks")
        if self.know_stocks is not None:
            for item in self.know_stocks:
                self.central.combobox.addItem(item[0])

        self.setWindowTitle('Learning Python Lab 9')
        self.show()

    def aboutAction(self):
        """
        Display UI_about class
        :return:
        """
        about = UI_about.UI_about()
        about.exec_()
        return

    def addButtonClicked(self):
        """
        Create instance of GoogleFinance class based on data entered through GUI
        :return:
        """
        date = self.central.calendar.selectedDate()
        date_string = "{0} {1} {2}".format(
            date.day(), date.longMonthName(date.month()),
            date.year())
        stock_str = self.central.stock_name.toPlainText().upper()
        # Check shares number is numeric and greater than 0
        try:
            shares_number = int(self.central.stock_number.toPlainText())
            if shares_number < 0:
                shares_number = 0
        except:
            shares_number = 0

        # Check if stock symbol already exists in config file
        if self.configuration.has_section(stock_str):
            message = "Stock {0} already exists in stocks file".format(stock_str)
            print(message)
            logging.info(message)
        else:
        # Add stock data in config if symbol doesnt exist yet
            self.configuration.add_section(stock_str)
            self.configuration.set(stock_str, "SHARES", str(shares_number))
            self.configuration.set(stock_str, "DATE", date_string)
            # Try to write data on config file
            try:
                config_file = open('stocks.cfg', "w")
                self.configuration.write(config_file)
                config_file.close()
            except:
                message = "Data: {0} - {1} - {2} failed to open/write to file: {3} "\
                    .format(stock_str, shares_number, date_string, 'stocks.cfg')
                print(message)
                logging.error(message)

        # Create new instance of GoogleFinance class
        stock_date = time.strptime(date_string, "%d %B %Y")
        my_stock = GoogleFinance.GoogleFinance(stock_str, stock_date)
        filename = "{0}.csv".format(stock_str)
        # Check if data has been retrieved from URL with get_historical_data()
        if (my_stock.get_historical_data(filename)):
            try:
                self.db.insertData('know_stocks', (stock_str, shares_number))
            except:
                message = "Error during inserting data {1} {2} in table {0}".format('know_stocks', stock_str, shares_number)
                print(message)
                logging.error(message)
            try:
                self.db.createTable(stock_str, [('DATE', 'date'), ('STOCK_PRICE', 'money')])
            except:
                message = "Error during creation of table {0}".format(stock_str)
                print(message)
                logging.error(message)

            # Export data in .csv file with stock name
            list_stocks = []
            with open(filename) as fp:
                for line in fp:
                    list_stocks.append(line.split(","))

            # Insert data in stock name table
            for items in list_stocks:
                if items[0] != 'Date' and items[0] != '\n':
                    try:
                        self.db.insertData(stock_str, items)
                    except:
                        message = "Error during inserting data {1} {2} in table {0}".format(stock_str, items[0], items[1])
                        print(message)
                        logging.error(message)
                        return

            self.central.combobox.addItem(stock_str)

    def stock_button_clicked(self):
        self.central.text_edit.clear()
        stock_str = self.central.combobox.currentText()
        url = "https://www.google.com/finance?q="
        url += stock_str
        # Try to get URL
        try:
            req = requests.get(url)
        except:
            message = "Error accessing {0} webpage".format(url)
            print(message)
            logging.error(message)
            self.central.text_edit.setText(url)
            return
        # Build soup object
        try:
            soup = bs4.BeautifulSoup(req.text)
        except:
            message = "Error on Soup"
            print(message)
            logging.error(message)
            return
        # Retrieve data from Soup table in display it in Text Edit item
        try:
            table = soup.find_all("table", {"class": "id-mgmt-table"})
            rows = table[0].find_all('tr')
            data = []
            for row in rows:
                cols = row.find_all('td')
                cols = [str.text.strip() for str in cols]
                data = ([str for str in cols if str])
                # Append each item of the list to the text edit item
                for d in data:
                    self.central.text_edit.append(d)
        except:
            message = "Error extracting data from table"
            print(message)
            logging.error(message)
            return

        self.updateGraph(stock_str)

    def updateGraph(self, symbol=None):
        if symbol == None:
            return

        symbol_data = self.db.queryAllData(symbol)
        symbol_prices = [x[1].strip('$') for x in symbol_data]
        date_list = [x[0] for x in symbol_data]
        date_string = [x.strftime("%m/%d/%Y") for x in date_list]
        symbol_dates = [datetime.datetime.strptime(d, '%m/%d/%Y').date()
                  for d in date_string]

        self.central.mpl.addLine(symbol_dates, symbol_prices, symbol)

