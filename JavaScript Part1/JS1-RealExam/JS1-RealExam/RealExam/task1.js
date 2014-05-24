function solve(params) {
    var originalSum = parseInt(params[0]);
    var cake1 = parseInt(params[1]);
    var cake2 = parseInt(params[2]);
    var cake3 = parseInt(params[3]);
    var tempSum = 0;
    var finalAnswer = 0;
    
    for (var i = 0; cake1*i <= originalSum; i ++) {
        tempSum = cake1 * i;

        if (tempSum == originalSum) {
            return originalSum;
        }
        if (tempSum > finalAnswer) {
            finalAnswer = tempSum;
        }

        for (var j = 0; j * cake2 <= originalSum - tempSum; j++) {
            tempSum += j * cake2;

            if (tempSum == originalSum) {
                return originalSum;
            }
            if (tempSum > finalAnswer) {
                finalAnswer = tempSum;
            }

            for (var k = 0; k * cake3 <= originalSum - tempSum ; k++) {
                tempSum += k * cake3;
                if (tempSum == originalSum) {
                    return originalSum;
                }
                if (tempSum > finalAnswer) {
                    finalAnswer = tempSum;
                }
                tempSum -= k * cake3;
            }

            tempSum -= j * cake2;
        }
    }

    return finalAnswer;
}
