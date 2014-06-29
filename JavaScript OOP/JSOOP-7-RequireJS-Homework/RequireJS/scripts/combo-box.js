/// <reference path="libs/require.js" />
/// <reference path="libs/jquery.min.js" />
/// <reference path="combo-box-generator.js" />
/// <reference path="libs/handlebars.min.js" />
(function () {
    require.config({
        paths: {
            "jquery": "libs/jquery.min",
            "handlebars": "libs/handlebars.min"
        }
    });

    require(['jquery', 'combo-box-generator', 'data/allPeople'], function (unUsed$, generator, people) {
        var $controlBox = generator.getControlBox(people);

        $controlBox.on('onCollapsing', function () {
            alert('colapsed');
        });

        $controlBox.on('onExpanding', function () {
            alert('expanded');
        });

        $controlBox.on('onSelectionChanged', function (e, old, current) {
            alert('check console for info for old and new element');
            console.log(old);
            console.log(current);
        });

        $('#holder').html($controlBox);
    });
}());