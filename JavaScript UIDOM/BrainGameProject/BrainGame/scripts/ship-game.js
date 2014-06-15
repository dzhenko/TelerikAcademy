// needs coordinates ot top left window and size of window (square as the other game)
function getShipGame(containerID, difficulty) {
    var gameDifficulty = difficulty || 1;
    var windowSize = document.getElementById(containerID).offsetWidth;

    var stage = new Kinetic.Stage({
        container: containerID,
        width: windowSize,
        height: windowSize
    });

    var constants = {
        moveSpeed: 5,
        moveCheckInterval: 20,
        asteroidSizeVary: 2,
        asteroidSizeConst: 20,
        addNewAsteroidTime1: 1500,
        addNewAsteroidTime2: 2000,
        addNewAsteroidTime3: 2500,
        moveAsteroidsTime: 25,
    };

    var observerFunction = false;

    var layer = new Kinetic.Layer();

    // background setUp
    var backgroundImage = new Image();
    var backgroundKinetic = new Kinetic.Image({
        image: backgroundImage
    });
    layer.add(backgroundKinetic);

    // asteroids setUp
    var asteroids = [];
    var asteroidImage = new Image();
    asteroidImage.src = 'images/ship-game/asteroid.png';

    var asteroidsAdder1; 
    var asteroidsAdder2;
    var asteroidsAdder3;
    var asteroidsMover;
    
    // ship set Up
    var ship;
    (function () {
        var shipImageSprites = new Image();
        shipImageSprites.src = 'images/ship-game/shipSprite.png';
        ship = new Kinetic.Sprite({
            x: 20,
            y: 230,
            image: shipImageSprites,
            animation: 'fly',
            animations: {
                fly: [
                    0, 0, 50, 45,
                    53, 0, 50, 45,
                    105, 0, 50, 45,
                    53, 0, 50, 45
                ]
            },
            frameRate: 15,
            frameIndex: 0
        });
        layer.add(ship);
        ship.start();
    }());
    
    // Player Movement Set Up
    var keyboardListener;
    var keyArrowUp = false;
    var keyArrowDown = false;
    var keyArrowLeft = false;
    var keyArrowRight = false;
    
    window.addEventListener("keydown", function (e) {
        switch (e.which) {
            case 38:
            case 87: // W
                keyArrowUp = true;
                break;
            case 40:
            case 83: // S
                keyArrowDown = true;
                break;
            case 37:
            case 65: // A
                keyArrowLeft = true;
                break;
            case 39:
            case 68: // D
                keyArrowRight = true;
                break;
        }
        e.preventDefault();
    });

    window.addEventListener("keyup", function (e) {
        switch (e.which) {
            case 38:
            case 87: // W
                keyArrowUp = false;
                break;
            case 40:
            case 83: // S
                keyArrowDown = false;
                break;
            case 37:
            case 65: // A
                keyArrowLeft = false;
                break;
            case 39:
            case 68: // D
                keyArrowRight = false;
                break;
        }
        e.preventDefault();
    });

    function getPlayerMovement() {
        if (keyArrowUp) {
            ship.setY(ship.getY() - constants.moveSpeed);
            if (ship.getY() < 0) {
                ship.setY(0);
            }
        }
        else if (keyArrowDown) {
            ship.setY(ship.getY() + constants.moveSpeed);
            // vertical size of ship is 45 and field size is 460
            if (ship.getY() > 460 - 45) {
                ship.setY(460 - 45);
            }
        }
        if (keyArrowLeft) {
            ship.setX(ship.getX() - constants.moveSpeed);
            if (ship.getX() < 0) {
                ship.setX(0);
            }
        }
        else if (keyArrowRight) {
            ship.setX(ship.getX() + constants.moveSpeed);
            // horizontal size of ship is 50 and field size is 460
            if (ship.getX() > 460 - 50) {
                ship.setX(460 - 50);
            }
        }

        checkAsteroids();
    }

    stage.add(layer);

    return {
        attachObserverFunction: attachObserverFunction,
        startGame: startGame,
        pauseGame: pauseGame,
        endGame: endGame,
    };

    function pauseGame() {
        clearInterval(asteroidsMover);
        clearInterval(keyboardListener);

        clearInterval(asteroidsAdder1);
        if (asteroidsAdder2) {
            clearInterval(asteroidsAdder2);
        }
        if (asteroidsAdder3) {
            clearInterval(asteroidsAdder3);
        }
    }

    function startGame() {
        keyboardListener = setInterval(getPlayerMovement, constants.moveCheckInterval);

        if (!gameDifficulty || gameDifficulty == 1) {
            asteroidsAdder1 = setInterval(addNewAsteroid, constants.addNewAsteroidTime1);
            asteroidsMover = setInterval(moveAsteroids, constants.moveAsteroidsTime);
        }
        else {
            if (gameDifficulty == 3) {
                asteroidsAdder1 = setInterval(addNewAsteroid, constants.addNewAsteroidTime1);
                asteroidsAdder2 = setInterval(addNewAsteroid, constants.addNewAsteroidTime2);
                asteroidsAdder3 = setInterval(addNewAsteroid, constants.addNewAsteroidTime3);
                asteroidsMover = setInterval(moveAsteroids, constants.moveAsteroidsTime - 10);
            }
            else if (gameDifficulty == 2) {
                asteroidsAdder1 = setInterval(addNewAsteroid, constants.addNewAsteroidTime1);
                asteroidsAdder2 = setInterval(addNewAsteroid, constants.addNewAsteroidTime2);
                asteroidsMover = setInterval(moveAsteroids, constants.moveAsteroidsTime - 5);
            }
        }
    }

    function attachObserverFunction(notifyFunction) {
        observerFunction = notifyFunction;
    }

    function moveAsteroids() {
        for (var i = 0; i < asteroids.length; i++) {
            asteroids[i].setX(asteroids[i].getX() - 2);
            if (asteroids[i].getX() <= -100) {
                asteroids.shift();
            }
        }
        checkAsteroids();
    }

    function addNewAsteroid() {
        asteroids.push(getAsteroid(layer, asteroidImage, getRandom(constants.asteroidSizeVary * constants.asteroidSizeConst) + 2 * constants.asteroidSizeConst));

        function getAsteroid(currLayerToUse, imageToUse, sizeToUse) {
            var currAsteroid = new Kinetic.Image({
                image: imageToUse,
                width: sizeToUse,
                height: sizeToUse,
                x: 460 - sizeToUse,
                y: getRandom(460 - sizeToUse)
            });
            currLayerToUse.add(currAsteroid);

            return currAsteroid;
        }
    }

    function checkAsteroids() {
        for (var i = 0; i < asteroids.length; i++) {
            if (checkCollision(ship.getX() + 18,
                               ship.getY() + 16,
                               asteroids[i].attrs.x + asteroids[i].attrs.width / 2,
                               asteroids[i].attrs.y + asteroids[i].attrs.height / 2,
                               19, asteroids[i].attrs.width / 2)) {
                endGame();
                if (observerFunction) {
                    observerFunction();
                }
            }
        }

        function checkCollision(c1X, c1Y, c2X, c2Y, R1, R2) {
            return (c1X - c2X) * (c1X - c2X) + (c1Y - c2Y) * (c1Y - c2Y) <= (R1 + R2) * (R1 + R2);
        }
    }

    function getRandom(x) {
        return Math.floor(Math.random() * x);
    }

    function endGame() {
        clearInterval(asteroidsMover);
        clearInterval(keyboardListener);
        explode();
        
        clearInterval(asteroidsAdder1);
        if (asteroidsAdder2) {
            clearInterval(asteroidsAdder2);
        }
        if (asteroidsAdder3) {
            clearInterval(asteroidsAdder3);
        }

        function explode() {
            var explosion = new Image();
            explosion.src = 'images/ship-game/explode.png';
            var boom = new Kinetic.Sprite({
                x: ship.getX() - 25,
                y: ship.getY() - 22,
                image: explosion,
                animation: 'explode',
                animations: {
                    explode: [
                        0, 0, 100, 100,
                        100, 0, 100, 100,
                        200, 0, 100, 100,
                        300, 0, 100, 100,
                        400, 0, 100, 100,
                        500, 0, 100, 100,
                        600, 0, 100, 100,
                        700, 0, 100, 100,
                        800, 0, 100, 100,
                        900, 0, 100, 100,
                        0, 100, 100, 100,
                        100, 100, 100, 100,
                        200, 100, 100, 100,
                        300, 100, 100, 100,
                        400, 100, 100, 100,
                        500, 100, 100, 100,
                        600, 100, 100, 100,
                        700, 100, 100, 100,
                        800, 100, 100, 100,
                        900, 100, 100, 100,
                        0, 200, 100, 100,
                        100, 200, 100, 100,
                        200, 200, 100, 100,
                        300, 200, 100, 100,
                        400, 200, 100, 100,
                        500, 200, 100, 100,
                        600, 200, 100, 100,
                        700, 200, 100, 100,
                        800, 200, 100, 100,
                        900, 200, 100, 100,
                        0, 300, 100, 100,
                        100, 300, 100, 100,
                        200, 300, 100, 100,
                        300, 300, 100, 100,
                        400, 300, 100, 100,
                        500, 300, 100, 100,
                        600, 300, 100, 100,
                        700, 300, 100, 100,
                        800, 300, 100, 100,
                        900, 300, 100, 100,
                        0, 400, 100, 100,
                        100, 400, 100, 100,
                        200, 400, 100, 100,
                        300, 400, 100, 100,
                        400, 400, 100, 100,
                        500, 400, 100, 100,
                        600, 400, 100, 100,
                        700, 400, 100, 100,
                        800, 400, 100, 100,
                        900, 400, 100, 100,
                        0, 500, 100, 100,
                        100, 500, 100, 100,
                        200, 500, 100, 100,
                        300, 500, 100, 100,
                        400, 500, 100, 100,
                        500, 500, 100, 100,
                        600, 500, 100, 100,
                        700, 500, 100, 100,
                        800, 500, 100, 100,
                        900, 500, 100, 100,
                        0, 600, 100, 100,
                        100, 600, 100, 100,
                        200, 600, 100, 100,
                        300, 600, 100, 100,
                        400, 600, 100, 100,
                        500, 600, 100, 100,
                        600, 600, 100, 100,
                        700, 600, 100, 100,
                        800, 600, 100, 100,
                        900, 600, 100, 100,
                        0, 700, 100, 100,
                        100, 700, 100, 100,
                        200, 700, 100, 100,
                        300, 700, 100, 100,
                        400, 700, 100, 100,
                        500, 700, 100, 100,
                        600, 700, 100, 100,
                        700, 700, 100, 100,
                        800, 700, 100, 100,
                        900, 700, 100, 100,
                        0, 800, 100, 100,
                        100, 800, 100, 100,
                        200, 800, 100, 100,
                        300, 800, 100, 100,
                        400, 800, 100, 100,
                        500, 800, 100, 100,
                        600, 800, 100, 100,
                        700, 800, 100, 100,
                        800, 800, 100, 100,
                        900, 800, 100, 100,
                        0, 900, 100, 100,
                        100, 900, 100, 100,
                        200, 900, 100, 100,
                        300, 900, 100, 100,
                        400, 900, 100, 100,
                        500, 900, 100, 100,
                        600, 900, 100, 100,
                        700, 900, 100, 100,
                        800, 900, 100, 100,
                        900, 900, 100, 100
                    ]
                },
                frameRate: 45,
                frameIndex: 0
            });
            layer.add(boom);
            boom.start();
            setTimeout(function () {
                boom.stop();
            }, 800);
        }
    }
}