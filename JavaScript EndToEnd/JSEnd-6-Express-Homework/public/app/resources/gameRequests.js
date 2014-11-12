app.factory('GameRequests', function($q, $http, $resource, UsersResource) {
    'use strict';

    function makeRequest(url, data) {
        data = data || {};
        var deferred = $q.defer();

        $http.post(url, data).success(function(response) {
            if (response.success) {
                deferred.resolve(response);
            }
            else {
                deferred.resolve(false);
            }
        });

        return deferred.promise;
    }

    function getRequest(url) {
        var deferred = $q.defer();

        $http.get(url).success(function(response) {
            if (response.success) {
                deferred.resolve(response);
            }
            else {
                deferred.resolve(false);
            }
        });

        return deferred.promise;
    }

    return {
        scanUser: function(targetID) {
            return getRequest('/api/users-scan/' + targetID);
        },
        createTask: function (taskType, taskIndexToAddTo) {
            return makeRequest('/api/game-tasks', {
                taskType : taskType,
                taskIndexToAddTo: taskIndexToAddTo
            });
        },
        getAllUsers: function() {
            var deferred = $q.defer();

            UsersResource.query().$promise.then(function(users) {
                if (!users) {
                    deferred.reject('No such user exists');
                }
                deferred.resolve(users);
            });

            return deferred.promise;
        },
        getUserReports: function() {
            return getRequest('/api/game-reports');
        },
        getUserMessages: function() {
            return getRequest('/api/game-messages');
        },
        createMessage: function(targetID, textToSend) {
            return makeRequest('/api/game-messages', {
                targetID: targetID.target,
                textToSend : textToSend
            });
        },
        createAttack: function(targetID, ships, turns) {
            return makeRequest('/api/game-attack/' + targetID, {
                ships : ships,
                turns: turns
            });
        },
        simulateAttack: function(attacker, defender, turns) {
            return makeRequest('/api/game-attack-simulate', {
                attacker : attacker,
                turns: turns,
                defender: defender
            });
        },
        findUserIdByCoords: function(coords) {
            var deferred = $q.defer();

            UsersResource.query().$promise.then(function(users) {
                if (!users) {
                    console.log('no users found error');
                }

                for (var i = 0; i < users.length; i++) {
                    var targetCoords = users[i].coordinates;
                    if (targetCoords[0] == coords[0] && targetCoords[1] == coords[1] && targetCoords[2] == coords[2]) {
                        deferred.resolve(users[i]._id);
                    }
                }

                deferred.reject('No such user exists');
            });

            return deferred.promise;
        },
        findUserIdByUsername: function(username) {
            var deferred = $q.defer();

            UsersResource.query().$promise.then(function(users) {
                if (!users) {
                    console.log('no users found error');
                }

                for (var i = 0; i < users.length; i++) {
                    if (username == users[i].username) {
                        deferred.resolve(users[i]._id);
                    }
                }

                deferred.reject('No such user exists');
            });

            return deferred.promise;
        },
        getUserObjects: function() {
            return $resource('/api/game-objects').get();
        }
    }
});