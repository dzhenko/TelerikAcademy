function getFTDrawer(containerID) {
    var constants = {
        kinectColor: 'yellowgreen',
        kinectTextColor: 'black',
        innerRectHeight: 50,
        innerRectWidth: 200,
        innerTextFont: 18,
        arrowSize: 5,
        beizerStrokeWidth: 2,
    };

    var layer = new Kinetic.Layer();

    // combined function to draw a rectangle with text in it
    function innerGetRectWithText(x, y, cornerRad, text) {
        var currRect = new Kinetic.Rect({
            x: x,
            y: y,
            width: constants.innerRectWidth,
            height: constants.innerRectHeight,
            strokeWidth: 3,
            stroke: constants.kinectColor,
            cornerRadius: cornerRad,
        });

        var currText = new Kinetic.Text({
            x: x,
            y: y + (constants.innerRectHeight / 3),
            text: text,
            fontSize: constants.innerTextFont,
            fontFamily: 'Calibri',
            width: constants.innerRectWidth,
            align: 'center',
            fill: constants.kinectTextColor,
        });

        layer.add(currRect);
        layer.add(currText);
    }

    function makeFemaleRect(x, y, name) {
        innerGetRectWithText(x, y, 25, name);
    }

    function makeMaleRect(x, y, name) {
        innerGetRectWithText(x, y, 10, name);
    }

    // builds links between malesAndFemales
    function innerLinkMaleToFemale(leftX, leftY) {
        var currLine = new Kinetic.Shape({
            drawFunc: function (context) {
                context.beginPath();
                context.moveTo(leftX + constants.innerRectWidth, leftY + constants.innerRectHeight / 2);
                context.lineTo(leftX + constants.innerRectWidth * 1.5, leftY + constants.innerRectHeight / 2);
                context.stroke(this);
            },
            strokeWidth: constants.beizerStrokeWidth,
            stroke: constants.kinectColor,
        });
        layer.add(currLine);
    }

    // build links between child and parents
    function makeConnection(leftParentX, leftParentY, childX, childY) {
        var startX = leftParentX + constants.innerRectWidth * 1.25;
        var startY = leftParentY + constants.innerRectHeight / 2;
        var endX = childX + constants.innerRectWidth / 2;
        var endY = childY;
        innerGetBezierLine(startX, startY, endX, endY, layer);

        function innerGetBezierLine(stX, stY, eX, eY) {
            var beizerCPdx = Math.abs(eX - stX) / 10;
            var beizerCPdY = Math.abs(eY - stY) * 0.95;
            var currLine = new Kinetic.Shape({
                drawFunc: function (context) {
                    context.beginPath();
                    context.moveTo(stX, stY);
                    context.bezierCurveTo(stX + beizerCPdx, stY + beizerCPdY,
                                          eX - beizerCPdx, eY - beizerCPdY,
                                          eX, eY);
                    context.stroke(this);
                    context.beginPath();
                    context.lineTo(eX + constants.arrowSize, eY - constants.arrowSize);
                    context.lineTo(eX - constants.arrowSize, eY - constants.arrowSize);
                    context.lineTo(eX, eY);
                    context.fill(this);
                },
                strokeWidth: constants.beizerStrokeWidth,
                fill: constants.kinectColor,
                stroke: constants.kinectColor,
            });

            layer.add(currLine);
        }
    }

    function renderTree(FTMembers) {
        // finds the max number of elements to be present on one level
        var stageSize = (function () {
            var maxWidth = 0;
            var maxDepth = 0;
            for (var i = 0; i < FTMembers.length; i++) {
                if (maxWidth < FTMembers[i].xIndexes) {
                    maxWidth = FTMembers[i].xIndexes;
                }
                if (maxDepth < FTMembers[i].depth) {
                    maxDepth = FTMembers[i].depth;
                }
            }
            return {
                maxXIndexes: maxWidth + 1,
                maxDepth: maxDepth + 1,
            };
        }());

        // constructs the canvas depending on the abovementioned value
        var stage = new Kinetic.Stage({
            container: containerID,
            width: stageSize.maxXIndexes * constants.innerRectWidth * 1.5,
            height: stageSize.maxDepth * constants.innerRectHeight * 2,
        });

        var shownHumans = [];

        for (var i = 0; i < FTMembers.length; i++) {
            if (shownHumans.indexOf(FTMembers[i].name) < 0) {
                var coords = innerGetCoords(FTMembers[i]);

                if (FTMembers[i].female) {
                    makeFemaleRect(coords.X, coords.Y, FTMembers[i].name);

                    if (FTMembers[i].partner) {
                        var pCoords = innerGetCoords(FTMembers[i].partner);

                        // gets the left side parent
                        var connectionX = Math.min(coords.X, pCoords.X);
                        var connectionY = Math.min(coords.Y, pCoords.Y);

                        innerLinkMaleToFemale(connectionX, connectionY);
                    }
                }
                else {
                    makeMaleRect(coords.X, coords.Y, FTMembers[i].name);
                }

                // if there is a parent - show the link
                if (FTMembers[i].parent) {
                    var coords1 = innerGetCoords(FTMembers[i].parent);
                    var coords2 = innerGetCoords(FTMembers[i].parent.partner);

                    var minX = Math.min(coords1.X, coords2.X);
                    var minY = Math.min(coords1.Y, coords2.Y);

                    makeConnection(minX, minY, coords.X, coords.Y);
                }

                shownHumans.push(FTMembers[i].name);
            }
        }

        function innerGetCoords(human) {
            return {
                X: human.xIndexes * constants.innerRectWidth * 1.5,
                Y: human.depth * constants.innerRectHeight * 2,
            };
        }

        stage.add(layer);
    }

    return {
        renderTree: renderTree,
        constants: constants,
    };
}