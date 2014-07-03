/// <reference path="game-renderer.js" />
/// <reference path="game-logic.js" />
/// <reference path="game-objects.js" />
var snakeGame = snakeGame || {};
snakeGame.SnakeGame = function (canvas, pixelSize, numberOfObsticles, gamespeed) {
    'use strict';

    var score = 0,
        startGame;

    startGame = function () {
        var snake,
            obsticles,
            apple,
            renderer,
            logic,
            gameLoopInterval,
            gameRefresh,
            reDrawBoard,
            gameOver;

        snake = new snakeGame.gameObjects.Snake(pixelSize, canvas.width / 2, canvas.height / 2);

        document.onkeydown = snake.keyPressedHandler;

        obsticles = new snakeGame.gameObjects.Obsticles(pixelSize, canvas.width, canvas.height, numberOfObsticles);

        apple = new snakeGame.gameObjects.Apple(pixelSize, canvas.width, canvas.height);

        renderer = new snakeGame.GameRenderer(canvas);

        logic = new snakeGame.GameLogic();

        gameRefresh = function () {
            reDrawBoard();

            var headElement;

            score += 1;

            snake.move();
            headElement = snake.getHeadElement();

            if (logic.checkIfSnakeHitsObsticles(obsticles, headElement)) {
                snake.kill();
            }

            if (logic.checkIfSnakeEatsApple(apple, headElement)) {
                snake.grow();
                score += 50;

                apple.refresh();
                while (logic.checkIfAppleIsOnObsticle(apple, obsticles)) {
                    apple.refresh();
                }
            }

            // checked, because if snake eats itself only she knows :)
            if (!snake.getIsAlive()) {
                clearInterval(gameLoopInterval);
                setTimeout(gameOver, 750);
            }
        };

        reDrawBoard = function () {
            renderer.clear();
            renderer.drawApple(apple);
            renderer.drawSnake(snake);
            renderer.drawObsticles(obsticles);
        };

        gameOver = function () {
            renderer.clear();
            renderer.drawGameOver(score);
        };

        gameLoopInterval = setInterval(gameRefresh, gamespeed);
    };

    return {
        startGame: startGame
    };
};