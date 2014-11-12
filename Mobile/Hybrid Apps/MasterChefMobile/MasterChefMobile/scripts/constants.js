var app = app || {};

(function(app) {
    'use strict';
    
    var everliveApiKey = "95kmJDN7rCOytUwQ";
    
    app.constants = {
        everliveApiKey: everliveApiKey,
        everlivePictureStorageUri: "http://api.everlive.com/v1/" + everliveApiKey + "/Files/"
    }
}(app));