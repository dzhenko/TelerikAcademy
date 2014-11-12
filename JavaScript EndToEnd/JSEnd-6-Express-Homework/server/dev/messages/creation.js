'use strict';

var Message = require('mongoose').model('Message');

module.exports = {
    run: function() {
        for (var i = 0; i < 33; i++) {
            var message = {
                owner : '53e7777a9efe98ec111e22c7',
                fromID: '53e777fd9efe98ec111e22c9',
                from : 'Pesho',
                text: 'hello message'
            };

            Message.create(message, function (err, report) {
                if (err) {
                    console.log('Failed to create new report ' + err);
                }
            })
        }
    }
};