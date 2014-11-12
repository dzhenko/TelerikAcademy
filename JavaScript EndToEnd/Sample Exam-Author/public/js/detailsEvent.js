$(document).ready(function() {
    var txtArea = $('#comment-text-area');
    var idHolder = $('#eventIdHolder');

    $('#leaveCommentBtn').on('click', function() {
        $.post('/api/leave-comment', {
            id : idHolder.val(),
            comment : txtArea.val()
        }, function() {
            location.reload();
        });

        txtArea.val('');
    })
});