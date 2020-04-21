import cv2
import numpy as np
import matplotlib
import math

# matplotlib.use('TkAgg') # uncomment this if you are not using an OS with Tkinter compaitble window manager
from matplotlib import pyplot as plt


# read image and make greyscale and color copies
img = cv2.imread('images/outline.png')
color_img = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

# Gaussian blur the grayscale image

KernelSizeWidth = 3
KernelSizeHeight = 3
blurred_img_3v3 = cv2.GaussianBlur(gray,(KernelSizeWidth, KernelSizeHeight),0)

KernelSizeWidth = 13
KernelSizeHeight = 13
blurred_img_13v13 = cv2.GaussianBlur(gray,(KernelSizeWidth, KernelSizeHeight),0)


# use canny to detect edges
canny_threshold = 30
canny_param2 = 135
canny_img = cv2.Canny(blurred_img_3v3, canny_threshold, canny_param2)

# threshold to close gaps in the edges
thresh = cv2.threshold(canny_img, 45, 255, cv2.THRESH_BINARY)[1]
thresh = cv2.dilate(thresh, None, iterations=2)


def center_horizontally(x1, y1):
    # get max length to go right
    max_length = len(canny_img[0]) - x1

    print("max:", max_length)
    for x in range(max_length):
        pos = x1 + x

        if canny_img[y1][pos] != 0:
            distance_right = x
            cv2.circle(color_img,(pos,y1), radius, (255,0, 0), -1)
            break

    # get max length to go left
    # start at x1
    # decrement by 1 until 0
    for x in range(x1,0,-1):
        pos = x
        if canny_img[y1][x] != 0:
            distance_left = x1 - x
            cv2.circle(color_img,(pos,y1), radius, (255,0, 0), -1)
            break

    if distance_left and distance_right:
        print("left:", distance_left)
        print("right:", distance_right)

        center = int((distance_right - distance_left) / 2)
        x1 += center

    return (x1, y1)


def center_vertically(x1, y1):
    # get max length to go down
    max_length = len(color_img) - y1 -1
    distance_top, distance_down = 0, 0

    print("top max:", max_length)
    for y in range(max_length):
        pos = y1 + y

        if canny_img[pos][x1] != 0:
            distance_down = y
            cv2.circle(color_img,(x1,pos), radius, (255,0, 0), -1)
            break

    # get max length to go up
    max_length = 0

    print("down max:", max_length)
    for y in range(y1, max_length, -1):
        pos = y

        if canny_img[pos][x1] != 0:
            distance_top = y
            cv2.circle(color_img,(x1,pos), radius, (255,0, 0), -1)
            break

    if distance_top and distance_down:
        print("top:", distance_top)
        print("down:", distance_down)

    center = int((distance_down - distance_top) / 2)

    y1 += center

    return (x1, y1)


def is_point_edge(x, y):
    return canny_img[y][x] != 0


def find_point(x1, y1, radians):
    angle = 3.14
    m = abs(math.tan(angle)) * 100
    m = -1 # -1 = 135 degrees in slope

    x = x1
    y = y1

    b = y - (m) * (x)

    for x in range(x,0,-1):
        y = (m * x) + b
        x = int(x)
        y = int(y)

        if is_point_edge(x, y):
            cv2.circle(color_img,(x,y), radius, (255,0, 0), -1)
            return (x, y)

    return (None, None)


def draw_stuff(x1, y1):
    for x in range(3):
        x1, y1 = center_horizontally(x1, y1)
        x1, y1 = center_vertically(x1, y1)

    x2, y2 = find_point(x1, y1, 0)
    # draw angle

    cv2.circle(color_img,(x1,y1), radius, (0,0, 255), -1)

    angle = 135
    length = 1000
    lineThickness = 5

    radians = math.radians(angle)

    x2 = int(x1 + length * math.cos(radians))
    y2 = int(y1 + length * math.sin(radians))

    print(x2, y2)

    cv2.line(color_img, (x1, y1), (x2, y2), (0,255,0), lineThickness)


def draw_circle(event,x,y,flags,param):
    if event == cv2.EVENT_LBUTTONDBLCLK:
        draw_stuff(x,y)


if __name__ == "__main__":
    radius = 10

    cv2.namedWindow('image')
    cv2.setMouseCallback('image' ,draw_circle)


    while(1):
        cv2.imshow('image',color_img)
        if cv2.waitKey(20) & 0xFF == 27:
            break


    cv2.destroyAllWindows()
    exit()


