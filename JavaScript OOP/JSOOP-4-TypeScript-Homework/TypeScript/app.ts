// At least 2 modules
// At least 3 interfaces
// At least 6 classes
// At least 2 uses of inheritance
// At least 12 methods
// At least one generic use
// At least one static use
// Everything should be strongly typed
module NovCraft {
    export module Enums {
        export enum Race {
            Terran,
            Protos,
            Zerg,
            Neutral
        }

        export enum GatherableObject {
            MineralField,
            GasRafinery
        }
    }

    export module Collections {
        export class SameUnitsHolder<T extends GameObjects._Unit> {
            private collection: T[];

            constructor() {
                this.collection = [];
            }

            add(raceObject: T): void {
                this.collection.push(raceObject);
            }

            removeById(raceObject: T): T {
                var indexOfRemoved = this.collection.indexOf(raceObject);

                if (indexOfRemoved < 0) {
                    return null;
                }

                var removedObj = this.collection[indexOfRemoved];

                this.collection[indexOfRemoved] = this.collection[this.collection.length - 1];
                this.collection.pop();

                return removedObj;
            }

            removeAll(): void {
                this.collection = [];
            }
        }
    }

    export module Interfaces {
        export interface IGameObject {
            id: string;
        }

        export interface IGatherableObject extends IGameObject {
            ammount: number;
            type: Enums.GatherableObject;
        }

        export interface IUnit extends IGameObject {
            health: number;
            armour: number;
            race: Enums.Race;
        }

        export interface IFighter extends IUnit {
            attack: number;

            attackTarget(target: IUnit): void;
        }

        export interface IGatherer extends IUnit {
            buildSpeed: number;

            gather(source: IGatherableObject): { ammount: number; type: Enums.GatherableObject };
        }
    }

    export module GameObjects {
        export class GatherableObject implements Interfaces.IGatherableObject {
            constructor(public id: string, public type: Enums.GatherableObject, public ammount: number = 1000) { }
        }

        export class _Unit implements Interfaces.IUnit {
            constructor(public id: string, public race: Enums.Race, public health: number, public armour: number) { }
        }

        export class _Gatherer extends _Unit implements Interfaces.IGatherer {
            // every gatherer gathers the same ammount of resources
            public static carryCapacity: number = 5;

            constructor(id: string, race: Enums.Race, health: number, armour: number,
                public buildSpeed: number) {
                super(id, race, health, armour);
            }

            gather(source: Interfaces.IGatherableObject): { ammount: number; type: Enums.GatherableObject } {
                source.ammount -= _Gatherer.carryCapacity;
				
				return {
                    ammount: _Gatherer.carryCapacity,
                    type: source.type
                }
			}
        }

        export class _Fighter extends _Unit implements Interfaces.IFighter {
            constructor(id: string, race: Enums.Race, health: number, armour: number,
                public attack: number) {
                super(id, race, health, armour);
            }

            attackTarget(target: Interfaces.IUnit): void {
                if (target.race === this.race) {
                    return;
                }

                var dmg = Math.max(0, this.attack - target.armour)
				 target.health -= dmg;
            }
        }
    }

    export module Units {
        export module Terran {
            export class SCV extends GameObjects._Gatherer {
                constructor(id: string) {
                    super(id, Enums.Race.Terran, 60, 0, 90);
                }
            }

            export class Marine extends GameObjects._Fighter {
                constructor(id: string, public hasShield: boolean) {
                    super(id, Enums.Race.Terran, 50, 0, 6);
                    if (hasShield) {
                        this.health += 10;
                        this.armour += 1;
                    }
                }

                stim(): void {
                    this.attack += 10;
                }

            }

            export class Tank extends GameObjects._Fighter {
                private _isSieged;

                constructor(id: string, public canSiege: boolean) {
                    super(id, Enums.Race.Terran, 150, 0, 25);
                    this._isSieged = false;
                }

                changeMode(): void {
                    if (this.canSiege) {
                        this._isSieged = !this._isSieged;

                        if (this._isSieged) {
                            this.attack += 50;
                        }
                        else {
                            this.attack -= 50;
                        }
                    }
                }
            }
        }

        export module Zerg {
            export class Drone extends GameObjects._Gatherer {
                constructor(id: string) {
                    super(id, Enums.Race.Zerg, 40, 0, 100);
                }
            }

            export class Zergling extends GameObjects._Fighter {
                private _isBuried;

                constructor(id: string, public canBury: boolean) {
                    super(id, Enums.Race.Zerg, 40, 0, 5);
                    this._isBuried = false;
                }

                bury(): void {
                    if (this.canBury) {
                        this._isBuried = !this._isBuried;

                        if (this._isBuried) {
                            this.armour += 100;
                        }
                        else {
                            this.armour -= 100;
                        }
                    }
                }
            }

            export class Ultralisk extends GameObjects._Fighter {
                constructor(id: string, public isUpgraded: boolean) {
                    super(id, Enums.Race.Zerg, 250, 3, 40);
                    if (this.isUpgraded) {
                        this.armour += 4;
                    }
                }
            }
        }
    }

    export module Tests {
        export class Test1 {
            static run(): void {
                var scv1 = new Units.Terran.SCV('scv1');
                var scv2 = new Units.Terran.SCV('scv2');
                var scv3 = new Units.Terran.SCV('scv3');
                var marine1 = new Units.Terran.Marine('marine1', false);
                var marine2 = new Units.Terran.Marine('marine2', false);
                var marine3 = new Units.Terran.Marine('marine3', false);
                var marine4 = new Units.Terran.Marine('marine4', false);
                var tank = new Units.Terran.Tank('tank1', true);

                var scvs = new Collections.SameUnitsHolder<NovCraft.Units.Terran.SCV>();
                scvs.add(scv1);
                scvs.add(scv2);
                scvs.add(scv3);

                var marines = new Collections.SameUnitsHolder<NovCraft.Units.Terran.Marine>();
                marines.add(marine1);
                marines.add(marine2);
                marines.add(marine3);
                marines.add(marine4);

                var mineralField = new GameObjects.GatherableObject('mineralField', NovCraft.Enums.GatherableObject.MineralField);
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
            }
        }
    }
}

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