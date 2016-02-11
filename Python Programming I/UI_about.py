__author__ = 'Julien Heck'

"""
UI_about.py
"""

from PyQt4 import QtCore
from PyQt4 import QtGui

class UI_about(QtGui.QDialog):

    """
    UI about class
    """

    def __init__(self, parent=None):
        super(UI_about, self).__init__(parent)
        self.about_info = QtGui.QLabel(
            "Learning Python\nJulien Heck\nLab 10")
        vbox = QtGui.QVBoxLayout()
        vbox.addWidget(self.about_info)
        self.setLayout(vbox)
        self.setWindowTitle("About Learning Python Lab 7")
        pass