from .basedetector import BaseDetector
from .contourdetector import ContourDetector
from .manualdetector import ManualDetector

detectors = {
    #'basedetector': BaseDetector,
    'contour': ContourDetector,
    'manual': ManualDetector
}
