/// <reference path="controls.js" />
/// <reference path="controls.js" />
(function () {
    require.config({
        paths: {
            "jquery": "libs/jquery.min",
            "handlebars": "libs/handlebars.min"
        }
    });

    //var comboBox = controls.ComboBox(people);
    //var template = $("#person-template").html();
    //var comboBoxHtml = comboBox.render(template);
    //container.innerHTML = comboBoxHtml;
    require(['jquery', 'controls', 'data/allPeople'], function (unUsed$, controls, people) {
        var comboBox = controls.ComboBox(people);
        var template = $('#person-template').html();
        var comboBoxHtml = comboBox.render(template);
        $('#holder').html(comboBoxHtml);
    });
}());