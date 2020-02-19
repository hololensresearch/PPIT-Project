import cv2
import numpy as np
from .basedetector import BaseDetector


class ContourDetector(BaseDetector):
    def parse_image(self):
        img = cv2.imread(self.filename,)
        gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
        color_img = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)

        KernelSizeWidth = 3
        KernelSizeHeight = 3
        blurred_img_3v3 = cv2.GaussianBlur(gray,(KernelSizeWidth, KernelSizeHeight),0)

        KernelSizeWidth = 13
        KernelSizeHeight = 13
        blurred_img_13v13 = cv2.GaussianBlur(gray,(KernelSizeWidth, KernelSizeHeight),0)

        canny_threshold = 30
        canny_param2 = 135
        canny_img = cv2.Canny(blurred_img_3v3, canny_threshold, canny_param2)

        thresh = cv2.threshold(canny_img, 45, 255, cv2.THRESH_BINARY)[1]
# thresh = cv2.erode(thresh, None, iterations=2)
        thresh = cv2.dilate(thresh, None, iterations=2)


        contours, hierarchy = cv2.findContours(thresh,cv2.RETR_TREE,cv2.CHAIN_APPROX_SIMPLE)
        contours = sorted(contours, key=cv2.contourArea, reverse=True)
        img_contours = img.copy()
        cv2.drawContours(img_contours, contours, 0, (0,255,0), 2)

        for cnt in contours:
                M = cv2.moments(cnt)
                cx = int(M['m10']/M['m00'])
                cy = int(M['m01']/M['m00'])
                center = (cx, cy)
                radius = 5
                cv2.circle(img_contours, (cx,cy), radius, (0, 255, 255), -1)

        self.finished_img = img_contours
