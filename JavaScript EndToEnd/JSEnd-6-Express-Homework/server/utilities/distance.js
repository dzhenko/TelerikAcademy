'use strict';

var timePerClick = 18000000 / 1730;
var takeOffMS = 17 * 60000;

function get3DDistance(coord1, coord2) {
    return Math.sqrt(
        ((coord1[0] - coord2[0]) * (coord1[0] - coord2[0]) +
        (coord1[1] - coord2[1]) * (coord1[1] - coord2[1]) +
        (coord1[2] - coord2[2]) * (coord1[2] - coord2[2]))
    )
}

module.exports = {
    millisecondsBetweenCoords: function(coord1, coord2) {
        return Math.round(timePerClick * get3DDistance(coord1, coord2)) + takeOffMS;
    }
};