define(['jquery', '../../storage'], function ($, storage) {
    function init() {
        $('#main-content').load('scripts/app/areas/login/login.html', function () {
            $('#currentUsername').html(storage.username.get());

            $('#changeUsername').on('click', function () {
                var username = $('#username').val();
                storage.username.set(username);
                $('#currentUsername').html(username);
            })
        });
    }

    return {
        init: init
    }
})