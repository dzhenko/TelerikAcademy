var controls = (function () {

    function getGridView(currTable, mainTable, mainTableQSelector) {

        var returned = {
            addRow: function () {
                var currCreatedRow = new Row(arguments);
                currTable.rows.push(currCreatedRow);

                return {
                    getNestedGridView: function () {
                        var currCreatedInnerTable = new Table();
                        currCreatedRow.innerTable = currCreatedInnerTable;
                        return getGridView(currCreatedInnerTable, false);
                    }
                }
            },

            addHeader: function () {
                var currCreatedHeadRow = new Row(arguments);
                currTable.headRow = currCreatedHeadRow;
            },

            getGridViewData: function () {
                return currTable.getTableDataObj();
            }
        }

        if (mainTable) {
            returned.render = function () {
                var elementToAppendTo = document.querySelector(mainTableQSelector);
                var generatedTable = currTable.generateHtmlElement();
                elementToAppendTo.appendChild(generatedTable);
            }
        }

        return returned;
    }

    return {
        getGridView: function (qSelector) {
            var mainTable = new Table();
            return getGridView(mainTable, true, qSelector);
        },

        buildGridView : function (qSelector,data) {
            //remove render() if you dont want to generateTable when you build it
            var builtTable = new Table();
            builtTable.populateByObj(data);
            var returned = getGridView(builtTable, true, qSelector);
            returned.render();
            return returned;
        }
    }
})();

function Row(info) {
    this.cols = [];

    for (var i = 0; i < info.length; i++) {
        this.cols.push(info[i]);
    }

    this.innerTable = false;
}

function Table() {
    this.rows = [];
    this.headRow = false;
    this._innerTableHtmlEl = false;
}

Table.prototype.generateHtmlElement = function () {
    var self = this;

    //if table was created - dont recreate it
    if (self._innerTableHtmlEl) {
        return self._innerTableHtmlEl;
    }

    var curTable = document.createElement('table');

    //headrow
    if (self.headRow) {
        var headerRow = document.createElement('thead');
        var currRow = document.createElement('tr');

        for (var i = 0; i < self.headRow.cols.length; i++) {
            var currHeadCell = document.createElement('th');
            currHeadCell.innerHTML = escapeTag(self.headRow.cols[i]);

            //atribute for altering the sorting
            currHeadCell.setAttribute('sortStyle', 'descending');
            //onclick event for sorting the rows in active (self == this) table
            currHeadCell.addEventListener('click', onSortInAlteringOrder);

            currRow.appendChild(currHeadCell);
        }

        headerRow.appendChild(currRow);
        curTable.appendChild(headerRow);

        function onSortInAlteringOrder(ev) {
            ev.stopImmediatePropagation();
            var target = ev.target;

            //finding the clicked index in the row
            var clickedIndex = (function () {
                var currChild = target.parentElement.firstElementChild;
                var index = 0;
                while (target !== currChild) {
                    index++;
                    currChild = currChild.nextElementSibling;
                }
                return index;
            })();

            //altering the sort order
            var descending = true;
            if (target.getAttribute('sortStyle') == 'descending') {
                target.setAttribute('sortStyle', 'ascending');
            }
            else {
                target.setAttribute('sortStyle', 'descending');
                descending = false;
            }

            self.rows.sort(function (a, b) {
                if (a.cols[clickedIndex] < b.cols[clickedIndex]) {
                    return descending ? 1 : -1;
                }
                else if (a.cols[clickedIndex] > b.cols[clickedIndex]) {
                    return descending ? -1 : 1;
                }
                else {
                    return 0;
                }
            });

            refreshTableBody();
        }
    }

    //body
    if (self.rows.length > 0) {
        refreshTableBody();
    }
    
    function refreshTableBody() {
        var oldBody = curTable.getElementsByTagName('tbody')[0];
        if (oldBody) {
            curTable.removeChild(oldBody);
        }

        var tbody = document.createElement('tbody');

        for (var r = 0; r < self.rows.length; r++) {
            var currDataRow = self.rows[r];
            var currAppendedRow = document.createElement('tr');

            for (var i = 0; i < currDataRow.cols.length; i++) {
                var currDCell = document.createElement('td');
                currDCell.innerHTML = escapeTag(currDataRow.cols[i]);
                currAppendedRow.appendChild(currDCell);
            }

            tbody.appendChild(currAppendedRow);

            if (currDataRow.innerTable) {
                var generatedNestedTableHtmlEl =
                currDataRow.innerTable.generateHtmlElement();

                var rowHolder = document.createElement('tr');
                var cellHolder = document.createElement('td');
                cellHolder.colSpan = self.headRow.cols.length;

                cellHolder.appendChild(generatedNestedTableHtmlEl);
                rowHolder.appendChild(cellHolder);
                tbody.appendChild(rowHolder);

                //onclick event for hiding the now appended table
                currAppendedRow.addEventListener('click', function (ev) {
                    ev.stopImmediatePropagation();
                    var target = ev.target.parentElement.nextElementSibling;
                    if (target.style.display == 'none') {
                        target.style.display = 'table-row';
                    }
                    else {
                        target.style.display = 'none';
                    }
                });
            }
        }
        curTable.appendChild(tbody);
    }

    self._innerTableHtmlEl = curTable;
    return self._innerTableHtmlEl;

    function escapeTag(currString) {
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
}

Table.prototype.sortByIndex = function (indexToSortBy,descending) {
    var self = this;
    var newRows = [];

    for (var r = 0; r < self.rows.length; r++) {
        newRows.push(self.rows[r]);
    }

    newRows.sort(function (a, b) {
        if (a.cols[indexToSortBy] < b.cols[indexToSortBy]) {
            return descending ? 1 : -1;
        }
        else if (a.cols[indexToSortBy] > b.cols[indexToSortBy]) {
            return descending ? -1 : 1;
        }
        else {
            return 0;
        }
    });
    self._innerTableHtmlEl = false;
    self.rows = newRows;
    self.generateHtmlElement();
}

Table.prototype.getTableDataObj = function () {
    var allSchools = [];
    var allValues =  getInnerTableData(this);

    for (var s = 0; s < allValues.length; s++) {
        var currSchData = allValues[s];
        if (currSchData.length == 5) {//school has sets of courses - must generate courses first
            var coursesArray = [];

            var currCourseData = currSchData[4];

            for (var cr = 0; cr < currCourseData.length; cr++) {
                var currCourseRow = currCourseData[cr];

                if (currCourseRow.length == 4) {//courses has sets of students - must generate them first
                    var students = [];

                    var currStudentData = currCourseRow[3];

                    for (var st = 0; st < currStudentData.length; st++) {
                        var curStudentInfo = currStudentData[st];
                        students.push(new Student(curStudentInfo[0], curStudentInfo[1], curStudentInfo[2], curStudentInfo[3]));
                    }

                    coursesArray.push(new Course(currCourseRow[0], currCourseRow[1], currCourseRow[2], students));
                }
                else {
                    coursesArray.push(new Course(currCourseRow[0], currCourseRow[1], currCourseRow[2],[]))
                }
            }

            allSchools.push(new School(currSchData[0], currSchData[1], currSchData[2], currSchData[3],coursesArray));
        }
        else {//no courses - push new school
            allSchools.push(new School(currSchData[0], currSchData[1], currSchData[2], currSchData[3],[]));
        }
    }

    return allSchools;
    
    function getInnerTableData(currTable) {
        var objToReturn = [];

        for (var i = 0; i < currTable.rows.length; i++) {
            var currRow = currTable.rows[i];
            var currRowObjects = [];

            for (var d = 0; d < currRow.cols.length; d++) {
                currRowObjects.push(currRow.cols[d]);
            }

            if (currRow.innerTable) {
                currRowObjects.push(getInnerTableData(currRow.innerTable));
            }

            objToReturn.push(currRowObjects);
        }

        return objToReturn;
    }
}

Table.prototype.populateByObj = function (objData) {
    var self = this;

    if (objData.length == 0) {
        return;
    }
    self.headRow = new Row(['Name','Location','Number of Courses', 'Speciality']);

    for (var sch = 0; sch < objData.length; sch++) {
        var curSchool = objData[sch];
        var crRowSc = new Row([curSchool.name, curSchool.location, curSchool.numberOfCourses, curSchool.speciality]);
        self.rows.push(crRowSc);

        if (curSchool.courses.length > 0) {
            var curCourseTable = new Table();
            crRowSc.innerTable = curCourseTable;

            curCourseTable.headRow = new Row(['Title', 'Start Date', 'Total Students']);

            for (var crs = 0; crs < curSchool.courses.length; crs++) {
                var curCourse = curSchool.courses[crs];
                var crRowCr = new Row([curCourse.title, curCourse.startDate, curCourse.totalStudents]);
                curCourseTable.rows.push(crRowCr);

                if (curCourse.students.length > 0) {
                    var currStudentsTable = new Table();
                    crRowCr.innerTable = currStudentsTable;

                    currStudentsTable.headRow = new Row(['First Name', 'Last Name', 'Grade', 'Marks']);

                    for (var st = 0; st < curCourse.students.length; st++) {
                        var curStudent = curCourse.students[st];

                        currStudentsTable.rows.push(new Row([curStudent.firstName, curStudent.lastName, curStudent.grade, curStudent.marks]));
                    }
                }
            }
        }
    }
}

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
            }

        }
        if (!Storage.prototype.getObject) {
            Storage.prototype.getObject = function getObject(key) {
                var jsonObj = this.getItem(key);
                var obj = JSON.parse(jsonObj);
                return obj;
            }
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