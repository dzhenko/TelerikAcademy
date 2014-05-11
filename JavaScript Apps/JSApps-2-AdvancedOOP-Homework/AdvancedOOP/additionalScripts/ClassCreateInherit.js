// holds class creation and inheritance module for both prototypal and classical OOP
// v.0 - zero data validation :)
var OOPHelper = (function () {

    // provides fast creation of classes by given function as a constructor and a JSON like object holding property names and values
    // constructor function is given as a seperate object, not as init: function() object
    function innerCreateClass(constructorFunction, properties) {
        
        var builtClass = function () {

            // _superConstructor property is set by the inheritClass function in this module and allowes access to the base class properties
            if (this._superConstructor) {

                // actually holds a instance of the object which it inherits from
                this._super = new this._superConstructor(arguments);
            }

            this._init.apply(this, arguments);
        }

        // constructor function of the class
        builtClass.prototype._init = constructorFunction;

        if (!builtClass.prototype._init) {

            //sets default empty constructor if none is given
            builtClass.prototype._init = function () { }
        }

        // aplies all the properties from the given set to this class
        for (var prop in properties) {
            builtClass.prototype[prop] = properties[prop];
        }

        return builtClass;
    }

    // provides inheritance in means of classical oop and enables a _super property - refference to the parent class
    function innerInheritClass(childClass,parentClass) {

        // saves the current prototype for later overriding of parent properties with same names
        var oldChildPrototype = childClass.prototype;

        // initial prototype is set as a new parent
        childClass.prototype = new parentClass();

        // the _superConstructor property is used in the createClass function of this module for saving a refference to the parent class (base)
        childClass.prototype._superConstructor = parentClass;

        // overriding of parent properties
        for (var prop in oldChildPrototype) {
            childClass.prototype[prop] = oldChildPrototype[prop];
        }
    }

    return {
        classical: {
            createClass: innerCreateClass,

            inheritClass: innerInheritClass,
        },

        prototypal: {
            createObject: function (object) {

            },

            extendObject: function () {

            }
        }
    }
}())