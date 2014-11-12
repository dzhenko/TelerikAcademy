"use strict";

var http = require('http'),
	util = require('util'),
	formidable = require('formidable'),
	fs = require('fs'),
	uuid = require('node-uuid');

var port = 9999;
var	uploadDir = "../uploads";

function findExtention(str) {
	var indexOfExtention = str.indexOf('.');
	if (indexOfExtention) {
		return str.substring(indexOfExtention);
	}
	else {
		throw new Error('Invalid file');
	}
}

var server = http.createServer(function (req, res) {
	if (req.url === '/') {
		fs.readFile('../html/index.html', function (err, data) {
			if (err) {
				console.log(err);
			}
			res.end(data);
		});
	}

	if (req.url === '/uploads' && req.method.toLowerCase() === 'post') {
		var uploadedFiles = [],
			form = new formidable.IncomingForm();

		form.uploadDir = uploadDir;
		form.multiples = true;
		form.keepExtensions = true;

		if (!fs.existsSync(uploadDir)) {
			fs.mkdirSync(uploadDir);
		}

		// Rename the file whit GUID
		form.on('fileBegin', function (name, file) {
			var fileName = form.uploadDir + "/" + uuid.v4() + findExtention(file.name);
			uploadedFiles.push(fileName);
			file.path = fileName;
		});

		form.parse(req, function (err, fields, photos) {
			if (err) {
				console.log(err);
			} else {
				res.writeHead(200, {'content-type': 'text/text'});
				var fileName;
				for (var x = 0; x < uploadedFiles.length; x++) {
					fileName = uploadedFiles[x].substring(uploadDir.length+1);
					x === uploadedFiles.length - 1 ? res.write(fileName) : res.write(fileName + '[|]');
				}
				res.end();
			}
		});

		return;
	}

	// Parsing the static request on local.../getImage/
	if (req.url.substr(0, 10) === '/getImage/') {
		fs.readFile('../uploads/'+req.url.substring(10), function (err, image) {
			if (err) {
				console.log(err);
			}
			res.writeHead(200, {'content-type': 'image/png'})
			res.end(image, 'binary');
		});
	}

	if (req.url === '/scripts/file-sender.js') {
		fs.readFile('../scripts/file-sender.js', function (err, data) {
			if (err) {
				console.log(err);
			}
			res.writeHead(200, {'Content-type': 'text/javascript'});
			res.end(data);
		});
	}
});

server.listen(port);
console.log("The server is up and running @ http://localhost:" + port);