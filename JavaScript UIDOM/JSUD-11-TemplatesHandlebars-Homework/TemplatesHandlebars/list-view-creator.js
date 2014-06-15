(function () {
    $.fn.listView = function (dataToView) {
        $this = $(this);

        // get the id of the template
        var templateStringID = $this.attr('data-template');

        // id is converted to jQuery select
        var $templateElement = $('#' + templateStringID);

        // no such element - template is inside the THIS element (task 4)
        if ($templateElement.length < 1) {
            $templateElement = $this;
        }

        // the actual template
        var innerTemplateString = $templateElement.html();

        // adding the iteration
        var collectionStartString = '{{#colection}}';
        var collectionEndString = '{{/colection}}';

        // the result template
        var resultTemplateString = collectionStartString + innerTemplateString + collectionEndString;

        var template = Handlebars.compile(resultTemplateString);

        // calling the template with an object with colection property and passed data as data
        var resultHTML = template({
            colection: dataToView,
        });

        // removing the template if it was inside the element and adding the result
        $this.html(resultHTML);
    }
}())