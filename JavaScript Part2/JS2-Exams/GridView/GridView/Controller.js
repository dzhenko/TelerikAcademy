function getControls() {
    
    function getGridView(elementToAppendTo,nested) {
        var currTable = document.createElement('table');
        currTable.style.display = 'none';
        if (nested) {
            currTable.style.display = 'table';
            currTable.className = 'nested';
            currTable.style.margin = 'auto';
        }
        elementToAppendTo.appendChild(currTable);

        function render() {
            currTable.style.display = 'table';
        }

        function escapedBr(currString) {
            if (typeof(currString) != 'string') {
                return currString;
            }
            var indexOfBR = currString.indexOf('<br/>');
            if (indexOfBR > -1) {
                return currString.substr(0, indexOfBR) + '&lt' + 'br' + '/' + '&gt' + currString.substr(indexOfBR + 5);
            }
            else {
                return currString;
            }
        }

        function sortHere(ev) {
            var sorter = ev.target;

            var objectValues = [];
            var indexValues = [];
            var objectRows = [];
            var correctOrder = [];
            var counter = 0;
            
            var curEl = currTable.firstElementChild.firstElementChild;
            while (curEl != sorter) {
                counter++;
                curEl = curEl.nextElementSibling;
            }

            curEl = currTable.firstElementChild.nextElementSibling;
            while (curEl) {
                var curChildVal = curEl.firstElementChild;
                for (var i = 0; i < counter; i++) {
                    curChildVal = curChildVal.nextElementSibling;
                }
                if (curChildVal) {
                    objectValues.push(curChildVal.innerHTML.toString());
                    indexValues.push(curChildVal.innerHTML.toString());
                }
                curEl = curEl.nextElementSibling.nextElementSibling;
            }

            curEl = currTable.firstElementChild.nextElementSibling;
            while (curEl) {
                objectRows.push(curEl);
                curEl = curEl.nextElementSibling;
            }
            
            curEl = currTable.firstElementChild.nextElementSibling;

            while (curEl) {
                var next = curEl.nextElementSibling;
                currTable.removeChild(curEl);
                curEl = next;
            }

            getindexed();

            for (var i = 0; i < correctOrder.length; i++) {
                currTable.appendChild(correctOrder[i]);
            }

            function getindexed() {
                var alpha = sorter.getAttribute('alpha');

                if (alpha == 'true') {
                    while (correctOrder.length < objectRows.length) {
                        var min = 0;
                        for (var i = 1; i < objectValues.length; i++) {
                            
                            if (objectValues[min] > objectValues[i]) {
                                min = i;
                            }
                        }
                        var indexToAdd = 2 * indexValues.indexOf(objectValues[min]);
                        while (correctOrder.indexOf(objectRows[indexToAdd]) > -1) {
                            indexToAdd = 2 * indexValues.indexOf(objectValues[min], indexValues.indexOf(objectValues[min]) + 1);
                        }
                        correctOrder.push(objectRows[indexToAdd]);
                        correctOrder.push(objectRows[indexToAdd + 1]);
                        objectValues.splice(min, 1);
                    }
                    sorter.setAttribute('alpha','false');
                }
                else {
                    while (correctOrder.length < objectRows.length) {
                        var max = 0;
                        for (var i = 1; i < objectValues.length; i++) {

                            if (objectValues[max] < objectValues[i]) {
                                max = i;
                            }
                        }
                        var indexToAdd = 2 * indexValues.indexOf(objectValues[max]);
                        while (correctOrder.indexOf(objectRows[indexToAdd]) > -1) {
                            indexToAdd = 2 * indexValues.indexOf(objectValues[max], indexValues.indexOf(objectValues[max]) + 1);
                        }
                        correctOrder.push(objectRows[indexToAdd]);
                        correctOrder.push(objectRows[indexToAdd + 1]);
                        objectValues.splice(max, 1);
                    }
                    sorter.setAttribute('alpha', 'true');
                }
            }
        }

        function addHeader() {
            var len = arguments.length;
            var header = document.createElement('tr');
            for (var i = 0; i < len; i++) {
                var currH = document.createElement('th');
                currH.innerHTML = escapedBr(arguments[i]);
                header.appendChild(currH);
                currH.setAttribute('alpha', 'true');
                currH.onclick = sortHere;
            }
            currTable.appendChild(header);
            header.nextElementSibling
        }

        function clickedRow(target) {
            if (target.style.display == 'none') {
                target.style.display = 'table-row';
            }
            else {
                target.style.display = 'none';
            }
        }

        function addRow() {
            var len = arguments.length;
            var currRow = document.createElement('tr');
            for (var i = 0; i < len; i++) {
                var currD = document.createElement('td');
                currD.innerHTML = escapedBr(arguments[i]);
                currRow.appendChild(currD);
            }
            currTable.appendChild(currRow);
            var nestedRow = document.createElement('tr');
            currTable.appendChild(nestedRow);
            nestedRow.style.display = 'none';

            return {
                getNestedGridView: function () {
                    currRow.onclick = function () {
                        clickedRow(nestedRow);
                    };
                    nestedRow.style.display = 'table-row';
                    var nestedD = document.createElement('td');
                    nestedD.colSpan = len;
                    nestedRow.appendChild(nestedD);
                    return getGridView(nestedD, true);
                }
            }
        }

        return {
            addHeader: addHeader,
            addRow: addRow,
            render : render,
        }
    }

    return {
        getGridView: function (selector) {
            var holder = document.querySelector(selector);
            return getGridView(holder,false);
        }
    };
};