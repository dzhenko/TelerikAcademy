'use strict';

var mongoose = require('mongoose'),
    encryption = require('../utilities/encryption');

var userSchema = mongoose.Schema({
    username: { type: String, require: '{PATH} is required', unique: true },
    firstName: { type: String, require: '{PATH} is required' },
    lastName: { type: String, require: '{PATH} is required' },
    salt: String,
    hashPass: String,
    coordinates: [Number],
    race: { type: String, enum: ['terran', 'protoss', 'zerg'] },
    roles: [String]
});

userSchema.method({
    authenticate: function (password) {
        return (encryption.generateHashedPassword(this.salt, password) === this.hashPass);
    }
});

var User = mongoose.model('User', userSchema);

module.exports = {
    // For Future :)
    addAdmins: function () {
        var salt,
            hashedPwd;

        salt = encryption.generateSalt();
        hashedPwd = encryption.generateHashedPassword(salt, 'admin');
        User.create({username: 'admin', firstName: 'Administrator', lastName: 'Pesho', salt: salt, hashPass: hashedPwd, roles: ['admin'], race: 'terran', coordinates: [0,0,0]});

        salt = encryption.generateSalt();
        hashedPwd = encryption.generateHashedPassword(salt, 'password');
        User.create({username: 'administrator', firstName: 'administrator', lastName: 'Gosho', salt: salt, hashPass: hashedPwd, roles: ['admin'], race: 'terran', coordinates: [0,0,1]});

        console.log('Added 2 admins - admin and administrator');
    },
    // For development
    removeAll: function() {
        User.remove({}).exec(function(err){
            if (err) {
                console.log('Can not delete users ' + err);
            }
            else {
                console.log('All Users deleted successfully');
            }
        })
    },
    // For development
    showAll: function() {
        User.find({}).exec(function(err, users) {
            if (err) {
                console.log('Can not delete users ' + err);
            }
            else {
                console.log('----------------------------------------');
                console.log('All Users :');
                console.log(users);
            }
        })
    }
};