var fs = require('fs');
var PICTURES_PATH = __dirname + '/../../public/';
var PICTURES_DIR = 'profilePictures/';

var defaultFileType = 'jpg';

module.exports = {
    saveUserPicture: function(file, username) {
        file.pipe(fs.createWriteStream(PICTURES_PATH + PICTURES_DIR + username + '.' + defaultFileType));
    },
    handleNoUserPicture: function(file, fileType, userData) {
        file.on('data', function(chunk) {
            // simulates reading of empty file
        });
    },
    getPathToUserPicture: function(username) {
        if (fs.existsSync(PICTURES_PATH + PICTURES_DIR + username + '.' + defaultFileType)) {
            return PICTURES_DIR + username + '.' + defaultFileType;
        }
        else {
            // as username can not contain - this is always valid file name
            return PICTURES_DIR + 'default-profile-picture.jpg';
        }
    }
};