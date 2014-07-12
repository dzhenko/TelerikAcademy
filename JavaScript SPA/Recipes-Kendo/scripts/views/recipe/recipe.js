define(['data/data-persister', 'views/views-loader'], function(persister, viewsLoader) {
    function init(id) {
        var viewHTML;
        return viewsLoader.loadView('recipe')
            .then(function (responseHTML) {
                viewHTML = responseHTML;
                return persister.getRecipesById(id);
            })
            .then(function (recipe) {
                console.log(recipe);
                var model = {
                    title: recipe.Name,
                    imgSrc: recipe.Image,
                    minutes: recipe.Minutes,
                    clock: 'http://upload.wikimedia.org/wikipedia/commons/b/b2/Red_clock.png',
                    products: recipe.Products,
                    directions: recipe.Directions
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