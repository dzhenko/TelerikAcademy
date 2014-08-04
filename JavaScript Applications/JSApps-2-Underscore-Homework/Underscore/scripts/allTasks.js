/// <reference path="data.js" />
/// <reference path="underscore.js" />
var allTasks = (function () {
    // Task 1
    // Write a method that from a given array of students finds all students whose first name 
    // is before its last name alphabetically. Print the students in descending order by 
    // full name. Use Underscore.js
    function task1() {
        return _.chain(data.students)
        .filter(function (student) {
            return student.firstName < student.lastName;
        })
        .map(function (student) {
            return student.firstName + ' ' + student.lastName;
        })
        .sort()
        .value();
    }

    // Task 2
    // Write function that finds the first name and last name of all students with age between 
    // 18 and 24. Use Underscore.js
    function task2() {
        return _.chain(data.students)
        .filter(function (student) {
            return 18 <= student.age && student.age <= 24
        })
        .map(function (student) {
            return {
                firstName: student.firstName,
                lastName: student.lastName
            }
        })
        .value();
    }

    // Task 3
    // Write a function that by a given array of students finds the student with highest marks
    function task3() {
        return _.max(data.students, function (student) {
            return student.mark;
        });
    }

    // Task 4
    // Write a function that by a given array of animals, groups them by species and sorts them by number of legs
    function task4() {
        return _.chain(data.animals)
       .groupBy('species')
       .sortBy('legs')
       .value();
    }

    // Task 5
    // Write a function that by a given array of animals, groups them by species and sorts them by number of legs
    function task5() {
        return _.reduce(data.animals, function (memo, animal) {
            return memo + animal.legs;
        }, 0);
    }

    // Task 6
    // By a given collection of books, find the most popular author (the author with the highest number of books)
    function task6() {
        return _.chain(data.books)
       .groupBy('author')
       .pairs()
       .max(function (pair) {
           return pair[1].length;
       })
       // so far returned array of two elements - name and array of books belonging to the author
       .first()
       .value();
    }

    // Task 7
    // By an array of people find the most common first and last name. Use underscore.
    function task7() {
        var byFirstName =  _.chain(data.humans)
            .groupBy('firstName')
            .pairs()
            .max(function (pair) {
                return pair[1].length;
            })
            .first()
            .value();

        var byLastName = _.chain(data.humans)
            .groupBy('lastName')
            .pairs()
            .max(function (pair) {
                return pair[1].length;
            })
            .first()
            .value();

        return 'By first name: ' + byFirstName + '| By last name :' + byLastName;
    }
    console.log(task1());
    console.log(task2());
    console.log(task3());
    console.log(task4());
    console.log(task5());
    console.log(task6());
    console.log(task7());

    return {
        tasks: [task1, task2, task3, task4, task5, task6, task7]
    }
}());