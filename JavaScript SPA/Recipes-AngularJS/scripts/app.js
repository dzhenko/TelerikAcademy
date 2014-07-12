'use strict';

var recipesApp = angular
    .module('recipesApp', ['ngRoute'])
    .config(function($routeProvider){
        $routeProvider
            .when('/home', {
                templateUrl: 'templates/home.html'
            })
            .when('/all-recipes', {
                templateUrl: 'templates/all-recipes.html'
            })
            .when('/all-categories', {
                templateUrl: 'templates/all-categories.html'
            })
            .when('/category-recipes/:categoryName', {
                templateUrl: 'templates/category-recipes.html'
            })
            .when('/single-recipe/:id', {
                templateUrl: 'templates/single-recipe.html'
            })
            .when('/search-recipes/:searchText', {
                templateUrl: 'templates/search-recipes.html'
            })
            .when('/add-recipe', {
                templateUrl: 'templates/add-recipe.html'
            })
            .when('/add-category', {
                templateUrl: 'templates/add-category.html'
            })
            .otherwise({redirectTo: '/home'});
    });
