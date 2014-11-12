var app = app || {};
app.allRecipes = app.allRecipes || {};

(function (app) {
    'use strict'
    var currentClickedId = 0;
    var searchTypeIndex = 0;
    var searchTypes = [{
        text: 'Name',
        call: app.requester.recipe.byName
    }, {
        text: 'Category',
        call: app.requester.recipe.byCategory
    }, {
        text: 'UserId',
        call: app.requester.recipe.byUser
    }, {
        text: 'Id',
        call: function(passedId) {
            app.main.navigate('views/single-recipe/single-recipe.html?id='+ passedId);
        }
    }];
    
    app.allRecipes.init = function () {
        var dataSource = new kendo.data.DataSource({
            transport: {
                read : function(options) {
                    app.requester.recipe.all().then(function(data){
                        options.success(data);
                    })
                }
            }
        });
        
        var viewModel = kendo.observable({
            recipes: dataSource,
            searchText: '',
            onSearchTypeClick: function(e) {
                searchTypeIndex++;
                if (searchTypeIndex === searchTypes.length) {
                    searchTypeIndex = 0;
                }
                
                e.currentTarget.innerText = searchTypes[searchTypeIndex].text;
            },
            onSearchClick: function() {
                 if (this.get('searchText') === '' || this.get('searchText') === ' ') {
                     app.notifier.error('Search text is empty');
                     return;
                 }
                
                 searchTypes[searchTypeIndex].call(this.get('searchText')).then(function(foundData){
                     if (foundData[0] === undefined) {
                         app.notifier.error('No results found');
                         return;
                     }

                     $("#all-recipes-list-div").hide();
                     
                     $("#search-recipes-results").kendoMobileListView({
                        dataSource: kendo.data.DataSource.create({data: foundData}),
                        template: $("#all-recipes-template").html()
                     });
                 },app.errorHandler);
                
                 this.set('searchText','');
            },
            onLikeClick : function(e) {
                app.requester.actions.like(e.button.context.dataset.id).then(function() {
                    e.button.context.innerText = e.button.context.innerText === "Like" ? "Unlike" : "Like";
                });
            },
            onCommentClick : function(e) {
                currentClickedId = e.button.context.dataset.id;
            },
            onViewClick : function(e) {
                app.main.navigate('views/single-recipe/single-recipe.html?id='+ e.button.context.dataset.id);
            }
        });
        
        kendo.bind($("#all-recipes-view"), viewModel);
    };
    
    app.allRecipes.model = {
        closeModal: function() {
            $("#modalview-comment").kendoMobileModalView("close");
        },
        comment: function() {
            app.requester.actions.comment(currentClickedId, $('#commentText').val());
            $('#commentText').val('');
            $("#modalview-comment").kendoMobileModalView("close");
        }
    }
}(app));