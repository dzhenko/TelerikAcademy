(function() {
	require.config({
    	paths: {
    	    jquery: '../libs/jquery',
        	mustache: '../libs/mustache',
        	q: '../libs/q',
        	sammy: '../libs/sammy',
        	underscore: '../libs/underscore'
    	}
	});

	require(['jquery', 'sammy', 'controllers'], function ($, sammy, controllers) {
	    var app = sammy('#main-content', function () {
	        this.get('#/', controllers.initHome)

	        this.get('#/login', controllers.initLogin)

	        this.get('#/chat', controllers.initChat)

	        this.get('#/about', controllers.initAbout)
	    });

	    $(function () {
	        app.run('#/');
	    })
	})
}())