(function() {
    "use strict";

    var paper = new Raphael(10, 10, 800, 800);

    // Telerik Logo
    var text = paper.text(285, 100, 'Telerik');
    text.attr({
        'font-weight': 'bold',
        'font-size': 85,
        'font-family': 'Calibri'
    });

    var tradeMark = paper.text(412, 97, 'R');
    tradeMark.attr({
        'font-size': 12,
        'font-weight': 'bold',
        'font-family': 'Calibri',
        'text-anchor': 'start'
    });

    var trademarkCircle = paper.circle(416, 97, 7);
    trademarkCircle.attr({
        'stroke-width': 2
    });

    var slogan = paper.text(320, 150, 'Develop experiences');
    slogan.attr({
        'font-size': 34,
        'font-family': 'Calibri'
    });

    paper.setStart();
    paper.path('M106 89 L117 77 L143 106 L130 119 L117 106 L143 77 L154 89');
    var telerikLogo = paper.setFinish()
        .attr({
            'stroke-width': 9,
            stroke: '#5CE600',
        })
        .translate(-9, -5)
        .scale(1.3, 1.3);

    // Youtube logo
    var you = paper.text(350, 300, 'You');
    you.scale(0.6, 1);
    you.attr({
        'font-weight': 'bold',
        'font-size': 100,
        'font-family': 'Calibri',
        fill: '#4A4A4A'
    });

    var rect = paper.rect(405, 254, 150, 100, 25);
    rect.attr({
        fill: '#EC2828'
    });

    var tube = paper.text(480, 300, 'Tube');
    tube.scale(0.6, 1);
    tube.attr({
        'font-weight': 'bold',
        'font-size': 100,
        'font-family': 'Calibri',
        fill: 'white'
    });
})();