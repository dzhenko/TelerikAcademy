define([], function() {
    'use strict';
    var Item;
    Item = (function() {
        // private
        var allowedTypes = ['accessory', 'smart-phone', 'notebook', 'pc', 'tablet'];

        function validateItemValues(type, name, price) {
            if (!checkIfValueIsString(type)) {
                throw {
                    message: 'Type must be string.'
                }
            }

            if (!checkIfTypeIsCorrect(type)) {
                throw {
                    message: 'Allowed types are accessory, smart-phone, notebook, pc or tablet.'
                }
            }

            if (!checkIfValueIsString(name)) {
                throw {
                    message: 'Name must be string.'
                }
            }

            if (!checkIfNameIsCorrectLength(name)) {
                throw {
                    message: 'Name must be between 6 and 40 characters long'
                }
            }

            if (!checkIfPriceIsCorrect(price)) {
                throw {
                    message: 'Price must be a decimal floating point number'
                }
            }

            function checkIfTypeIsCorrect(type) {
                return allowedTypes.indexOf(type) >= 0;
            }

            function checkIfValueIsString(value) {
                return typeof name === 'string';
            }

            function checkIfNameIsCorrectLength(name) {
                return name.length > 5 && name.length < 41;
            }

            function checkIfPriceIsCorrect(price) {
                var priceIsNumber = !isNaN(price) && isFinite(price);
                // 10.00 is converted to 10 - still it counts as a decimal point number
                var priceHasDecimalPoint = price.toString().indexOf('.') >= 0 || Math.floor(price) === price;
                return  priceIsNumber && priceHasDecimalPoint;
            }
        }

        // public
        function Item(type, name, price) {
            validateItemValues(type, name, price);

            this.type = type;
            this.name = name;
            this.price = price;
        }

        return Item;
    }());

    return Item;
});