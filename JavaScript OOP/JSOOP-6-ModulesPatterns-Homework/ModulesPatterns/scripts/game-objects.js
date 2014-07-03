var snakeGame = snakeGame || {};
snakeGame.gameObjects = function () {
    'use strict';

    var Snake = function (elementSize, startX, startY) {
        // private
        var elements = [],
            direction = 'R',
            isAlive = true,
            newElement,
            lastElement,
            i,
            changeDirection,
            keyPressedHandler

        // initialization
        (function () {
            elements.push({ x: startX + elementSize * 2, y: startY });
            elements.push({ x: startX + elementSize, y: startY });
            elements.push({ x: startX + 0, y: startY });
            elements.push({ x: startX - elementSize, y: startY });
        }());

        changeDirection = function (newDirection) {
            if (newDirection === 'U') {

                if (direction !== 'D') {
                    direction = 'U';
                }
            }
            else if (newDirection === 'D') {
                if (direction !== 'U') {
                    direction = 'D';
                }
            }
            else if (newDirection === 'R') {
                if (direction !== 'L') {
                    direction = 'R';
                }
            }
            else if (newDirection === 'L') {
                if (direction !== 'R') {
                    direction = 'L';
                }
            }
        }

        // public
        keyPressedHandler = function (e) {
            switch (e.keyCode) {
                case 37: changeDirection('L'); break;       //left 
                case 38: changeDirection('U'); break;       //up
                case 39: changeDirection('R'); break;       //right
                case 40: changeDirection('D'); break;       //down 
            }
            move();
        }

        var getElements = function () {
            return elements;
        }

        var getElementSize = function () {
            return elementSize;
        }

        var getIsAlive = function () {
            return isAlive
        }

        var kill = function () {
            isAlive = false;
        }

        var grow = function () {
            elements.push(lastElement);
        }

        var move = function () {
            switch (direction) {
                case 'R': newElement = { x: elements[0].x + elementSize, y: elements[0].y }; break;
                case 'L': newElement = { x: elements[0].x - elementSize, y: elements[0].y }; break;
                case 'U': newElement = { x: elements[0].x, y: elements[0].y - elementSize }; break;
                case 'D': newElement = { x: elements[0].x, y: elements[0].y + elementSize }; break;
            }

            lastElement = elements.pop();
            elements.unshift(newElement);

            // check if I bite myself
            for (i = 1; i < elements.length; i += 1) {
                if (elements[i].x === newElement.x && elements[i].y === newElement.y) {
                    isAlive = false;
                    return;
                }
            }
        }

        var getHeadElement = function () {
            return elements[0];
        }

        return {
            getElements: getElements,
            getElementSize: getElementSize,
            grow: grow,
            getIsAlive: getIsAlive,
            kill: kill,
            move: move,
            getHeadElement: getHeadElement,
            keyPressedHandler: keyPressedHandler
        }
    }

    var Apple = function (appleSize, maxX, maxY) {
        // private
        var X = 0,
            Y = 0,
            getCoordinates,
            getAppleSize,
            refresh;

        // public
        getCoordinates = function () {
            return {
                x: X,
                y: Y,
            }
        }

        getAppleSize = function () {
            return appleSize;
        }

        refresh = function () {
            X = getNumberCloseToPixel(getRandomNumberInRange(0, maxX), appleSize);
            Y = getNumberCloseToPixel(getRandomNumberInRange(0, maxY), appleSize);
        }

        return {
            getCoordinates: getCoordinates,
            getAppleSize: getAppleSize,
            refresh: refresh
        }
    }

    var Obsticles = function (obsticleSize, maxX, maxY, ammount) {
        var obsticles = [],
            getObsticles,
            getObsticleSize;

        // build obsticle array
        (function () {
            var i,
                j,
                newX,
                newY,
                loop;

            function generateObsticle(_x, _y) {
                obsticles.push({ x: _x, y: _y });
            }

            // generating walls
            for (i = 0; i < maxX; i += obsticleSize) {
                obsticles.push({ x: i, y: 0 });
                obsticles.push({ x: i, y: maxY - obsticleSize });
            }
            for (i = 0; i < maxY; i += obsticleSize) {
                obsticles.push({ x: 0, y: i });
                obsticles.push({ x: maxX - obsticleSize, y: i });
            }

            // generate random obsticles
            for (i = 0; i < ammount; i += 1) {
                newX = getNumberCloseToPixel(getRandomNumberInRange(0, maxX), obsticleSize);
                newY = getNumberCloseToPixel(getRandomNumberInRange(0, maxY), obsticleSize);

                // checks if the obsticle is near the start of the snake
                while (newY == maxY / 2) {
                    newX = getNumberCloseToPixel(getRandomNumberInRange(0, maxX), obsticleSize);
                    newY = getNumberCloseToPixel(getRandomNumberInRange(0, maxY), obsticleSize);
                }

                //checks if the obsticle is near another obsticle
                loop = true;

                while (loop) {
                    loop = false;

                    for (j = 0; j < obsticles.length; j += 1) {
                        if (isInRangeOfObject(newX, newY, obsticles[j].x, obsticles[j].y, obsticleSize)) {
                            newX = getNumberCloseToPixel(getRandomNumberInRange(0, maxX), obsticleSize);
                            newY = getNumberCloseToPixel(getRandomNumberInRange(0, maxY), obsticleSize);

                            loop = true;
                            break;
                        }
                    }
                }

                obsticles.push({ x: newX, y: newY });
            }
        }());

        getObsticles = function () {
            return obsticles;
        }

        getObsticleSize = function () {
            return obsticleSize;
        }

        return {
            getObsticles: getObsticles,
            getObsticleSize: getObsticleSize
        }
    }

    var isInRangeOfObject = function (sourceX, sourceY, targetX, targetY, radius) {
        return ((sourceX === targetX - radius || sourceX === targetX || sourceX === targetX + radius) &&
                (sourceY === targetY - radius || sourceY === targetY || sourceY === targetY + radius));
    }

    var getRandomNumberInRange = function (min, max) {
        return Math.floor(Math.random() * (max - min + 1) + min);
    }

    var getNumberCloseToPixel = function (num, pixelSize) {
        return num - num % pixelSize;
    }

    return {
        Snake: Snake,
        Apple: Apple,
        Obsticles: Obsticles
    }
}();// singleton - only one instance of gameObjects