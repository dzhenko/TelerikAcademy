'use strict';

//module.exports = [1.00, 1.01, 1.02, 1.03, 1.05, 1.07, 1.09, 1.12, 1.15, 1.18, 1.22, 1.26, 1.30] ;
//    names: [
//        'Increased minerals mine rate',                   index 0
//        'Increased gas mine rate',                        index 1
//
//        'Increased buildings construction speed',         index 2
//        'Increased air units construction speed',         index 3
//        'Increased ground units construction speed',      index 4
//        'Increased upgrades creation speed',              index 5
//
//        'Increased air units flight speed',               index 6
//
//        'Increased air units attack',                     index 7
//        'Increased air units defence',                    index 8
//        'Increased air units health',                     index 9
//
//        'Increased ground units attack',                  index 10
//        'Increased ground units defence',                 index 11
//        'Increased ground units health'                   index 12
//    ]

// separate module, because attack modules only needs the indexes
module.exports = {
    minerals: [0, 2000, 5000, 10000, 20000, 30000, 40000, 60000, 80000, 100000, 150000, 200000, 250000],
    gas: [0, 200, 500, 1000, 2000, 4000, 8000, 12000, 16000, 20000, 40000, 60000, 80000],
    time: [0, 50, 60, 70, 80, 90, 100, 120, 150, 200, 300, 400, 6000]
};