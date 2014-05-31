function getFTIndexes(allGrandparents,allHumans) {
    var depth = 0;
    var xIndexes = [];

    while (allGrandparents.length > 0) {

        if (!xIndexes[depth]) {
            xIndexes[depth] = 0;
        }

        var len = allGrandparents.length;
        var shownPartners = [];

        for (var i = 0; i < len; i++) {
            // some partners were already added no point in adding them again
            if (shownPartners.indexOf(allGrandparents[i].name) >= 0) {
                continue;
            }

            // setting the current element depth and x index (depth is like Y)
            allGrandparents[i].xIndexes = xIndexes[depth]++;
            allGrandparents[i].depth = depth;
    
            // if you have partner it will be a new object to the current one
            if (allGrandparents[i].partner) {
                shownPartners.push(allGrandparents[i].partner.name);
                allGrandparents[i].partner.xIndexes = xIndexes[depth]++;
                allGrandparents[i].partner.depth = depth;
            }

            // if you dont have a partner - you cant have children
            else {
                continue;
            }

            // empty array by default
            var children = allGrandparents[i].children;

            if (children.length === 0) {
                children = allGrandparents[i].partner.children;
            }

            // push all children for the next level
            for (var j = 0; j < children.length; j++) {
                allGrandparents.push(children[j]);
            }
        }

        allGrandparents.splice(0, len);
        depth++;
    }

    return allHumans;
}