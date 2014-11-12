$(document).ready(function() {
    $('#date').datepicker();

    var initiatives = $('#create-event-initiatives');
    var seasons = $('#create-event-seasons');
    var hiddenInput =$('#create-event-type');

    $('#publicBtn').on('click', function() {
        initiatives.attr('required','false').hide();
        seasons.attr('required','false').hide();
        hiddenInput.val('public');
    });

    $('#initiativeBasedBtn').on('click', function() {
        initiatives.attr('required','true').show();
        seasons.attr('required','false').hide();
        hiddenInput.val('initiative');
    });

    $('#InitiativeAndSeasonBasedBtn').on('click', function() {
        initiatives.attr('required','true').show();
        seasons.attr('required','true').show();
        hiddenInput.val('season');
    });
});