function generateTable(holderQuerry,data) {
    var $table = $('<table />').appendTo($(holderQuerry));

    // generating header
    var $tHeader = $('<thead />').appendTo($table);

    var $headRow = $('<tr />').appendTo($tHeader);

    for (var propName in allStudents[0]) {
        $('<th />')
            .html(makePropNameCorrectText(propName))
            .appendTo($headRow);
    }

    // generating body
    var $tbody = $('<tbody />').appendTo($table);

    for (var i = 0; i < allStudents.length; i++) {
        var $currRow = $('<tr />').appendTo($tbody);

        var currStudent = allStudents[i];

        for (var stProp in currStudent) {
            $('<td />')
                .html(currStudent[stProp])
                .appendTo($currRow);
        }
    }

    // from camel case to standard text
    function makePropNameCorrectText(prop) {
        var newPropName = prop[0].toUpperCase();
        for (var i = 1; i < prop.length; i++) {
            // capital letter
            if (prop.charCodeAt(i) < 97) {
                newPropName += " ";
            }
            newPropName += prop[i];
        }

        return newPropName;
    }
}