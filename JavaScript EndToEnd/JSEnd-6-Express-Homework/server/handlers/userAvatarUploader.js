module.exports = {
	upload : function(req, res, next) {
		var fstream;
		req.pipe(req.busboy);

		var user = {};

		req.busboy.on('file', function (fieldname, file, filename) {
			fstream = fs.createWriteStream(__dirname + '/../avatars/' + filename);
			file.pipe(fstream);
			user.avatar = filename;
		});

		req.busboy.on('field', function(fieldname, val, fieldnameTruncated, valTruncated) {
			user[fieldname] = val;
		});

		req.busboy.on('finish', function() {
			next();
		});
	}
}