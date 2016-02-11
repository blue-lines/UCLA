__author__ = 'Julien Heck'

from PyQt4 import QtGui
import matplotlib
import matplotlib.dates as mdates
from matplotlib.backends.backend_qt4agg import FigureCanvasQTAgg


class QtMpl(FigureCanvasQTAgg):

    """
    MatPlotlib object derived from FigureCanvasQTAgg
    """

    def __init__(self, parent):

        self.fig = matplotlib.figure.Figure()
        FigureCanvasQTAgg.__init__(self, self.fig)

        # Set date format
        self.fig.gca().xaxis.set_major_formatter(
            mdates.DateFormatter('%m/%d/%Y'))
        self.fig.gca().xaxis.set_major_locator(
            mdates.DayLocator())
        self.setParent(parent)
        # List to hold axis point
        self.line_list = []

        self.axes = self.fig.add_subplot(111)

        # Define the widget as expandable
        FigureCanvasQTAgg.setSizePolicy(self,
                                        QtGui.QSizePolicy.Expanding,
                                        QtGui.QSizePolicy.Expanding)
        # Notify the system of updated policy
        FigureCanvasQTAgg.updateGeometry(self)

    def addLine(self, x, y, title):
        # Draw line
        self.line_list.append(self.axes.plot(x, y, label=title))
        self.axes.legend()
        self.fig.canvas.draw()
        self.fig.autofmt_xdate()