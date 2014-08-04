/// <reference path="../libs/q.js" />
define(['jquery', 'q', 'storage'], function($, Q) {
	function getAll() {
	    var def = Q.defer();

	    $.ajax({
	        url: 'http://crowd-chat.herokuapp.com/posts',
	        type: 'GET',
	        success: function (allMessages) {
	            def.resolve(allMessages);
	        },
	        error: function (error) {
	            def.reject(error);
	        }
	    })
		
		return def.promise;
	}

	function post(message) {
	    var def = Q.defer();

	    $.ajax({
	        url: 'http://crowd-chat.herokuapp.com/posts',
	        type: 'POST',
	        data: message,
	        success: function (data) {
	            def.resolve(data);
	        },
	        error: function (error) {
	            def.reject(error);
	        }
	    })

	    return def.promise;
	}

	return {
	    get: getAll,
        post: post
	}
})