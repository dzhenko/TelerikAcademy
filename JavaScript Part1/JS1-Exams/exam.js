function Solve(params) {
    var funcs = {};
    var currLine = '';
    var divideByZero = 'Division by zero! At Line:';

    for (var lin = 0; lin < params.length; lin++) {
        currLine = executeLine(formatLine(params[lin]));

        if (currLine == divideByZero) {
            return divideByZero + (lin + 1);
        }
    }

    return currLine;

    function formatLine(line) {
        var formatedLine = line.substr(line.indexOf('(') + 1);
        formatedLine = formatedLine.substr(0, formatedLine.lastIndexOf(')'));
        formatedLine = formatedLine.replace(/\s{2,}/g, ' ');
        var startIndex = 0;
        var endIndex = formatedLine.length;

        for (var i = 0; i < formatedLine.length; i++) {

            if (formatedLine[i] == ' ') {
                startIndex++;
            }
            else {
                break;
            }
        }

        for (var i = formatedLine.length - 1; i >= 0; i--) {
            if (formatedLine[i] == ' ') {
                endIndex--;
            }
            else {
                break;
            }
        }

        return formatedLine.substring(startIndex, endIndex);
    }

    function executeLine(fLine) {
        var answer = 0;
        if (fLine.indexOf('def ') == 0) {
            return defineFunction(fLine.substr(4));
        }

        else {
            var numbersAll = fLine.substr(2).split(' ');
            var numbers = new Array(numbersAll.length);
            for (var i = 0; i < numbersAll.length; i++) {
                var currNum = parseInt(numbersAll[i]);
                if (!currNum && currNum !== 0) {
                    currNum = funcs[numbersAll[i]];
                }
                numbers[i] = currNum;
            }

            answer = numbers[0];

            switch (fLine[0]) {
                case '+':
                    for (var i = 1; i < numbers.length; i++) {
                        answer += numbers[i];
                    }
                    break;

                case '-':
                    for (var i = 1; i < numbers.length; i++) {
                        answer -= numbers[i];
                    }
                    break;

                case '*':
                    for (var i = 1; i < numbers.length; i++) {
                        answer *= numbers[i];
                    }
                    break;

                case '/':
                    for (var i = 1; i < numbers.length; i++) {
                        if (numbers[i] == 0) {
                            return divideByZero;
                        }
                        answer = Math.floor(answer / numbers[i]);
                    }
                    break;
            }
        }
        return answer;
    }

    function defineFunction(defLine) {
        var whiteSpaceIndex = defLine.indexOf(' ');
        var fName = defLine.substring(0, whiteSpaceIndex);
        var fValue = defLine.substr(whiteSpaceIndex + 1);
        if (fValue.indexOf(' ') < 0) { //no equasion - function is givven a direct value
            var currFvalu = parseInt(fValue);
            if (!currFvalu && currFvalu !== 0) {
                funcs[fName] = funcs[fValue];
            }
            else {
                funcs[fName] = currFvalu;
            }
        }
        else {
            var curFunVal = executeLine(formatLine(fValue));
            if (curFunVal == divideByZero) {
                return divideByZero;
            }
            funcs[fName] = Number(curFunVal);
        }
    }
}