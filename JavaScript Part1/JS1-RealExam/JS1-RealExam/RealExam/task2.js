function solve(params) {
    var rowCol = params[0].split(' ');
    var matrixRows = parseInt(rowCol[0]);
    var matrixCols = parseInt(rowCol[1]);

    var currRow = matrixRows - 1;
    var currCol = matrixCols - 1;

    var score = 0;
    var steps = 0;
    var used = Array(matrixCols * matrixRows + 1);

    function makePow2(pow) {
        var answer = 1;
        for (var i = 0; i < pow; i++) {
            answer *= 2;
        }

        return answer;
    }

    while (true) {
        var indexUsed = currRow*matrixCols + currCol;
        var currScore = makePow2(currRow) - currCol;
        var currStep = parseInt(params[currRow + 1].charAt(currCol));

        if (used[indexUsed]) {
            return 'Sadly the horse is doomed in ' + steps + ' jumps'
        }
        steps++;
        used[indexUsed] = true;

        score += currScore;

        switch (currStep) {
            case 1: currRow -= 2; currCol += 1; break;
            case 2: currRow -= 1; currCol += 2; break;
            case 3: currRow += 1; currCol += 2; break;
            case 4: currRow += 2; currCol += 1; break;
            case 5: currRow += 2; currCol -= 1; break;
            case 6: currRow += 1; currCol -= 2; break;
            case 7: currRow -= 1; currCol -= 2; break;
            case 8: currRow -= 2; currCol -= 1; break;

        }

        if (currRow < 0 || currRow >= matrixRows || currCol < 0 || currCol > matrixCols) {
            return 'Go go Horsy! Collected '+score + ' weeds';
        }
    }
}