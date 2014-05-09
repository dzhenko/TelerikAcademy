var controls = (function () {

    function escapedTag(currString) {
        if (typeof (currString) != 'string') {
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

    function Table(holder) {
        this.rows = [];
        this.headRow = null;
        this.holder = holder;
        this.htmlEl = false;
    }

    Table.prototype.getHtmlEl = function () {
        if (!this.htmlEl) {
            this.htmlEl = document.createElement('table');
        }
        return this.htmlEl;
    }

    function Row(information, headRow, tableOwner) {
        this.cols = [];
        this.htmlEl = document.createElement('tr');

        var htmlString = headRow ? 'th' : 'td';
        for (var i = 0; i < information.length; i++) {
            this.cols.push(information[i]);

            var curCel = document.createElement(htmlString);
            curCel.innerHTML = escapedTag(information[i]);
            this.htmlEl.appendChild(curCel);

            if (headRow) {
                curCel.addEventListener('click', function () {
                    rearangeRows(event,tableOwner);
                })
            }
        }

        this.innerTableRowHolder = null;
        this.innerTable = null;
    }

    function rearangeRows(event, srcTbl) {
        event.stopPropagation();
        var curCelElement = event.target;
        var firstChild = curCelElement.parentElement.firstElementChild;
        var indexForSorting = 0;
        while (firstChild !== curCelElement) {
            firstChild = firstChild.nextElementSibling;
            indexForSorting++;
        }
        var oldRows = srcTbl.rows;
        var newRows = [];
        var valuesToSort = [];
        var originalValues = [];
        for (var i = 0; i < oldRows.length; i++) {
            valuesToSort.push(oldRows[i].cols[indexForSorting]);
            originalValues.push(oldRows[i].cols[indexForSorting]);
        }

        var sortMode = curCelElement.getAttribute('sortMode');

        if (sortMode == 'descending') {
            while (newRows.length < oldRows.length) {
                var max = 0;
                for (var i = 1; i < valuesToSort.length; i++) {
                    
                    if (valuesToSort[max]<valuesToSort[i]) {
                        max = i;
                    }
                }
                var maxIndex = originalValues.indexOf(valuesToSort[max]);
                
                while (newRows.indexOf(oldRows[maxIndex]) > -1) {
                    maxIndex = originalValues.indexOf(valuesToSort[max],maxIndex + 1);
                }

                newRows.push(oldRows[maxIndex]);
                valuesToSort.splice(max, 1);
            }
            curCelElement.setAttribute('sortMode', 'ascending');

        }

        else {
            while (newRows.length < oldRows.length) {
                var min = 0;
                for (var i = 1; i < valuesToSort.length; i++) {

                    if (valuesToSort[min] > valuesToSort[i]) {
                        min = i;
                    }
                }
                var minIndex = originalValues.indexOf(valuesToSort[min]);

                while (newRows.indexOf(oldRows[minIndex]) > -1) {
                    minIndex = originalValues.indexOf(valuesToSort[min], minIndex + 1);
                }

                newRows.push(oldRows[minIndex]);
                valuesToSort.splice(min, 1);
            }
            curCelElement.setAttribute('sortMode', 'descending');
        }

        srcTbl.rows = newRows;

        render(srcTbl);
    }

    function toggleView(element) {
        if (element.style.display == 'none') {
            element.style.display = 'table-row';
        }
        else {
            element.style.display = 'none';
        }
    }

    function getGridViewDataFromTable(srcTable) {
        srcTable = new Table(); //REMOVE
        var objectToReturn = {};
        //use recursion
        //give asoc.obj to fill it in.


    }

    function render(inputTableToRender) {
        var tableToAppend = inputTableToRender.getHtmlEl();

        tableToAppend.appendChild(inputTableToRender.headRow.htmlEl);

        for (var i = 0; i < inputTableToRender.rows.length; i++) {

            tableToAppend.appendChild(inputTableToRender.rows[i].htmlEl);

            if (inputTableToRender.rows[i].innerTableRowHolder) {
                tableToAppend.appendChild(inputTableToRender.rows[i].innerTableRowHolder);

                inputTableToRender.rows[i].innerTableRowHolder.firstElementChild.colSpan =
                    inputTableToRender.headRow.cols.length;

                render(inputTableToRender.rows[i].innerTable);
            }
        }
    }

    function renderTableOnScrean(sourceTableToRender) {
        render(sourceTableToRender);
        sourceTableToRender.holder.appendChild(sourceTableToRender.getHtmlEl());
    }

    function getGridView(currTable, mainTable) {

        var returned = {
            addRow: function () {
                var createdRow = new Row(arguments, false);
                currTable.rows.push(createdRow);
                return {
                    getNestedGridView: function () {
                        var nestedRow = document.createElement('tr');
                        var nestedCell = document.createElement('td');
                        nestedRow.appendChild(nestedCell);
                        var nestedTable = new Table(nestedRow);
                        createdRow.innerTableRowHolder = nestedRow;
                        createdRow.innerTable = nestedTable;

                        nestedCell.appendChild(nestedTable.getHtmlEl());

                        createdRow.htmlEl.addEventListener('click', function () {
                            toggleView(nestedRow);
                        })

                        return getGridView(nestedTable, false);
                    }
                }
            },

            addHeader: function () {
                var newHRow = new Row(arguments, true, currTable);
                currTable.headRow = newHRow;
            }
        }

        if (mainTable) {
            returned.render = function () {
                renderTableOnScrean(currTable);
            }
        }

        return returned;
    }

    return {
        getGridView: function (qSelector) {
            var elementToAppendTo = document.querySelector(qSelector);
            var mainTable = new Table(elementToAppendTo);
            return getGridView(mainTable, true);
        }
    }
})()

function School(name, location, numberOfCourses, speciality, courses) {
    this.name = name;
    this.location = location;
    this.numberOfCourses = numberOfCourses;
    this.speciality = speciality;
    this.courses = courses;
}

function Course(title, startDate, totalStudents, students) {
    this.title = title;
    this.startDate = startDate;
    this.totalStudents = totalStudents;
    this.students = students;
}

function Student(firstName, lastName, grade, marks) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.grade = grade;
    this.marks = marks;
}

var schoolRepository = (function () {
    (function () {
        if (!Storage.prototype.setObject) {
            Storage.prototype.setObject = function setObject(key, obj) {
                var jsonObj = JSON.stringify(obj);
                this.setItem(key, jsonObj);
            };

        }
        if (!Storage.prototype.getObject) {
            Storage.prototype.getObject = function getObject(key) {
                var jsonObj = this.getItem(key);
                var obj = JSON.parse(jsonObj);
                return obj;
            };
        }
    })();

    return {
        save: function (key, value) {
            localStorage.setObject(key, value);
        },
        load: function (key) {
            return localStorage.getObject(key);
        }
    }
})();