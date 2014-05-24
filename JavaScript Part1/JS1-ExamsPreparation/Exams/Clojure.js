function Solve(params) {
    var vars = {};
    var warning = 'Division by zero! At Line:';

    for (var i = 0; i < params.length; i++) {
        var currCommand = extractCommand(params[i]);

        if (currCommand.indexOf('def') == 0) {
            //removing def
            currCommand = currCommand.substr(4);

            //extracting name of func
            var spaceIndex = currCommand.indexOf(' ');
            var varName = currCommand.substr(0, spaceIndex);

            //removing funcname
            currCommand = currCommand.substr(spaceIndex + 1);

            //are there ( ) 
            var bracketIndex = currCommand.indexOf('(');
            if (bracketIndex >= 0) {
                var operationContent = extractCommand(currCommand).split(' ');

                var currValue = executeOperation(operationContent);

                if (currValue == warning) {
                    return warning + (i + 1);
                }

                vars[varName] = currValue;
            }
            else {
                //no operations
                vars[varName] = getValue(currCommand);
            }
        }
        else if (i == params.length - 1) {
            var lastValue = executeOperation(currCommand.split(' '));

            if (lastValue == warning) {
                return warning + (i + 1);
            }
            else {
                return lastValue;
            }
        }
    }

    function getValue(stuff) {
        if (!vars[stuff] && vars[stuff] != 0) {
            return parseInt(stuff);
        }
        else {
            return vars[stuff];
        }
    }

    function extractCommand(line) {
        var extracted = '';
        var space = true;
        for (var i = line.indexOf('(') + 1; i < line.lastIndexOf(')'); i++) {
            if (line[i] == ' ') {
                if (!space) {
                    extracted += ' ';
                    space = true;
                }
            }
            else {
                extracted += line[i];
                space = false;
            }
        }

        return extracted.trim();
    }

    function executeOperation(arr) {
        var answer = getValue(arr[1]);

        if (arr[0] == '+') {
            for (var i = 2; i < arr.length; i++) {
                answer += getValue(arr[i]);
            }
        }
        else if (arr[0] == '-') {
            for (var i = 2; i < arr.length; i++) {
                answer -= getValue(arr[i]);
            }
        }
        else if (arr[0] == '*') {
            for (var i = 2; i < arr.length; i++) {
                answer *= getValue(arr[i]);
            }
        }
        else if (arr[0] == '/') {
            for (var i = 2; i < arr.length; i++) {
                var curNum = getValue(arr[i]);
                if (curNum == 0) {
                    return warning;
                }
                answer = parseInt(answer / curNum);
            }
        }

        return answer;
    }
}