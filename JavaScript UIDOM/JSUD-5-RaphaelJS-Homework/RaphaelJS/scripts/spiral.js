(function(){
    'use strict'
   var paper = Raphael(50, 10, 700, 700);

   function drawSpiral(centerX, centerY, a, b) {
        var spiralPoints = 'M' + centerX + ' ' + centerY;

        for (var i = 0; i < 300; i++) {
            var angle = 0.1 * i,
            // Archimedian spiral equation r = a + b * angle;
            // a - the offset from the center
            // b - the distance between turnings
            x = centerX + (a + b * angle) * Math.cos(angle),         
            y = centerY + (a + b * angle) * Math.sin(angle);

            spiralPoints += ' L' + x + ' ' + y;
         }

        var spiral = paper.path(spiralPoints)
            .attr({
            stroke: 'orange',
            'stroke-width': 8
        })
            .animate({
                transform: "r -3600",
            }, 45000);
    }
    // rotate !
	drawSpiral(300, 300, 0, 8);
})();