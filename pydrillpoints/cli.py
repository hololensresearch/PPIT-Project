#!/usr/bin/env python3
import cv2
from detectors import detectors
from argparse import ArgumentParser


DEFAULT_DETECTOR = "contour"


def get_args():
    ''' fetches CLI args '''
    parser = ArgumentParser(description='Draws drill points on xrays for hip pinning surgeries')
    parser.add_argument("--filename", required=True,
                        help='location of image')
    parser.add_argument("--detector", default=DEFAULT_DETECTOR,
                        help='Create a new database')

    return parser.parse_args()


def main():
    args = get_args()

    if args.detector not in detectors:
        print("Invalid detector specified, valid detectors: ")
        print(', '.join([d for d in detectors.keys()]))
    else:
        Detector = detectors.get(args.detector)
        d = Detector(args.filename)

        # display output
        cv2.imshow("Original", d.get_image())
        cv2.waitKey()


if __name__=="__main__":
    main()
