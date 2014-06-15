$.fn.tabs = function () {
    var $this = this;
    $this.addClass($this.attr('id'));
    $this.find('.tab-item-content').hide();

    $this.on('click', '.tab-item-title', function () {
        var $clicked = $(this);
        $this.find('.tab-item-content').hide();
        $this.find('.current').removeClass('current');
        $clicked.next().show();
        $clicked.parent().addClass('current');
    })

    $this.find('.tab-item-content').first().show().parent().addClass('current');
};