__author__ = 'Julien Heck'

"""
UI_central.py
"""

from PyQt4 import QtCore
from PyQt4 import QtGui
import QtMpl

class UI_central(QtGui.QDialog):

    """
    UI Central widget
    """

    def __init__(self, label="", parent=None):
        super(UI_central, self).__init__(parent)
        hbox = QtGui.QHBoxLayout()

        vbox = QtGui.QVBoxLayout();
        hbox2 = QtGui.QHBoxLayout();
        hbox3 = QtGui.QHBoxLayout();

        # Create QtGui items
        ## hbox
        self.stock_name = QtGui.QTextEdit()
        self.stock_info1 = QtGui.QLabel("Stock:")
        self.stock_number = QtGui.QTextEdit()
        self.stock_info2 = QtGui.QLabel("How many?")
        self.calendar = QtGui.QCalendarWidget()
        self.button = QtGui.QPushButton(self)
        self.button.setText("Add")

        ## hbox2
        self.know_stock_lb = QtGui.QLabel("Known Stocks")
        self.combobox = QtGui.QComboBox()
        self.button2 = QtGui.QPushButton()
        self.button2.setText("Display Officers")

        ## hbox3
        self.off_dir_lb = QtGui.QLabel("Officers and Directors")
        self.text_edit = QtGui.QTextEdit()

        ## Matplotlib object
        self.mpl = QtMpl.QtMpl(self)

        # Add QtGui items to layout
        hbox.addWidget(self.stock_info1)
        hbox.addWidget(self.stock_name)
        hbox.addWidget(self.stock_info2)
        hbox.addWidget(self.stock_number)
        hbox.addWidget(self.stock_info1)
        hbox.addWidget(self.calendar)
        hbox.addWidget(self.button)

        hbox2.addWidget(self.know_stock_lb)
        hbox2.addWidget(self.combobox)
        hbox2.addWidget(self.button2)

        hbox3.addWidget(self.off_dir_lb)
        hbox3.addWidget(self.text_edit)

        vbox.addLayout(hbox)
        vbox.addLayout(hbox2)
        vbox.addLayout(hbox3)
        vbox.addWidget(self.mpl)

        self.setLayout(vbox)
        pass
