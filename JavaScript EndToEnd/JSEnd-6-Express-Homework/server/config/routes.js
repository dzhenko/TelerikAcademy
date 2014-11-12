'use strict';

var auth = require('./auth'),
    controllers = require('../controllers');

module.exports = function(app) {
    app.get('/api/users', auth.isAuthenticated, controllers.users.getAllUsers);
    app.post('/api/users', controllers.users.createUser);
    app.put('/api/users', auth.isAuthenticated, controllers.users.updateUser);

    app.get('/api/users-scan/:target', auth.isAuthenticated, controllers.users.scanUser);

    app.get('/api/game-objects', auth.isAuthenticated, controllers.gameObjects.getGameObjectsForUserId);

    app.post('/api/game-tasks', auth.isAuthenticated, controllers.gameTasks.createTask);

    app.post('/api/game-attack/:target', auth.isAuthenticated, controllers.gameAttacks.createAttack);
    app.post('/api/game-attack-simulate', auth.isAuthenticated, controllers.gameAttacks.simulateAttack);

    app.get('/api/game-reports', auth.isAuthenticated, controllers.gameReports.getAll);

    app.get('/api/game-messages', auth.isAuthenticated, controllers.gameMessages.getAll);
    app.post('/api/game-messages', auth.isAuthenticated, controllers.gameMessages.createMessage);

    app.get('/partials/:partialArea/:partialName', function (req, res) {
        res.render('../../public/app/' + req.params.partialArea+ '/' + req.params.partialName);
    });

    app.post('/login', auth.login);
    app.post('/logout', auth.logout);

    // any other api request is forbidden
    app.get('/api/*', function(req, res) {
        res.render('index');
        res.status(404);
        res.end();
    });

    app.get('*', function (req, res) {
        res.render('index', {currentUser: req.user});
    });
};