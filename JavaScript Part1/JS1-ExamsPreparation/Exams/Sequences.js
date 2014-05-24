function Solve(params) {
    var answer = 0;
    if (params.length == 2) {
        return 0;
    }

    var prevNum = parseInt(params[1]);
    var counter = 1;

    for (var i = 2; i < params.length; i++) {
        var currNum = parseInt(params[i]);
        if (currNum < prevNum) {
            if (counter > 0) {
                answer++;
                counter = 1;
            }
        }
        else {
            counter++;
        }
        prevNum = currNum;
    }

    if (counter > 0) {
        answer++;
    }
    return answer;
}