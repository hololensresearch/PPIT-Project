FROM jjanzic/docker-python3-opencv
WORKDIR /usr/src/app
COPY . .
RUN pip3 install -r requirements.txt
EXPOSE 5000
CMD python3 api.py
