/// <reference path="game-main.js" />
window.addEventListener("load", function load(event) {
    'use strict';
    //remove listener, no longer needed
    window.removeEventListener("load", load, false);

    (function generateGameSettings() {
        var holder = document.getElementById('gameSettings');
        holder.style.fontSize = '1em';
        var pixelS = document.createElement('select');
        pixelS.id = 'pixelSizeValue';
        var pixelSText = document.createElement('span');
        holder.appendChild(pixelSText);
        holder.appendChild(pixelS);
        pixelSText.innerHTML = "Pixel size: ";
        
        var sugestedPixels = [1,2, 5, 10, 15, 20, 25, 30, 50];
        var suggestedObsticles = [300, 200, 100, 50, 40, 20, 15, 10,1];
        var subbestedSpeed = [50, 50, 50, 75, 100, 120, 120, 135, 150];

        for (var i = 0; i < sugestedPixels.length; i++) {
            var currSelection = document.createElement('option');
            currSelection.innerHTML = sugestedPixels[i];
            if (currSelection.innerHTML == '10') {
                currSelection.innerHTML += ' (Recomended)';
                currSelection.selected = 'selected';                    
            }
            pixelS.appendChild(currSelection);
        }
        var obsticlesText = document.createElement('span');
        obsticlesText.innerHTML = ' Obsticles count: ';
        var obsticlesInput = document.createElement('input');
        obsticlesInput.type = 'number';
        obsticlesInput.id = 'obsticlesValue';
        obsticlesInput.style.width = '60px';
        obsticlesInput.value = 50;
        holder.appendChild(obsticlesText);
        holder.appendChild(obsticlesInput);

        var speedText = document.createElement('span');
        speedText.innerHTML = ' Game Delay: ';
        var speedInput = document.createElement('input');
        speedInput.type = 'number';
        speedInput.id = 'speedValue';
        speedInput.style.width = '60px';
        speedInput.value = 75;
        holder.appendChild(speedText);
        holder.appendChild(speedInput);

        pixelS.onchange = function () {
            speedInput.value = subbestedSpeed[pixelS.selectedIndex];
            obsticlesInput.value = suggestedObsticles[pixelS.selectedIndex];
        }

        var button = document.createElement('button');
        button.innerHTML = 'START';
        button.onclick = function () {
            onStartGame();
            holder.style.display = 'none';
        }
        holder.appendChild(button);

        function onStartGame() {
            var canvas = document.getElementById('canvas');
            canvas.style.border = '1px solid black';

            //game settings // 10 - 75 (<50) // 15 - 40 - 100speed / 20 , 25 = 120 gs 30 - 135 gs 50 - 150gs
            var pixelSizeHolder = document.getElementById('pixelSizeValue');
            var pixelSize = parseInt(pixelSizeHolder.options[pixelSizeHolder.selectedIndex].text);
            var gamespeed = parseInt(document.getElementById('speedValue').value);
            var numberOfObsticles = parseInt(document.getElementById('obsticlesValue').value);

            var currentGame = new snakeGame.SnakeGame(canvas, pixelSize, numberOfObsticles, gamespeed);
            currentGame.startGame();
        }
    }());
},false);