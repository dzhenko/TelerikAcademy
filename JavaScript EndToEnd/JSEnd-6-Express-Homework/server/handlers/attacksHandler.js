'use strict';

var mongoose = require('mongoose'),
    GameObjects = mongoose.model('GameObjects'),
    Report = mongoose.model('Report'),
    game = require('../game'),
    chance = require('../utilities/chance');

function handleAttack(attacker, defender, turns) {
    var report = {
        win: false,
        attacker: {
            ships: [],
            damage: []
        },
        defender: {
            ships: [],
            troops: [],
            damage: []
        }
    };

    

    for (var i = 0; i < turns; i++) {
        var attackerDamage = game.ships.attack[0] * game.upgrades[attacker.airUpgrades[0]] * attacker.ships[0] +
            game.ships.attack[1] * game.upgrades[attacker.airUpgrades[0]] * attacker.ships[1] +
            game.ships.attack[2] * game.upgrades[attacker.airUpgrades[0]] * attacker.ships[2] +
            game.ships.attack[3] * game.upgrades[attacker.airUpgrades[0]] * attacker.ships[3];

        var defenderDamage = game.troops.attack[0] * game.upgrades[defender.groundUpgrades[0]] * defender.troops[0] +
            game.troops.attack[1] * game.upgrades[defender.groundUpgrades[0]] * defender.troops[1] +
            game.troops.attack[2] * game.upgrades[defender.groundUpgrades[0]] * defender.troops[2] +
            game.ships.attack[1] * game.upgrades[defender.airUpgrades[0]] * defender.ships[0] +
            game.ships.attack[1] * game.upgrades[defender.airUpgrades[0]] * defender.ships[1] +
            game.ships.attack[2] * game.upgrades[defender.airUpgrades[0]] * defender.ships[2] +
            game.ships.attack[3] * game.upgrades[defender.airUpgrades[0]] * defender.ships[3];

        report.attacker.ships.push([attacker.ships[0], attacker.ships[1], attacker.ships[2], attacker.ships[3]]);
        report.attacker.damage.push(attackerDamage);

        report.defender.troops.push([defender.troops[0], defender.troops[1], defender.troops[2]]);
        report.defender.ships.push([defender.ships[0], defender.ships[1], defender.ships[2], defender.ships[3]]);
        report.defender.damage.push(defenderDamage);

        if (attackerDamage === 0 || defenderDamage === 0) {
            report.win = attackerDamage > 0;
            break;
        }

        while (attackerDamage > 0) {
            if (defender.troops[0] > 0) {
                attackerDamage -= game.troops.health[0] * game.upgrades[defender.groundUpgrades[2]] *
                    chance.doubleHealth(game.troops.defence[0] * game.upgrades[defender.groundUpgrades[1]]);
                defender.troops[0] -= (attackerDamage >= 0 ? 1 : 0);
            }
            else if (defender.troops[1] > 0) {
                attackerDamage -= game.troops.health[1] * game.upgrades[defender.groundUpgrades[2]] *
                    chance.doubleHealth(game.troops.defence[1] * game.upgrades[defender.groundUpgrades[1]]);
                defender.troops[1] -= (attackerDamage >= 0 ? 1 : 0);
            }
            else if (defender.troops[2] > 0) {
                attackerDamage -= game.troops.health[2] * game.upgrades[defender.groundUpgrades[2]] *
                    chance.doubleHealth(game.troops.defence[2] * game.upgrades[defender.groundUpgrades[1]]);
                defender.troops[2] -= (attackerDamage >= 0 ? 1 : 0);
            }
            else if (defender.ships[1] > 0) {
                attackerDamage -= game.ships.health[1] * game.upgrades[defender.airUpgrades[2]] *
                    chance.doubleHealth(game.ships.defence[1] * game.upgrades[defender.airUpgrades[1]]);
                defender.ships[1] -= (attackerDamage >= 0 ? 1 : 0);
            }
            else if (defender.ships[2] > 0) {
                attackerDamage -= game.ships.health[2] * game.upgrades[defender.airUpgrades[2]] *
                    chance.doubleHealth(game.ships.defence[2] * game.upgrades[defender.airUpgrades[1]]);
                defender.ships[2] -= (attackerDamage >= 0 ? 1 : 0);
            }
            else if (defender.ships[3] > 0) {
                attackerDamage -= game.ships.health[3] * game.upgrades[defender.airUpgrades[2]] *
                    chance.doubleHealth(game.ships.defence[3] * game.upgrades[defender.airUpgrades[1]]);
                defender.ships[3] -= (attackerDamage >= 0 ? 1 : 0);
            }
            else if (defender.ships[0] > 0) {
                attackerDamage -= game.ships.health[0] * game.upgrades[defender.airUpgrades[2]] *
                    chance.doubleHealth(game.ships.defence[0] * game.upgrades[defender.airUpgrades[1]]);
                defender.ships[0] -= (attackerDamage >= 0 ? 1 : 0);
            }
            else {
                break;
            }
        }

        while (defenderDamage > 0) {
            if (attacker.ships[1] > 0) {
                defenderDamage -= game.ships.health[1] * game.upgrades[attacker.airUpgrades[2]] *
                    chance.doubleHealth(game.ships.defence[1] * game.upgrades[attacker.airUpgrades[1]]);
                attacker.ships[1] -= (defenderDamage >= 0 ? 1 : 0);
            }
            else if (attacker.ships[2] > 0) {
                defenderDamage -= game.ships.health[2] * game.upgrades[attacker.airUpgrades[2]] *
                    chance.doubleHealth(game.ships.defence[2] * game.upgrades[attacker.airUpgrades[1]]);
                attacker.ships[2] -= (defenderDamage >= 0 ? 1 : 0);
            }
            else if (attacker.ships[3] > 0) {
                defenderDamage -= game.ships.health[3] * game.upgrades[attacker.airUpgrades[2]] *
                    chance.doubleHealth(game.ships.defence[3] * game.upgrades[attacker.airUpgrades[1]]);
                attacker.ships[3] -= (defenderDamage >= 0 ? 1 : 0);
            }
            else if (attacker.ships[0] > 0) {
                defenderDamage -= game.ships.health[0] * game.upgrades[attacker.airUpgrades[2]] *
                    chance.doubleHealth(game.ships.defence[0] * game.upgrades[attacker.airUpgrades[1]]);
                attacker.ships[0] -= (defenderDamage >= 0 ? 1 : 0);
            }
            else {
                break;
            }
        }
    }
    return report;
}

module.exports = {
    handleAttack: handleAttack,
    handleAttackForTargetId: function (attacker, targetID, turns, flightTime) {
        GameObjects.findOne({owner: targetID}).exec(function (err, defender) {
            if (err) {
                console.log('Game objects for target could not be loaded ' + err);
                // no return - attacker has to get his ships back
            }

            if (!defender) {
                defender = {
                    troops: [0, 0, 0],
                    groundUpgrades: [0, 0, 0],
                    ships: [0, 0, 0, 0],
                    airUpgrades: [0, 0, 0],
                    minerals: 0,
                    gas: 0,
                    fake: true
                }
            }

            var report = handleAttack(attacker, {
                troops: [defender.troops[0], defender.troops[1], defender.troops[2]],
                groundUpgrades: [defender.upgrades[10], defender.upgrades[11], defender.upgrades[12]],
                ships: [defender.ships[0], defender.ships[1], defender.ships[2], defender.ships[3]],
                airUpgrades: [defender.upgrades[7], defender.upgrades[8], defender.upgrades[9]]
            }, turns);

            var stolenMinerals = 0,
                stolenGas = 0,
                cargoCapacity = attacker.ships[0] * game.ships.capacity[0] +
                    attacker.ships[1] * game.ships.capacity[1] +
                    attacker.ships[2] * game.ships.capacity[2] +
                    attacker.ships[3] * game.ships.capacity[3],
                originalCargoCapacity = cargoCapacity;

            if (report.win && cargoCapacity > 0) {
                stolenMinerals = Math.min(defender.minerals, cargoCapacity);
                cargoCapacity -= stolenMinerals;
                defender.minerals -= stolenMinerals;

                stolenGas = Math.min(defender.gas, cargoCapacity);
                defender.gas -= stolenGas;
            }

            if (!defender.fake) {
                defender.ships = report.defender.ships[report.defender.ships.length - 1];
                defender.troops = report.defender.troops[report.defender.troops.length - 1];

                // async - doesn't matter
                defender.save();
            }

            report.stolen = [stolenMinerals, stolenGas];

            // if there is cargo capacity there must be alive ships - return them
            if (originalCargoCapacity > 0 && attacker.source) {
                GameObjects.findByIdAndUpdate(
                    attacker.attackerObjectsID,
                    {$push: {"comebacks": {
                        time: (flightTime + (new Date()).getTime()),
                        ships: report.attacker.ships[report.attacker.ships.length - 1],
                        cargo: [stolenMinerals, stolenGas]}}
                    },
                    {safe: true, upsert: true},
                    function (err, model) {
                        if (err) {
                            console.log(err);
                        }
                    }
                );
            }

            // reports dispatched to both players
            // sending to attacker
            report.owner = attacker.source;
            report.enemy = defender.coordinates;
            report.enemyID = defender.owner;

            Report.create(report, function (err) {
                if (err) {
                    console.log('Failed to create report ' + err);
                    return;
                }

                // sending to defender with opposite win status
                if (!defender.fake) {
                    report.owner = defender.owner;
                    report.win = !report.win;
                    report.enemy = attacker.sourceCoords;
                    report.enemyID = attacker.source;
                    report.own = false;

                    Report.create(report, function (err) {
                        if (err) {
                            console.log('Failed to create report ' + err);
                        }
                    });
                }
            });
        });
    },
    simulateAttack: function (attacker, defender, turns) {
        return handleAttack(attacker, defender, turns);
    }
};