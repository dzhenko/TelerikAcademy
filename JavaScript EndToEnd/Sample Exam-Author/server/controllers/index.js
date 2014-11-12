var UsersController = require('./UsersController'),
    ProfileController= require('./ProfileController'),
    EventsController = require('./EventsController'),
    HomeController = require('./HomeController');

module.exports = {
    users: UsersController,
    profile: ProfileController,
    events: EventsController,
    home : HomeController
};