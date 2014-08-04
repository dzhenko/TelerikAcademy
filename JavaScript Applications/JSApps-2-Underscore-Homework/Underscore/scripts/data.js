var data = (function () {
    // take object with keys and array of possible values and returns an array of such randomized objects
    function generateRandomObject(objectToClone, numberOfClones) {
        var result = [];

        for (var i = 0; i < numberOfClones; i++) {
            var currObj = {};

            for (var prop in objectToClone) {
                currObj[prop] = objectToClone[prop][Math.floor(Math.random() * objectToClone[prop].length)];
            }

            result.push(currObj)
        }

        return result;
    }

    var firstNames = ['Pesho', 'Gosho', 'Ivan', 'Stanimir', 'Zarko', 'Dimo', 'Narcis'];
    var lastNames = ['Petrov', 'Georgiev', 'Dimitrov', 'Dimitrov', 'Iliev', 'Markov', 'Angelov'];
    var ages = [16, 18, 20, 22, 24, 26, 28, 30];
    var marks = [3.14, 3.48, 4.17, 4.43, 4.87, 5.23, 5.57, 5.96];

    var students = generateRandomObject({
        firstName: firstNames,
        lastName: lastNames,
        age: ages,
        mark: marks
    }, 100);

    var animals = [
        { name: 'birdy', species: 'Bird', legs: 2 },
        { name: 'kwa-kwa', species: 'ostrich', legs: 2 },
        { name: 'evil meow', species: 'Cat', legs: 4 },
        { name: 'DOGE', species: 'Dog', legs: 4 },
        { name: 'Shisho', species: 'Elephant', legs: 4 },
        { name: 'buba', species: 'insect', legs: 8 },
        { name: 'NOOO', species: 'Tick', legs: 8 },
        { name: '8 eyed wonder', species: 'Spider', legs: 8 },
        { name: 'kill it before it lays eggs', species: 'Centipede', legs: 100 },
        { name: 'flyer 1', species: 'Bird', legs: 2 },
        { name: 'head in sand', species: 'ostrich', legs: 2 },
        { name: 'even more evil meow', species: 'Cat', legs: 4 },
        { name: 'best dog ever', species: 'Dog', legs: 4 },
        { name: 'Africa owner', species: 'Elephant', legs: 4 },
        { name: 'eeeww', species: 'insect', legs: 8 },
        { name: 'spider man creator', species: 'Spider', legs: 8 },
        { name: 'every day pigeon', species: 'Bird', legs: 2 },
        { name: 'the king of humans', species: 'Cat', legs: 4 },
        { name: 'Woof!', species: 'Dog', legs: 4 },
        { name: 'No room for me', species: 'Elephant', legs: 4 },
        { name: 'spider man creator\'s mother', species: 'Spider', legs: 8 },
        { name: 'Human owner #421', species: 'Cat', legs: 4 },
        { name: 'Rex', species: 'Dog', legs: 4 },
        { name: 'frog food', species: 'insect', legs: 8 },
        { name: 'kill it with fire', species: 'Centipede', legs: 100 }
    ];

    var books = [
        { author: 'Ivan Vazov', name: 'Neotdavna' },
        { author: 'Hristo Botev', name: 'Maice si' },
        { author: 'Ivan Vazov', name: 'Chichovci' },
        { author: 'Elisaveta Bagryana', name: 'Zvezda na moryaka' },
        { author: 'Hristo Botev', name: 'Elegiya' },
        { author: 'Ivan Vazov', name: 'Nora' },
        { author: 'Hristo Botev', name: 'Na proshtavane' },
        { author: 'Elisaveta Bagryana', name: 'Syrce choveshko' },
        { author: 'Ivan Vazov', name: 'Nemili-nedragi' },
    ];

    var humans = generateRandomObject({
        firstName: firstNames,
        lastName: lastNames
    }, 100);

    return {
        students: students,
        animals: animals,
        books: books,
        humans: humans
    }
}());