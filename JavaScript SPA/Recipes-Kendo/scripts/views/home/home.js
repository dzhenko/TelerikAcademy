define(['views/views-loader'], function(viewsLoader) {
    function init() {
        return viewsLoader.loadView('home')
            .then(function (responseHTML) {
                var model = {
                    title: 'Welcome to our recipes site',
                    content: 'Give us your comments (or money)',
                    imgSrc: 'http://www-tc.pbs.org/food/wp-content/blogs.dir/2/files/2012/12/Year-in-Food-2012-Recipes-Feat-602x338.jpg'
                };

                var view = new kendo.View(responseHTML, {
                    model: model
                });

                return view;
            });
    }

    return {
        init: init
    }
});
