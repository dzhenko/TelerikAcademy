app.filter('gameStateFilter', function() {
    return function(state) {
        switch (state) {
            case 0 : return 'Waiting for other players';
            case 1 : return 'It is first player\'s turn (X)';
            case 2 : return 'It is second player\'s turn (O)';
            case 3 : return 'First player wins (X)';
            case 4 : return 'Second player wins (O)';
            case 5 : return 'Draw';
        }
    }
});