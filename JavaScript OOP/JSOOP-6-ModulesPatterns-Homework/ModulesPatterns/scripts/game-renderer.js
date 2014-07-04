var snakeGame = snakeGame || {};
snakeGame.GameRenderer = function (canvas) {
    'use strict';

    // private
    var ctx,
        i,
        drawApple,
        drawSnake,
        drawObsticles,
        clear,
        drawGameOver;

    ctx = canvas.getContext('2d');

    // public
    drawApple = function (apple) {
        var appleSize,
            appleCoordinates;

        appleCoordinates = apple.getCoordinates();
        appleSize = apple.getAppleSize();

        ctx.fillStyle = '0F0';
        ctx.fillRect(appleCoordinates.x, appleCoordinates.y, appleSize, appleSize);

        ctx.fillStyle = 'F00';
        ctx.fillRect(appleCoordinates.x + appleSize / 4, appleCoordinates.y + appleSize / 4,
                     appleSize - appleSize / 2, appleSize - appleSize / 2);
    };

    drawSnake = function (snake) {
        var snakeElements,
            snakeSize;

        snakeElements = snake.getElements();
        snakeSize = snake.getElementSize();

        ctx.fillStyle = '#2A8EC2';
        for (i = 0; i < snakeElements.length; i += 1) {
            ctx.fillRect(snakeElements[i].x, snakeElements[i].y, snakeSize, snakeSize);
        }

        ctx.fillStyle = '#0F0';
        ctx.fillRect(snakeElements[0].x + snakeSize / 4, snakeElements[0].y + snakeSize / 4, snakeSize / 2, snakeSize / 2);
    };

    drawObsticles = function (obsticles) {
        var allObsticles,
            obsticleSize;

        allObsticles = obsticles.getObsticles();
        obsticleSize = obsticles.getObsticleSize();

        ctx.fillStyle = '#333';
        for (i = 0; i < allObsticles.length; i += 1) {
            ctx.fillRect(allObsticles[i].x, allObsticles[i].y, obsticleSize, obsticleSize);
        }
    };

    clear = function () {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
    };

    drawGameOver = function (score) {
        ctx.font = "20pt Arial";
        ctx.fillText("Game Over", 50, 50);
        ctx.fillText("Your Score", 50, 150);
        ctx.fillText(score.toString(), 50, 250);
    };

    return {
        drawApple: drawApple,
        drawSnake: drawSnake,
        drawObsticles: drawObsticles,
        clear: clear,
        drawGameOver: drawGameOver
    };
};