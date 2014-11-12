var app = app || {};
app.notificationsApi = app.notificationsApi || {};

(function(app) {    
    document.addEventListener("deviceready", function () {
        app.notificationsApi = {
            alert: function(message) {
                navigator.notification.alert(message);
            },
            confirm: function(message) {
                navigator.notification.confirm();
            },
            prompt: function(message) {
                navigator.notification.prompt(message, function(result) {               
                    navigator.notification.alert(result); 
                });
            },
            beep: function(times) {
                navigator.notification.beep(times);
            },
            vibrate: function(interval) {
                navigator.notification.vibrate(interval);
            }
        };
    });
}(app));