// creates a game in holder with difficulty 1 2 or 3
function createGame(holderQuerrySelector, difficultySetting) {
    var difficulty = difficultySetting || 1;
    var $holder = $(holderQuerrySelector);

    var $shipGame = $('<div />')
                        .attr('id', 'game-ship')
                        .addClass('game-ship')
                        .appendTo($holder);

    var $numbersGame = $('<div />')
                        .attr('id', 'game-numbers')
                        .addClass('game-numbers')
                        .appendTo($holder);

    var $graphGame = $('<div />')
                        .attr('id','game-graph')
                        .addClass('game-graph')
                        .appendTo($holder);

    var score = 0;
    var fuel = difficulty == 3 ? 60 : difficulty == 2 ? 80 : 100;
    
    var shipGame = getShipGame($shipGame.attr('id'), difficultySetting);
    shipGame.attachObserverFunction(gameOver);
    shipGame.startGame();

    var numbersGame = getNumbersGame($numbersGame.attr('id'), difficulty);
    numbersGame.attachRightAnswerObserverFunction(numbersRightAnswer);
    numbersGame.attachWrongAnswerObserverFunction(numbersWrongAnswer);

    var graph = createGraph($graphGame.attr('id'));

    var gameEngine = setInterval(gameRefresh, 100);

    function gameRefresh() {
        score += 0.2 * difficulty;
        fuel -= 0.1 * difficulty;

        if (fuel <= 0) {
            shipGame.endGame();
            gameOver();
        }

        // graph Y is on 0 to 120 -> on 100 fuel - 20 Y
        // less fuel means more Y
        graph.drawPoint(120 - fuel);

        graph.setScore(score);
        graph.setFuel(fuel);
    }

    function numbersRightAnswer() {
        fuel += 10;
        score += 10;
        graph.addAnswered();
    }

    function numbersWrongAnswer() {
        fuel -= 10;
    }

    function gameOver() {
        clearInterval(gameEngine);
        setTimeout(function () {
            $holder.fadeOut(3000);
        },500)
    }
}