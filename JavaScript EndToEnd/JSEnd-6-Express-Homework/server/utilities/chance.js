'use strict';
module.exports = {
    doubleHealth: function(percentToOccur) {
        if (Math.random()*100 < percentToOccur) {
            return 2;
        }
        else {
            return 1;
        }
    }
};