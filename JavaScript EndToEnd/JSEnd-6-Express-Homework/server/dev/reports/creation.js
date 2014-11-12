'use strict';

var Report = require('mongoose').model('Report'),
    attack = require('../../handlers/attacksHandler');

module.exports = {
    run: function() {
        for (var i = 0; i < 33; i++) {
            var report = attack.handleAttack(
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
            );

            report.owner = '53e7777a9efe98ec111e22c7';
            report.stolen = [i*200, i*100];
            report.enemyID = '53e777fd9efe98ec111e22c9';
            report.enemy = [ 230, 87, 312 ];

            Report.create(report, function (err, report) {
                if (err) {
                    console.log('Failed to create new report ' + err);
                }
            })
        }
    }
};