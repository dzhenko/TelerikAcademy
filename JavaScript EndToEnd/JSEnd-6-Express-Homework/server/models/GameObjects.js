'use strict';

var mongoose = require('mongoose');

var gameObjectsSchema = mongoose.Schema({
    owner: { type: mongoose.Schema.ObjectId, ref: 'User' },
    coordinates: [Number],
    minerals: Number,
    gas: Number,
    updated: Number,
    tasks: [
        {
            time: Number,
            type: { type: String, enum: ['buildings', 'ships', 'troops', 'upgrades'] },
            indexToAddTo: Number,
            created: { type : Number, default: (new Date()).getTime() }
        }
    ],
    // mineral gas energy supply troops ships lab - only indexes
    buildings: [Number],
    // transport tier 1 tier 2 tier 3
    ships: [Number],
    // tier 1 tier 2 tier 3
    troops: [Number],
    upgrades: [Number],
    attacks: [
        {
            // player ID
            target: { type: mongoose.Schema.ObjectId, ref: 'User' },
            // time of hit
            time: Number,
            // attacker's transport tier1 tier2 tier3 ships
            ships: [Number],
            // number of cycles to attack
            turns : Number,
            created: { type : Number, default: (new Date()).getTime() }
        }
    ],
    comebacks: [
        {
            // time of land home
            time: Number,
            // attacker's transport tier1 tier2 tier3 ships
            ships: [Number],
            // outcome of the battle may result in resources for the attacker
            cargo: [Number],
            created: { type : Number, default: (new Date()).getTime() }
        }
    ],
    defences: [
        {
            sourceID: { type: mongoose.Schema.ObjectId, ref: 'User' },
            // player coordinates
            source: [Number],
            // time of attack home
            time: Number,
            created: { type : Number, default: (new Date()).getTime() }
        }
    ]
});

var GameObjects = mongoose.model('GameObjects', gameObjectsSchema);

// For development
module.exports = {
    removeAll: function () {
        GameObjects.remove({}).exec(function (err) {
            if (err) {
                console.log('Can not delete game objects ' + err);
            }
            else {
                console.log('All Game Objects deleted successfully');
            }
        })
    },
    showAll: function () { // TODO: Remove after development
        GameObjects.find({}).exec(function (err, objects) {
            if (err) {
                console.log('Can not get game objects resources ' + err);
            }
            else {
                console.log('----------------------------------------');
                console.log('All Game Objects :');
                console.log(objects);
            }
        })
    }
};
