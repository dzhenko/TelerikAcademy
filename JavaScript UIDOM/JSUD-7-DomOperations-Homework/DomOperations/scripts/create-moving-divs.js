function generateMovingDivs() {
    var innerHtmls = ["ROUND", "AND", "ROUND", "WE" , "GO"];
    var divs = Array(innerHtmls.length);

    for (var i = 0; i < divs.length; i++) {
        var currDiv = document.createElement('div');
        currDiv.innerHTML = innerHtmls[i];
        styleCurrentDiv(currDiv);
        document.body.appendChild(currDiv);
        divs[i] = currDiv;
    }

    var centerX = 200;
    var centerY = 200;
    var radius = 200;

    var angle = 0;
    setInterval(moveDivs, 100);

    function moveDivs() {
        angle++;
        if (angle == 360) {
            angle = 0;
        }

        for (var i = 0; i < divs.length; i++) {
            //to space out the divs
            var addition = (360 / divs.length) * i;

            var left = centerX + Math.cos((2 * 3.14 / 180) * (angle + addition)) * radius;
            var right = centerY + Math.sin((2 * 3.14 / 180) * (angle + addition)) * radius;
            divs[i].style.left = left + "px";
            divs[i].style.top = right + "px";
        }
    }

    function styleCurrentDiv(divElement) {
        divElement.style.textAlign = 'center';
        divElement.style.lineHeight = '120px';
        divElement.style.width = '120px';
        divElement.style.height = '120px';
        divElement.style.border = '3px solid red';
        divElement.style.borderRadius = '120px';
        divElement.style.position = 'absolute';
    }
}