/// <reference path="views/home/home.js" />
/// <reference path="libs/kendo.web.min.js" />
(function () {
    var layoutHtml = '<div id=content-div></div>';
    var layout = new kendo.Layout(layoutHtml);
    layout.render('#content');

    var router = new kendo.Router();

    function viewShower(view) {
        layout.showIn('#content-div', view);
    }

    router.route('/', function () {
        require(['views/home/home'], function(home) {
            home.init().then(viewShower);
        });
    });

    router.route('/categories', function () {
        // all categories
    });

    router.route('/categories/:id', function (id) {
        // category id view
    });

    router.route('/recipes', function () {
        require(['views/recipes/recipes'], function(recipes) {
            recipes.init().then(viewShower);
        });
    });

    router.route('/recipe/:id', function (id) {
        require(['views/recipe/recipe'], function(recipe) {
            recipe.init(id).then(viewShower);
        });
    });

    router.route('/add', function () {
        require(['views/add/add'], function(add) {
            add.init().then(viewShower);
        });
    });

    $(function () {
        router.start();
    });
}());