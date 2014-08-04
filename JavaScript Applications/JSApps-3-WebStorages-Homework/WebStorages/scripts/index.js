var theNumber = [];
while (theNumber.length < 4) {
    var candidate = (Math.floor(Math.random() * 10));
    if (theNumber.indexOf(candidate) >= 0) {
        continue;
    }
    if (theNumber.length === 0 && candidate === 0) {
        continue;
    }

    theNumber.push(candidate);
}

theNumber = theNumber.join('');
var guesses = document.getElementById('guesses');
var guessesCounter = document.getElementById('count');
var hallOfFame = document.getElementById('hall');
var count = 0;
var currDigitIndex = 0;
var digits = [document.getElementById('digit1'), document.getElementById('digit2'), document.getElementById('digit3'), document.getElementById('digit4'), ]
window.addEventListener('keypress', function (ev) {
    ev.preventDefault();
    if (currDigitIndex === 4) {
        return;
    }

    switch (ev.keyCode) {
        case 48:
            if (digits.innerHTML === '') {
                currDigitIndex--;
            }
            else {
                digits[currDigitIndex].innerHTML = '0';
            }
            break;
        case 49: digits[currDigitIndex].innerHTML = '1'; break;
        case 50: digits[currDigitIndex].innerHTML = '2'; break;
        case 51: digits[currDigitIndex].innerHTML = '3'; break;
        case 52: digits[currDigitIndex].innerHTML = '4'; break;
        case 53: digits[currDigitIndex].innerHTML = '5'; break;
        case 54: digits[currDigitIndex].innerHTML = '6'; break;
        case 55: digits[currDigitIndex].innerHTML = '7'; break;
        case 56: digits[currDigitIndex].innerHTML = '8'; break;
        case 57: digits[currDigitIndex].innerHTML = '9'; break;
        default: currDigitIndex--; break;
    }
    currDigitIndex++;
});

document.getElementById('btn').addEventListener('click', guessNumber);

function guessNumber() {
    if (currDigitIndex !== 4) {
        document.getElementById('inform').classList.add('panel-danger');
        document.getElementById('inform').classList.remove('panel-primary');
        return;
    }
    document.getElementById('inform').className = 'panel panel-primary';

    var number = digits[0].innerHTML + digits[1].innerHTML + digits[2].innerHTML + digits[3].innerHTML;

    count++;
    var sheeps = 0;
    var rams = 0;

    for (var i = 0; i < number.length; i++) {
        if (theNumber.indexOf(number[i]) >= 0) {
            if (theNumber.indexOf(number[i]) === i) {
                rams++;
            }
            else {
                sheeps++;
            }
        }
    }

    if (rams === 4) {
        endGame(count);
    }

    currDigitIndex = 0;
    digits[0].innerHTML = '_';
    digits[1].innerHTML = '_';
    digits[2].innerHTML = '_';
    digits[3].innerHTML = '_';

    var oldGuesses = guesses.innerHTML;
    guesses.innerHTML = '<li class="list-group-item"><span class="badge">' + sheeps + '</span><span class="badge">' + rams + '</span>' + number + '</li>';
    guesses.innerHTML += oldGuesses;
    guessesCounter.innerHTML = count;
}

function endGame(count) {
    var name = prompt('Enter your name champion', 'Unnamed champion');
    saveScore(name, count);
    showScore();
}

function saveScore(name, currScore) {
    var saved = localStorage.getItem('highScores');

    if (!saved) {
        saved = [];
    }
    else {
        saved = JSON.parse(saved);
    }

    saved.push({
        name: name,
        guesses: currScore
    });

    saved.sort(function (a, b) {
        return a.guesses - b.guesses;
    });

    localStorage.setItem('highScores', JSON.stringify(saved));
}

function showScore() {
    var savedScores = localStorage.getItem('highScores');
    hallOfFame.innerHTML = '';

    if (!savedScores) {
        savedScores = [];
    }
    else {
        savedScores = JSON.parse(savedScores);
    }
    for (var i = 0; i < Math.min(5, savedScores.length) ; i++) {
        hallOfFame.innerHTML += '<li class="list-group-item lead"><span class="text-primary">' + savedScores[i].name + '</span> ' + savedScores[i].guesses + '</li>';
    }

}

showScore();