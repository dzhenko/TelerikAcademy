'use strict';

recipesApp.controller('HomeController', function HomeController($scope, dataFetcher) {
    dataFetcher.getRecipes.all().then(function (data) {
        $scope.$apply(function () {
            $scope.recipesCount = data.length;
        });
    });

    $scope.welcome = 'Welcome to our recipes site';
    $scope.joke = 'Give us your comments (or money)';
    $scope.imgSrc = 'http://www-tc.pbs.org/food/wp-content/blogs.dir/2/files/2012/12/Year-in-Food-2012-Recipes-Feat-602x338.jpg';
});
