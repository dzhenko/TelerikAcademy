var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
// At least 2 modules
// At least 3 interfaces
// At least 6 classes
// At least 2 uses of inheritance
// At least 12 methods
// At least one generic use
// At least one static use
// Everything should be strongly typed
var NovCraft;
(function (NovCraft) {
    (function (Enums) {
        (function (Race) {
            Race[Race["Terran"] = 0] = "Terran";
            Race[Race["Protos"] = 1] = "Protos";
            Race[Race["Zerg"] = 2] = "Zerg";
            Race[Race["Neutral"] = 3] = "Neutral";
        })(Enums.Race || (Enums.Race = {}));
        var Race = Enums.Race;

        (function (GatherableObject) {
            GatherableObject[GatherableObject["MineralField"] = 0] = "MineralField";
            GatherableObject[GatherableObject["GasRafinery"] = 1] = "GasRafinery";
        })(Enums.GatherableObject || (Enums.GatherableObject = {}));
        var GatherableObject = Enums.GatherableObject;
    })(NovCraft.Enums || (NovCraft.Enums = {}));
    var Enums = NovCraft.Enums;

    (function (Collections) {
        var SameUnitsHolder = (function () {
            function SameUnitsHolder() {
                this.collection = [];
            }
            SameUnitsHolder.prototype.add = function (raceObject) {
                this.collection.push(raceObject);
            };

            SameUnitsHolder.prototype.removeById = function (raceObject) {
                var indexOfRemoved = this.collection.indexOf(raceObject);

                if (indexOfRemoved < 0) {
                    return null;
                }

                var removedObj = this.collection[indexOfRemoved];

                this.collection[indexOfRemoved] = this.collection[this.collection.length - 1];
                this.collection.pop();

                return removedObj;
            };

            SameUnitsHolder.prototype.removeAll = function () {
                this.collection = [];
            };
            return SameUnitsHolder;
        })();
        Collections.SameUnitsHolder = SameUnitsHolder;
    })(NovCraft.Collections || (NovCraft.Collections = {}));
    var Collections = NovCraft.Collections;

    (function (GameObjects) {
        var GatherableObject = (function () {
            function GatherableObject(id, type, ammount) {
                if (typeof ammount === "undefined") { ammount = 1000; }
                this.id = id;
                this.type = type;
                this.ammount = ammount;
            }
            return GatherableObject;
        })();
        GameObjects.GatherableObject = GatherableObject;

        var _Unit = (function () {
            function _Unit(id, race, health, armour) {
                this.id = id;
                this.race = race;
                this.health = health;
                this.armour = armour;
            }
            return _Unit;
        })();
        GameObjects._Unit = _Unit;

        var _Gatherer = (function (_super) {
            __extends(_Gatherer, _super);
            function _Gatherer(id, race, health, armour, buildSpeed) {
                _super.call(this, id, race, health, armour);
                this.buildSpeed = buildSpeed;
            }
            _Gatherer.prototype.gather = function (source) {
                source.ammount -= _Gatherer.carryCapacity;

                return {
                    ammount: _Gatherer.carryCapacity,
                    type: source.type
                };
            };
            _Gatherer.carryCapacity = 5;
            return _Gatherer;
        })(_Unit);
        GameObjects._Gatherer = _Gatherer;

        var _Fighter = (function (_super) {
            __extends(_Fighter, _super);
            function _Fighter(id, race, health, armour, attack) {
                _super.call(this, id, race, health, armour);
                this.attack = attack;
            }
            _Fighter.prototype.attackTarget = function (target) {
                if (target.race === this.race) {
                    return;
                }

                var dmg = Math.max(0, this.attack - target.armour);
                target.health -= dmg;
            };
            return _Fighter;
        })(_Unit);
        GameObjects._Fighter = _Fighter;
    })(NovCraft.GameObjects || (NovCraft.GameObjects = {}));
    var GameObjects = NovCraft.GameObjects;

    (function (Units) {
        (function (Terran) {
            var SCV = (function (_super) {
                __extends(SCV, _super);
                function SCV(id) {
                    _super.call(this, id, 0 /* Terran */, 60, 0, 90);
                }
                return SCV;
            })(GameObjects._Gatherer);
            Terran.SCV = SCV;

            var Marine = (function (_super) {
                __extends(Marine, _super);
                function Marine(id, hasShield) {
                    _super.call(this, id, 0 /* Terran */, 50, 0, 6);
                    this.hasShield = hasShield;
                    if (hasShield) {
                        this.health += 10;
                        this.armour += 1;
                    }
                }
                Marine.prototype.stim = function () {
                    this.attack += 10;
                };
                return Marine;
            })(GameObjects._Fighter);
            Terran.Marine = Marine;

            var Tank = (function (_super) {
                __extends(Tank, _super);
                function Tank(id, canSiege) {
                    _super.call(this, id, 0 /* Terran */, 150, 0, 25);
                    this.canSiege = canSiege;
                    this._isSieged = false;
                }
                Tank.prototype.changeMode = function () {
                    if (this.canSiege) {
                        this._isSieged = !this._isSieged;

                        if (this._isSieged) {
                            this.attack += 50;
                        } else {
                            this.attack -= 50;
                        }
                    }
                };
                return Tank;
            })(GameObjects._Fighter);
            Terran.Tank = Tank;
        })(Units.Terran || (Units.Terran = {}));
        var Terran = Units.Terran;

        (function (Zerg) {
            var Drone = (function (_super) {
                __extends(Drone, _super);
                function Drone(id) {
                    _super.call(this, id, 2 /* Zerg */, 40, 0, 100);
                }
                return Drone;
            })(GameObjects._Gatherer);
            Zerg.Drone = Drone;

            var Zergling = (function (_super) {
                __extends(Zergling, _super);
                function Zergling(id, canBury) {
                    _super.call(this, id, 2 /* Zerg */, 40, 0, 5);
                    this.canBury = canBury;
                    this._isBuried = false;
                }
                Zergling.prototype.bury = function () {
                    if (this.canBury) {
                        this._isBuried = !this._isBuried;

                        if (this._isBuried) {
                            this.armour += 100;
                        } else {
                            this.armour -= 100;
                        }
                    }
                };
                return Zergling;
            })(GameObjects._Fighter);
            Zerg.Zergling = Zergling;

            var Ultralisk = (function (_super) {
                __extends(Ultralisk, _super);
                function Ultralisk(id, isUpgraded) {
                    _super.call(this, id, 2 /* Zerg */, 250, 3, 40);
                    this.isUpgraded = isUpgraded;
                    if (this.isUpgraded) {
                        this.armour += 4;
                    }
                }
                return Ultralisk;
            })(GameObjects._Fighter);
            Zerg.Ultralisk = Ultralisk;
        })(Units.Zerg || (Units.Zerg = {}));
        var Zerg = Units.Zerg;
    })(NovCraft.Units || (NovCraft.Units = {}));
    var Units = NovCraft.Units;

    (function (Tests) {
        var Test1 = (function () {
            function Test1() {
            }
            Test1.run = function () {
                var scv1 = new Units.Terran.SCV('scv1');
                var scv2 = new Units.Terran.SCV('scv2');
                var scv3 = new Units.Terran.SCV('scv3');
                var marine1 = new Units.Terran.Marine('marine1', false);
                var marine2 = new Units.Terran.Marine('marine2', false);
                var marine3 = new Units.Terran.Marine('marine3', false);
                var marine4 = new Units.Terran.Marine('marine4', false);
                var tank = new Units.Terran.Tank('tank1', true);

                var scvs = new Collections.SameUnitsHolder();
                scvs.add(scv1);
                scvs.add(scv2);
                scvs.add(scv3);

                var marines = new Collections.SameUnitsHolder();
                marines.add(marine1);
                marines.add(marine2);
                marines.add(marine3);
                marines.add(marine4);

                var mineralField = new GameObjects.GatherableObject('mineralField', 0 /* MineralField */);
                var mineralChunk = scv1.gather(mineralField);

                var zergling = new Units.Zerg.Zergling('zergling', true);
                var ultralisk = new Units.Zerg.Ultralisk('untouchable:)', true);

                console.log('Initial state');
                console.log(tank);
                console.log(ultralisk);

                console.log('Attack');
                tank.attackTarget(ultralisk);
                ultralisk.attackTarget(tank);

                console.log(tank);
                console.log(ultralisk);

                console.log('Tank sieges up and attack');
                tank.changeMode();
                tank.attackTarget(ultralisk);
                ultralisk.attackTarget(tank);

                console.log(tank);
                console.log(ultralisk);
            };
            return Test1;
        })();
        Tests.Test1 = Test1;
    })(NovCraft.Tests || (NovCraft.Tests = {}));
    var Tests = NovCraft.Tests;
})(NovCraft || (NovCraft = {}));

NovCraft.Tests.Test1.run();
/* ---------------------Output---------------------
Initial state
Tank {id: "tank1", race: 0, health: 150, armour: 0, attack: 25…}
Ultralisk {id: "untouchable:)", race: 2, health: 250, armour: 7, attack: 40…}
Attack
Tank {id: "tank1", race: 0, health: 110, armour: 0, attack: 25…}
Ultralisk {id: "untouchable:)", race: 2, health: 232, armour: 7, attack: 40…}
Tank sieges up and attack
Tank {id: "tank1", race: 0, health: 70, armour: 0, attack: 75…}
Ultralisk {id: "untouchable:)", race: 2, health: 164, armour: 7, attack: 40…}
*/
//# sourceMappingURL=app.js.map
