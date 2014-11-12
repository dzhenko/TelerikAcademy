'use strict';

// used to make requests and return promises
app.factory('appData', ['requester','baseServiceUrl', function(requester, baseServiceUrl){
    return {
        userInfo: function(authorizationToken) {
            return requester.get(baseServiceUrl + '/api/users/userInfo', authorizationToken);
        },
        stats: function() {
            return requester.get(baseServiceUrl + '/api/stats');
        },
        cities: function() {
            return requester.get(baseServiceUrl + '/api/cities');
        },
        lastTrips: function() {
            return requester.get(baseServiceUrl + '/api/trips');
        },
        createTrip: function(trip, authorizationToken) {
            return requester.post(baseServiceUrl + '/api/trips', trip, authorizationToken);
        },
        tripDetails: function(id, authorizationToken){
            return requester.get(baseServiceUrl + '/api/trips/' + id, authorizationToken);
        },
        joinTrip: function(id, authorizationToken) {
            return requester.put(baseServiceUrl + '/api/trips/' + id, {}, authorizationToken);
        },
        filterTrips: function(pageNumber, sortValue, orderValue, fromValue, toValue, includeFinished, onlyMine, authorizationToken) {
            var queryString = '?page=' + pageNumber;
            if (sortValue) {
                queryString+='&orderBy=' + sortValue;
            }
            if (orderValue) {
                queryString+='&orderType=' + orderValue;
            }
            if (fromValue) {
                queryString+='&from=' + fromValue;
            }
            if (toValue) {
                queryString+='&to=' + toValue;
            }
            if (includeFinished) {
                queryString+='&finished=true';
            }
            if (onlyMine) {
                queryString+='&onlyMine=true';
            }

            return requester.get(baseServiceUrl + '/api/trips' + queryString, authorizationToken);
        },
        lastDrivers: function() {
            return requester.get(baseServiceUrl + '/api/drivers');
        },
        filterDrivers: function(username, pageNumber, authorizationToken) {
            var queryString = '?page=' + pageNumber + '&username=' + username;
            return requester.get(baseServiceUrl + '/api/drivers' + queryString, authorizationToken);
        },
        driverDetails: function(id, authorizationToken) {
            return requester.get(baseServiceUrl + '/api/drivers/' + id, authorizationToken);
        }
    }
}]);