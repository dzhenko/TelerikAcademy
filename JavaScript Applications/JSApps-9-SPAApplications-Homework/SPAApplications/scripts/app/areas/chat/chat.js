define(['jquery', 'messages', 'mustache', 'storage'], function ($, messages, mustache, storage) {
    var interval;
    function init() {
        $('#main-content').load('scripts/app/areas/chat/chat.html', function () {
            $('#sendBtn').on('click', sendMessage);

            populateMessages();
            interval = setInterval(populateMessages, 30000);
        });
    }

    function populateMessages() {
        $('#theImg').show();
        messages.get().then(function (allMessages) {
            var templateHTML = $('#messagesTemplate').html();
            var output = mustache.render(templateHTML, {
                messages: allMessages.reverse()
            });

            $('#messages-content').html(output);
            $('#theImg').hide();
        })
    }

    function sendMessage() {
        var txt = $('#message').val();
        $('#message').val('');
        if (interval) {
            clearInterval(interval);
        }

        messages.post({
            user: storage.username.get(),
            text: txt
        }).then(function () {
            populateMessages();
            interval = setInterval(populateMessages, 30000);
        });

    }

    return {
        init: init
    }
})
