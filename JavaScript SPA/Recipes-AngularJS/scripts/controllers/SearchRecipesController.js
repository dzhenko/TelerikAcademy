'use strict';

recipesApp.controller('SearchRecipesController', function SearchRecipesController($scope, $routeParams, dataFetcher) {
    dataFetcher.getRecipes.byPartOfName($routeParams.searchText).then(function(data){
        $scope.information = '. . . searching';

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
