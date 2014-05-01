function vehicleModule() {

    //easier inheritance
    Function.prototype.inherit = function (parent) {
        this.prototype = new parent();
        this.prototype.constructor = this;
    }

    //propulsion unit constructor
    function PropulsionUnit() {
    }

    //default acceleration value of undefined getAcceleration method
    PropulsionUnit.prototype.getAcceleration = function () {
        return 0;
    }

    //wheel
    function Wheel(wheelRadius) {
        this.radius = wheelRadius;
    }
    Wheel.inherit(PropulsionUnit);
    Wheel.prototype.getAcceleration = function () {
        return 2 * 3.14 * this.radius;
    }


    //nozzle
    function PropellingNozzle(nozzlePower) {
        this.power = nozzlePower;
        this.afterburnerSwitchedOn = false;
    }
    PropellingNozzle.inherit(PropulsionUnit);
    PropellingNozzle.prototype.getAcceleration = function () {
        if (this.afterburnerSwitchedOn) {
            return 2 * this.power;
        }
        else {
            return this.power;
        }
    }

    //propeller
    function Propeller(numberOfFins) {
        this.fins = numberOfFins;
        this.clockwise = true;
    }
    Propeller.inherit(PropulsionUnit);
    Propeller.prototype.getAcceleration = function () {
        if (this.clockwise) {
            return this.fins
        }
        else {
            return this.fins * (-1);
        }
    }

    //----------------------------------------------------

    //vehicle constructor
    function Vehicle() {
        this.speed = 0;
        this.propulsionUnits = [];
    }
    Vehicle.prototype.accelerate = function () {
        this.speed = 0;
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            this.speed += this.propulsionUnits[i].getAcceleration();
        }
    }

    //land vehicle
    function LandVehicle(fourWheelsArray) {
        if (fourWheelsArray.length != 4) {
            throw Error('use an array of 4 wheels!');
        }

        for (var i = 0; i < fourWheelsArray.length; i++) {
            if (fourWheelsArray[i] instanceof Wheel) {
                this.propulsionUnits.push(new Wheel(fourWheelsArray[i].radius));
            }
            else {
                throw Error('use only wheels!');
            }
        }
    }
    LandVehicle.inherit(Vehicle);

    //air vehicles
    function AirVehicle(nozzle) {
        if (nozzle instanceof PropellingNozzle) {
            this.propulsionUnits.push(new PropellingNozzle(nozzle.power));
        }
        else {
            throw Error('use an propelling nozzle!');
        }
    }
    AirVehicle.inherit(Vehicle);
    AirVehicle.prototype.toggleAfterBurner = function () {
        this.propulsionUnits[0].afterburnerSwitchedOn = !this.propulsionUnits[0].afterburnerSwitchedOn;
        this.accelerate();
    }

    //water vehicles
    function WaterVehicle(propellersArray) {
        for (var i = 0; i < propellersArray.length; i++) {
            if (propellersArray[i] instanceof Propeller) {
                this.propulsionUnits.push(new Propeller(propellersArray[i].fins));
            }
            else {
                throw Error('use only propellers!');
            }
        }
    }
    WaterVehicle.inherit(Vehicle);
    WaterVehicle.prototype.togglePropellerSpinDirection = function () {
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            this.propulsionUnits[i].clockwise = !this.propulsionUnits[i].clockwise;
        }
        this.accelerate();
    }

    //amphibia
    function AmphibiousVehicle(propellersArray, wheelsArray) {
        this.LandMode = true;
        this.LandPropulsionUnits = [];
        this.WaterPropulsionUnits = [];

        for (var i = 0; i < propellersArray.length; i++) {
            if (propellersArray[i] instanceof Propeller) {
                this.WaterPropulsionUnits.push(new Propeller(propellersArray[i].fins));
            }
            else {
                throw Error('use only propellers!');
            }
        }

        for (var i = 0; i < wheelsArray.length; i++) {
            if (wheelsArray[i] instanceof Wheel) {
                this.LandPropulsionUnits.push(new Wheel(wheelsArray[i].radius));
            }
            else {
                throw Error('use only wheels!');
            }
        }

        //by default it is on water
        this.propulsionUnits = this.LandPropulsionUnits;
    }
    AmphibiousVehicle.inherit(Vehicle);
    AmphibiousVehicle.prototype.toggleLandWaterMode = function () {
        this.LandMode = !this.LandMode;
        if (this.LandMode) {
            this.propulsionUnits = this.LandPropulsionUnits;
            this.speed = 0;
        }
        else {
            this.propulsionUnits = this.WaterPropulsionUnits;
            this.speed = 0;
        }
    }
    AmphibiousVehicle.prototype.togglePropellerSpinDirection = WaterVehicle.prototype.togglePropellerSpinDirection;

    return {
        Wheel: Wheel,
        PropellingNozzle: PropellingNozzle,
        Propeller: Propeller,
        LandVehicle: LandVehicle,
        AirVehicle: AirVehicle,
        WaterVehicle: WaterVehicle,
        AmphibiousVehicle: AmphibiousVehicle,
    }
};