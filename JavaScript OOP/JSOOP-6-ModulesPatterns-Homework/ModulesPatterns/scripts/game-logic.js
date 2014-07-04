var snakeGame = snakeGame || {};
snakeGame.GameLogic = function () {
    'use strict';

    // private
    var i,
        isInRangeOfObject,
        checkIfAppleIsOnObsticle,
        checkIfSnakeHitsObsticles,
        checkIfSnakeEatsApple;

    // public
    checkIfAppleIsOnObsticle = function (apple, allObsticles) {
        var appleCoordinates,
            appleSize,
            obsticles;

        appleCoordinates = apple.getCoordinates();
        appleSize = apple.getAppleSize();

        obsticles = allObsticles.getObsticles();

        for (i = 0; i < obsticles.length; i += 1) {
            if (isInRangeOfObject(appleCoordinates.x, appleCoordinates.y,
                    obsticles[i].x, obsticles[i].y, appleSize)) {
                return true;
            }
        }

        return false;
    };

    checkIfSnakeHitsObsticles = function (allObsticles, newSnakeElement) {
        var obsticles = allObsticles.getObsticles();

        for (i = 0; i < obsticles.length; i += 1) {
            if (obsticles[i].x === newSnakeElement.x && obsticles[i].y === newSnakeElement.y) {
                return true;
            }
        }

        return false;
    };

    checkIfSnakeEatsApple = function (apple, newSnakeElement) {
        var appleCoordinates,
            answer;

        appleCoordinates = apple.getCoordinates();
        answer = newSnakeElement.x === appleCoordinates.x && newSnakeElement.y === appleCoordinates.y;
        return answer;
    };

    isInRangeOfObject = function (sourceX, sourceY, targetX, targetY, radius) {
        return ((sourceX === targetX - radius || sourceX === targetX || sourceX === targetX + radius) &&
                (sourceY === targetY - radius || sourceY === targetY || sourceY === targetY + radius));
    };

    return {
        checkIfAppleIsOnObsticle: checkIfAppleIsOnObsticle,
        checkIfSnakeHitsObsticles: checkIfSnakeHitsObsticles,
        checkIfSnakeEatsApple: checkIfSnakeEatsApple
    };
};