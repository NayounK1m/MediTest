import NOCR
from flask import Flask, request, make_response
import json
from PIL import Image
from io import BytesIO
import base64
app = Flask(__name__)
app.config['JSON_AS_ASCII'] = False

@app.route("/ocr", methods=['POST'])
def nocr():
	params = request.get_data().decode("utf-8").replace("%3d", '=')
	params = base64.b64decode(params)
	img = Image.open(BytesIO(base64.b64decode(params)))
	result = NOCR.NOCR(img)
	print(result)
	result = json.dumps(result, ensure_ascii=False)
	res = make_response(result)

	return res

if __name__ == "__main__":
	app.run(debug=True, host='0.0.0.0', port=9090)