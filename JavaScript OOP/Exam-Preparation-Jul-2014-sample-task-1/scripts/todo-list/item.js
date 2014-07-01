define(function () {
    'use strict';
    var Item;
    Item = (function () {
        function Item(content) {
            if (typeof content !== 'string') {
                throw new Error('Item content must be string');
            }

            this.getData = function () {
                return {
                    content: content
                }
            }
        }

        return Item;
    })();

    return Item;
});