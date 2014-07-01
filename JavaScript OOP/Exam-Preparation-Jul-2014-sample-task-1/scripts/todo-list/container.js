define(['./section'], function (Section) {
    'use strict';
    var Container;
    Container = (function () {
        function Container() {
            var allSections = [];

            this.add = function (section) {
                if (section instanceof Section) {
                    allSections.push(section);
                }
                else {
                    throw new Error('You can add only sections to a container');
                }
            };

            this.getData = function () {
                var allData = [];

                for (var i = 0; i < allSections.length; i+=1) {
                    allData.push(allSections[i].getData());

                }

                return allData;
            }
        }

        return Container;
    }());

    return Container;
});