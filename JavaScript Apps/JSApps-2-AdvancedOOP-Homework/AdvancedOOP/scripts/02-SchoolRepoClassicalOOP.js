(function () {
    function createClass(properties) {
        var f = function () {
            if (this._superConstructor) {
                this._super = new this._superConstructor();
            }
            this.init.apply(this, arguments);
        }

        for (var prop in properties) {
            f.prototype[prop] = properties[prop];
        }
        if (!f.prototype.init) {
            f.prototype.init = function () { }
        }
        return f;
    }

    Function.prototype.inherit = function (parent) {
        var oldPrototype = this.prototype;
        this.prototype = new parent();
        this.prototype._superConstructor = parent;
        for (var prop in oldPrototype) {
            this.prototype[prop] = oldPrototype[prop];
        }
    }

    var Person = createClass({
        init: function (firstName, lastName, age) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        },
        introduce: function () {
            var introduction = "";
            for (var prop in this) {
                if (typeof this[prop] != 'function' && prop.toString() != '_super') {
                    introduction += prop + " : " + this[prop] + "; ";
                }
            }
            return introduction;
        },
    });

    var Student = createClass({
        init: function (firstName, lastName, age, grade) {
            this._super.init.call(this,firstName, lastName, age);
            this.grade = grade;
        },
    });
    Student.inherit(Person);

    var Teacher = createClass({
        init: function (firstName, lastName, age, speciality) {
            this._super.init.call(this, firstName, lastName, age);
            this.speciality = speciality;
        },
    });
    Teacher.inherit(Person);

    var Class = createClass({
        init: function (name, capacityOfStudents, setOfStudents, formTeacher) {
            this.name = name;
            this.capacityOfStudents = capacityOfStudents;
            this.setOfStudents = setOfStudents;
            this.formTeacher = formTeacher;
        }
    });

    var School = createClass({
        init: function (name, town, classesOfStudents) {
            this.name = name;
            this.town = town;
            this.classesOfStudents = classesOfStudents;
        }
    });


    var pesho = new Student('pesho', 'peshev', 12, 3);
    console.log(pesho.introduce());

    var gosho = new Student('gosho', 'goshev', 14, 2);
    console.log(gosho.introduce());

    var mrIvan = new Teacher('mrIvan', 'ivanov', 43, 'sorcerry');
    console.log(mrIvan.introduce());

    var classSorcery = new Class('sorc101', 30, [pesho, gosho], mrIvan);

    var school = new School('wizardSchool', 'georgia', [classSorcery]);
}())