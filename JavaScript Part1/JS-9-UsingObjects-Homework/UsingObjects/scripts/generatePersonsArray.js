function generatePersonsArray(count) {

    var count = count || 20;

    var firstNames = ["Ivan", "Dragan", "Petko", "Gosho", "Pesho"];
    var lastNames = ["Ivanov", "Draganov", "Petkov", "Dimitrov" , "Aprilov"];
    var ages = [18, 22, 27, 42, 65];

    function getPerson(fname, lname, age) {
        return {
            firstName: fname,
            lastName: lname,
            age: age,
        };
    }

    var persons = new Array(count);

    for (var i = 0; i < count; i++) {
        persons[i] = getPerson(
                firstNames[Math.floor((Math.random() * firstNames.length))],
                lastNames[Math.floor((Math.random() * lastNames.length))],
                ages[Math.floor((Math.random() * ages.length))]
            );
    }

    return persons;
}