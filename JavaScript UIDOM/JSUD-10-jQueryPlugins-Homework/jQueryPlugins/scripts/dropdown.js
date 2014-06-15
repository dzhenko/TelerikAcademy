(function () {
    $.fn.dropdown = function () {
        var $this = $(this).hide();
        var options = $this.children();

        var $container = $('<div />')
                .addClass('dropdown-list-container');

        $this.after($container);

        var $options = $('<ul />')
                .addClass('dropdown-list-options')
                .appendTo($container);

        for (var i = 0; i < options.length; i++) {
            $('<li />')
                .addClass('dropdown-list-option')
                .attr('data-value', i)
                .html($($this.children()[i]).html())
                .appendTo($options)
                .on('click', function () {
                    $this.children('option:selected').first().removeAttr('selected');
                    $($this.children()[$(this).attr('data-value')]).attr('selected', true);
                });
        }
    }
}());