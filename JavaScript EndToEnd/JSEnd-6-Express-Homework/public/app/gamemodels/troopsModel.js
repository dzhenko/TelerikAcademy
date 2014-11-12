app.factory('TroopsModel', function () {
    'use strict';

    return {
        // tier1 tier2 tier3
        attack: [6, 19, 34],
        defence: [5, 15, 30],
        health: [45, 130, 280],
        minerals: [3499, 15999, 34999],
        gas: [0, 5999, 16999],
        supply: [1, 1, 2],
        time: [139, 419, 699]
    }
});