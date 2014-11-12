'use strict';

var tasksHandler = require('../../handlers/userTasksCreatorHandler'),
    usedResources = require('../../utilities/usedResources');

function showUser(userObjects) {
    console.log('User objects:');
    console.log(JSON.stringify(userObjects));
}

module.exports = {
    run: function() {
        console.log('Tests for tasks handler started:');

        var userObjects = {
            minerals: 500000,
            gas: 500000,
            tasks: [
                {
                    type: 'ships',
                    indexToAddTo: 3
                }
            ],
            // mineral gas energy supply troops ships lab - only indexes
            buildings: [1, 1, 9, 9, 9, 1, 1],
            // transport tier 1 tier 2 tier 3
            ships: [3, 3, 3, 3],
            // tier 1 tier 2 tier 3
            troops: [1, 2, 3],
            upgrades: [1, 2, 3, 3, 3, 3, 3, 3, 3, 9, 9, 9, 2],
            attacks: [
                {
                    ships: [1, 2, 3, 4]
                },
                {
                    ships: [2, 3, 4, 5]
                }
            ],
            comebacks: [
                {
                    ships: [5, 5, 1, 1]
                }
            ]
        };
        console.log('Original user objects:');
        showUser(userObjects);
        console.log('--------------------------------');

        tasksHandler.createTask(userObjects, 'buildings', 5);
        console.log('Expected: new task to be added');
        showUser(userObjects);
        console.log('--------------------------------');

        console.log('Tests for units supply counter started:');
        console.log(usedResources.usedSupply(userObjects) + ' -> Expected: 174');
        console.log('--------------------------------');


        console.log('Tests for consumed power started:');
        console.log(usedResources.usedEnergy(userObjects) + ' -> Expected: 500');
        console.log('--------------------------------');
    }
};