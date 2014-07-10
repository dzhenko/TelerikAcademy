define(['data/data-persister', 'views/views-loader'],function(persister, viewsLoader) {
    function addNewInput(e) {
        var target = e.target;
        var node = target.cloneNode(true);
        node.addEventListener('change', addNewInput);
        node.value = '';
        target.parentElement.appendChild(node);
    }

    function getNewRecepieInfo() {
        var directions = (function () {
            var val,
                i;
            var arr = [];
            var $directions = $('#add-recepie-input-directions').children('input');
            for (i = 0; i < $directions.length; i += 1) {
                val = $directions[i].value;
                if (val) {
                    arr.push(val);
                }
                else {
                    break;
                }
            }
            return arr;
        }());
        var products = (function () {
            var val,
                i;
            var arr = [];
            var $products = $('#add-recepie-input-products').children('input');
            for (i = 0; i < $products.length; i += 1) {
                val = $products[i].value;
                if (val) {
                    arr.push(val);
                }
                else {
                    break;
                }
            }
            return arr;
        }());
        var name = document.getElementById('add-recepie-input-name').value;
        var category = document.getElementById('add-recepie-input-category').value;
        var time = document.getElementById('add-recepie-input-time').value;
        var image = document.getElementById('add-recepie-input-image').value;

        var newRecepie = {
            'Category': category,
            'Name': name,
            'Image': image,
            'Minutes': time,
            'Products': products,
            'Directions': directions

        };

        persister.createRecepie(newRecepie);
    }

    function init() {
        var viewHTML;
        var times = (function () {
            var arr = [];
            for (var i = 5; i < 185; i += 5) {
                arr.push(i);
            }
            return arr;
        }());
        return viewsLoader.loadView('add')
            .then(function (responseHTML) {
                viewHTML = responseHTML;
                return persister.getAllCategories();
            })
            .then(function (categories) {
                var model = {
                    title: 'Add recipe',
                    content: 'Here you can add a brand new recipe',
                    categories: categories,
                    times: times,
                    addItem: getNewRecepieInfo,
                    addNewInput: addNewInput
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
