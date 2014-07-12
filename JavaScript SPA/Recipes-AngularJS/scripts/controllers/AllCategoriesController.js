'use strict';

recipesApp.controller('AllCategoriesController', function AllCategoriesController($scope, dataFetcher) {
    dataFetcher.getCategories.all().then(function (data) {
        $scope.$apply(function () {
            $scope.foundCategories = data;
        });
    });
});
