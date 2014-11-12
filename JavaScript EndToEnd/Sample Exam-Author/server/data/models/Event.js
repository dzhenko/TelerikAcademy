var mongoose = require('mongoose'),
    systemConstants = require('../../config/systemConstants');

module.exports.init = function() {
    var eventSchema = mongoose.Schema({
        title : {type: String, required: true },
        description : {type: String, required: true },
        date: {type: Date, required: true},
        location : {
            latitude: String,
            longitude: String
        },
        category: { type: String, enum: systemConstants.eventCategories, required: true },
        type : {
            initiatives : [{ type: String, enum: systemConstants.initiativesTypes }],
            seasons: [{ type: String, enum: systemConstants.seasonsTypes }]
        },
        creatorName : { type: String, required: true },
        creatorPhone : { type: String, required: true },
        participants: [String],
        comments : [String],
        organization: Number,
        venue: Number
    });

    var Event = mongoose.model('Event', eventSchema);
};