'use strict';

app.controller('MyCtrl2', ['$scope','notifier', function($scope, notifier) {
    notifier.success('Partial 2!');
    notifier.error('Partial 2');
}]);