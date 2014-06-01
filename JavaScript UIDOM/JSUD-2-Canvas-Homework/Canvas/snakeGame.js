function SnakeGame(canvas, pixelSize, numberOfObsticles, gamespeed) {
    this.canvas = canvas;
    this.pixelSize = pixelSize;
    this.numberOfObsticles = numberOfObsticles;
    this.gamespeed = gamespeed;

    this.startGame = Start;

    function Start() {
        var obsticles = generateObsticles(canvas, numberOfObsticles, pixelSize);

        var apple = new Apple();

        var snake = new Snake(this.pixelSize);

        var ctx = canvas.getContext('2d');

        var gameEngine = setInterval(gameRefresh, gamespeed);

        snake.initialize(this.canvas);

        apple.refresh(obsticles, canvas, pixelSize);

        document.onkeydown = keyPressedHandler;

        function gameRefresh() {
            if (snake.alive) {
                snake.score++;

                var newSnakeEl = snake.move();

                checkSnakeAndObsticles(obsticles, newSnakeEl);
                checkSnakeAndApple(apple, newSnakeEl);

                reDraw();
            }
            else {
                gameOver();
            }
        }

        function gameOver() {
            clearInterval(gameEngine);

            var userName = prompt('Enter your name: ', 'unnamed');

            var currentScores = localStorage.getItem('scores');
            if (!currentScores) {
                currentScores = [];
            }
            else {
                currentScores = JSON.parse(currentScores);
            }

            if (currentScores.length == 0) {
                currentScores.push({ name: userName, score: snake.score });
            }
            else {

                if (snake.score < currentScores[currentScores.length - 1].score) {
                    currentScores.push({ name: userName, score: snake.score });
                }
                else {
                    for (var i = 0; i < currentScores.length; i++) {
                        if (currentScores[i].score < snake.score) {
                            currentScores.splice(i, 0, { name: userName, score: snake.score });
                            break;
                        }
                    }
                }
            }

            localStorage.removeItem('scores');
            localStorage.setItem('scores', JSON.stringify(currentScores));
            showScoreOnCanvas();

            function showScoreOnCanvas() {
                canvas.style.display = 'none';

                var scoresBoard = document.createElement('div');
                var gameOverSighn = document.createElement('div');
                gameOverSighn.innerHTML = 'GAME OVER';
                scoresBoard.appendChild(gameOverSighn);

                var listScores = document.createElement('ol');
                for (var i = 0; i < currentScores.length; i++) {
                    var currLI = document.createElement('li');
                    currLI.innerHTML = currentScores[i].name + " --> " + currentScores[i].score;
                    listScores.appendChild(currLI);
                }

                scoresBoard.appendChild(listScores);
                document.body.appendChild(scoresBoard);
            }

            return false;
        }
        
        function reDraw() {
            //clear
            ctx.clearRect(0, 0, canvas.width, canvas.height);

            //obsticles
            ctx.fillStyle = '#333';
            for (var i = 0; i < obsticles.length; i++) {
                ctx.fillRect(obsticles[i].x, obsticles[i].y, pixelSize, pixelSize);
            }

            //apple
            ctx.fillStyle = '0F0';
            ctx.fillRect(apple.X, apple.Y, pixelSize, pixelSize);
            ctx.fillStyle = 'F00';
            ctx.fillRect(apple.X + pixelSize / 4, apple.Y + pixelSize / 4, pixelSize - pixelSize / 2, pixelSize - pixelSize / 2);

            //snake
            ctx.fillStyle = '#2A8EC2';
            for (var i = 0; i < snake.elements.length; i++) {
                ctx.fillRect(snake.elements[i].x, snake.elements[i].y, pixelSize, pixelSize);
            }
            ctx.fillStyle = '#0F0';
            ctx.fillRect(snake.elements[0].x + pixelSize / 4, snake.elements[0].y + pixelSize / 4, pixelSize / 2, pixelSize / 2);
        }

        function keyPressedHandler(e) {
            switch (e.keyCode) {
                case 37: snake.changeDirection('L'); break;       //left 
                case 38: snake.changeDirection('U'); break;           //up
                case 39: snake.changeDirection('R'); break;        //right
                case 40: snake.changeDirection('D'); break;         //down 
            }
            gameRefresh();
        }

        function checkSnakeAndObsticles(allObsticles, newSnakeElement) {
            for (var i = 0; i < obsticles.length; i++) {

                if (allObsticles[i].x == newSnakeElement.x && allObsticles[i].y == newSnakeElement.y) {
                    snake.alive = false;
                    return;
                }
            }
        }

        function checkSnakeAndApple(theApple, newSnakeElement) {
            if (newSnakeElement.x != theApple.X || newSnakeElement.y != theApple.Y) {
                snake.elements.pop();
            }
            else {
                snake.score += 50;
                theApple.refresh(obsticles, canvas, pixelSize);
            }
        }
    }

    //helping functions
    function getRandomNumberInRange(min, max) {
        return Math.floor(Math.random() * (max - min + 1) + min);
    }

    function getNumberCloseToPixel(num) {
        return num - num % pixelSize;
    }

    //obstacles
    function generateObsticles(canvas, numberOfObsticles, pixelSize) {
        var obsticles = [];

        function generateObsticle(_x, _y) {
            obsticles.push({ x: _x, y: _y });
        }

        //generating walls
        for (var i = 0; i < canvas.width; i += pixelSize) {
            generateObsticle(i, 0);
            generateObsticle(i, canvas.height - pixelSize);
        }
        for (var i = 0; i < canvas.height; i += pixelSize) {
            generateObsticle(0, i);
            generateObsticle(canvas.width - pixelSize, i);
        }

        for (var i = 0; i < numberOfObsticles; i++) {
            var newX = getNumberCloseToPixel(getRandomNumberInRange(0, canvas.width));
            var newY = getNumberCloseToPixel(getRandomNumberInRange(0, canvas.height));

            //checks if the obsticle is near the start of the snake
            while (newY == canvas.height / 2) {
                newX = getNumberCloseToPixel(getRandomNumberInRange(0, canvas.width));
                newY = getNumberCloseToPixel(getRandomNumberInRange(0, canvas.height));
            }

            //checks if the obsticle is near another obsticle
            var loop = true;
            while (loop) {
                loop = false;
                for (var j = 0; j < obsticles.length; j++) {
                    if ((newX == obsticles[j].x - pixelSize || newX == obsticles[j].x || newX == obsticles[j].x + pixelSize) &&
                        (newY == obsticles[j].y - pixelSize || newY == obsticles[j].y || newY == obsticles[j].y + pixelSize)) {
                        newX = getNumberCloseToPixel(getRandomNumberInRange(0, canvas.width));
                        newY = getNumberCloseToPixel(getRandomNumberInRange(0, canvas.height));

                        loop = true;
                        break;
                    }
                }
            }

            generateObsticle(newX, newY);
        }

        return obsticles;
    }

    //apple
    function Apple() {
        this.X = 0;
        this.Y = 0;

        this.refresh = function (obsticles, canvas, pixelSize) {
            this.X = getNumberCloseToPixel(getRandomNumberInRange(0, canvas.width));
            this.Y = getNumberCloseToPixel(getRandomNumberInRange(0, canvas.height));

            //aplle not close to obsticles
            var loop = true;
            while (loop) {
                loop = false;
                for (var j = 0; j < obsticles.length; j++) {
                    if ((this.X == obsticles[j].x - pixelSize || this.X == obsticles[j].x || this.X == obsticles[j].x + pixelSize) &&
                        (this.Y == obsticles[j].y - pixelSize || this.Y == obsticles[j].y || this.Y == obsticles[j].y + pixelSize)) {
                        this.X = getNumberCloseToPixel(getRandomNumberInRange(0, canvas.width));
                        this.Y = getNumberCloseToPixel(getRandomNumberInRange(0, canvas.height));

                        loop = true;
                        break;
                    }
                }
            }
        }
    }

    //snake
    function Snake(pixelSize) {
        this.elements = [];
        this.direction = 'R';
        this.alive = true;
        this.score = 0;

        function getNewElement(_x, _y) {
            return { x: _x, y: _y };
        }

        //initialize snake
        this.initialize = function (canvas) {
            this.elements.push(getNewElement(canvas.width / 2 + pixelSize * 2, canvas.height / 2));
            this.elements.push(getNewElement(canvas.width / 2 + pixelSize, canvas.height / 2));
            this.elements.push(getNewElement(canvas.width / 2 + 0, canvas.height / 2));
            this.elements.push(getNewElement(canvas.width / 2 - pixelSize, canvas.height / 2));
        }


        this.move = function () {
            var newElement;

            switch (this.direction) {
                case 'R': newElement = getNewElement(this.elements[0].x + pixelSize, this.elements[0].y); break;
                case 'L': newElement = getNewElement(this.elements[0].x - pixelSize, this.elements[0].y); break;
                case 'U': newElement = getNewElement(this.elements[0].x, this.elements[0].y - pixelSize); break;
                case 'D': newElement = getNewElement(this.elements[0].x, this.elements[0].y + pixelSize); break;
            }

            this.elements.unshift(newElement);

            // check if I bite myself
            for (var i = 0; i < this.elements.length; i++) {

                for (var j = 0; j < this.elements.length; j++) {

                    if (i == j) {
                        continue;
                    }

                    if (this.elements[i].x == this.elements[j].x && this.elements[i].y == this.elements[j].y) {
                        this.alive = false;
                        return;
                    }
                }
            }

            return newElement;
        }

        this.changeDirection = function (newDirection) {
            if (newDirection == 'U') {

                if (this.direction != 'D') {
                    this.direction = 'U';
                }
            }
            else if (newDirection == 'D') {
                if (this.direction != 'U') {
                    this.direction = 'D';
                }
            }
            else if (newDirection == 'R') {
                if (this.direction != 'L') {
                    this.direction = 'R';
                }
            }
            else if (newDirection == 'L') {
                if (this.direction != 'R') {
                    this.direction = 'L';
                }
            }
        }
    }
}

