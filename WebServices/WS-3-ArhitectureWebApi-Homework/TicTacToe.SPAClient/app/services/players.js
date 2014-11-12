'use strict';

// manages the games services
app.factory('player', function(identity, requester, rootUrl){
    function bestPlayer(){
        var url = rootUrl + 'api/Users/GetTopPlayer';
        return requester.get(url, undefined, identity.getToken());
    }

    return {
        best: bestPlayer
    }
});