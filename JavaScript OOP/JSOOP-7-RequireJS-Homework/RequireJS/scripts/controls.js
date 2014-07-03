/// <reference path="libs/require.js" />
/// <reference path="libs/jquery.min.js" />
/// <reference path="libs/handlebars.min.js" />
define(['jquery', 'handlebars'], function (unUsed$, unUsedHandlebars) {
    var ComboBox = function (people) {
        var render = function (templateString) {
            var $resultElement,
                template,
                i;

            $resultElement = $('<div />');

            template = Handlebars.compile(templateString);

            for (i = 0; i < people.length; i++) {
                var person = template(people[i]);
                $(person).appendTo($resultElement);
            }

            $resultElement.children().first().addClass('selected');

            var colapsed = true;
            $resultElement.on('click', '.person-item', function () {
                if (colapsed) {
                    $resultElement.children().show();

                    colapsed = false;
                }
                else {
                    $resultElement.children().hide();
                    $oldSelected = $resultElement.find('.selected').removeClass('selected');
                    $(this).addClass('selected');

                    colapsed = true;
                }
            });

            return $resultElement;
        }

        return {
            render: render
        }
    }

    return {
        ComboBox: ComboBox
    }
});