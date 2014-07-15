'use strict';

recipesApp.controller('AddCategoryController', function AddCategoryController($scope, $location, dataFetcher) {
    dataFetcher.getCategories.all().then(function(data){
        $scope.$apply(function () {
            $scope.categories = data;
        });
    });

    $scope.saveCategory = function(category, invalidForm) {
        if (invalidForm) {
            alert('Invalid category info!');
            return;
        }

        // check existing
        for (var i = 0; i < $scope.categories.length; i++) {
            var o = $scope.categories[i];
            if (o.Name === category.Name) {
                alert('Category already exists!');
                return;
            }
        }

        dataFetcher.create.category(category, function() {
            alert('Category successfully created!');
        }, function() {
            alert('Error - try again later!');
        });

        $location.path("/home" );
    };

    $scope.cancelEdit = function() {
        $location.path("/home" );
    }
});
