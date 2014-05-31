function getFTObjects(familyMembers) {
    'use strict';

    // constructor function for a human object
    function Human(name) {
        this.parent = false;
        this.name = name;
        this.partner = false;
        this.children = [];
        this.female = false;
    }

    // creates a human for each of the properties of the json objects in family members
    var allHumans = (function () {

        // the end array to return
        var allHumansArray = [];

        for (var i = 0; i < familyMembers.length; i++) {
            var currHuman = getCurrentHuman(familyMembers[i].mother);
            currHuman.female = true;

            // if the partner has not been set - set it here as well as the partner of the partner!
            if (!currHuman.partner) {
                currHuman.partner = getCurrentHuman(familyMembers[i].father);
                currHuman.partner.partner = currHuman;
            }

            // for all the children - creates (or gets) a child and sets its parent property
            for (var j = 0; j < familyMembers[i].children.length; j++) {
                var currChild = getCurrentHuman(familyMembers[i].children[j]);
                currChild.parent = currHuman;

                currHuman.children.push(currChild);
            }
        }

        return allHumansArray;

        // checks the array of humans and if there is no object with this name creates a new one, pushes it in the array and returns it
        // if there is one already - returns it instead
        function getCurrentHuman(currMotherString) {
            for (var i = 0; i < allHumansArray.length; i++) {

                // you can imagine duplicate names are not allowed
                if (currMotherString == allHumansArray[i].name) {
                    return allHumansArray[i];
                }
            }

            var newHuman = new Human(currMotherString);
            allHumansArray.push(newHuman);

            return newHuman;
        }
    }());

    // checks and returns all those humans, who has no parent but have children (they are the roots of the family tree).
    var allGrandparents = (function () {
        var grandparents = [];

        for (var i = 0; i < allHumans.length; i++) {
            if (!allHumans[i].parent && allHumans[i].children.length > 0) {
                grandparents.push(allHumans[i]);
            }
        }

        return grandparents;
    }());

    return {
        allHumans: allHumans,

        allGrandparents: allGrandparents,
    }
}