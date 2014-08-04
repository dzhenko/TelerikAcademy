/// <reference path="oauth.js" />
function loadLastTweets() {
    OAuth.initialize('WLU8nD7gAiDzfyf_dqDPQa3rLTs');

    OAuth.popup('twitter', { cache: true })
    .done(function (result) {
        result.get('https://api.twitter.com/1.1/statuses/user_timeline.json?count=' +
            $('#tb-count').val() + '&screen_name=' + $('#tb-username').val())
        .done(function (tweets) {
            console.log(tweets);
            var holder = $('#feed');
            holder.html('');
            for (var i = 0; i < tweets.length; i++) {
                holder.append('<li>' + tweets[i].text +' (created at: ' +tweets[i].created_at +')</li>');
            }
        })
        .fail(function (error) {
            alert(1);
        })
    })
    .fail(function (err) {
        alert(1);
    });
}