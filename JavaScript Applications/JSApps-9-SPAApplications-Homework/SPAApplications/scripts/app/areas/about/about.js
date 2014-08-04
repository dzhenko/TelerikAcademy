define(['jquery'], function ($) {
    function init() {
        $('#main-content').load('scripts/app/areas/about/about.html');
    }

    return {
        init: init
    }
})