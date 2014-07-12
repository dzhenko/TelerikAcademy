'use strict';

recipesApp.controller('SingleRecipeController', function SingleRecipeController($scope, $routeParams, dataFetcher) {
    dataFetcher.getRecipes.byId($routeParams.id).then(function(data){
        $scope.$apply(function () {
            $scope.recipe = data;
        });
    });
});
