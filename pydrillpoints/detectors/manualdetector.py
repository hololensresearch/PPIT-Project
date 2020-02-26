import cv2
import numpy as np
from .basedetector import BaseDetector


class ManualDetector(BaseDetector):
    def parse_image(self):
        img = cv2.imread(self.filename,)
        color_img = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)

        x1, y1 = 105, 73
        x2, y2 = 39, 150

        self.head_coords = (x1,y1)
        self.femur_coords = (x2,y2)

        line_thickness = 5

        cv2.line(color_img, (x1, y1), (x2, y2), (0,255,0), line_thickness)
        self.finished_img = color_img
