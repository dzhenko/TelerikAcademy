'use strict';

var app = angular.module('myApp', ['ngRoute', 'ngResource', 'ngCookies', 'ngSanitize']).
    config(['$routeProvider', function($routeProvider) {
        var authenticatedCheck = {
            authenticate: function (auth) {
                return auth.isAuthenticated();
            }};

        $routeProvider
            .when('/trips', {
                templateUrl: 'views/partials/trips.html',
                controller: 'TripsCtrl'
            })
            .when('/trips/create', {
                templateUrl: 'views/partials/trip-create.html',
                controller: 'TripCreateCtrl',
                resolve: authenticatedCheck
            })
            .when('/trips/:id', {
                templateUrl: 'views/partials/trip-details.html',
                controller: 'TripDetailsCtrl',
                resolve: authenticatedCheck
            })
            .when('/drivers', {
                templateUrl: 'views/partials/drivers.html',
                controller: 'DriversCtrl'
            })
            .when('/drivers/:id', {
                templateUrl: 'views/partials/driver-details.html',
                controller: 'DriverDetailsCtrl',
                resolve: authenticatedCheck
            })
            .when('/register', {
                templateUrl: 'views/partials/register.html',
                controller: 'RegisterCtrl'
            })
            .when('/unauthorized', {
                templateUrl: 'views/partials/unauthorized.html'
            })
            .when('/', {
                templateUrl: 'views/partials/home.html',
                controller: 'HomeCtrl'
            })
            .otherwise({ redirectTo: '/' });
    }])
    .value('toastr', toastr)
    // default error handling for the app
    .value('errorHandler', function(error){
        if (error.message) {
            toastr.error(error.message)
        }
    })
    .constant('baseServiceUrl', 'http://spa2014.bgcoder.com');

app.run(function($rootScope, $location) {
    $rootScope.$on('$routeChangeError', function(ev, current, previous, rejection) {
        // uses the returned rejected promise with 'not authorized' data from auth service
        if (rejection === 'not authorized') {
            $location.path('/unauthorized');
        }
    })
});