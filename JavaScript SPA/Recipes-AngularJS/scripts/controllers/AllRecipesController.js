'use strict';

recipesApp.controller('AllRecipesController', function AllRecipesController($scope, dataFetcher) {
    dataFetcher.getRecipes.all().then(function(data){
        $scope.$apply(function () {
            $scope.recipes = data;
            $scope.information = data.length + " recipes";
        });
    });

    $scope.information = ". . . loading";

    $scope.sortBy = 'Id';
    $scope.sortTypeText = 'Ascending';
    $scope.sortByReverse = false;

    $scope.sortTypeClicked = function() {
        if ($scope.sortTypeText === 'Ascending') {
            $scope.sortTypeText = 'Descending';
        }
        else {
            $scope.sortTypeText = 'Ascending';
        }
        $scope.sortByReverse = !$scope.sortByReverse;
    }
});
