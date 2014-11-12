app.factory('UpgradesModel', function () {
    'use strict';

    return {
        multiplier: [1.00, 1.01, 1.02, 1.03, 1.05, 1.07, 1.09, 1.12, 1.15, 1.18, 1.22, 1.26, 1.30],
        names: [
            {
                name: 'Increased minerals production rate',
                image: 'http://img1.wikia.nocookie.net/__cb20100610012154/starcraft/images/8/86/GraviticBooster_SC2_Game1.png'
            },
            {
                name: 'Increased gas production rate',
                image: 'http://img1.wikia.nocookie.net/__cb20100610012154/starcraft/images/8/86/GraviticBooster_SC2_Game1.png'
            },
            {
                name: 'Increased buildings construction speed',
                image: 'http://img1.wikia.nocookie.net/__cb20100610012154/starcraft/images/8/86/GraviticBooster_SC2_Game1.png'
            },
            {
                name: 'Increased air units construction speed',
                image: 'http://img1.wikia.nocookie.net/__cb20100610012154/starcraft/images/8/86/GraviticBooster_SC2_Game1.png'
            },
            {
                name: 'Increased ground units construction speed',
                image: 'http://img1.wikia.nocookie.net/__cb20100610012154/starcraft/images/8/86/GraviticBooster_SC2_Game1.png'
            },
            {
                name: 'Increased upgrades creation speed',
                image: 'http://img1.wikia.nocookie.net/__cb20100610012154/starcraft/images/8/86/GraviticBooster_SC2_Game1.png'
            },
            {
                name: 'Increased air units flight speed',
                image: 'http://img1.wikia.nocookie.net/__cb20100610012154/starcraft/images/8/86/GraviticBooster_SC2_Game1.png'
            },
            {
                name: 'Increased air units attack',
                image: 'http://img1.wikia.nocookie.net/__cb20100610012154/starcraft/images/8/86/GraviticBooster_SC2_Game1.png'
            },
            {
                name: 'Increased air units defence',
                image: 'http://img1.wikia.nocookie.net/__cb20100610012154/starcraft/images/8/86/GraviticBooster_SC2_Game1.png'
            },
            {
                name: 'Increased air units health',
                image: 'http://img1.wikia.nocookie.net/__cb20100610012154/starcraft/images/8/86/GraviticBooster_SC2_Game1.png'
            },
            {
                name: 'Increased ground units attack',
                image: 'http://img1.wikia.nocookie.net/__cb20100610012154/starcraft/images/8/86/GraviticBooster_SC2_Game1.png'
            },
            {
                name: 'Increased ground units defence',
                image: 'http://img1.wikia.nocookie.net/__cb20100610012154/starcraft/images/8/86/GraviticBooster_SC2_Game1.png'
            },
            {
                name: 'Increased ground units health',
                image: 'http://img1.wikia.nocookie.net/__cb20100610012154/starcraft/images/8/86/GraviticBooster_SC2_Game1.png'
            }
        ],
        cost: {
            minerals: [0, 2000, 5000, 10000, 20000, 30000, 40000, 60000, 80000, 100000, 150000, 200000, 250000],
            gas: [0, 200, 500, 1000, 2000, 4000, 8000, 12000, 16000, 20000, 40000, 60000, 80000],
            time: [0, 50, 60, 70, 80, 90, 100, 120, 150, 200, 300, 400, 6000]
        }
    }
});