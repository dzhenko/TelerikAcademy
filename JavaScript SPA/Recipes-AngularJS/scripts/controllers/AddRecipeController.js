'use strict';

recipesApp.controller('AddRecipeController', function AddRecipeController($scope, $compile, $location, dataFetcher) {
    dataFetcher.getCategories.all().then(function(data){
        $scope.$apply(function () {
            $scope.categories = data;
        });
    });

    var minutesArr = [];
    for (var i = 1; i <= 36; i++) {
        minutesArr.push(i*5);
    }
    $scope.minutes=minutesArr;

    $scope.products = [''];
    $scope.directions = [''];

    $scope.addProduct = function() {
        $scope.products.push('');
        angular.element('#add-recepie-input-products')
            .append( $compile('<input type="text" class="form-control" ng-model="products['+ ($scope.products.length - 1) +']"/>')($scope) );
    };

    $scope.addDirection = function() {
        $scope.directions.push('');
        angular.element('#add-recepie-input-directions')
            .append( $compile('<input type="text" class="form-control" ng-model="directions['+ ($scope.directions.length - 1) +']"/>')($scope) );
    };

    $scope.saveRecipe = function(recipe, invalidForm) {
        var i;

        if (invalidForm) {
            alert('Invalid recipe info!');
            return;
        }

        // check for empty products or steps
        for (i = 0; i < $scope.products.length; i+=1) {
            if ($scope.products[i] === '') {
                $scope.products.splice(i,1);
            }
        }
        for (i = 0; i < $scope.directions.length; i+=1) {
            if ($scope.directions[i] === '') {
                $scope.directions.splice(i,1);
            }
        }

        recipe.Products = $scope.products;
        recipe.Directions = $scope.directions;

        dataFetcher.create.recipe(recipe, function() {
            alert('Recipe successfully created!');
        }, function() {
            alert('Error - try again later!');
        });

        $location.path("/home" );
    };

    $scope.cancelEdit = function() {
        $location.path("/home" );
    }
});
