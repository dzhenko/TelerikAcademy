var app = app || {};
app.home = app.home || {};

(function (app) {
    'use strict'
    
    app.home.init = function() {
        app.requester.recipe.random().then(function(data){
            var recipe = data;
            kendo.bind($('#newest-recipe'), kendo.observable({
                recipe:recipe,
                onViewClick: function() {
                    if (!app.auth.isAuthenticated()) {
                        app.notifier.error('You must login or register!');
                        return;
                    }
                    
                    app.main.navigate('views/single-recipe/single-recipe.html?id='+ recipe.Id);
                }
            }));
            
            $('#recipe-image-holder').css('background-image','url(' + recipe.Image + ')');
        }, app.errorHandler);
        
        if (!app.home.shakeNotificationActivated) {
            app.home.shakeNotificationActivated = true;
            
            app.shakeNotifier.startWatch(function() {
                app.requester.recipe.random().then(function(data){
                    var recipe = data;
                    kendo.bind($('#newest-recipe'), kendo.observable({
                        recipe:recipe,
                        onViewClick: function() {
                            if (!app.auth.isAuthenticated()) {
                                app.notifier.error('You must login or register!');
                                return;
                            }
                            
                            app.main.navigate('views/single-recipe/single-recipe.html?id='+ recipe.Id);
                        }
                    }));
                    $('#recipe-image-holder').css('background-image','url(' + recipe.Image + ')');
                }, app.errorHandler);
            })
        }
    }
    
    app.home.onEventClick = function(e){
        if (!app.auth.isAuthenticated()) {
            app.notifier.error('You must login or register!');
            return;
        }
        app.main.navigate('views/single-recipe/single-recipe.html?id='+ e.target.context.dataset.id);
    }
    
    function successFindContacts(contacts, hrefLink, message) {
        console.log(contacts);
        
        app.notificationsApi.beep(1);
        app.notificationsApi.vibrate([100,200,100,100]);
        
        var user = message.substring(0, message.indexOf(' '));
        message = message.substring(message.indexOf(' '));
        
        var found = false;
        
        for(var i = 0; i < contacts.length; i+=1){
            for(var j = 0; j < contacts[i].emails.length; j+=1){
                if (contacts[i].emails[j].value === user) {
                    found = true;
                    user = contacts[i].displayName;
                    break;
                }
            }
            
            if (found) {
                break;
            }
        }
        
        $('#all-events-holder').prepend($('<li><a data-role="button" data-id="'+hrefLink+'">'+user + ' ' + message+'</a></li>'));
    }
    
    function onRecieveMessage(message) {
        var hrefLink = message.substr(0, 36);
        var message = message.substr(39);
        
        var options = new ContactFindOptions();
        options.multiple=true;
        var fields = ["name","displayName","emails"];
        navigator.contacts.find(fields, function(results){
            successFindContacts(results, hrefLink, message);
        }, app.errorHandler, options);
        
        
    }
    
    var pubnub = PUBNUB.init({
        subscribe_key: 'sub-c-e6269c5c-3d90-11e4-87bf-02ee2ddab7fe'
    });
    pubnub.subscribe({
        channel: 'MasterChef',
        message: onRecieveMessage
    });
}(app));