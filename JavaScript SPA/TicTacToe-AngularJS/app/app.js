'use strict';

var app = angular.module("TicTacToeApp", ["ngRoute", "ngCookies"])
    .config(function($routeProvider, $sceDelegateProvider){
        // allows getting data from all urls - useful when getting REST services from some Cloud
        // kinda like CORS in WebApi 2 :)
        $sceDelegateProvider.resourceUrlWhitelist([
            'self',
            '*'
        ]);

        $routeProvider
            .when('/register', {
                templateUrl: 'app/views/partials/register.html',
                controller: 'RegisterCtrl'
            })
            .when('/home', {
                templateUrl: 'app/views/partials/home.html',
                controller: 'HomeCtrl'
            })
            .when('/players', {
                templateUrl: 'app/views/partials/players.html',
                controller: 'PlayersCtrl'
            })
            .when('/play-game/:id', {
                templateUrl: 'app/views/partials/play-game.html',
                controller: 'PlayGameCtrl'
            })
            .otherwise({redirectTo: '/register'})
    })
    // the default error handling is set here
    .constant('errorHandler', function(error) {console.log(error)})
    // change this to work with your host
    .constant('rootUrl', 'http://localhost:33257/');

// when a user changes a route, before the new route is invoked (as well as its controller and partial)
// the identity service will cancel the route change and invoke the initial (/register) route
app.run(function($rootScope, $location, identity) {
    $rootScope.$on('$locationChangeStart', function(ev, current, previous, rejection) {
        if (!identity.isAuthenticated()) {
            $location.path('/register');
        }
    });
});