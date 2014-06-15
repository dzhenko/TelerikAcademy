var mainView = getGridControl('#holder');
var $holder = $('#holder').hide();
var $controls = $('#controls');
var $contentHolder = $('<div />');
var createdRows = [];
var $nestDiv = $('<div />');

function generateTableControls() {
    var cells = parseInt($('#tableCols').val()) | 4;
    $holder.show();
    $controls.html('');

    $('<button />')
            .html('Create Head')
            .on('click', createHead)
            .appendTo($controls);
    $('<button />')
            .html('Create Row')
            .on('click', createRow)
            .appendTo($controls);

    $('<label />')
            .html("For Row Number")
            .attr('for', 'cellNumber')
            .appendTo($nestDiv);

    $('<input />')
            .attr('id', 'cellNumber')
            .attr('type', 'number')
            .attr('placeholder', 'Nested table in Cell')
            .css('width', '60px')
            .appendTo($nestDiv);

    $('<input />')
            .attr('id', 'nestedCellsNum')
            .attr('type', 'number')
            .attr('placeholder', 'Number of cells in Nested Table')
            .css('width', '200px')
            .appendTo($nestDiv);
    $('<button />')
            .html('Create Nested Table')
            .on('click', showNestedControls)
            .appendTo($nestDiv);

    $('<label />')
            .html("Main Table")
            .attr('for', 'mainRadioBut')
            .appendTo($controls);
    $('<input />')
            .attr('type', 'radio')
            .attr('id', 'mainRadioBut')
            .attr('name', 'nested')
            .attr('checked', 'checked')
            .attr('value', 'main')
            .appendTo($controls)
            .change(function () {
                $nestDiv.hide();
                showInputs(cells);
            });

    $('<label />')
            .html("Nested Table")
            .attr('for', 'nestedRadioBut')
            .appendTo($controls);
    $('<input />')
            .attr('type', 'radio')
            .attr('id', 'nestedRadioBut')
            .attr('name', 'nested')
            .attr('value', 'nested')
            .appendTo($controls)
            .change(function () {
                $nestDiv.show();
            });

    $('<hr />').appendTo($controls);

    $nestDiv.appendTo($controls).hide();

    $('<hr />').appendTo($controls);

    showInputs(cells);
    $contentHolder.appendTo($controls)

    $('<hr />').appendTo($controls);
}

function showInputs(num) {
    $contentHolder.html('');
    for (var i = 0; i < num; i++) {
        $('<input />')
            .attr('type', 'text')
            .attr('placeholder', 'Cell ' + (i + 1))
            .appendTo($contentHolder);
    }
}

function showNestedControls() {
    var valueOfNestedCellsNum = $('#nestedCellsNum').val();
    var shownInputs = valueOfNestedCellsNum == "" ? 4 : parseInt(valueOfNestedCellsNum);
    showInputs(shownInputs);
    $nestDiv.hide();
}

// $('#cellNumber').val() - cell index + 1
function createRow() {
    var dataToUse = extractData();
    if ($('#mainRadioBut').is(':checked')) {
        var currentRow = mainView.addRow(dataToUse);
        createdRows.push(currentRow);
        $holder
            .find('tbody > tr')
            .last()
            .hover(
                function (e) {
                    $(e.target).animate({ height: '50px', opacity: '0.5' }, "slow");
                    $(e.target).animate({ height: 0, opacity: '1' }, "slow");
                    $('<div />').html('Place OR Use Nested Table here')
                        .attr('id', 'hoveredInfoDiv')
                        .css('position', 'absolute').css('background-color', '#ff3700')
                        .css('border-radius', '25px').css('border', '3px solid black')
                        .css('left', e.pageX).css('top', e.pageY).fadeIn()
                        .appendTo($controls)
                }, function () {
                    $('#hoveredInfoDiv').fadeOut(500).remove();
                }
            )
            .on('click', function (e) {
                $('#nestedRadioBut').attr('checked', 'checked').change();
                $('#cellNumber').val($(this).index() + 1);
            });
    }
    else {
        var selectedCellNumberIndex = parseInt($('#cellNumber').val()) - 1;
        var functionControler = createdRows[selectedCellNumberIndex];
        functionControler.addRow(dataToUse)
    }
}

function createHead() {
    var dataToUse = extractData();
    if ($('#mainRadioBut').is(':checked')) {
        mainView.addHead(dataToUse);
    }
    else {
        var selectedCellNumberIndex = parseInt($('#cellNumber').val()) - 1;
        var functionControler = createdRows[selectedCellNumberIndex];
        functionControler.addHead(dataToUse);
    }
}

function extractData() {
    var data = [];
    var inputs = $contentHolder.children("input[type='text']");
    for (var i = 0; i < inputs.length; i++) {
        data.push(inputs[i].value == "" ? " - " : inputs[i].value);
    }
    return data;
}