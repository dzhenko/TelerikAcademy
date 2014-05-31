function getFTData1() {
    return [
    {
        mother: 'Maria Petrova',
        father: 'Georgi Petrov',
        children: ['Teodora Petrova', 'Peter Petrov']
    },
    {
        mother: 'Petra Stamatova',
        father: 'Todor Stamatov',
        children: ['Teodor Stamatov', 'Boris Opanov', 'Maria Petrova']
    },
    {
        mother: 'Boriana Stamatova',
        father: 'Teodor Stamatov',
        children: ['Martin Stamatov', 'Albena Dimitrova']
    },
    {
        mother: 'Albena Dimitrova',
        father: 'Ivan Dimitrov',
        children: ['Doncho Dimitrov', 'Ivaylo Dimitrov']
    },
    {
        mother: 'Donika Dimitrova',
        father: 'Doncho Dimitrov',
        children: ['Vladimir Dimitrov', 'Iliana Dobreva']
    },
    {
        mother: 'Juliana Petrova',
        father: 'Peter Petrov',
        children: ['Dimitar Petrov', 'Galina Opanova']
    },
    {
        mother: 'Iliana Dobreva',
        father: 'Delian Dobrev',
        children: ['Dimitar Dobrev', 'Galina Pundiova']
    },
    {
        mother: 'Galina Pundiova',
        father: 'Martin Pundiov',
        children: ['Dimitar Pundiov', 'Todor Pundiov']
    },
    {
        mother: 'Maria Pundiova',
        father: 'Dimitar Pundiov',
        children: ['Georgi Pundiov', 'Stoian Pundiov']
    },
    {
        mother: 'Dobrinka Pundiova',
        father: 'Georgi Pundiov',
        children: ['Pavel Pundiov', 'Marian Pundiov']
    },
    {
        mother: 'Elena Pundiova',
        father: 'Marian Pundiov',
        children: ['Kamen Pundiov', 'Hristina Ivancheva']
    },
    {
        mother: 'Hristina Ivancheva',
        father: 'Martin Ivanchev',
        children: ['Kamen Ivanchev', 'Dpnv Created', 'Evgeny Ivanchev']
    },
    {
        mother: 'Maria Ivancheva',
        father: 'Kamen Ivanchev',
        children: ['Ivo Ivanchev', 'Delian Ivanchev']
    },
    {
        mother: 'Nadejda Ivancheva',
        father: 'Ivo Ivanchev',
        children: ['Petio Ivanchev', 'Marin Ivanchev']
    },
    {
        mother: 'Natalia Ivancheva',
        father: 'Delian Ivanchev',
        children: ['Galina Hristova']
    },
    {
        mother: 'Galina Opanova',
        father: 'Boian Opanov',
        children: ['Maria Opanova', 'Patar Opanov']
    },
    {
        mother: 'Galina Hristova',
        father: 'Marin Hristov',
        children: ['Petar Hristov', 'Kamen Hristov', 'Ivan Hristov']
    },
    {
        mother: 'Simona Hristova',
        father: 'Kamen Hristov',
        children: ['Elena Hristova', 'Valeria Hristova']
    }
    ];
}

function getFTData2() {
    return [{
        mother: 'Ganka',
        father: 'Petur',
        children: ['Stefan', 'Rumqna']
    }, {
        mother: 'Stanka',
        father: 'Rumen',
        children: ['Stamen', 'Petq', 'Stoqn']
    }, {
        mother: 'Mariq',
        father: 'Ico',
        children: ['Ivo']
    }, {
        mother: 'Pavlina',
        father: 'Genadi',
        children: ['Jivka']
    }, {
        mother: 'Diana',
        father: 'Pesho',
        children: ['Iva']
    }, {
        mother: 'Iva',
        father: 'Stefan',
        children: ['Joro']
    }, {
        mother: 'Jivka',
        father: 'Joro',
        children: ['Stefani', 'Daniela']
    }, {
        mother: 'Petq',
        father: 'Ivo',
        children: ['Doncho', 'Monika']
    }, {
        mother: 'Rumqna',
        father: 'Stamen',
        children: ['Gancho', 'Mihaela']
    }];
}

function getFTData3() {
    var totalObjecto = [];
       
    function getName(name,level) {
        var nameToReturn = '';

        for (var i = 0; i < level; i++) {
            nameToReturn += name;
        }

        return nameToReturn;
    }

    for (var i = 1; i <= 20; i++) {

        totalObjecto.push({
            mother: getName('A', i),
            father: getName('B', i),
            children: [getName('F', i), getName('G', i), getName('I', i)]
        });

        totalObjecto.push({
            mother: getName('C', i),
            father: getName('D', i),
            children: [getName('J', i), getName('K', i), getName('M', i)]
        });

        totalObjecto.push({
            mother: getName('E', i),
            father: getName('F', i),
            children: [getName('P', i), getName('Q', i)]
        });

        totalObjecto.push({
            mother: getName('G', i),
            father: getName('H', i),
            children: [getName('S', i)]
        });

        totalObjecto.push({
            mother: getName('I', i),
            father: getName('J', i),
            children: [getName('T', i), getName('U', i)]
        });

        totalObjecto.push({
            mother: getName('K', i),
            father: getName('L', i),
            children: [getName('V', i)]
        });

        totalObjecto.push({
            mother: getName('M', i),
            father: getName('N', i),
            children: [getName('X', i), getName('Y', i)]
        });

        totalObjecto.push({
            mother: getName('Q', i),
            father: getName('R', i),
            children: [getName('a', i), getName('b', i)]
        });

        totalObjecto.push({
            mother: getName('S', i),
            father: getName('T', i),
            children: [getName('d', i)]
        });

        totalObjecto.push({
            mother: getName('V', i),
            father: getName('W', i),
            children: [getName('e', i), getName('f', i)]
        });

        totalObjecto.push({
            mother: getName('Y', i),
            father: getName('Z', i),
            children: [getName('g', i), getName('h', i)]
        });

        totalObjecto.push({
            mother: getName('b', i),
            father: getName('c', i),
            children: [getName('i', i), getName('j', i), getName('A', i+1)]
        });

        totalObjecto.push({
            mother: getName('d', i),
            father: getName('e', i),
            children: [getName('B', i+1), getName('k', i), getName('C', i + 1)]
        });

        totalObjecto.push({
            mother: getName('f', i),
            father: getName('g', i),
            children: [getName('D', i + 1), getName('l', i), getName('m', i)]
        });
    }
    
    return totalObjecto;
}