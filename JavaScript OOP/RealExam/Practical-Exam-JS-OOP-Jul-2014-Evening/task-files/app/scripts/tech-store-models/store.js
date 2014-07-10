define(['tech-store-models/item'], function(Item) {
    'use strict';
    var Store;
    Store = (function() {
        // private
        var allowedTypes = ['accessory', 'smart-phone', 'notebook', 'pc', 'tablet'];

        function validateStoreName(name) {
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

            function checkIfValueIsString(value) {
                return typeof name === 'string';
            }

            function checkIfNameIsCorrectLength(name) {
                return name.length > 5 && name.length < 41;
            }
        }

        function sortByName(items) {
            items.sort(function(first, second) {
                return first.name.localeCompare(second.name);
            });

            return items;
        }

        // using only up to 2 filters
        function getItemsByFiltersSortedByName(items, firstFilterType, secondFilterType) {
            var copyOfAllItems,
                filteredCopy;

            if (!items) {
                return;
            }

            if (!firstFilterType && !secondFilterType) {
                copyOfAllItems = items.slice(0);

                return sortByName(copyOfAllItems);
            }

            if (firstFilterType && !secondFilterType) {
                filteredCopy = items.filter(function(item) {
                    return item.type === firstFilterType;
                });

                return sortByName(filteredCopy);
            }

            if (firstFilterType && secondFilterType) {
                filteredCopy = items.filter(function(item) {
                    return item.type === firstFilterType || item.type === secondFilterType;
                });

                return sortByName(filteredCopy);
            }
        }

        // public
        function Store(name) {
            validateStoreName(name);

            this.name = name;
            this._items = [];
        }

        Store.prototype.addItem = function(item) {
            if(!(item instanceof Item)) {
                throw {
                    message: 'You can only add items to a store'
                }
            }

            this._items.push(item);

            return this;
        };

        Store.prototype.getAll = function() {
            return getItemsByFiltersSortedByName(this._items);
        };

        Store.prototype.getSmartPhones = function() {
            return getItemsByFiltersSortedByName(this._items, 'smart-phone');
        };

        Store.prototype.getMobiles = function() {
            return getItemsByFiltersSortedByName(this._items, 'smart-phone', 'tablet');
        };

        Store.prototype.getComputers = function() {
            return getItemsByFiltersSortedByName(this._items, 'pc', 'notebook');
        };

        Store.prototype.filterItemsByType = function(filterType) {
            if (allowedTypes.indexOf(filterType) < 0) {
                throw {
                    message: 'Allowed types are accessory, smart-phone, notebook, pc or tablet.'
                }
            }

            return getItemsByFiltersSortedByName(this._items, filterType);
        };

        Store.prototype.filterItemsByPrice = function(options) {
            var min,
                max,
                filteredByPriceCopy;

            min = 0;
            max = Number.POSITIVE_INFINITY;
            if (options) {
                // will work although 0 is false-like value
                min = options.min || min;
                max = options.max || max;
            }

            filteredByPriceCopy = this._items.filter(function(item) {
                return item.price > min && item.price < max;
            });

            filteredByPriceCopy.sort(function(first, second) {
                return first.price - second.price;
            });

            return filteredByPriceCopy;
        };

        Store.prototype.countItemsByType = function() {
            // predefining the object will give us 0 for the types that are not contained in the store
            var result = {};

            allowedTypes.forEach(function(type) {
                result[type] = 0;
            });

            this._items.forEach(function(item){
                result[item.type] += 1;
            });

            return result;
        };

        Store.prototype.filterItemsByName = function(partOfName) {
            var filteredByPartOfNameCopy,
                partOfNameLower;

            partOfNameLower = partOfName.toLowerCase();

            filteredByPartOfNameCopy = this._items.filter(function(item) {
                return item.name.toLowerCase().indexOf(partOfNameLower) >= 0;
            });

            sortByName(filteredByPartOfNameCopy);

            return filteredByPartOfNameCopy;
        };

        return Store;
    }());

    return Store;
});