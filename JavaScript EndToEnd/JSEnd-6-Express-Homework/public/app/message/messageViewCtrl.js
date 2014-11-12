app.controller('MessageViewCtrl', function ($scope, GameRequests, identity) {
    'use strict';

    var currentMessages = JSON.parse(localStorage.getItem('novcraft-userobjects-usermessages-'+identity.currentUser._id)) || [];

    GameRequests.getUserMessages().then(function (responce) {
        var newMessages = currentMessages.concat(responce.allMessages);
        localStorage.setItem('novcraft-userobjects-usermessages-'+identity.currentUser._id, JSON.stringify(newMessages));

        $scope.allMessages = newMessages;

    }, function (error) {
        console.log(error);
    });

    $scope.deleteMessage = function(index) {
        $scope.allMessages.splice(index,1);
        localStorage.setItem('novcraft-userobjects-usermessages-'+identity.currentUser._id, JSON.stringify($scope.allMessages));
    };

    $scope.viewMessage = function (index) {
        $scope.selectedMessage = $scope.allMessages[$scope.allMessages.length - index - 1];
    }
});