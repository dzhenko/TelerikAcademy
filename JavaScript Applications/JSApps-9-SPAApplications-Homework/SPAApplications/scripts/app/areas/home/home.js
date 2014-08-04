define(['jquery'], function ($) {
    function init() {
        $('#main-content').load('scripts/app/areas/home/home.html');
    }

    return {
        init: init
    }
})