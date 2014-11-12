'use strict';

var app = angular.module('myApp', ['ngRoute', 'ngResource', 'ngCookies']).
    config(['$routeProvider', function($routeProvider) {
        $routeProvider
            .when('/register', {
                templateUrl: 'views/partials/register.html',
                controller: 'RegisterCtrl'
            })
            .when('/partial1', {
                templateUrl: 'views/partials/partial1.html',
                controller: 'MyCtrl1'
            })
            .when('/partial2', {
                templateUrl: 'views/partials/partial2.html',
                controller: 'MyCtrl2'
            })
            .otherwise({ redirectTo: '/partial1' });
    }])
    .value('toastr', toastr)
    .value('errorHandler', function(error){console.warn(error)})
    .constant('baseServiceUrl', 'http://localhost:33257');

app.run(function($rootScope, $location) {
    $rootScope.$on('$routeChangeError', function(ev, current, previous, rejection) {
        if (rejection === 'not authorized') {
            $location.path('/');
        }
    })
});