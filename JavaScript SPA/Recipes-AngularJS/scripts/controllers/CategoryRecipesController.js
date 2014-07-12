'use strict';

recipesApp.controller('CategoryRecipesController', function CategoryRecipesController($scope, $routeParams, dataFetcher) {
    $scope.name = $routeParams.categoryName;
    $scope.information = '. . . loading';

    dataFetcher.getRecipes.byCategoryName($routeParams.categoryName).then(function(data){
        $scope.$apply(function () {
            $scope.foundRecipes = data;
            if(data.length === 0) {
                $scope.information = 'None';
            }
            else {
                $scope.information = data.length;
            }
        });
    });
});
