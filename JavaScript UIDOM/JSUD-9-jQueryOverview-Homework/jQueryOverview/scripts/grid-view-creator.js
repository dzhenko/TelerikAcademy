function getGridControl(holderQuerry) {
    var $table = $('<table />').appendTo($(holderQuerry));
    var $newTBody = $('<tbody />').appendTo($table);

    function addRow(data) {
        var $newRow = $('<tr />').appendTo($newTBody);

        for (var i = 0; i < data.length; i++) {
            $('<td />').html(data[i]).appendTo($newRow);
        }

        return {
            addRow: function (dataToUse) {
                var $nextRow = $newRow.next();
                var $currNewTBody = $nextRow.children().first().children('table').first().children('tbody');

                if (!$nextRow.hasClass('nested')) {
                    $nextRow = $('<tr />').addClass('nested');
                    $newRow.after($nextRow);

                    var $nextCol = $('<td />')
                        .attr('colspan', $newRow.children().length)
                        .appendTo($nextRow);

                    $currNewTable = $('<table />').appendTo($nextCol);
                    $currNewTBody = $('<tbody />').appendTo($currNewTable);
                }
                else if ($currNewTBody.length < 1) {
                    $currNewTBody = $('<tbody />').appendTo($nextRow.children().first().children('table').first());
                }

                var $currNewRow = $('<tr />').appendTo($currNewTBody);

                for (var i = 0; i < dataToUse.length; i++) {
                    $('<td />').html(dataToUse[i]).appendTo($currNewRow);
                }
            },

            addHead: function (dataToUse) {
                var $nextRow = $newRow.next();
                var $currNewTable = $nextRow.children('table');

                if (!$nextRow.hasClass('nested')) {
                    $nextRow = $('<tr />').addClass('nested');
                    $newRow.after($nextRow);

                    var $nextCol = $('<td />')
                        .attr('colspan', $newRow.children().length)
                        .appendTo($nextRow);

                    $currNewTable = $('<table />').appendTo($nextCol);
                }

                var $oldHead = $currNewTable.children('thead');
                $oldHead.remove();

                var $currNewHead = $('<thead />').appendTo($currNewTable);
                var $rowToUse = $('<tr />').appendTo($currNewHead);

                for (var i = 0; i < dataToUse.length; i++) {
                    $('<th />').html(dataToUse[i]).appendTo($rowToUse);
                }
            }
        }
    }

    function addHead(data) {
        $table.children('thead').remove();

        var $newHead = $('<thead />').appendTo($table);
        var $rowToUse = $('<tr />').appendTo($newHead);

        for (var i = 0; i < data.length; i++) {
            $('<th />').html(data[i]).appendTo($rowToUse);
        }
    }

    return {
        addHead: addHead,
        addRow: addRow,
    }
}