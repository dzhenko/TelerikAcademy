function createRandomDivs(divsCount) {
    
    var frag = document.createDocumentFragment();

    for (var i = 0; i < divsCount; i++) {
        // frag.appendChild(styleCurrentDiv(document.createElement('div'))); not KPK friendly
        var currDiv = document.createElement('div');
        styleCurrentDiv(currDiv);
        frag.appendChild(currDiv);
    }

    return frag;

    function styleCurrentDiv(currDivToStyle) {
        currDivToStyle.style.width = getRandomNumber(20, 100) + "px";
        currDivToStyle.style.height = getRandomNumber(20, 100) + "px";

        currDivToStyle.style.backgroundColor = getRandomColor();
        currDivToStyle.style.color = getRandomColor();

        currDivToStyle.style.position = 'absolute';
        currDivToStyle.style.top = getRandomNumber(0, screen.height - 220) + "px";
        currDivToStyle.style.left = getRandomNumber(0, screen.width - 120) + "px";

        currDivToStyle.innerHTML = '<strong>div</strong>';
        currDivToStyle.style.textAlign = 'center';

        currDivToStyle.style.border = "" + getRandomNumber(0, 100) + "px " + "solid " + getRandomColor();
        currDivToStyle.style.borderWidth = getRandomNumber(1, 20) + "px";
        currDivToStyle.style.borderRadius = getRandomNumber(1, 100) + "px";
        currDivToStyle.style.borderColor = getRandomColor();
        currDivToStyle.style.borderStyle = ['dashed', 'solid', 'dotted'][getRandomNumber(0, 2)];

        function getRandomColor() {
            return "#" + (Math.round(Math.random() * 0XFFFFFF)).toString(16);
        }

        function getRandomNumber(min, max) {
            return Math.floor(Math.random() * (max - min + 1)) + min;
        }
    }
}