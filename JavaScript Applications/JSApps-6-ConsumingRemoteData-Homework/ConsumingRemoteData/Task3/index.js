/// <reference path="C:\Users\dzhenko\Documents\Visual Studio 2013\Projects\TelerikAcademy\JavaScript Applications\JSApps-6-ConsumingRemoteData-Homework\ConsumingRemoteData\libs/jquery.js" />
(function () {
    var container = $('#students');
    container.on('click', 'button', function () {
        var id = $(this).parent().parent().children().first().html();
        deleteStudent(id);
    });

    function deleteStudent(id) {
        $.ajax({
            url: 'http://localhost:3000/students/' + id,
            type: 'POST',
            data: {_method: 'delete'},
            success: function (data) {
                console.log('Student successfully deleted ' + data);
                refreshStudents();
            },
            error: function (err) {
                alert('You have to start the server first')
            }
        })
    }

    function refreshStudents() {
        $.ajax({
            url: 'http://localhost:3000/students',
            type: 'GET',
            contentType: 'application/json',
            success: function (data) {
                container.html('');
                for (var i = 0; i < data.students.length; i++) {
                    container.append(
                        '<tr>' +
                            '<td>' + data.students[i].id + '</td>' +
                            '<td><strong>' + data.students[i].name + '</strong></td>' +
                            '<td>' + data.students[i].grade + '</td>' +
                            '<td><button>Delete</button></td>' +
                        '</tr>');
                }
            },
            error: function (err) {
                alert('You have to start the server first')
            }
        })
    }

    function addStudent() {
        var name = $('#tb-name').val() || 'unnamed';
        var grade = parseInt($('#tb-grade').val()) || 2;
        $.ajax({
            url: 'http://localhost:3000/students',
            type: 'POST',
            data: JSON.stringify({
                name: name,
                grade: grade
            }),
            contentType: 'application/json',
            success: function (data) {
                console.log('Student added ' + data);
                refreshStudents();
            },
            error: function (err) {
                alert('You have to start the server first')
            }
        });
    }

    $('#btn-add').on('click', addStudent);
    $('#btn-refresh').on('click', refreshStudents);

    refreshStudents();
}())