'use strict';
var mongoose = require('mongoose');

var messageSchema = mongoose.Schema({
    owner: { type: mongoose.Schema.ObjectId, ref: 'User' },
    fromID : { type: mongoose.Schema.ObjectId, ref: 'User' },
    from: String,
    created: { type : Number, default: (new Date()).getTime() },
    text: String
});

var Message = mongoose.model('Message', messageSchema);

// For development
module.exports = {
    removeAll: function () {
        Message.remove({}).exec(function (err) {
            if (err) {
                console.log('Can not delete game objects ' + err);
            }
            else {
                console.log('All Messages deleted successfully');
            }
        })
    },
    showAll: function () {
        Message.find({}).exec(function (err, objects) {
            if (err) {
                console.log('Can not get Messages ' + err);
            }

            else {
                console.log('----------------------------------------');
                console.log('All Messages :');
                console.log(objects);
            }
        })
    }
};
