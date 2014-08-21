function getGridControl(element) {
    var currTable = document.createElement('table');

    if (element instanceof HTMLTableRowElement) {

    }
    else {
        element.appendChild(currTable);
    }
    
    return {
        addRow: function () {
            var newRow = document.createElement('tr');

            var currTBody = currTable.getElementsByTagName('tbody');
            if (!currTBody) {
                currTBody = document.createElement('tbody');
                currTable.appendChild(currTBody);
            }

            currTBody.appendChild(newRow);

            for (var i = 0; i < arguments.length; i++) {
                var currCell = document.createElement('td');
                currCell.innerText = arguments[i];
                newRow.appendChild(currCell);
            }

            return getGridControl(newRow);
        },

        addHead: function () {
            var oldHead = currTable.getElementsByTagName('thead');
            if (oldHead) {
                currTable.removeChild(oldHead);
            }

            var thead = document.createElement('thead');
            currTable.appendChild(thead);

            var theadRow = document.createElement('tr');
            thead.appendChild(theadRow);

            for (var i = 0; i < arguments.length; i++) {
                var currHead = document.createElement('th');
                currHead.innerText = arguments[i];
                theadRow.appendChild(currHead);
            }
        }
    }
}