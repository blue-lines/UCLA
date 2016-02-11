__author__ = 'Julien Heck'


"""
lab10.py
"""

import sys
import time
import configparser
import logging
from PyQt4 import QtCore
from PyQt4 import QtGui
import UI
import GoogleFinance


if __name__ == '__main__':

    # Try to open the config file
    # If failure, exit program
    try:
        config = configparser.ConfigParser()
        config.read("stocks.cfg")
    except:
        print("Failed to read config file")
        sys.exit(-1)

    # Default name of the log file
    logfile_name = 'default.log'

    # Retrieve log file name from config file if it exists
    if config.has_option('LOGGING', 'LOG_FILE'):
        logfile_name = config.get('LOGGING', 'LOG_FILE')

    # Try to create the log file using log file name
    # If failure, exit program
    try:
        logging.basicConfig(filename=logfile_name,
                            level=logging.DEBUG,
                            format='%(asctime)s, %(levelname)s, %(message)s',
                            datefmt='%m/%d/%Y %I:%M:%S %p')
    except:
        print("Failed to open log file {0}".format(logfile_name))
        sys.exit(-1)

    logging.info("Program Started")

    # Create and execute GUI
    app = QtGui.QApplication(sys.argv)
    gui = UI.UI(config)
    gui.show()
    app.exec_()

    logging.info("Program done. Exit.")
    sys.exit(0)
