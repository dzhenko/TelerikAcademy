var auth = require('./auth'),
    controllers = require('../controllers');

module.exports = function(app) {
    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);

    app.get('/login', controllers.users.getLogin);
    app.post('/login', auth.login);
    app.get('/logout', auth.isAuthenticated, auth.logout);

    app.get('/', controllers.home.getHome);

    app.get('/create-event', auth.isAuthenticated, controllers.events.getCreateEvent);
    app.post('/create-event', auth.isAuthenticated, controllers.events.postCreateEvent);

    app.get('/join-event/:id', auth.isAuthenticated, controllers.events.joinEvent);
    app.get('/leave-event/:id', auth.isAuthenticated, controllers.events.leaveEvent);

    app.get('/event/:id', auth.isAuthenticated, controllers.events.getEventDetails);

    app.get('/list-events/:category', auth.isAuthenticated, controllers.events.getListEvents);

    app.get('/profile', auth.isAuthenticated, controllers.profile.getProfile);
    app.post('/profile', auth.isAuthenticated, controllers.profile.postProfile);

    app.get('/profile-events-created', auth.isAuthenticated, controllers.profile.getCreatedEvents);
    app.get('/profile-events-joined', auth.isAuthenticated, controllers.profile.getJoinedEvents);
    app.get('/profile-events-joined', auth.isAuthenticated, controllers.profile.getPastEvents);

    app.post('/api/leave-comment', auth.isAuthenticated, controllers.events.createComment);

    app.get('*', function(req, res) {
        res.redirect('/');
    });
};