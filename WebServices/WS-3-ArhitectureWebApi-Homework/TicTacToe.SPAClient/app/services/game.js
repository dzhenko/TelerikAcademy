'use strict';

// manages the games services
app.factory('game', function(identity, requester, rootUrl){
    function createGame(){
        var url = rootUrl + 'games/create';
        return requester.post(url, undefined, identity.getToken());
    }

    function  joinGame() {
        var url = rootUrl + 'games/join';
        return requester.post(url, undefined, identity.getToken());
    }

    function gameStatus(id) {
        var url = rootUrl + 'games/status/' + id;
        return requester.get(url, identity.getToken());
    }

    // GameId , Row, Col (1 - 3)
    function playGame(data) {
        var url = rootUrl + 'games/play';
        return requester.post(url, data, identity.getToken());
    }

    return {
        create: createGame,
        join: joinGame,
        status: gameStatus,
        play: playGame
    }
});