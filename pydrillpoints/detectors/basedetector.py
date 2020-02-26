class BaseDetector:
    def __init__(self, filename):

        self.head_coords = None # (1,1)
        self.femur_coords = None # (1,1)

        self.filename = filename
        self.finished_img = None
        self.parse_image()

    def get_image(self):
        return self.finished_img

    def parse_image(self):
        pass
