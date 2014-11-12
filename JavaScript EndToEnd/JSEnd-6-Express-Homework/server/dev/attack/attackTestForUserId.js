'use strict';

var mongoose = require('mongoose'),
    attack = require('../../handlers/attacksHandler');

function setUsersWithStats() {
    mongoose.model('User').find({}).exec(function (err, allUsers) {
        if (err) {
            console.log(err);
        }

        var user1Id = allUsers[0]._id;
        var user2Id = allUsers[1]._id;

        mongoose.model('GameObjects').findOne({owner: user1Id}).exec(function (err, obj) {
            if (err) {
                console.log(err);
            }

            obj.ships = [20, 20, 20, 120];
            obj.troops = [0, 0, 0];
            obj.buildings = [8, 8, 19, 18, 8, 8, 8];
            obj.upgrades = [1, 0, 2, 0, 3, 0, 4, 7, 7, 7, 0, 1, 1];
            obj.minerals = 400000;
            obj.gas = 200000;
            obj.attacks=[];
            obj.defences = [];

            obj.save(function () {
                console.log('-------------------------------');
                console.log('saved ships for player ID ' + user1Id);
                console.log(obj);
                console.log('-------------------------------');
            })
        });

        mongoose.model('GameObjects').findOne({owner: user2Id}).exec(function (err, obj) {
            if (err) {
                console.log(err);
            }

            obj.ships = [10,10,10,10];
            obj.troops = [30,30,30];
            obj.buildings = [8, 8, 19, 18, 8, 8, 8];
            obj.upgrades = [1, 0, 2, 0, 3, 0, 4, 7, 7, 7, 0, 1, 1];
            obj.minerals = 400000;
            obj.gas = 200000;
            obj.attacks=[];
            obj.defences = [];

            obj.save(function () {
                console.log('-------------------------------');
                console.log('saved ships and troops for player ID ' + user2Id);
                console.log(obj);
                console.log('-------------------------------');
            })
        });
    });
}

function testHandleAttackFromAttackerObjectToUserId() {
    mongoose.model('User').find({}).exec(function (err, allUsers) {
        if (err) {
            console.log(err);
        }

        var user1Id = allUsers[0]._id;
        var user2Id = allUsers[1]._id;

        mongoose.model('GameObjects').findOne({owner: user1Id}).exec(function (err, obj) {
            if (err) {
                console.log(err);
            }
            console.log('attacker ' + obj);
            attack.handleAttackForTargetId({
                source: user1Id,
                ships: obj.ships,
                airUpgrades: [obj.upgrades[7], obj.upgrades[8], obj.upgrades[9]]
            }, user2Id, 15, 200);
        });
    });
}

function testHandleAttackSimulator() {
    console.dir(attack.handleAttack(
        {
            ships: [13, 44, 13, 5],
            airUpgrades: [3, 4, 5]
        },
        {
            troops: [17, 22, 8],
            groundUpgrades: [4, 5, 7],
            ships: [5, 14, 3, 1],
            airUpgrades: [5, 5 , 5]
        },
        15
    ))
}

module.exports = {
    simulator: testHandleAttackSimulator,
    setUsersWithStats: setUsersWithStats,
    testHandleAttackFromAttackerObjectToUserId: testHandleAttackFromAttackerObjectToUserId,
    testAttackDispatcherNotifierAfterUsersAreSetWithStats: function () {
        require('../../controllers/gameAttacksController').createAttack({
            params: {
                owner: '53e7777a9efe98ec111e22c7',
                targetID: '53e777fd9efe98ec111e22c9',
                ships: [12, 23, 31, 6],
                turns: 12
            }
        }, {
            send: function (stuff) {
                console.log(stuff);
            }
        })
    }
};