app.factory('RaceModel', function() {
    'use strict';

    return {
        protoss: {
            buildings: [
                {
                    name: 'Nexus',
                    image: 'http://img2.wikia.nocookie.net/__cb20090719192439/starcraft/images/b/b7/Nexus_SC2_DevRend3.jpg',
                    alt: 'Nexus',
                    description: 'The Nexus serves as the hub of any protoss base providing the precious minerals.'
                },
                {
                    name: 'Assimilator',
                    image: 'http://img1.wikia.nocookie.net/__cb20090129231558/starcraft/images/4/42/Assimilator_SC2_Rend1.jpg',
                    alt: 'Assimilator',
                    description: 'The Assimilator is a protoss building used for harvesting vespene gas.'
                },
                {
                    name: 'Cybernetics core',
                    image: 'http://img2.wikia.nocookie.net/__cb20090129231417/starcraft/images/8/8d/CyberneticsCore_SC2_DevRend2.jpg',
                    alt: 'Cybernetics core',
                    description: 'The Cybernetics core is the protoss building used for supplying energy for the other buildings'
                },
                {
                    name: 'Pylon',
                    image: 'http://img3.wikia.nocookie.net/__cb20081019210108/starcraft/images/a/ad/Pylon_SC2_DevRend3.jpg',
                    alt: 'Pylon',
                    description: 'The protoss Pylon provides the supply needed to build a great army'
                },
                {
                    name: 'Gateway',
                    image: 'http://img2.wikia.nocookie.net/__cb20090129232926/starcraft/images/6/6a/Gateway_SC2_Rend1.jpg',
                    alt: 'Gateway',
                    description: 'Gateways create a swirling rift that warps in protoss warriors.'
                },
                {
                    name: 'Stargate',
                    image: 'http://img2.wikia.nocookie.net/__cb20081019220804/starcraft/images/9/9e/Stargate_SC2_Rend1.jpg',
                    alt: 'Stargate',
                    description: 'The Stargate provides a warp link strong enough to call ships to a planets surface.'
                },
                {
                    name: 'Forge',
                    image: 'http://img4.wikia.nocookie.net/__cb20090129231907/starcraft/images/2/21/Forge_SC2_DevRend3.jpg',
                    alt: 'Forge',
                    description: 'The protoss Forge provides the ability to research upgrades'
                }
            ],
            shipsImage: 'http://img3.wikia.nocookie.net/__cb20110213203818/starcraft/images/e/e5/Carrier_SC2_Head1.gif',
            ships: [
                {
                    name: 'Warp prism',
                    image: 'http://img2.wikia.nocookie.net/__cb20090129012049/starcraft/images/6/69/WarpPrism_SC2_Rend1.jpg',
                    alt: 'Warp prism',
                    description: 'The protoss warp prism, is a flying protoss robotic machine designed for transportation.'
                },
                {
                    name: 'Phoenix',
                    image: 'http://img1.wikia.nocookie.net/__cb20090129010039/starcraft/images/3/3d/Phoenix_SC2_Rend1.jpg',
                    alt: 'Phoenix',
                    description: 'The protoss Phoenix is a tier 1 spaceship'
                },
                {
                    name: 'Void ray',
                    image: 'http://img1.wikia.nocookie.net/__cb20090129011444/starcraft/images/1/1d/VoidRay_SC2_Rend1.jpg',
                    alt: 'Void ray',
                    description: 'The protoss Void ray is a deadly tier 2 spaceship'
                },
                {
                    name: 'Carrier',
                    image: 'http://img3.wikia.nocookie.net/__cb20090516031103/starcraft/images/a/a8/Carrier_SC2_DevRend1.jpg',
                    alt: 'Carrier',
                    description: 'The protoss Carrier is the most superior spaceship.'
                }
            ],
            troopsImage: 'http://img2.wikia.nocookie.net/__cb20110213202251/starcraft/images/4/48/Archon_SC2_Head1.gif',
            troops: [
                {
                    name: 'Stalker',
                    image: 'http://img3.wikia.nocookie.net/__cb20090129010543/starcraft/images/9/9f/Stalker_SC2_render2.jpg',
                    alt: 'Stalker',
                    description: 'The protoss Stalker is a good tier 1 defender.'
                },
                {
                    name: 'Immortal',
                    image: 'http://img1.wikia.nocookie.net/__cb20081019212305/starcraft/images/6/6f/Immortal_SC2_Rend1.jpg',
                    alt: 'Immortal',
                    description: 'The protoss Immortal is a deadly tier 2 defender.'
                },
                {
                    name: 'Archon',
                    image: 'http://img2.wikia.nocookie.net/__cb20090128235706/starcraft/images/3/3a/Archon_SC2_Rend2.jpg',
                    alt: 'Archon',
                    description: 'The protoss Archon is the most superior defender.'
                }
            ]
        },
        terran: {
            buildings: [
                {
                    name: 'Command Center',
                    image: 'http://img2.wikia.nocookie.net/__cb20100725194510/starcraft/images/a/a7/OrbitalCommand_SC2_Rend1.jpg',
                    alt: 'Command Center',
                    description: 'The Command Center serves as the hub of any terran base providing the precious minerals.'
                },
                {
                    name: 'Refinery',
                    image: 'http://img3.wikia.nocookie.net/__cb20080629225502/starcraft/images/6/6d/Refinery_SC2_Game1.jpg',
                    alt: 'Refinery',
                    description: 'The Refinery is a terran building used for harvesting vespene gas.'
                },
                {
                    name: 'Fusion core',
                    image: 'http://img3.wikia.nocookie.net/__cb20100716232527/starcraft/images/7/75/FusionCore_SC2_Rend1.jpg',
                    alt: 'Fusion core',
                    description: 'The Fusion core is the terran building used for supplying energy for the other buildings'
                },
                {
                    name: 'Supply Depot',
                    image: 'http://img3.wikia.nocookie.net/__cb20080629221708/starcraft/images/4/4e/SupplyDepot_SC2_DevGame2.jpg',
                    alt: 'Supply Depot',
                    description: 'The terran Supply Depot provides the supply needed to build a great army'
                },
                {
                    name: 'Barracks',
                    image: 'http://img4.wikia.nocookie.net/__cb20080629230915/starcraft/images/7/78/Barracks_SC2_Game1.jpg',
                    alt: 'Barracks',
                    description: 'Barracks create all the mighty terran warriors.'
                },
                {
                    name: 'Starport',
                    image: 'http://img3.wikia.nocookie.net/__cb20080629223825/starcraft/images/2/25/Starport_SC2_DevRend2.jpg',
                    alt: 'Starport',
                    description: 'The Starport provides the terran race with its home ship army.'
                },
                {
                    name: 'Armory',
                    image: 'http://img2.wikia.nocookie.net/__cb20100716232157/starcraft/images/b/ba/Armory_SC2_Rend1.jpg',
                    alt: 'Armory',
                    description: 'The terran Armory provides the ability to research upgrades'
                }
            ],
            shipsImage: 'http://img2.wikia.nocookie.net/__cb20110408231333/starcraft/images/b/bc/Battlecruiser_SC2_HeadAnim1.gif',
            ships: [
                {
                    name: 'Dropship',
                    image: 'http://img1.wikia.nocookie.net/__cb20090829122920/starcraft/images/5/57/MedivacDropship_SC2_DevRend2.jpg',
                    alt: 'Dropship',
                    description: 'The terran dropship, is a spaceship designed for transportation.'
                },
                {
                    name: 'Raven',
                    image: 'http://img2.wikia.nocookie.net/__cb20090129013727/starcraft/images/a/ad/Nighthawk_SC2_Rend1.jpg',
                    alt: 'Raven',
                    description: 'The terran Raven is a tier 1 spaceship'
                },
                {
                    name: 'Banshee',
                    image: 'http://img1.wikia.nocookie.net/__cb20090419001652/starcraft/images/0/0d/Banshee_SC2_DevRend2.jpg',
                    alt: 'Banshee',
                    description: 'The terran Banshee ray is a deadly tier 2 spaceship'
                },
                {
                    name: 'Battlecruiser',
                    image: 'http://img3.wikia.nocookie.net/__cb20090708231108/starcraft/images/9/94/BattlecruiserYamato_SC2_Rend1.jpg',
                    alt: 'Battlecruiser',
                    description: 'The terran Battlecruiser is the most superior spaceship.'
                }
            ],
            troopsImage: 'http://img1.wikia.nocookie.net/__cb20110213152619/starcraft/images/6/64/Thor_SC2_Head1.gif',
            troops: [
                {
                    name: 'Marauder',
                    image: 'http://img2.wikia.nocookie.net/__cb20110218165959/starcraft/images/2/28/Marauder_SC2_Rend1.jpg',
                    alt: 'Marauder',
                    description: 'The terran Marauder is a good tier 1 defender.'
                },
                {
                    name: 'Viking',
                    image: 'http://img1.wikia.nocookie.net/__cb20080628185129/starcraft/images/a/ac/VikingGroundMode_SC2_Game1.jpg',
                    alt: 'Viking',
                    description: 'The terran Viking is a deadly tier 2 defender.'
                },
                {
                    name: 'Thor',
                    image: 'http://img2.wikia.nocookie.net/__cb20100817135552/starcraft/images/2/21/Thor_SC2_Rend1.jpg',
                    alt: 'Thor',
                    description: 'The terran Thor is the most superior defender.'
                }
            ]
        },
        zerg: {
            buildings: [
                {
                    name: 'Hive',
                    image: 'http://img4.wikia.nocookie.net/__cb20090708231423/starcraft/images/f/f0/Hive_SC2_Rend1.jpg',
                    alt: 'Hive',
                    description: 'The Hive serves as the hub of any zerg base providing the precious minerals.'
                },
                {
                    name: 'Extractor',
                    image: 'http://img3.wikia.nocookie.net/__cb20090708231200/starcraft/images/3/3b/Extractor_SC2_Rend1.jpg',
                    alt: 'Extractor',
                    description: 'The Extractor is a zerg building used for harvesting vespene gas.'
                },
                {
                    name: 'Nest core',
                    image: 'http://img1.wikia.nocookie.net/__cb20090711011823/starcraft/images/8/83/BanelingNest_SC2_Rend1.jpg',
                    alt: 'Nest core',
                    description: 'The Nest core is the zerg building used for supplying energy for the other buildings'
                },
                {
                    name: 'Nydus Network',
                    image: 'http://img2.wikia.nocookie.net/__cb20090708231829/starcraft/images/e/ef/NydusNetwork_SC2_Rend1.jpg',
                    alt: 'Nydus Network',
                    description: 'The zerg Nydus Network provides the supply needed to build a great army'
                },
                {
                    name: 'Roach Warren',
                    image: 'http://img2.wikia.nocookie.net/__cb20090708231912/starcraft/images/a/a3/RoachWarren_SC2_Rend1.jpg',
                    alt: 'Roach Warren',
                    description: 'The Roach Warren builds all the scary zerg troops.'
                },
                {
                    name: 'Greater Spire',
                    image: 'http://img2.wikia.nocookie.net/__cb20090708231242/starcraft/images/2/27/GreaterSpire_SC2_Rend1.jpg',
                    alt: 'Greater Spire',
                    description: 'The zerg Greater Spire morphs all the ships of the mighty zerg race.'
                },
                {
                    name: 'Evolution Chamber',
                    image: 'http://img3.wikia.nocookie.net/__cb20090630035933/starcraft/images/3/36/EvolutionChamber_SC2_DevRend2.jpg',
                    alt: 'Evolution Chamber',
                    description: 'The zerg EvolutionChamber provides the ability to research upgrades'
                }
            ],
            shipsImage: 'http://img1.wikia.nocookie.net/__cb20110213143938/starcraft/images/d/d8/Mutalisk_SC2_Head1.gif',
            ships: [
                {
                    name: 'Overlord',
                    image: 'http://img1.wikia.nocookie.net/__cb20100817144901/starcraft/images/1/17/Overlord_SC2_Rend1.jpg',
                    alt: 'Overlord',
                    description: 'The zerg Overlord, is a flying protoss robotic machine designed for transportation.'
                },
                {
                    name: 'Mutalisk',
                    image: 'http://img3.wikia.nocookie.net/__cb20090511221650/starcraft/images/e/e9/Mutalisk_SC2_DevRend2.png',
                    alt: 'Mutalisk',
                    description: 'The zerg Mutalisk is a tier 1 spaceship'
                },
                {
                    name: 'Corruptor',
                    image: 'http://img3.wikia.nocookie.net/__cb20080603115750/starcraft/images/8/89/Corruptor_SC2_Art1.jpg',
                    alt: 'Corruptor',
                    description: 'The zerg Corruptor ray is a deadly tier 2 spaceship'
                },
                {
                    name: 'Brood Lord',
                    image: 'http://img1.wikia.nocookie.net/__cb20110212030028/starcraft/images/e/ee/BroodLord_SC2_Rend1.jpg',
                    alt: 'Brood Lord',
                    description: 'The zerg Brood Lord is the most superior spaceship.'
                }
            ],
            troopsImage : 'http://img4.wikia.nocookie.net/__cb20110213204932/starcraft/images/0/08/Hydralisk_SC2_Head1.gif',
            troops: [
                {
                    name: 'Roach',
                    image: 'http://img3.wikia.nocookie.net/__cb20080701195047/starcraft/images/c/c5/Roach_SC2_Rend1.jpg',
                    alt: 'Roach',
                    description: 'The zerg Roach is a good tier 1 defender.'
                },
                {
                    name: 'Hydralisk',
                    image: 'http://img4.wikia.nocookie.net/__cb20090407222208/starcraft/images/b/bf/Hydralisk_SC2_DevRend2.jpg',
                    alt: 'Hydralisk',
                    description: 'The zerg Hydralisk is a deadly tier 2 defender.'
                },
                {
                    name: 'Ultralisk',
                    image: 'http://img1.wikia.nocookie.net/__cb20090129014840/starcraft/images/c/c9/Ultralisk_SC2_Rend1.jpg',
                    alt: 'Ultralisk',
                    description: 'The zerg Ultralisk is the most superior defender.'
                }
            ]
        }
    }
});