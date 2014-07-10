define(function () {
    var appKey = 'lYI6vh7P7BFSL2Wr';
    var everliveApp = new Everlive(appKey);

    function onCreation() {
        console.log('added');
    }

    function onFail() {
        console.log('error');
    }

    function createRecepie(obj) {
        var data = everliveApp.data('Recepies');
        data.create(obj, onCreation, onFail);
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
                return getRecepiesByCategoryID(category.result[0].Id);
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

    function getRecipesByMinutes(minutes) {
        return everliveApp.data('Recepies').get({
            Minutes: minutes
        })
            .then(function (data) {
                return data.result;
            });
    }

    return {
        createRecepie: createRecepie,
        onCreation: onCreation,
        onFail: onFail,
        getAllRecipes: getAllRecipes,
        getAllCategories: getAllCategories,
        getRecipesById: getRecipesById,
        getRecipesByCategoryName: getRecipesByCategoryName,
        getRecipesByCategoryID: getRecipesByCategoryID,
        getRecipesByName: getRecipesByName,
        getRecipesByMinutes: getRecipesByMinutes
    }
});