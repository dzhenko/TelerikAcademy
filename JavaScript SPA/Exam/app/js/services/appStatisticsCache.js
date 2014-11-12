'use strict';

// used to make requests and return promises
app.factory('appStatisticsCache', ['appData', '$q','errorHandler', function(appData, $q, errorHandler){
    var stats;

    return {
        stats: function() {
            var deferred = $q.defer();

            if (stats) {
                deferred.resolve(stats);
            }
            else {
                appData.stats().then(function(data){
                    stats = data;
                    deferred.resolve(stats);
                }, errorHandler);
            }

            return deferred.promise;
        }
    }
}]);