#!/usr/bin/env python3
import os
import sys
import cv2
from flask import request, send_file, Flask, make_response
from detectors import detectors


app = Flask(__name__)


@app.route('/', methods=['GET'])
def index():
    return "/detectors - list detectors<br />/images - list images<br />/image/[detector]/[image] - get image"

@app.route('/detectors', methods=['GET'])
def list_detectors():
    return {'detectors': [d for d in detectors.keys()] }


@app.route('/images', methods=['GET'])
def list_images():
    return {'images': [filename for filename in os.listdir('images')] }

@app.route('/image/<detector>/<filename>', methods=['GET'])
def get_image(detector, filename):

    if not filename:
        return "Error: No filename provided. Please specify a filename.", 400

    # prevent path traversal attacks
    file_location = os.path.join("images/", os.path.basename(filename))

    if not os.path.exists(file_location):
        return "Error: File does not exist.", 400

    # select detector class
    if detector not in detectors:
        return "Error: Invalid detector specified", 400

    Detector = detectors.get(detector)
    d = Detector(file_location)

    # get output image and return in response
    retval, buffer = cv2.imencode('.png', d.get_image())
    response = make_response(buffer.tobytes())
    response.headers['Content-Type'] = 'image/png'
    return response


if __name__=="__main__":
    if (len(sys.argv) > 1):
        port = sys.argv[1]
    else:
        port = 5000

    app.run(host = '0.0.0.0', port=port)
