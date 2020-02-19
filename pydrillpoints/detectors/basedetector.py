class BaseDetector:
    def __init__(self, filename):
        self.filename = filename
        self.finished_img = None
        self.parse_image()

    def get_image(self):
        return self.finished_img

    def parse_image(self):
        pass
