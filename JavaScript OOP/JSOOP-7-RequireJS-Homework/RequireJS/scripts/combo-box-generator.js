/// <reference path="libs/require.js" />
/// <reference path="libs/jquery.min.js" />
/// <reference path="libs/handlebars.min.js" />
define(['jquery', 'handlebars'], function (unUsed$, unUsedHandlebars) {
    var getControlBox = function (people) {
        var templateString = $('#person-template').html();
        var template = Handlebars.compile(templateString);

        var $controlBox = $('<div />');

        for (var i = 0; i < people.length; i++) {
            var person = template(people[i]);
            $(person).appendTo($controlBox);
        }

        $controlBox.children().first().addClass('selected');

        var colapsed = true;
        var $oldSelected;

        $controlBox.on('click', '.person-item', function () {
            if (colapsed) {
                $controlBox.children().show();

                $controlBox.trigger("onExpanding");

                colapsed = false;
            }
            else {
                $controlBox.children().hide();
                $oldSelected = $controlBox.find('.selected').removeClass('selected');
                $(this).addClass('selected');

                $controlBox.trigger("onCollapsing");

                $controlBox.trigger('onSelectionChanged', [$oldSelected, $(this)]);
                
                colapsed = true;
            }
        });

        return $controlBox;
    }

    return {
        getControlBox: getControlBox,
    }
})