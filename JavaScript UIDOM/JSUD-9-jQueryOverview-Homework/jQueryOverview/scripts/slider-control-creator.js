function generateSliderControl(holder) {
    var allSlidesJSONArray = getAllSlides();

    // in case a normal DOM element is givven
    var $holder = $(holder);

    var $sliderContent = $('<div />')
                            .attr('id', 'sliderContent')
                            .css('position', 'relative')
                            .appendTo($holder);

    for (var i = 0; i < allSlidesJSONArray.length; i++) {
        var $currElement = $('<div />')
                            .html(allSlidesJSONArray[i])
                            .hide()
                            .css('position', 'absolute');

        $sliderContent.append($currElement);
    }

    $sliderContent.children().first().show();

    var $prevButton = $('<button />')
                        .on('click', function () {
                            showSlide(true);
                        })
                        .html('Previous Slide')
                        .appendTo($holder);

    var $nextButton = $('<button />')
                        .on('click', function () {
                            showSlide(false);
                        })
                        .html('Next Slide')
                        .appendTo($holder);

    var refresher = setInterval(showSlide, 5000);

    function showSlide(previous) {
        clearInterval(refresher);
        refresher = setInterval(showSlide, 5000);

        var $currentVisible = $sliderContent.children(':visible');
        var $nextToShow = $currentVisible.first().next();

        if (previous) {
            $nextToShow = $currentVisible.first().prev();
        }

        if ($nextToShow.length == 0) {
            $nextToShow = $sliderContent.children().first();
            if (previous) {
                $nextToShow = $sliderContent.children().last();
            }
        }

        $currentVisible.fadeOut(750);
        $nextToShow.fadeIn(750);
    }
}