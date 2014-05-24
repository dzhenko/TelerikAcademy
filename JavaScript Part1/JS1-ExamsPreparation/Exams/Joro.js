function Solve(params) {
    var NMJ = params[0].split(' ');
    var startRC = params[1].split(' ');

    var score = 0;
    var jumps = 0;

    var matrixRows = parseInt(NMJ[0]);
    var matrixCols = parseInt(NMJ[1]);
    var allPatterns = parseInt(NMJ[2]);
    var used = Array(matrixRows * matrixCols + 1);

    var positionRow = parseInt(startRC[0]);
    var positionCol = parseInt(startRC[1]);
    var currPatternIndex = 2;

    while (true) {
        var currField = positionRow * matrixCols + positionCol + 1;

        if (used[currField]) {
            return 'caught ' + jumps;
        }

        score += currField;
        used[currField] = true;
        jumps++;

        var currPattern = params[currPatternIndex].split(' ');
        currPatternIndex++;
        if (currPatternIndex == allPatterns + 2) {
            currPatternIndex = 2;
        }

        var dRow = parseInt(currPattern[0]);
        var dCol = parseInt(currPattern[1]);

        positionRow += dRow;
        positionCol += dCol;

        if (positionRow < 0 || positionRow >= matrixRows || positionCol < 0 || positionCol >= matrixCols) {
            return 'escaped ' + score;
        }
    }
}