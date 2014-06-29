function createCalendar(qSelector, events) {
    var calendar = document.createElement('div');
    var asd = document.querySelector(qSelector);
    asd.appendChild(calendar);

    var days = new Array();
    days.push("Sun"); days.push("Mon"); days.push("Tue"); days.push("Wed"); days.push("Thu"); days.push("Fri"); days.push("Sat");

    var orderedEventArray = orderEvents(events);

    calendar.style.width = '720px';
    calendar.style.height = '610px';
    calendar.style.margin = '0';
    calendar.style.padding = '0';
    calendar.style.fontSize = '12px';
    calendar.style.borderCollapse = 'collapse';


    for (var i = 0; i < 30; i++) {
        var currDay = createDay();
        calendar.appendChild(currDay);

        var currDescription = createDescription(i);
        currDay.appendChild(currDescription);

        var currText = createText(i);
        currDay.appendChild(currText);
    }

    function createDay() {
        var currentDayDiv = document.createElement('div');

        currentDayDiv.style.display = 'inline-block';
        currentDayDiv.style.border = '1px solid black';
        currentDayDiv.style.minWidth = '100px';
        currentDayDiv.style.minHeight = '120px';
        currentDayDiv.style.margin = '0';
        currentDayDiv.style.padding = '0';

        return currentDayDiv;
    }


    function createDescription(index) {
        var currentDescription = document.createElement('div');
        currentDescription.style.minWidth = '100px';
        currentDescription.style.minHeight = '20px';
        currentDescription.style.margin = '0';
        currentDescription.style.padding = '0';
        currentDescription.style.borderBottom = '1px solid black';
        currentDescription.style.textAlign = 'center';
        currentDescription.innerHTML = "<strong>" + days[index % 7] + " " + (index + 1) + " June 2014" + "</strong>";

        return currentDescription;
    }

    function createText(index) {
        var currentText = document.createElement('div');
        currentText.style.minWidth = '100px';
        currentText.style.minHeight = '100px';
        currentText.style.margin = '0';
        currentText.style.padding = '0';
        currentText.style.borderBottom = '1px solid black';

        if (orderedEventArray[index]) {
            currentText.innerHTML = orderedEventArray[index].hour + '&nbsp;' +orderedEventArray[index].date +" <strong>" + orderedEventArray[index].title + "</strong>";
        }

        return currentText;
    }

    function orderEvents(evnts) {
        var result = [];

        for (var i = 0; i < evnts.length; i++) {
            result[evnts[i].date] = evnts[i];
        }

        return result;
    }
}