function onButtonClick(event, args) {
    'use strict';
    var currentWindow = window;
    var currentBrowser = currentWindow.navigator.appCodeName;
    var browserIsMozilla = currentBrowser === "Mozilla";

    if (browserIsMozilla) {
        alert("Yes");
    }
    else {
        alert("No");
    }
}
