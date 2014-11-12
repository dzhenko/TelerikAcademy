'use strict';

var GameObjects = require('mongoose').model('GameObjects'),
    userObjectsHandler = require('../handlers/userObjectsHandler'),
    userTasksCreatorHandler = require('../handlers/userTasksCreatorHandler');

module.exports = {
    // needs post with these two params req.body.taskType, req.body.taskIndexToAddTo
    createTask : function(req, res, next) {
        GameObjects.findOne({owner: req.user._id}).exec(function(err, userGameObjects) {
            if (err) {
                console.log('Game objects could not be loaded ' + err);
                return;
            }

            if (!userGameObjects) {
                console.log('Un-existing user required his game objects');
                res.status(404);
                res.end();
                return;
            }

            // sync call
            userObjectsHandler.refreshUserGameObjects(userGameObjects);

            // sync call
            var success = userTasksCreatorHandler.createTask(userGameObjects, req.body.taskType, req.body.taskIndexToAddTo);

            userGameObjects.save(function(){
                res.send({
                    userGameObjects : userGameObjects,
                    success : success
                });
            });
        })
    }
};