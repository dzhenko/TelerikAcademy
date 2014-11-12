app.factory('ShipsModel', function () {
    'use strict';

    return {
        // transport tier1 tier2 tier3
        attack: [1, 15, 59, 99],
        defence: [5, 0, 10, 15],
        health: [200, 100, 300, 500],
        capacity: [15000, 500, 2000, 4000],
        minerals: [19999, 12999, 59999, 139999],
        gas: [3999, 0, 19999, 59999],
        supply: [2, 2, 3, 6],
        time: [199, 49, 299, 499]
    }
});