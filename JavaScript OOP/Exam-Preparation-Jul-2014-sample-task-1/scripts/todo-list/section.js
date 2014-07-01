define(['./item'], function (Item) {
    'use strict';
    var Section;
    Section = (function () {
        function Section(title) {
            if (typeof title !== 'string') {
                throw new Error('Section title must be string');
            }

            var allItems = [];

            this.add = function (item) {
                if (item instanceof Item) {
                    allItems.push(item);
                }
                else {
                    throw new Error('You can add only items to a section');
                }
            };

            this.getData = function () {
                var allData = {
                    title: title,
                    items: []
                };

                for (var i = 0; i < allItems.length; i += 1) {
                    allData.items.push(allItems[i].getData());

                }

                return allData;
            }
        }

        return Section;
    }());

    return Section;
});