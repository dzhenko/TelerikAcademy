window.onload = function () {
    // background
    var paper = new Raphael('wrapperBackground');
    var background = paper.image('images/mario_level_1.png', 0, 0, 256, 240);

    // mario
    var stage = new Kinetic.Stage({
        container: 'wrapperMario',
        width: 256,
        height: 280
    });

    var layer = new Kinetic.Layer();

    var marioSprites = new Image();
    marioSprites.src = "images/mario_sheet_sprites.png";
    var framecounter = 8;
    marioSprites.onload = function() {
        var mario = new Kinetic.Sprite({
            x: 130,
            y: 183,
            image: marioSprites,
            animation: 'stayRight',
            animations: {
                moveRight:[
                    230, 50, 25, 33,
                    260, 50, 25, 33,
                    290, 50, 25, 33,
                    260, 50, 25, 33,
                ],
                moveLeft:[
                    140, 50, 25, 33,
                    110, 50, 25, 33,
                    80, 50, 25, 33,
                    110, 50, 25, 33,
                ],
                stayRight:[
                    260, 50, 25, 33,
                    260, 50, 25, 33,
                    260, 50, 25, 33,
                    260, 50, 25, 33,
                ],
                stayLeft:[
                    110, 50, 25, 33,
                    110, 50, 25, 33,
                    110, 50, 25, 33,
                    110, 50, 25, 33,
                ]
            },
            frameRate: framecounter,
            frameIndex: 0
        });

        layer.add(mario);

        stage.add(layer);

        mario.start();

        var moveRight = true;

        window.addEventListener("keydown", function(e) {
            switch(e.keyCode){
                case 37: // LeftArrow
                    if (framecounter == 8) {
                        mario.animation('moveLeft');
                        framecounter = 0;
                    }
                    framecounter++;
                    moveRight = false;
                    mario.setX(mario.getX() - 3);
                    if (mario.getX() < 0) {
                        mario.setX(0);
                    }
                break;

                case 39: // RightArrow
                    if (framecounter == 8) {
                        mario.animation('moveRight');
                        framecounter = 0;
                    }
                    framecounter++;
                    moveRight = true;
                    mario.setX(mario.getX() + 3);
                    if (mario.getX() > 230) {
                        mario.setX(230);
                    }
                break;
            }
            e.preventDefault();
        });

        window.addEventListener("keyup", function() {
            if (moveRight) {
                mario.animation('stayRight');
            }
            else {
                mario.animation('stayLeft');
            }
            framecounter = 8;
            e.preventDefault();
        });
    };
};