var app = app || {};
app.ownRecipes = app.ownRecipes || {};

(function (app) {
    'use strict'
    
    app.ownRecipes.init = function () {
        var dataSource = new kendo.data.DataSource({
            transport: {
                read : function(options) {
                    app.requester.recipe.own().then(function(data){
                        options.success(data);
                    })
                }
            }
        });
        
        var viewModel = kendo.observable({
            recipes: dataSource,
            onDeleteClick : function(e) {
                app.requester.recipe.delete(e.button.context.dataset.id).then(function(data){
                    app.notifier.success('Deleted');
                    $(e.target.context.parentNode.parentNode).fadeOut()
                    
                }, app.errorHandler);
            },
            onViewClick : function(e) {
                app.main.navigate('views/single-recipe/single-recipe.html?id='+ e.button.context.dataset.id);
            }
        });
        
        kendo.bind($("#own-recipes-view"), viewModel);
    };
}(app));