'use strict';

recipesApp.factory('dataFetcher', function() {
    var appKey = 'lYI6vh7P7BFSL2Wr';
    var everliveApp = new Everlive(appKey);

    function onCreationDefault() {
        console.log('added');
    }

    function onFailDefault() {
        console.log('error');
    }

    function createRecipe(obj, onCreation, onFail) {
        var data = everliveApp.data('Recepies');
        data.create(obj,
            onCreation? onCreation: onCreationDefault,
            onFail? onFail: onFailDefault);
    }

    function createCategory(obj, onCreation, onFail) {
        var data = everliveApp.data('Categories');
        data.create(obj,
            onCreation? onCreation: onCreationDefault,
            onFail? onFail: onFailDefault);
    }

    function getAllCategories() {
        return everliveApp.data('Categories').get()
            .then(function (data) {
                return data.result;
            });
    }

    function getAllRecipes() {
        // typo in the telerik backend services :)
        return everliveApp.data('Recepies').get()
            .then(function (data) {
                return data.result;
            });
    }

    function getRecipesByCategoryName(name) {
        return everliveApp.data('Categories').get({
            Name: name
        })
            .then(function (category) {
                return getRecipesByCategoryID(category.result[0].Id);
            });
    }

    function getRecipesByCategoryID(id) {
        return everliveApp.data('Recepies').get({
            Category: id
        })
            .then(function (data) {
                return data.result;
            });
    }

    function getRecipesById(id) {
        return everliveApp.data('Recepies').get({
            Id: id
        })
            .then(function (data) {
                // single ID for a recipe
                return data.result[0];
            });
    }

    function getRecipesByName(name) {
        return everliveApp.data('Recepies').get({
            Name: name
        })
            .then(function (data) {
                return data.result;
            });
    }

    function getRecipesByPartOfName(partOfName) {
        return everliveApp.data('Recepies').get()
            .then(function (data) {
                return data.result.filter(function(recipe){
                    if (recipe.Name.toLowerCase().indexOf(partOfName.toLowerCase()) >= 0) {
                        return true;
                    }
                });
            });
    }

    function getRecipesByMinutes(minutes) {
        return everliveApp.data('Recepies').get({
            Minutes: minutes
        })
            .then(function (data) {
                return data.result;
            });
    }

    return {
        create: {
            recipe: createRecipe,
            category: createCategory
        },

        getCategories: {
            all: getAllCategories
        },
        getRecipes: {
            all: getAllRecipes,
            byId: getRecipesById,
            byName: getRecipesByName,
            byMinutes: getRecipesByMinutes,
            byCategoryName: getRecipesByCategoryName,
            byCategoryId: getRecipesByCategoryID,
            byPartOfName: getRecipesByPartOfName
        }
    }
});