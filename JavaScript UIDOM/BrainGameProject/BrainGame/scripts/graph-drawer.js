function createGraph(containerID) {
    var width = document.getElementById(containerID).offsetWidth;

    var xStep = 5;
    var nextPoint = 0;

    var stage = new Kinetic.Stage({
        container: containerID,
        width: width,
        height: document.getElementById(containerID).offsetHeight,
    });

    var layer = new Kinetic.Layer();
    var line = new Kinetic.Line({
        points: [],
        stroke: '#0F0',
        strokeWidth: 5,
        tension: 0.5,
    });

    var scoreStat = new Kinetic.Text({
        x: stage.width() / 2 - 90,
        y: 15,
        text: '9990',
        fontSize: 90,
        fontFamily: 'Calibri',
        fill: '#00FFFF',
        align: 'center'
    });

    var fuelStat = new Kinetic.Text({
        x: 0,
        y: 0,
        text: 'fuel : 100',
        fontSize: 32,
        fontFamily: 'Calibri',
        fill: '#00FFFF',
        align: 'left',
        opacity:0.6,
    })

    var correctAnswersStat = new Kinetic.Text({
        x: stage.width()/ 2,
        y: 0,
        text: 'Correct: 0',
        fontSize: 32,
        fontFamily: 'Calibri',
        fill: '#00FFFF',
        align: 'right',
        opacity:0.6,
    })

    var points = [];
    points.push(0);
    points.push(100);

    layer.add(line);
    layer.add(fuelStat);
    layer.add(correctAnswersStat);
    layer.add(scoreStat);
    stage.add(layer);

    var anim = new Kinetic.Animation(function() {
        line.setPoints(points);
    }, layer);

    anim.start();

    return {
        drawPoint: drawPoint,

        setScore: function (score) {
            scoreStat.setText(Math.round(score));
        },

        setFuel: function (fuel) {
            fuelStat.setText('Fuel : ' + Math.floor(fuel));
        },

        addAnswered: function () {
            var old = correctAnswersStat.getText();
            var ammount = parseInt(old.substr(old.indexOf(':') + 1)) + 1;
            correctAnswersStat.setText("Correct : " + ammount);
        }
    }

    function drawPoint(y) {
        if (nextPoint < width) { nextPoint += xStep }
        points.push(nextPoint);

        points.push(y);

        if (line.attrs.points.length / 2 > width / xStep) {
            points.shift();
            points.shift();
        }

        for (var i = 0; i < line.attrs.points.length; i += 2) {
            line.attrs.points[i] -= xStep;
        }

        line.setPoints(points);
        line.attrs.stroke = getLineColor(y);

        function getLineColor(yHeight) {
            yHeight = Math.min(120, yHeight);
            var red = Math.floor(yHeight * 2.12).toString(16);
            if (red.length == 1) {
                red = red + '0';
            }
            var green = Math.floor(255 - (yHeight * 2.12)).toString(16);
            if (green.length == 1) {
                green = green + 'f';
            }
            return "#" + red + green + "00";
        }
    }
}
