var mongoose = require('mongoose'),
    encryption = require('../../utilities/encryption'),
    systemConstants = require('../../config/systemConstants');

module.exports.init = function() {
    var userSchema = mongoose.Schema({
        username: { type: String, require: '{PATH} is required', unique: true },
        salt: String,
        hashPass: String,
        points: { type: Number, default: 0 },
        initiatives: [{ type: String, enum: systemConstants.initiativesTypes }],
        seasons: [{ type: String, enum: systemConstants.seasonsTypes }],
        firstName: { type: String, required: true },
        lastName: { type: String, required: true },
        email: { type: String, required: true },
        phone: String,
        profileFacebook: String,
        profileTwitter: String,
        profileLinkedIn: String,
        profileGoogle: String
    });

    // validate username length in the db
    userSchema.path('username').validate(function(username) {
        var success = true;
        if (!username) {
            success = false;
        }
        else if (username.length < 6 || username.length > 20) {
            success = false;
        }
        else {
            var validSymbols = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_ .';
            for (var i = 0; i < username.length; i++) {
                if (validSymbols.indexOf(username[i]) < 0) {
                    success = false;
                    break;
                }
            }
        }
        return success;
    }, 'Username must be between 6 and 20 characters and can only contain Latin letters, digits and the symbols "_" (underscore), " " (space) and "." (dot)');

    userSchema.method({
        authenticate: function(password) {
            return encryption.generateHashedPassword(this.salt, password) === this.hashPass;
        }
    });

    var User = mongoose.model('User', userSchema);
};


