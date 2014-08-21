(function () {
    if (!Object.create) {
        Object.create = function (obj) {
            function f() { };
            f.prototype = obj;
            return new f();
        }
    }

    if (!Object.prototype.extend) {
        Object.prototype.extend = function (properties) {
            function f() { };
            f.prototype = Object.create(this);
            for (var prop in properties) {
                f.prototype[prop] = properties[prop];
            }
            return new f();
        }
    }

    var Person = {
        init: function (firstName, lastName, age) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        },
        introduce: function () {
            var introduction = "";
            for (var prop in this) {
                if (typeof this[prop] != 'function') {
                    introduction += prop + " : " + this[prop] + "; ";
                }
            }
            return introduction;
        },
    }

    var Student = Person.extend({
        init: function (firstName, lastName, age, grade) {
            Person.init.call(this, firstName, lastName, age);
            this.grade = grade;
        },
        
    });

    var Teacher = Person.extend({
        init: function (firstName, lastName, age, speciality) {
            Person.init.call(this, firstName, lastName, age);
            this.speciality = speciality;
        },
    });

    var Class = {
        init: function (name, capacityOfStudents, setOfStudents, formTeacher) {
            this.name = name;
            this.capacityOfStudents = capacityOfStudents;
            this.setOfStudents = setOfStudents;
            this.formTeacher = formTeacher;
        }
    };

    var School = {
        init: function (name,town,classesOfStudents) {
            this.name = name;
            this.town = town;
            this.classesOfStudents = classesOfStudents;
        }
    }

    var pesho = Object.create(Student);
    pesho.init('pesho', 'peshov', 21, 3);
    console.log(pesho.introduce());

    var gosho = Object.create(Student);
    gosho.init('gosho', 'goshev', 14, 2);
    console.log(gosho.introduce());

    var mrIvan = Object.create(Teacher);
    mrIvan.init('mrIvan', 'Ivanov', 34, 'magic');
    console.log(mrIvan.introduce());

    var magicClass = Object.create(Class);
    magicClass.init('magic101', 30, [pesho,gosho], mrIvan);

    var magicSchool = Object.create(School);
    magicSchool.init('Hogwards', 'nowhere', [magicClass]);
}());