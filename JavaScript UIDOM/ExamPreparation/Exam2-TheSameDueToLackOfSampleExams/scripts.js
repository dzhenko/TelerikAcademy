function createCalendar(qSelector, eventsData) {
    var events = prepareEvents(eventsData);
    var allDays = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];

    var holderDiv = document.createElement('div');
    styleHolderDiv(holderDiv);
    document.querySelector(qSelector).appendChild(holderDiv);

    for (var i = 0; i < 30; i++) {
        var currDay = document.createElement('p');
        createCurrDayContent(currDay, i + 1);
        styleCurrDay(currDay);
        holderDiv.appendChild(currDay);
    }

    holderDiv.addEventListener('mouseover', function (e) {
        var targetHeading = getHeadingTarget(e.target);
        if (targetHeading) {
            targetHeading.style.backgroundColor = 'gray';
        }
    });

    holderDiv.addEventListener('mouseout', function (e) {
        var targetHeading = getHeadingTarget(e.target);
        if (targetHeading) {
            targetHeading.style.backgroundColor = 'lightgray';
        }
    });

    function getHeadingTarget(el) {
        if (el instanceof HTMLSpanElement) {
            return el.parentNode.firstElementChild;
        }
        else if (el instanceof HTMLParagraphElement) {
            return el.firstElementChild;
        }
        else if (el instanceof HTML) {
            return el.firstElementChild;
        }
        else if (el instanceof HTMLHeadElement) {
            return el;
        }
    }

    function styleHolderDiv(elementToStyle) {
        elementToStyle.style.width = 720 + 'px';
        elementToStyle.style.height = 610 + 'px';
        elementToStyle.style.margin = 0;
        elementToStyle.style.padding = 0;
        elementToStyle.style.borderCollapse = 'collapse';
    }

    function createCurrDayContent(dayDiv, index) {
        var heading = document.createElement('h4');
        heading.innerHTML = allDays[(index - 1) % 7] + " " + index + " June 2014";
        styleCurrHeading(heading);

        var content = document.createElement('span');
        if (events[index]) {
            content.innerHTML = events[index].hour + " <strong>" + events[index].title + "</strong>";
        }
        styleCurrContent(content);

        dayDiv.appendChild(heading);
        dayDiv.appendChild(content);

        function styleCurrContent(elementToStyle) {
            elementToStyle.style.cssFloat = 'left';
            elementToStyle.style.margin = 0;
            elementToStyle.style.padding = 0;
        }

        function styleCurrHeading(elementToStyle) {
            elementToStyle.style.backgroundColor = 'lightgray';
            elementToStyle.style.fontSize = 12 + 'px';
            elementToStyle.style.margin = 0;
            elementToStyle.style.paddingTop = '3px';
            elementToStyle.style.height = 20 + 'px';
            elementToStyle.style.borderBottom = '1px solid #000';
        }
    }

    function styleCurrDay(elementToStyle) {
        elementToStyle.style.textAlign = 'center';
        elementToStyle.style.width = 100 + 'px';
        elementToStyle.style.height = 120 + 'px';
        elementToStyle.style.margin = 0;
        elementToStyle.style.padding = 0;
        elementToStyle.style.border = '1px solid #000';
        elementToStyle.style.display = 'inline-block';
    }

    function prepareEvents(data) {
        var result = [];
        for (var i = 0; i < data.length; i++) {
            result[data[i].date] = data[i];
        }

        return result;
    }
}