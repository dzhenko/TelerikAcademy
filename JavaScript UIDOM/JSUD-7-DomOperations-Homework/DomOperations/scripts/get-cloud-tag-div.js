function generateTagCloud(words, minFont, maxFont) {

    var ocurences = {};

    //counting the words
    for (var i = 0; i < words.length; i++) {
        var currWord = words[i].toLowerCase().trim();

        if (!ocurences[currWord]) {
            ocurences[currWord] = 0;
        }

        ocurences[currWord]++;
    }

    var mostCommon = 0;
    var leastCommon = words.length + 1;

    for (var word in ocurences) {
        if (mostCommon < ocurences[word]) {
            mostCommon = ocurences[word];
        }

        if (leastCommon > ocurences[word]) {
            leastCommon = ocurences[word];
        }

        console.log(ocurences[word]);
    }

    var allFontsCount = mostCommon - leastCommon;

    var fontDifference = maxFont - minFont;

    var oneStep = fontDifference / allFontsCount;

    var resultDiv = document.createElement('div');

    for (var word in ocurences) {
        var currSpan = document.createElement('span');
        var currSize = ((ocurences[word] - 1) * oneStep);
        currSize += Number(minFont);
        currSpan.style.fontSize = currSize + "px";
        currSpan.innerHTML = word;
        resultDiv.appendChild(currSpan);
        resultDiv.innerHTML += " ";
    }
    resultDiv.style.border = "1px solid #000000";
    resultDiv.style.width = 180 + "px";
    resultDiv.style.padding = "5px";


    return resultDiv;
}