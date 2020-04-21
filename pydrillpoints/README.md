# Xray drill point detection

Display an xray image with the drill points marked on it.

## Installation

Clone the github repository, and install the required pip packages by running the following:

`pip install -r requirements.txt`

## Usage

This application can be used via a CLI as well as an HTTP API.

The command line version is useful for testing and rapid development of new detection algorithms.

To run it via the command line, run the following command to get the help page:

`python cli.py --help`

To detect an example image, run the following command:

`python cli.py --filename 1.jpg`

Additionally, there is a work-in-progress demo showing a detector which is able to draw a guideline when the user manually selects a point near the center of the hip head. It can be run using:

`python demo.py`

## API

The HTTP API can be started by running:

`python api.py`

This will start the API at http://0.0.0.0:5000

## Docker

The HTTP API can also be deployed using docker:

`docker image build -t pydrillpoints:1.0 . --network=host`

`docker container run --publish 5000:5000 --detach --name pydp pydrillpoints:1.0`

Further information will be added later.

# API Documentation

API documentation can also be found here:
https://app.swaggerhub.com/apis-docs/l258/test/1.0.0

### /detectors

#### GET
##### Summary:

List available detectors

##### Description:

List out the names of various detectors that can be used

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | list showing available detectors |

### /images

#### GET
##### Summary:

List available images

##### Description:

List out the filenames of available xray images

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | list showing available image filenames |

### /image/[detector]/[filename]

#### GET
##### Summary:

Get xray image with xray drill points marked

##### Description:

Returns an image in PNG format with te xray drill points marked


##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| detector | path | Name of detector | Yes | string |
| image | path | Filename of image | Yes | string |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | PNG image with drill points marked |
| 400 | Invalid parameters specified |

### /coords/[detector]/[filename]

#### GET
##### Summary:

Get co-ordinates of head and femur of xray

##### Description:

Returns JSON data containing the x and y co-ordinates for the head and femur


##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| detector | path | Name of detector | Yes | string |
| image | path | Filename of image | Yes | string |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | JSON data |
| 400 | Invalid parameters specified |

