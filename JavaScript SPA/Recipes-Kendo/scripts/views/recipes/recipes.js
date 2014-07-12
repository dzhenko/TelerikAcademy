define(['data/data-persister', 'views/views-loader'], function(persister, viewsLoader) {
    function init() {
        var viewHTML;
        return viewsLoader.loadView('recipes')
            .then(function (responseHTML) {
                viewHTML = responseHTML;
                return persister.getAllRecipes();
            })
            .then(function (recipes) {
                var model = {
                    title: 'All recipes',
                    content: 'Here you can feast your eyes upon our countless recipes',
                    recipes: recipes
                };

                var view = new kendo.View(viewHTML, {
                    model: model
                });

                return view;
            });
    }

    return {
        init: init
    }
});