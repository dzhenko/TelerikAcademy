function solve(params) {
    var finalAnswer = [];
    var processedLines = [];
    var numberOfKeyVals = parseInt(params[0]);
    var keyVals = {};
    var templates = {};

    for (var i = 1; i <= numberOfKeyVals; i++) {
        var currPair = params[i].split('-');
        keyVals[currPair[0]] = currPair[1];
    }

    for (var i = numberOfKeyVals + 2; i < params.length; i++) {
        var currRawLine = params[i];

        //condition
        var indexCondition = currRawLine.indexOf('<nk-if condition="');

        if (indexCondition >= 0 && !isComented(indexCondition, currRawLine)) {
            var condAppend = false;
            var indexOfCondBeg = currRawLine.indexOf('"', indexCondition + 1) + 1;
            var indexOfCondEnd = currRawLine.indexOf('"', indexOfCondBeg + 1);
            var conditionKey = currRawLine.substring(indexOfCondBeg, indexOfCondEnd);

            var conditionValue = keyVals[conditionKey];

            if (conditionValue == 'true') {
                condAppend = true;
            }

            i++;

            while (params[i].indexOf('</nk-if>') < 0) {
                if (condAppend) {
                    processedLines.push(params[i]);
                }
                i++;
            }
            continue;
        }

        //repeat

        var indexOfRepeat = currRawLine.indexOf('<nk-repeat for="');

        if (indexOfRepeat >= 0 && !isComented(indexOfRepeat, currRawLine)) {
            var contentBeguin = currRawLine.indexOf('"', indexOfRepeat + 1) + 1;
            var contentEnd = currRawLine.indexOf('"', contentBeguin + 1);
            var contentInside = currRawLine.substring(contentBeguin, contentEnd);
            var splitetContent = contentInside.split(' ');
            var tempVarName = splitetContent[0];
            var repeatKeyName = splitetContent[2];

            var contentOfRepeat = [];
            i++;
            while (params[i].indexOf('</nk-repeat>') < 0) {
                contentOfRepeat.push(params[i]);
                i++;
            }

            var arrayOfValues = keyVals[repeatKeyName].split(';');

            for (var p = 0; p < arrayOfValues.length; p++) {

                for (var cont = 0; cont < contentOfRepeat.length; cont++) {
                    
                    if (contentOfRepeat[cont].indexOf(tempVarName) >= 0) {
                        var indexOfBeginModel = contentOfRepeat[cont].indexOf('<nk-model>');
                        var indexOfEndModel = contentOfRepeat[cont].indexOf('</nk-model>');
                        var currNewLine = contentOfRepeat[cont].substr(0, indexOfBeginModel) + arrayOfValues[p] + contentOfRepeat[cont].substr(indexOfEndModel);
                        processedLines.push(currNewLine);
                    }
                    else {
                        processedLines.push(contentOfRepeat[cont]);
                    }
                }
            }

            continue;
        }

        processedLines.push(currRawLine);
    }

    for (var i = 0; i < processedLines.length; i++) {
        var currRawLine = processedLines[i];

        //template definition
        var indexOfTemplateDefinition = currRawLine.indexOf('<nk-template name="');

        if (indexOfTemplateDefinition >= 0 && !isComented(indexOfTemplateDefinition,currRawLine)) {
            var templateDefinitionLines = [];
            var indexStartName = currRawLine.indexOf('"', indexOfTemplateDefinition);
            var indexEndName = currRawLine.indexOf('"', indexStartName + 1);
            var templateName = currRawLine.substring(indexStartName + 1, indexEndName);
            i++;

            while (processedLines[i].indexOf('</nk-template') < 0) {
                templateDefinitionLines.push(processedLines[i]);
                i++;
            }

            templates[templateName] = templateDefinitionLines;
            continue;
        }

        //template model keys
        var indexOfModelProp = currRawLine.indexOf('<nk-model');

        if (indexOfModelProp >= 0 && !isComented(indexOfModelProp, currRawLine)) {
            var currNewLine = getKeyValueModel(currRawLine, indexOfModelProp);
            finalAnswer.push(currNewLine);
            continue;
        }

        //template render
        var indexOfTemplateRender = currRawLine.indexOf('<nk-template render');

        if (indexOfTemplateRender >= 0 && !isComented(indexOfTemplateRender, currRawLine)) {
            var indexOfNameBegin = currRawLine.indexOf('"') + 1;
            var indexOfNameEnd = currRawLine.indexOf('"', indexOfNameBegin);
            var tempName = currRawLine.substring(indexOfNameBegin, indexOfNameEnd);

            for (var q = 0; q < templates[tempName].length; q++) {
                finalAnswer.push(templates[tempName][q])
            }

            continue;
        }


        //not a model
        finalAnswer.push(currRawLine);
    }

    return finalAnswer.join('\r');

    function getKeyValueModel(currLine, indexOfModelProp) {
        var indexOfContentBegin = currLine.indexOf('>', indexOfModelProp + 1) + 1;
        var indexOfContentEnd = currLine.indexOf('<', indexOfContentBegin + 1);
        var endOfModelString = currLine.indexOf('>', indexOfContentEnd + 1);
        var modelKey = currLine.substring(indexOfContentBegin, indexOfContentEnd);

        return currLine.substr(0, indexOfModelProp) + keyVals[modelKey] + currLine.substr(endOfModelString + 1);
    }

    function isComented(index,currLine) {
        
        if (index == 0 || index == 1) {
            return false;
        }
        if (currLine[index - 1] == '{' && currLine[index - 2] == '{') {
            return true;
        }

        return false;
    }
}