var app = angular.module('app', ['ngResource', 'ngRoute']).value('toastr', toastr);

app.config(function($routeProvider, $sceDelegateProvider) {
    'use strict';

    $sceDelegateProvider.resourceUrlWhitelist([
        'self',
        'http://img*.wikia.nocookie.net/**'
    ]);

    var routeUserChecks = {
        adminRole: {
            authenticate: function(auth) {
                return auth.isAuthorizedForRole('admin');
            }
        },
        authenticated: {
            authenticate: function(auth) {
                var userRace = auth.isAuthenticated();
                if (userRace) {
                    $('body').removeClass('zerg-back').removeClass('protoss-back').removeClass('terran-back')
                        .addClass(userRace + '-back');
                    return true;
                }
                else {
                    return false;
                }
            }
        }
    };

    $routeProvider
        .when('/signup', {
            templateUrl: '/partials/account/signup',
            controller: 'SignUpCtrl'
        })
        .when('/profile', {
            templateUrl: '/partials/account/profile',
            controller: 'ProfileCtrl',
            resolve: routeUserChecks.authenticated
        })
        .when('/settings', {
            templateUrl: '/partials/account/settings',
            controller: 'SettingsCtrl',
            resolve: routeUserChecks.authenticated
        })
        .when('/overview', {
            templateUrl: '/partials/overview/overview',
            controller: 'OverviewCtrl',
            resolve: routeUserChecks.authenticated
        })
        .when('/buildings', {
            templateUrl: '/partials/buildings/buildings',
            controller: 'BuildingsCtrl',
            resolve: routeUserChecks.authenticated
        })
        .when('/ships', {
            templateUrl: '/partials/ships/ships',
            controller: 'ShipsCtrl',
            resolve: routeUserChecks.authenticated
        })
        .when('/troops', {
            templateUrl: '/partials/troops/troops',
            controller: 'TroopsCtrl',
            resolve: routeUserChecks.authenticated
        })
        .when('/upgrades', {
            templateUrl: '/partials/upgrades/upgrades',
            controller: 'UpgradesCtrl',
            resolve: routeUserChecks.authenticated
        })
        .when('/map', {
            templateUrl: '/partials/map/map',
            controller: 'MapCtrl',
            resolve: routeUserChecks.authenticated
        })
        .when('/scan', {
            templateUrl: '/partials/scan/scan',
            controller: 'ScanCtrl',
            resolve: routeUserChecks.authenticated
        })
        .when('/scan/:target', {
            templateUrl: '/partials/scan/scanOverview',
            controller: 'ScanOverviewCtrl',
            resolve: routeUserChecks.authenticated
        })
        .when('/attack', {
            templateUrl: '/partials/attack/attack',
            controller: 'AttackCtrl',
            resolve: routeUserChecks.authenticated
        })
        .when('/attack/:target', {
            templateUrl: '/partials/attack/attackUser',
            controller: 'AttackUserCtrl',
            resolve: routeUserChecks.authenticated
        })
        .when('/attack-simulate', {
            templateUrl: '/partials/attack/simulateAttack',
            controller: 'SimulateAttackCtrl',
            resolve: routeUserChecks.authenticated
        })
        .when('/reports', {
            templateUrl: '/partials/reports/reports',
            controller: 'ReportsCtrl',
            resolve: routeUserChecks.authenticated
        })
        .when('/messages', {
            templateUrl: '/partials/message/messageView',
            controller: 'MessageViewCtrl',
            resolve: routeUserChecks.authenticated
        })
        .when('/message-create', {
            templateUrl: '/partials/message/message',
            controller: 'MessageCtrl',
            resolve: routeUserChecks.authenticated
        })
        .when('/message-create/:target', {
            templateUrl: '/partials/message/messageCreate',
            controller: 'MessageCreateCtrl',
            resolve: routeUserChecks.authenticated
        })
        .when('/about', {
            templateUrl: '/partials/about/about',
            controller: 'HomeCtrl'
        })
        .when('/', {
            templateUrl: '/partials/home/home',
            controller: 'HomeCtrl'
        })
        .otherwise({redirectTo: '/'})
});

app.run(function($rootScope, $location) {
    'use strict';

    $rootScope.$on('$routeChangeError', function(ev, current, previous, rejection) {
        if (rejection === 'not authorized') {
            $location.path('/');
        }
    })
});;// http://siddii.github.io/angular-timer/
app.directive('timer', ['$compile', function ($compile) {
    return  {
        restrict: 'EAC',
        replace: false,
        scope: {
            interval: '=interval',
            startTimeAttr: '=startTime',
            endTimeAttr: '=endTime',
            countdownattr: '=countdown',
            finishCallback: '&finishCallback',
            autoStart: '&autoStart',
            maxTimeUnit: '='
        },
        controller: ['$scope', '$element', '$attrs', '$timeout', function ($scope, $element, $attrs, $timeout) {

            // Checking for trim function since IE8 doesn't have it
            // If not a function, create trim with RegEx to mimic native trim
            if (typeof String.prototype.trim !== 'function') {
                String.prototype.trim = function () {
                    return this.replace(/^\s+|\s+$/g, '');
                };
            }

            //angular 1.2 doesn't support attributes ending in "-start", so we're
            //supporting both "autostart" and "auto-start" as a solution for
            //backward and forward compatibility.
            $scope.autoStart = $attrs.autoStart || $attrs.autostart;

            if ($element.html().trim().length === 0) {
                $element.append($compile('<span>{{millis}}</span>')($scope));
            } else {
                $element.append($compile($element.contents())($scope));
            }

            $scope.startTime = null;
            $scope.endTime = null;
            $scope.timeoutId = null;
            $scope.countdown = $scope.countdownattr && parseInt($scope.countdownattr, 10) >= 0 ? parseInt($scope.countdownattr, 10) : undefined;
            $scope.isRunning = false;

            $scope.$on('timer-start', function () {
                $scope.start();
            });

            $scope.$on('timer-resume', function () {
                $scope.resume();
            });

            $scope.$on('timer-stop', function () {
                $scope.stop();
            });

            $scope.$on('timer-clear', function () {
                $scope.clear();
            });

            $scope.$on('timer-set-countdown', function (e, countdown) {
                $scope.countdown = countdown;
            });

            function resetTimeout() {
                if ($scope.timeoutId) {
                    clearTimeout($scope.timeoutId);
                }
            }

            $scope.start = $element[0].start = function () {
                $scope.startTime = $scope.startTimeAttr ? new Date($scope.startTimeAttr) : new Date();
                $scope.endTime = $scope.endTimeAttr ? new Date($scope.endTimeAttr) : null;
                if (!$scope.countdown) {
                    $scope.countdown = $scope.countdownattr && parseInt($scope.countdownattr, 10) > 0 ? parseInt($scope.countdownattr, 10) : undefined;
                }
                resetTimeout();
                tick();
                $scope.isRunning = true;
            };

            $scope.resume = $element[0].resume = function () {
                resetTimeout();
                if ($scope.countdownattr) {
                    $scope.countdown += 1;
                }
                $scope.startTime = new Date() - ($scope.stoppedTime - $scope.startTime);
                tick();
                $scope.isRunning = true;
            };

            $scope.stop = $scope.pause = $element[0].stop = $element[0].pause = function () {
                var timeoutId = $scope.timeoutId;
                $scope.clear();
                $scope.$emit('timer-stopped', {timeoutId: timeoutId, millis: $scope.millis, seconds: $scope.seconds, minutes: $scope.minutes, hours: $scope.hours, days: $scope.days});
            };

            $scope.clear = $element[0].clear = function () {
                // same as stop but without the event being triggered
                $scope.stoppedTime = new Date();
                resetTimeout();
                $scope.timeoutId = null;
                $scope.isRunning = false;
            };

            $element.bind('$destroy', function () {
                resetTimeout();
                $scope.isRunning = false;
            });

            function calculateTimeUnits() {

                // compute time values based on maxTimeUnit specification
                if (!$scope.maxTimeUnit || $scope.maxTimeUnit === 'day') {
                    $scope.seconds = Math.floor(($scope.millis / 1000) % 60);
                    $scope.minutes = Math.floor((($scope.millis / (60000)) % 60));
                    $scope.hours = Math.floor((($scope.millis / (3600000)) % 24));
                    $scope.days = Math.floor((($scope.millis / (3600000)) / 24));
                    $scope.months = 0;
                    $scope.years = 0;
                } else if ($scope.maxTimeUnit === 'second') {
                    $scope.seconds = Math.floor($scope.millis / 1000);
                    $scope.minutes = 0;
                    $scope.hours = 0;
                    $scope.days = 0;
                    $scope.months = 0;
                    $scope.years = 0;
                } else if ($scope.maxTimeUnit === 'minute') {
                    $scope.seconds = Math.floor(($scope.millis / 1000) % 60);
                    $scope.minutes = Math.floor($scope.millis / 60000);
                    $scope.hours = 0;
                    $scope.days = 0;
                    $scope.months = 0;
                    $scope.years = 0;
                } else if ($scope.maxTimeUnit === 'hour') {
                    $scope.seconds = Math.floor(($scope.millis / 1000) % 60);
                    $scope.minutes = Math.floor((($scope.millis / (60000)) % 60));
                    $scope.hours = Math.floor($scope.millis / 3600000);
                    $scope.days = 0;
                    $scope.months = 0;
                    $scope.years = 0;
                } else if ($scope.maxTimeUnit === 'month') {
                    $scope.seconds = Math.floor(($scope.millis / 1000) % 60);
                    $scope.minutes = Math.floor((($scope.millis / (60000)) % 60));
                    $scope.hours = Math.floor((($scope.millis / (3600000)) % 24));
                    $scope.days = Math.floor((($scope.millis / (3600000)) / 24) % 30);
                    $scope.months = Math.floor((($scope.millis / (3600000)) / 24) / 30);
                    $scope.years = 0;
                } else if ($scope.maxTimeUnit === 'year') {
                    $scope.seconds = Math.floor(($scope.millis / 1000) % 60);
                    $scope.minutes = Math.floor((($scope.millis / (60000)) % 60));
                    $scope.hours = Math.floor((($scope.millis / (3600000)) % 24));
                    $scope.days = Math.floor((($scope.millis / (3600000)) / 24) % 30);
                    $scope.months = Math.floor((($scope.millis / (3600000)) / 24 / 30) % 12);
                    $scope.years = Math.floor(($scope.millis / (3600000)) / 24 / 365);
                }

                // plural - singular unit decision
                $scope.secondsS = $scope.seconds == 1 ? '' : 's';
                $scope.minutesS = $scope.minutes == 1 ? '' : 's';
                $scope.hoursS = $scope.hours == 1 ? '' : 's';
                $scope.daysS = $scope.days == 1 ? '' : 's';
                $scope.monthsS = $scope.months == 1 ? '' : 's';
                $scope.yearsS = $scope.years == 1 ? '' : 's';
                //add leading zero if number is smaller than 10
                $scope.sseconds = $scope.seconds < 10 ? '0' + $scope.seconds : $scope.seconds;
                $scope.mminutes = $scope.minutes < 10 ? '0' + $scope.minutes : $scope.minutes;
                $scope.hhours = $scope.hours < 10 ? '0' + $scope.hours : $scope.hours;
                $scope.ddays = $scope.days < 10 ? '0' + $scope.days : $scope.days;
                $scope.mmonths = $scope.months < 10 ? '0' + $scope.months : $scope.months;
                $scope.yyears = $scope.years < 10 ? '0' + $scope.years : $scope.years;

            }

            //determine initial values of time units and add AddSeconds functionality
            if ($scope.countdownattr) {
                $scope.millis = $scope.countdownattr * 1000;

                $scope.addCDSeconds = $element[0].addCDSeconds = function (extraSeconds) {
                    $scope.countdown += extraSeconds;
                    $scope.$digest();
                    if (!$scope.isRunning) {
                        $scope.start();
                    }
                };

                $scope.$on('timer-add-cd-seconds', function (e, extraSeconds) {
                    $timeout(function () {
                        $scope.addCDSeconds(extraSeconds);
                    });
                });

                $scope.$on('timer-set-countdown-seconds', function (e, countdownSeconds) {
                    if (!$scope.isRunning) {
                        $scope.clear();
                    }

                    $scope.countdown = countdownSeconds;
                    $scope.millis = countdownSeconds * 1000;
                    calculateTimeUnits();
                });
            } else {
                $scope.millis = 0;
            }
            calculateTimeUnits();

            var tick = function () {

                $scope.millis = new Date() - $scope.startTime;
                var adjustment = $scope.millis % 1000;

                if ($scope.endTimeAttr) {
                    $scope.millis = $scope.endTime - new Date();
                    adjustment = $scope.interval - $scope.millis % 1000;
                }


                if ($scope.countdownattr) {
                    $scope.millis = $scope.countdown * 1000;
                }

                if ($scope.millis < 0) {
                    $scope.stop();
                    $scope.millis = 0;
                    calculateTimeUnits();
                    if($scope.finishCallback) {
                        $scope.$eval($scope.finishCallback);
                    }
                    return;
                }
                calculateTimeUnits();

                //We are not using $timeout for a reason. Please read here - https://github.com/siddii/angular-timer/pull/5
                $scope.timeoutId = setTimeout(function () {
                    tick();
                    $scope.$digest();
                }, $scope.interval - adjustment);

                $scope.$emit('timer-tick', {timeoutId: $scope.timeoutId, millis: $scope.millis});

                if ($scope.countdown > 0) {
                    $scope.countdown--;
                }
                else if ($scope.countdown <= 0) {
                    $scope.stop();
                    if($scope.finishCallback) {
                        $scope.$eval($scope.finishCallback);
                    }
                }
            };

            if ($scope.autoStart === undefined || $scope.autoStart === true) {
                $scope.start();
            }
        }]
    };
}]);;app.factory('notifier', function(toastr) {
    'use strict';

    return {
        success: function(msg) {
            toastr.success(msg);
        },
        error: function(msg) {
            toastr.error(msg);
        }
    }
});;app.factory('BuildingsModel', function () {
    'use strict';

    return [
        {
            //index 0 - minerals
            amount: [1, 2, 4, 6, 8, 11, 14, 17, 21, 26, 31, 38, 45, 53, 63, 74, 86, 100, 116, 135, 155, 179, 199],
            cost: [0, 112, 169, 252, 378, 568, 853, 1281, 1921, 2882, 4323, 6486, 9730, 14596, 21893, 32841, 49267, 73895, 103453, 166263, 249394, 374091, 561137],
            energy: [0, 12, 20, 29, 40, 53, 68, 86, 106, 130, 157, 188, 224, 266, 313, 341, 378, 402, 437, 479, 501, 543, 599],
            time: [0, 1, 20, 43, 68, 101, 158, 219, 280, 340, 400, 521, 555, 628, 688, 733, 877, 1037, 1486, 1924, 2488, 2950, 3599]
        },
        {
            // index 1 - gas
            amount: [0, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 13, 15, 18, 22, 28, 33, 39, 45, 52, 62, 75, 99],
            cost: [0, 449, 674, 1012, 1518, 2277, 3417, 5125, 7688, 11533, 17300, 25949, 38924, 58385, 87579, 131368, 197052, 295579, 443368, 665052, 997577, 1496365, 2244548],
            energy: [0, 24, 40, 59, 81, 106, 136, 171, 212, 259, 290, 321, 352, 383, 414, 445, 476, 507, 538, 569, 600, 631, 699],
            time: [0, 8, 22, 48, 76, 112, 176, 243, 311, 378, 444, 579, 617, 698, 764, 814, 974, 1152, 1651, 2138, 2764, 3278, 3999]
        },
        {
            // index 2 - energy
            amount: [20, 33, 72, 119, 176, 242, 318, 408, 513, 636, 777, 941, 1130, 1346, 1595, 1880, 2205, 2577, 3002, 3486, 3994],
            cost: [0, 105, 157, 235, 354, 530, 796, 1195, 1793, 2690, 4042, 6053, 9081, 12931, 18596, 28652, 43978, 68968, 103453, 155179, 232768],
            energy: [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
            time: [0, 84, 153, 213, 287, 357, 415, 498, 571, 654, 712, 767, 815, 997, 1267, 1341, 1552, 1683, 1988, 2543, 3200]
        },
        {
            // index 3 - supply
            amount: [6, 12, 24, 36, 48, 66, 84, 102, 126, 156, 186, 228, 270, 318, 378, 444, 516, 600, 696, 777, 888, 999],
            cost: [0, 336, 507, 756, 1134, 1704, 2559, 3843, 5763, 8646, 12969, 19458, 29190, 43788, 65679, 98523, 147801, 221685, 310359, 498789, 748182, 1122273],
            energy: [0, 8, 14, 20, 28, 37, 48, 60, 74, 91, 110, 132, 157, 186, 219, 258, 301, 350, 407, 471, 543, 599],
            time: [0, 67, 154, 214, 329, 384, 442, 497, 543, 612, 698, 754, 812, 888, 1023, 1267, 1312, 1452, 1674, 1980, 2457, 3200]
        },
        {
            // index 4 - troops
            amount: [0, 1, 1, 1, 1, 2, 2, 2, 3, 3, 4],
            cost: [0, 1029, 2206, 4622, 7328, 10111, 14611, 17999, 22879, 28829, 35999],
            energy: [0, 18, 32, 45, 76, 112, 154, 212, 267, 299, 399],
            time: [0, 1346, 1874, 2526, 3142, 3652, 4382, 5025, 5755, 6266, 6750]
        },
        {
            // index 5 - ships
            amount: [0, 1, 1, 1, 1, 2, 2, 2, 3, 3, 4],
            cost: [0, 1143, 2451, 5136, 8142, 11234, 16234, 19999, 25421, 32032, 39999],
            energy: [0, 27, 54, 87, 112, 154, 216, 338, 415, 499, 699],
            time: [0, 1591, 2215, 2985, 3713, 4316, 5179, 5938, 6802, 7405, 7977]
        },
        {
            // index 6 - upgrades
            amount: [0, 1, 1, 1, 1, 2, 2, 2, 3, 3, 4],
            cost: [0, 1134, 2941, 6163, 9770, 13481, 19481, 23999, 30505, 38438, 47999],
            energy: [0, 47, 143, 326, 412, 538, 653, 743, 821, 895, 999],
            time: [0, 943, 1704, 2296, 2856, 3320, 3984, 4568, 5232, 5696, 6136]
        }
    ]
});;app.factory('RaceModel', function() {
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
});;app.factory('ShipsModel', function () {
    'use strict';

    return {
        // transport tier1 tier2 tier3
        attack: [1, 15, 59, 99],
        defence: [5, 0, 10, 15],
        health: [200, 100, 300, 500],
        capacity: [15000, 500, 2000, 4000],
        minerals: [19999, 12999, 59999, 139999],
        gas: [3999, 0, 19999, 59999],
        supply: [2, 2, 3, 6],
        time: [199, 49, 299, 499]
    }
});;app.factory('TroopsModel', function () {
    'use strict';

    return {
        // tier1 tier2 tier3
        attack: [6, 19, 34],
        defence: [5, 15, 30],
        health: [45, 130, 280],
        minerals: [3499, 15999, 34999],
        gas: [0, 5999, 16999],
        supply: [1, 1, 2],
        time: [139, 419, 699]
    }
});;app.factory('UpgradesModel', function () {
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
});;app.factory('auth', function($q, $http, identity, UsersResource) {
    'use strict';
    return {
        signup: function(user) {
            var deferred = $q.defer();

            var user = new UsersResource(user);
            user.$save().then(function(){
                identity.currentUser = user;
                deferred.resolve(true);
            }, function(response){
                deferred.reject(response);
            });

            return deferred.promise;
        },
        update: function(user){
            var deferred = $q.defer();

            var updatedUser = new UsersResource(user);
            updatedUser._id = identity.currentUser._id;
            updatedUser.$update().then(function() {
                identity.currentUser.firstName = updatedUser.firstName;
                identity.currentUser.lastName = updatedUser.lastName;
                deferred.resolve();
            }, function(response) {
                deferred.reject(response);
            });

            return deferred.promise;
        },
        login: function(user) {
            var deferred = $q.defer();

            $http.post('/login', user).success(function(response) {
                if (response.success) {
                    var user = new UsersResource();
                    angular.extend(user, response.user);
                    identity.currentUser = user;
                    deferred.resolve(true);
                }
                else {
                    deferred.resolve(false);
                }
            });

            return deferred.promise;
        },
        logout: function() {
            var deferred = $q.defer();

            $http.post('/logout').success(function() {
                identity.currentUser = undefined;
                deferred.resolve();
            });

            return deferred.promise;
        },
        isAuthenticated: function() {
            if (identity.isAuthenticated()) {
                return identity.currentUser.race;
            }
            else {
                return $q.reject('not authorized');
            }
        },
        isAuthorizedForRole: function(role) {
            if (identity.isAuthorizedForRole(role)) {
                return true;
            }
            else {
                return $q.reject('not authorized');
            }
        }
    }
});;app.factory('identity', function($window, UsersResource) {
    'use strict';

    var user;
    if ($window.bootstrappedUserObject) {
        user = new UsersResource();
        angular.extend(user, $window.bootstrappedUserObject);
    }

    return {
        currentUser: user,
        isAuthenticated: function() {
            return !!this.currentUser;
        },
        isAuthorizedForRole: function(role) {
            return !!this.currentUser && this.currentUser.roles.indexOf(role) >= 0;
        }
    }
});;app.controller('LoginCtrl', function ($scope, $rootScope, $location, notifier, identity, auth, GameObjectsCache) {
    'use strict';

    $scope.identity = identity;

    $scope.login = function (user) {
        auth.login(user).then(function (success) {
            if (success) {
                $rootScope.objectsRefreshSeconds = localStorage.getItem('novcraft-usersettings-refreshrate-'+identity.currentUser._id) || 2;
                notifier.success('Successful login!');
                $('body').removeClass('zerg-back').removeClass('protoss-back').removeClass('terran-back').addClass(identity.currentUser.race + '-back');
                $location.path('/overview')
            }
            else {
                notifier.error('Invalid username or password');
            }
        })
    };

    $scope.logout = function () {
        auth.logout().then(function () {
            window.location.reload(true);
            notifier.success('Successful logout');
            $scope.user = {};
            GameObjectsCache.refresh();
            $location.path('/');
        });
    }
});;app.controller('ProfileCtrl', function($scope, identity) {
    'use strict';

    $scope.user = {
        username: identity.currentUser.username,
        firstName: identity.currentUser.firstName,
        lastName: identity.currentUser.lastName
    }
});;app.controller('SettingsCtrl', function ($scope, $location, identity, auth, notifier, $rootScope) {
    'use strict';

    $scope.user = identity.currentUser;

    $scope.refreshRate = $rootScope.objectsRefreshSeconds;

    $scope.hidePasswordInputs = true;
    $scope.showPassword = function () {
        $scope.user.password = '';
        $scope.hidePasswordInputs = false;
    };

    $scope.update = function (user) {
        auth.update(user).then(function () {
            $scope.firstName = user.firstName;
            $scope.lastName = user.lastName;
            notifier.success('Update successful !');
            $location.path('/overview');
        })
    };

    $scope.updateRefreshRate = function (rate) {
        $rootScope.objectsRefreshSeconds = rate;
        $scope.refreshRate = rate;
        localStorage.setItem('novcraft-usersettings-refreshrate-' + identity.currentUser._id, rate);

        notifier.success('Update successful !');
        $location.path('/overview');
    }
});;app.controller('SignUpCtrl', function ($scope, $location, auth, notifier) {
    'use strict';

    $scope.user = {};

    $scope.signup = function (user) {
        auth.signup(user).then(function () {
            notifier.success('Registration successful !');
            $location.path('/');

        }, function() {
            notifier.error('This username already exists !');
        });
    };

    $scope.changeRace = function (race) {
        $scope.user.race = race;

        $('body').removeClass('zerg-back').removeClass('protoss-back').removeClass('terran-back').addClass(race + '-back');
    }
});;app.factory('Calculator', function (BuildingsModel, ShipsModel, TroopsModel, UpgradesModel) {
    'use strict';

    function flightTime(objects, coords) {
        var timePerClick = 18000000 / 1730;
        var takeOffMS = 17 * 60000;

        function get3DDistance(coord1, coord2) {
            return Math.sqrt(
                ((coord1[0] - coord2[0]) * (coord1[0] - coord2[0]) +
                    (coord1[1] - coord2[1]) * (coord1[1] - coord2[1]) +
                    (coord1[2] - coord2[2]) * (coord1[2] - coord2[2]))
            )
        }

        return Math.round(timePerClick * get3DDistance(objects.coordinates, coords) *
            (2 - UpgradesModel.multiplier[objects.upgrades[6]])) + takeOffMS;
    }

    function freeEnergy(objects) {
        var indexes = objects.buildings;
        var energy = BuildingsModel[2].amount[indexes[2]];

        for (var i = 0; i < BuildingsModel.length; i++) {
            energy -= BuildingsModel[i].energy[indexes[i]];
        }

        return energy;
    }

    function freeSupply(objects) {
        var supply = BuildingsModel[3].amount[objects.buildings[3]];
        var troopsIndexes = objects.troops;
        var shipsIndexes = objects.ships;

        supply -= TroopsModel.supply[0] * troopsIndexes[0];
        supply -= TroopsModel.supply[1] * troopsIndexes[1];
        supply -= TroopsModel.supply[2] * troopsIndexes[2];

        supply -= ShipsModel.supply[0] * shipsIndexes[0];
        supply -= ShipsModel.supply[1] * shipsIndexes[1];
        supply -= ShipsModel.supply[2] * shipsIndexes[2];
        supply -= ShipsModel.supply[3] * shipsIndexes[3];

        var i;
        // includes all the attacking ships
        for (i = 0; i < objects.attacks.length; i++) {
            var attackShips = objects.attacks[i].ships;

            supply -= ShipsModel.supply[0] * attackShips[0];
            supply -= ShipsModel.supply[1] * attackShips[1];
            supply -= ShipsModel.supply[2] * attackShips[2];
            supply -= ShipsModel.supply[3] * attackShips[3];
        }

        // includes all the returning ships
        for (i = 0; i < objects.comebacks.length; i++) {
            var returningShips = objects.comebacks[i].ships;

            supply -= ShipsModel.supply[0] * returningShips[0];
            supply -= ShipsModel.supply[1] * returningShips[1];
            supply -= ShipsModel.supply[2] * returningShips[2];
            supply -= ShipsModel.supply[3] * returningShips[3];
        }

        // includes all the ships and troops being built
        for (i = 0; i < objects.tasks.length; i++) {
            var task = objects.tasks[i];

            if (task.type == 'ships') {
                supply -= ShipsModel.supply[task.indexToAddTo];
            }
            else if (task.type == 'troops') {
                supply -= TroopsModel.supply[task.indexToAddTo];
            }
        }

        return supply;
    }

    function requiredResources(objects, type, index) {
        if (!objects) {
            return;
        }

        var cost = {
            time: requiredTime(objects, type, index)
        };

        switch (type) {
            case 'buildings' :
                cost.minerals = BuildingsModel[index].cost[objects.buildings[index] + 1];
                cost.energy = BuildingsModel[index].energy[objects.buildings[index] + 1] - BuildingsModel[index].energy[objects.buildings[index]];
                break;
            case 'ships' :
                cost.minerals = ShipsModel.minerals[index];
                cost.gas = ShipsModel.gas[index];
                cost.supply = ShipsModel.supply[index];
                break;
            case 'troops' :
                cost.minerals = TroopsModel.minerals[index];
                cost.gas = TroopsModel.gas[index];
                cost.supply = TroopsModel.supply[index];
                break;
            case 'upgrades' :
                cost.minerals = UpgradesModel.cost.minerals[objects.upgrades[index] + 1];
                cost.gas = UpgradesModel.cost.gas[objects.upgrades[index] + 1];
                break;
        }

        return cost;
    }

    function requiredResourcesMessage(objects, type, index) {
        var cost = requiredResources(objects, type, index);

        cost.time = convertToTime(cost.time);

        var message = ' will cost you';
        for (var resource in cost) {
            if (cost.hasOwnProperty(resource)) {
                message += ' ' + cost[resource] + ' ' + resource;
            }
        }

        return message;
    }

    function convertToTime(minutes) {
        return Math.floor(minutes / 60) + ' hours , ' + minutes % 60 + ' minutes';
    }

    function requiredTime(objects, type, index) {
        var time;
        switch (type) {
            case 'buildings' :
                time = BuildingsModel[index].time[objects.buildings[index] + 1] * (2 - UpgradesModel.multiplier[objects.upgrades[2]]);
                break;
            case 'ships' :
                time = ShipsModel.time[index] * (2 - UpgradesModel.multiplier[objects.upgrades[3]]);
                break;
            case 'troops' :
                time = TroopsModel.time[index] * (2 - UpgradesModel.multiplier[objects.upgrades[4]]);
                break;
            case 'upgrades' :
                time = UpgradesModel.cost.time[objects.upgrades[index] + 1] * (2 - UpgradesModel.multiplier[objects.upgrades[5]]);
                break;
        }

        return Math.round(time);
    }

    function canAffordBuilding(objects, index) {
        var cost = BuildingsModel[index].cost[objects.buildings[index] + 1];
        var energy = BuildingsModel[index].energy[objects.buildings[index] + 1] - BuildingsModel[index].energy[objects.buildings[index]];

        if (objects.minerals < cost) {
            return {
                answer: false,
                reason: 'Not enough minerals'
            }
        }
        else if (freeEnergy(objects) < energy) {
            return {
                answer: false,
                reason: 'Not enough energy'
            }
        }

        return {
            answer: true
        }
    }

    function canAffordShip(objects, index) {
        var minerals = ShipsModel.minerals[index];
        var gas = ShipsModel.gas[index];
        var supply = ShipsModel.supply[index];

        if (minerals > objects.minerals) {
            return {
                answer: false,
                reason: 'Not enough minerals'
            }
        }
        else if (gas > objects.gas) {
            return {
                answer: false,
                reason: 'Not enough gas'
            }
        }
        else if (supply > freeSupply(objects)) {
            return {
                answer: false,
                reason: 'Not enough supply'
            }
        }

        return {
            answer: true
        }
    }

    function canAffordTroop(objects, index) {
        var minerals = TroopsModel.minerals[index];
        var gas = TroopsModel.gas[index];
        var supply = TroopsModel.supply[index];

        if (minerals > objects.minerals) {
            return {
                answer: false,
                reason: 'Not enough minerals'
            }
        }
        else if (gas > objects.gas) {
            return {
                answer: false,
                reason: 'Not enough gas'
            }
        }
        else if (supply > freeSupply(objects)) {
            return {
                answer: false,
                reason: 'Not enough supply'
            }
        }

        return {
            answer: true
        }
    }

    function canAffordUpgrade(objects, index) {
        var minerals = UpgradesModel.cost.minerals[index];
        var gas = UpgradesModel.cost.gas[index];

        if (minerals > objects.minerals) {
            return {
                answer: false,
                reason: 'Not enough minerals'
            }
        }
        else if (gas > objects.gas) {
            return {
                answer: false,
                reason: 'Not enough gas'
            }
        }

        return {
            answer: true
        }
    }

    function upgradeInProgress(objects, index) {
        for (var i = 0; i < objects.tasks.length; i++) {
            if (objects.tasks[i].type == 'upgrades' && objects.tasks[i].indexToAddTo == index) {
                return false;
            }
        }

        return true;
    }

    function mineralsPerMinute(objects) {
        return Math.round(UpgradesModel.multiplier[objects.upgrades[0]] * BuildingsModel[0].amount[objects.buildings[0]]);
    }

    function gasPerMinute(objects) {
        return Math.round(UpgradesModel.multiplier[objects.upgrades[1]] * BuildingsModel[1].amount[objects.buildings[1]]);
    }

    return {
        freeEnergy: freeEnergy,
        freeSupply: freeSupply,
        flightTime: flightTime,
        requiredResources: requiredResources,
        requiredResourcesMessage: requiredResourcesMessage,
        convertToTime: convertToTime,
        requiredTime: requiredTime,
        canAffordBuilding: canAffordBuilding,
        canAffordShip: canAffordShip,
        canAffordTroop: canAffordTroop,
        canAffordUpgrade: canAffordUpgrade,
        upgradeInProgress: upgradeInProgress,
        mineralsPerMinute: mineralsPerMinute,
        gasPerMinute: gasPerMinute
    }
});;app.factory('GameObjectsCache', function (GameRequests) {
    'use strict';

    var cachedGameObjects;

    function checkIfRefreshIsNeeded() {
        if (!cachedGameObjects) {
            return;
        }

        var now = new Date().getTime();
        var needsRefresh = false;
        var i;

        if (!cachedGameObjects.tasks) {
            needsRefresh = true;
            return;
        }

        for (i = 0; i < cachedGameObjects.tasks.length; i++) {
            if (cachedGameObjects.tasks[i].time <= now) {
                needsRefresh = true;
            }
        }

        if (!needsRefresh) {

            if (!cachedGameObjects.attacks) {
                needsRefresh = true;
                return;
            }

            for (i = 0; i < cachedGameObjects.attacks.length; i++) {
                if (cachedGameObjects.attacks[i].time <= now) {
                    needsRefresh = true;
                }
            }
        }

        if (!needsRefresh) {
            if (!cachedGameObjects.defences) {
                needsRefresh = true;
                return;
            }

            for (i = 0; i < cachedGameObjects.defences.length; i++) {
                if (cachedGameObjects.defences[i].time <= now) {
                    needsRefresh = true;
                }
            }
        }

        if (!needsRefresh) {
            for (i = 0; i < cachedGameObjects.comebacks.length; i++) {
                if (cachedGameObjects.comebacks[i].time <= now) {
                    needsRefresh = true;
                }
            }
        }

        if (needsRefresh) {
            cachedGameObjects = undefined;
        }
    }

    return {
        refresh: function() {
            cachedGameObjects = undefined;
        },
        getGameObjectsForUser: function () {
            checkIfRefreshIsNeeded();

            if (!cachedGameObjects || (new Date()).getTime() - cachedGameObjects.updated >= 60000) {
                cachedGameObjects = GameRequests.getUserObjects();
            }

            return cachedGameObjects;
        },
        update: function(newObjects) {
            cachedGameObjects = newObjects;
        }
    }
});;app.factory('GameRequests', function($q, $http, $resource, UsersResource) {
    'use strict';

    function makeRequest(url, data) {
        data = data || {};
        var deferred = $q.defer();

        $http.post(url, data).success(function(response) {
            if (response.success) {
                deferred.resolve(response);
            }
            else {
                deferred.resolve(false);
            }
        });

        return deferred.promise;
    }

    function getRequest(url) {
        var deferred = $q.defer();

        $http.get(url).success(function(response) {
            if (response.success) {
                deferred.resolve(response);
            }
            else {
                deferred.resolve(false);
            }
        });

        return deferred.promise;
    }

    return {
        scanUser: function(targetID) {
            return getRequest('/api/users-scan/' + targetID);
        },
        createTask: function (taskType, taskIndexToAddTo) {
            return makeRequest('/api/game-tasks', {
                taskType : taskType,
                taskIndexToAddTo: taskIndexToAddTo
            });
        },
        getAllUsers: function() {
            var deferred = $q.defer();

            UsersResource.query().$promise.then(function(users) {
                if (!users) {
                    deferred.reject('No such user exists');
                }
                deferred.resolve(users);
            });

            return deferred.promise;
        },
        getUserReports: function() {
            return getRequest('/api/game-reports');
        },
        getUserMessages: function() {
            return getRequest('/api/game-messages');
        },
        createMessage: function(targetID, textToSend) {
            return makeRequest('/api/game-messages', {
                targetID: targetID.target,
                textToSend : textToSend
            });
        },
        createAttack: function(targetID, ships, turns) {
            return makeRequest('/api/game-attack/' + targetID, {
                ships : ships,
                turns: turns
            });
        },
        simulateAttack: function(attacker, defender, turns) {
            return makeRequest('/api/game-attack-simulate', {
                attacker : attacker,
                turns: turns,
                defender: defender
            });
        },
        findUserIdByCoords: function(coords) {
            var deferred = $q.defer();

            UsersResource.query().$promise.then(function(users) {
                if (!users) {
                    console.log('no users found error');
                }

                for (var i = 0; i < users.length; i++) {
                    var targetCoords = users[i].coordinates;
                    if (targetCoords[0] == coords[0] && targetCoords[1] == coords[1] && targetCoords[2] == coords[2]) {
                        deferred.resolve(users[i]._id);
                    }
                }

                deferred.reject('No such user exists');
            });

            return deferred.promise;
        },
        findUserIdByUsername: function(username) {
            var deferred = $q.defer();

            UsersResource.query().$promise.then(function(users) {
                if (!users) {
                    console.log('no users found error');
                }

                for (var i = 0; i < users.length; i++) {
                    if (username == users[i].username) {
                        deferred.resolve(users[i]._id);
                    }
                }

                deferred.reject('No such user exists');
            });

            return deferred.promise;
        },
        getUserObjects: function() {
            return $resource('/api/game-objects').get();
        }
    }
});;app.factory('UsersResource', function($resource) {
    'use strict';

    return $resource('/api/users/:id', {_id: '@id'}, {update: {method:'PUT', isArray:false}});
});;app.controller('AttackCtrl', function ($scope, $location, GameRequests, notifier, identity) {
    'use strict';

    $scope.coords = ['', '', ''];
    $scope.targetUsername = '';

    $scope.confirmCoords = function () {
        if (identity.currentUser.coordinates[0] == $scope.coordinates[0] &&
            identity.currentUser.coordinates[1] == $scope.coordinates[1] &&
            identity.currentUser.coordinates[2] == $scope.coordinates[2]) {

            notifier.error('You can not attack yourself');
            return;
        }
        GameRequests.findUserIdByCoords($scope.coords).then(function (id) {
            $location.path('/attack/' + id);

        }, function (error) {
            notifier.error(error);
        });
    };

    $scope.confirmUsername = function () {
        if (identity.currentUser.username == $scope.targetUsername) {
            notifier.error('You can not attack yourself');
            return;
        }
        GameRequests.findUserIdByUsername($scope.targetUsername).then(function (id) {
            $location.path('/attack/' + id);

        }, function (error) {
            notifier.error(error);
        });
    };
});;app.controller('AttackUserCtrl', function ($scope, $location, $routeParams, ShipsModel, GameObjectsCache, GameRequests, RaceModel , notifier, identity) {
    'use strict';

    $scope.selectTurns = 10;
    $scope.raceModel = RaceModel[identity.currentUser.race];
    $scope.shipsModel = ShipsModel;
    $scope.ships = [0, 0, 0, 0];

    GameObjectsCache.getGameObjectsForUser().$promise.then(function (objects) {
        $scope.userShips = objects.ships;
    });

    $scope.confirm = function () {
        $scope.ships = [Math.max($scope.ships[0],0), Math.max($scope.ships[1],0), Math.max($scope.ships[2],0), Math.max($scope.ships[3],0)];

        $scope.confirmerText = 'Are you sure you want to send';
        for (var i = 0; i < $scope.ships.length; i++) {
            var shipAmmount = $scope.ships[i];
            if (shipAmmount > 0) {
                $scope.confirmerText += ' '+ shipAmmount+ ' ' + $scope.raceModel.ships[i].name + 's,';
            }
        }

        $scope.confirmerText +=' to fight for ' + $scope.selectTurns + ' turns?';
    };

    $scope.confirmerAccept = function () {
        GameRequests.createAttack($routeParams.target, $scope.ships, $scope.selectTurns).then(function(response) {
            if (response.success) {
                notifier.success('Attack sent');
                GameObjectsCache.refresh();
                GameObjectsCache.getGameObjectsForUser().$promise.then(function (objects) {
                    $scope.userShips = objects.ships;
                });
            }
            else {
                notifier.error('Not enough minerals or energy');
            }
        }, function(error) {
            console.log(error);
        });
    };
});;app.controller('SimulateAttackCtrl', function ($scope, $rootScope, GameRequests, identity, RaceModel, TroopsModel, ShipsModel, UpgradesModel) {
    'use strict';

    $scope.raceModel = RaceModel[identity.currentUser.race];
    $scope.Math = Math;
    $scope.troopsModel = TroopsModel;
    $scope.shipsModel = ShipsModel;
    $scope.upgradesModel = UpgradesModel;

    $scope.upgradeOptions = [];
    for (var i = 0; i < UpgradesModel.multiplier.length; i++) {
        $scope.upgradeOptions.push({
            value: i,
            text: 'Level ' + i + '  (' + Math.round((UpgradesModel.multiplier[i] - 1) * 100) + ' %)'
        });
    }

    $scope.defenderTroops = [0,0,0];
    $scope.defenderGroundUpgrades = [0,0,0];
    $scope.defenderShips = [0,0,0,0];
    $scope.defenderAirUpgrades = [0,0,0];

    $scope.attackerShips = [0,0,0,0];
    $scope.attackerUpgrades = [0,0,0];

    $scope.selectSimulatedTurns = 10;

    if ($rootScope.lastUserObject) {
        $scope.defenderTroops = $rootScope.lastUserObject.troops.slice();
        $scope.defenderShips =  $rootScope.lastUserObject.ships.slice();

        $rootScope.lastUserObject = undefined;
    }

    $scope.simulate = function () {
        var attacker = {
            ships: $scope.attackerShips,
            airUpgrades: $scope.attackerUpgrades
        };
        var defender = {
            troops: $scope.defenderTroops,
            groundUpgrades: $scope.defenderGroundUpgrades,
            ships: $scope.defenderShips,
            airUpgrades: $scope.defenderAirUpgrades
        };

        attacker.ships = [Math.max(attacker.ships[0],0), Math.max(attacker.ships[1],0), Math.max(attacker.ships[2],0), Math.max(attacker.ships[3],0)];
        defender.troops = [Math.max(defender.troops[0],0), Math.max(defender.troops[1],0), Math.max(defender.troops[2],0)];
        defender.ships = [Math.max(defender.ships[0],0), Math.max(defender.ships[1],0), Math.max(defender.ships[2],0), Math.max(defender.ships[3],0)];

        GameRequests.simulateAttack(attacker, defender, $scope.selectSimulatedTurns).then(function(response){
            $scope.simulatedReport = response.report;
        },function(error) {
            console.log('error fetching simulated report ' + error);
        })
    }
});;app.controller('BuildingsCtrl',
    function ($scope, $rootScope, $interval, GameObjectsCache, RaceModel, identity, BuildingsModel, Calculator, notifier, GameRequests) {
        'use strict';

        $scope.raceModel = RaceModel[identity.currentUser.race];
        $scope.buildingsModel = BuildingsModel;

        queryGameObjects();

        // the client queries himself every X or 30 sec. The server is queried only once per 2 min
        $rootScope.objectsRefreshSeconds = $rootScope.objectsRefreshSeconds || 30;
        $interval(queryGameObjects, 1000 * $rootScope.objectsRefreshSeconds);

        function queryGameObjects() {
            GameObjectsCache.getGameObjectsForUser().$promise.then(function (objects) {
                $scope.filteredTasks = objects.tasks
                    .filter(function (obj) {
                        return obj.type == 'buildings'
                    });

                $scope.gameObjects = objects;

                $scope.now = ((new Date()).getTime());

                $scope.freeEnergy = Calculator.freeEnergy(objects);
                $scope.freeSupply = Calculator.freeSupply(objects);
                $scope.mineralsPerMinute = Calculator.mineralsPerMinute(objects);
                $scope.gasPerMinute = Calculator.gasPerMinute(objects);

                refreshCosts();

                refreshButtons();
            })
        }

        function refreshCosts() {
            $scope.buildingCost = [];

            for (var i = 0; i < BuildingsModel.length; i++) {
                $scope.buildingCost.push(Calculator.requiredResources($scope.gameObjects, 'buildings', i));
                $scope.buildingCost[i].time = Calculator.convertToTime($scope.buildingCost[i].time);
            }
        }

        function refreshButtons() {
            $scope.btnClass = [];
            $scope.btnText = [];
            $scope.btnDisabled = [];

            for (var i = 0; i < BuildingsModel.length; i++) {
                if ($scope.filteredTasks.length > 0) {
                    $scope.btnClass.push('btn-danger');
                    $scope.btnText.push('Building in progress');
                    $scope.btnDisabled.push(true);
                    continue;
                }
                else if ($scope.gameObjects.buildings[i] == BuildingsModel[i].cost.length - 1) {
                    $scope.btnClass.push('btn-success');
                    $scope.btnText.push('Max level');
                    $scope.btnDisabled.push(true);
                }

                var canAfford = Calculator.canAffordBuilding($scope.gameObjects, i);

                if (canAfford.answer) {
                    $scope.btnClass.push('btn-success');
                    $scope.btnText.push('Build');
                    $scope.btnDisabled.push(false);
                }
                else {
                    $scope.btnClass.push('btn-danger');
                    $scope.btnText.push(canAfford.reason);
                    $scope.btnDisabled.push(true);
                }
            }
        }

        var buildingIndex = -1;
        $scope.confirm = function (index) {
            buildingIndex = index;
            $scope.confirmerText = 'Building the ' + $scope.raceModel.buildings[index].name
                + Calculator.requiredResourcesMessage($scope.gameObjects, 'buildings', index);
        };

        $scope.confirmerAccept = function () {
            GameRequests.createTask('buildings', buildingIndex).then(function (response) {
                if (response.success) {
                    notifier.success('Building started');
                    GameObjectsCache.refresh();
                    queryGameObjects();
                }
                else {
                    notifier.error('Not enough minerals or energy');
                }
            }, function (error) {
                console.log(error)
            })
        };
    });;app.controller('HomeCtrl', function($scope, identity) {
    'use strict';
    $scope.hideSignup = identity.isAuthenticated();
});;app.controller('MapCtrl', function ($scope, GameRequests, identity, RaceModel) {
    'use strict';

    $scope.raceModel = RaceModel[identity.currentUser.race];
    GameRequests.getAllUsers().then(function (users) {
        $scope.allUsers = users.filter(function (user) {
            return user.username !== identity.currentUser.username;
        });
    }, function (error) {
        console.log(error);
    });
});;app.controller('MessageCreateCtrl', function ($scope, $routeParams, GameRequests, notifier) {
    'use strict';

    $('#showMessageInputBtn').click();
    $scope.sendMessage = function() {
        GameRequests.createMessage($routeParams, $scope.textToSend).then(function (response) {
            if (!response.success) {
                notifier.error('Something is bad');
                return;
            }

            notifier.success('Message sent');
        }, function (error) {
            console.log(error)
        });
    };
});;app.controller('MessageCtrl', function ($scope, $location, $timeout, GameObjectsCache, Calculator, GameRequests, notifier, identity) {
    'use strict';

    $scope.confirm = function () {
        if (identity.currentUser.coordinates[0] == $scope.coords[0] &&
            identity.currentUser.coordinates[1] == $scope.coords[1] &&
            identity.currentUser.coordinates[2] == $scope.coords[2]) {

            notifier.error('You can not write to yourself');
            return;
        }
        GameRequests.findUserIdByCoords($scope.coords).then(function (id) {
            $location.path('/message-create/' + id);

        }, function (error) {
            notifier.error(error);
        });
    };

    $scope.confirmUsername = function () {
        if (identity.currentUser.username == $scope.targetUsername) {
            notifier.error('You can not write to yourself');
            return;
        }
        GameRequests.findUserIdByUsername($scope.targetUsername).then(function (id) {
            $location.path('/message-create/' + id);

        }, function (error) {
            notifier.error(error);
        });
    };
});;app.controller('MessageViewCtrl', function ($scope, GameRequests, identity) {
    'use strict';

    var currentMessages = JSON.parse(localStorage.getItem('novcraft-userobjects-usermessages-'+identity.currentUser._id)) || [];

    GameRequests.getUserMessages().then(function (responce) {
        var newMessages = currentMessages.concat(responce.allMessages);
        localStorage.setItem('novcraft-userobjects-usermessages-'+identity.currentUser._id, JSON.stringify(newMessages));

        $scope.allMessages = newMessages;

    }, function (error) {
        console.log(error);
    });

    $scope.deleteMessage = function(index) {
        $scope.allMessages.splice(index,1);
        localStorage.setItem('novcraft-userobjects-usermessages-'+identity.currentUser._id, JSON.stringify($scope.allMessages));
    };

    $scope.viewMessage = function (index) {
        $scope.selectedMessage = $scope.allMessages[$scope.allMessages.length - index - 1];
    }
});;app.controller('NavCtrl', function ($scope, identity) {
    'use strict';

    $scope.identity = identity;
});;app.controller('OverviewCtrl', function ($scope, $rootScope, $interval, GameObjectsCache, RaceModel, identity, UpgradesModel, Calculator) {
    'use strict';

    $scope.raceModel = RaceModel[identity.currentUser.race];
    $scope.raceModel.upgrades = UpgradesModel.names;

    queryGameObjects();

    // the client queries himself every 90 sec. The server is queried only once per 2 min
    $rootScope.objectsRefreshSeconds = $rootScope.objectsRefreshSeconds || 30;
    $interval(queryGameObjects, 1000 * $rootScope.objectsRefreshSeconds);

    function queryGameObjects() {
        GameObjectsCache.getGameObjectsForUser().$promise.then(function (objects) {
            $scope.gameObjects = objects;

            $scope.now = (new Date()).getTime();

            $scope.freeEnergy = Calculator.freeEnergy(objects);
            $scope.freeSupply = Calculator.freeSupply(objects);
            $scope.mineralsPerMinute = Calculator.mineralsPerMinute(objects);
            $scope.gasPerMinute = Calculator.gasPerMinute(objects);
        })
    }

    $scope.showAttackInfo = function (index) {
        $scope.additionalInfoHeader = "Attack info";
        $scope.additionalInfoText = 'Your attack consists of';

        for (var i = 0; i < $scope.raceModel.ships.length; i++) {
            if ($scope.gameObjects.attacks[index].ships[i] == 0) {
                continue;
            }
            $scope.additionalInfoText += ' ' + $scope.gameObjects.attacks[index].ships[i] + ' ' + $scope.raceModel.ships[i].name + 's';
        }

        $scope.additionalInfoText += ' and will continue for ' + $scope.gameObjects.attacks[index].turns + ' turns.';
    };

    $scope.showComebackInfo = function (index) {
        $scope.additionalInfoHeader = "Comeback info";
        $scope.additionalInfoText = 'Your comeback consists of';

        for (var i = 0; i < $scope.raceModel.ships.length; i++) {
            if ($scope.gameObjects.comebacks[index].ships[i] == 0) {
                continue;
            }
            $scope.additionalInfoText += ' ' + $scope.gameObjects.comebacks[index].ships[i] + ' ' + $scope.raceModel.ships[i].name + 's';
        }
        //{{ comeback.cargo[0] }} minerals and {{ comeback.cargo[1] }} gas
        $scope.additionalInfoText += ' and has stolen  ' + $scope.gameObjects.comebacks[index].cargo[0] + ' minerals and ' +
            $scope.gameObjects.comebacks[index].cargo[1] + ' gas.';
    }
});;app.controller('ReportsCtrl', function ($scope, GameRequests, identity, RaceModel) {
    'use strict';

    var currentReports = JSON.parse(localStorage.getItem('novcraft-userobjects-userreports-'+identity.currentUser._id)) || [];

    GameRequests.getUserReports().then(function (responce) {
        var newReports = currentReports.concat(responce.allReports);
        localStorage.setItem('novcraft-userobjects-userreports-'+identity.currentUser._id, JSON.stringify(newReports));

        $scope.allReports = newReports;

    }, function (error) {
        console.log(error);
    });

    $scope.raceModel = RaceModel[identity.currentUser.race];
    $scope.Math = Math;

    $scope.deleteReport = function(index) {
        $scope.allReports.splice(index,1);
        localStorage.setItem('novcraft-userobjects-userreports-'+identity.currentUser._id, JSON.stringify($scope.allReports));
    };

    $scope.viewReport = function (index) {
        $scope.selectedReport = $scope.allReports[$scope.allReports.length - index - 1];
        $scope.attackerClass = $scope.selectedReport.own ? 'text-success' : 'text-danger';
        $scope.defenderClass = $scope.selectedReport.own ? 'text-danger' : 'text-success';
        $scope.attackerPanelClass = $scope.selectedReport.own ? 'panel-success' : 'panel-danger';
        $scope.defenderPanelClass = $scope.selectedReport.own ? 'panel-danger' : 'panel-success';
        $scope.attackerPanelHeading = $scope.selectedReport.own ? 'Units killed' : 'Lost units';
        $scope.defenderPanelHeading = $scope.selectedReport.own ? 'Lost units' : 'Units killed';
    }
});;app.controller('ScanCtrl', function ($scope, $location, $timeout, GameObjectsCache, Calculator, GameRequests, notifier, identity) {
    'use strict';

    $scope.coords = ['','',''];

    GameObjectsCache.getGameObjectsForUser().$promise.then(function (objects) {
        $scope.gameObjects = objects;
        $scope.freeEnergy = Calculator.freeEnergy(objects);
        $scope.freeSupply = Calculator.freeSupply(objects);
        $scope.mineralsPerMinute = Calculator.mineralsPerMinute(objects);
        $scope.gasPerMinute = Calculator.gasPerMinute(objects);

        $scope.scanCost = 'Scanning will cost you ' +
            Calculator.mineralsPerMinute($scope.gameObjects) * 15 + ' minerals and ' +
            Calculator.gasPerMinute($scope.gameObjects) * 15 + ' gas';

        if (Calculator.mineralsPerMinute(objects) * 15 > objects.minerals) {
            $scope.btnText = 'Not enough minerals';
            $scope.btnClass = 'btn-danger';
            $scope.btnDisabled = true;
        }
        else if (Calculator.gasPerMinute(objects) * 15 > objects.gas) {
            $scope.btnText = 'Not enough gas';
            $scope.btnClass = 'btn-danger';
            $scope.btnDisabled = true;
        }
        else {
            $scope.btnText = 'Scan';
            $scope.btnClass = 'btn-success';
            $scope.btnDisabled = false;
        }
    });

    $scope.confirm = function () {
        if (identity.currentUser.coordinates[0] == $scope.coords[0] &&
            identity.currentUser.coordinates[1] == $scope.coords[1] &&
            identity.currentUser.coordinates[2] == $scope.coords[2]) {

            notifier.error('You can not scan yourself');
            return;
        }
        GameRequests.findUserIdByCoords($scope.coords).then(function (id) {
            $location.path('/scan/' + id);

        }, function (error) {
            notifier.error(error);
        });
    };

    $scope.confirmUsername = function () {
        if (identity.currentUser.username == $scope.targetUsername) {
            notifier.error('You can not scan yourself');
            return;
        }
        GameRequests.findUserIdByUsername($scope.targetUsername).then(function (id) {
            $location.path('/scan/' + id);

        }, function (error) {
            notifier.error(error);
        });
    };
});;app.controller('ScanOverviewCtrl', function ($scope, $routeParams, $rootScope, GameRequests, RaceModel , notifier, identity) {
    'use strict';

    GameRequests.scanUser($routeParams.target).then(function (response) {
        if (!response.success) {
            notifier.error('Not enough resources for a scan');
            return;
        }

        notifier.success('Scan was successful');

        $scope.raceModel = RaceModel[identity.currentUser.race];
        $scope.enemy = response.targetObjects;

        $rootScope.lastUserObject = $scope.enemy;

    }, function (error) {
        console.log(error)
    });
});;app.controller('ShipsCtrl',
    function ($scope, $rootScope, $interval, GameObjectsCache, RaceModel, identity, BuildingsModel, ShipsModel, Calculator, notifier, GameRequests) {
        'use strict';

        $scope.raceModel = RaceModel[identity.currentUser.race];
        $scope.buildingsModel = BuildingsModel;
        $scope.shipsModel = ShipsModel;

        queryGameObjects();

        //TODO: add link in the attack source coords to scan player

        // the client queries himself every X sec. The server is queried only once per 2 min
        $rootScope.objectsRefreshSeconds = $rootScope.objectsRefreshSeconds || 30;
        $interval(queryGameObjects, 1000 * $rootScope.objectsRefreshSeconds);

        function queryGameObjects() {
            GameObjectsCache.getGameObjectsForUser().$promise.then(function (objects) {
                $scope.filteredTasks = objects.tasks
                    .filter(function (obj) {
                        return obj.type == 'ships'
                    });

                $scope.gameObjects = objects;

                $scope.now = (new Date()).getTime();

                $scope.freeEnergy = Calculator.freeEnergy(objects);
                $scope.freeSupply = Calculator.freeSupply(objects);
                $scope.mineralsPerMinute = Calculator.mineralsPerMinute(objects);
                $scope.gasPerMinute = Calculator.gasPerMinute(objects);

                refreshButtons();
            })
        }

        function refreshButtons() {
            $scope.btnClass = [];
            $scope.btnText = [];
            $scope.btnDisabled = [];

            for (var i = 0; i < ShipsModel.time.length; i++) {
                if (BuildingsModel[5].amount[$scope.gameObjects.buildings[5]] == 0) {
                    $scope.btnClass.push('btn-danger');
                    $scope.btnText.push('Build ' + $scope.raceModel.buildings[5].name);
                    $scope.btnDisabled.push(true);
                }
                else if ($scope.filteredTasks.length >= BuildingsModel[5].amount[$scope.gameObjects.buildings[5]]) {
                    $scope.btnClass.push('btn-danger');
                    $scope.btnText.push('Building in progress');
                    $scope.btnDisabled.push(true);
                }
                else {
                    var canAfford = Calculator.canAffordShip($scope.gameObjects, i);

                    if (canAfford.answer) {
                        $scope.btnClass.push('btn-success');
                        $scope.btnText.push('Construct');
                        $scope.btnDisabled.push(false);
                    }
                    else {
                        $scope.btnClass.push('btn-danger');
                        $scope.btnText.push(canAfford.reason);
                        $scope.btnDisabled.push(true);
                    }
                }
            }
        }

        var shipIndex = -1;
        $scope.confirm = function (index) {
            shipIndex = index;
            $scope.confirmerText = 'Constructing this ' + $scope.raceModel.ships[index].name +
                Calculator.requiredResourcesMessage($scope.gameObjects, 'ships', index);
        };

        $scope.confirmerAccept = function () {
            GameRequests.createTask('ships', shipIndex).then(function (response) {
                if (response.success) {
                    notifier.success('Ship construction started');
                    GameObjectsCache.refresh();
                    queryGameObjects();
                }
                else {
                    notifier.error('Not enough minerals, gas or supply');
                }
            }, function (error) {
                console.log(error)
            })
        };
    });;app.controller('TroopsCtrl',
    function ($scope, $rootScope, $interval, GameObjectsCache, RaceModel, identity, BuildingsModel, TroopsModel, Calculator, notifier, GameRequests) {
        'use strict';

        $scope.raceModel = RaceModel[identity.currentUser.race];
        $scope.buildingsModel = BuildingsModel;
        $scope.troopsModel = TroopsModel;

        queryGameObjects();
        //TODO: add link in the attack source coords to scan player

        // the client queries himself every X sec. The server is queried only once per 2 min
        $rootScope.objectsRefreshSeconds = $rootScope.objectsRefreshSeconds || 30;
        $interval(queryGameObjects, 1000 * $rootScope.objectsRefreshSeconds);

        function queryGameObjects() {
            GameObjectsCache.getGameObjectsForUser().$promise.then(function (objects) {
                $scope.filteredTasks = objects.tasks
                    .filter(function (obj) {
                        return obj.type == 'troops'
                    });

                $scope.gameObjects = objects;

                $scope.now = (new Date()).getTime();

                $scope.freeEnergy = Calculator.freeEnergy(objects);
                $scope.freeSupply = Calculator.freeSupply(objects);
                $scope.mineralsPerMinute = Calculator.mineralsPerMinute(objects);
                $scope.gasPerMinute = Calculator.gasPerMinute(objects);

                refreshButtons();
            })
        }

        function refreshButtons() {
            $scope.btnClass = [];
            $scope.btnText = [];
            $scope.btnDisabled = [];

            for (var i = 0; i < TroopsModel.time.length; i++) {
                if (BuildingsModel[4].amount[$scope.gameObjects.buildings[4]] == 0) {
                    $scope.btnClass.push('btn-danger');
                    $scope.btnText.push('Build ' + $scope.raceModel.buildings[4].name);
                    $scope.btnDisabled.push(true);
                }
                else if ($scope.filteredTasks.length >= BuildingsModel[4].amount[$scope.gameObjects.buildings[4]]) {
                    $scope.btnClass.push('btn-danger');
                    $scope.btnText.push('Training in progress');
                    $scope.btnDisabled.push(true);
                }
                else {
                    var canAfford = Calculator.canAffordTroop($scope.gameObjects, i);

                    if (canAfford.answer) {
                        $scope.btnClass.push('btn-success');
                        $scope.btnText.push('Train');
                        $scope.btnDisabled.push(false);
                    }
                    else {
                        $scope.btnClass.push('btn-danger');
                        $scope.btnText.push(canAfford.reason);
                        $scope.btnDisabled.push(true);
                    }
                }
            }
        }

        var troopsIndex = -1;
        $scope.confirm = function (index) {
            troopsIndex = index;
            $scope.confirmerText = 'Training this ' + $scope.raceModel.troops[index].name +
                Calculator.requiredResourcesMessage($scope.gameObjects, 'troops', index);
        };

        $scope.confirmerAccept = function () {
            GameRequests.createTask('troops', troopsIndex).then(function (response) {
                if (response.success) {
                    notifier.success('Unit construction started');
                    GameObjectsCache.refresh();
                    queryGameObjects();
                }
                else {
                    notifier.error('Not enough minerals, gas or supply');
                }
            }, function (error) {
                console.log(error)
            })
        };
    });;app.controller('UpgradesCtrl',
    function ($scope, $rootScope, $interval, GameObjectsCache, RaceModel, identity, BuildingsModel, UpgradesModel, Calculator, notifier, GameRequests) {
        'use strict';

        $scope.raceModel = RaceModel[identity.currentUser.race];
        $scope.buildingsModel = BuildingsModel;
        $scope.upgradesModel = UpgradesModel;
        $scope.Math = Math;

        queryGameObjects();
        //TODO: add link in the attack source coords to scan player

        // the client queries himself every X sec. The server is queried only once per 2 min
        $rootScope.objectsRefreshSeconds = $rootScope.objectsRefreshSeconds || 30;
        $interval(queryGameObjects, 1000 * $rootScope.objectsRefreshSeconds);

        function queryGameObjects() {
            GameObjectsCache.getGameObjectsForUser().$promise.then(function (objects) {
                $scope.filteredTasks = objects.tasks
                    .filter(function (obj) {
                        return obj.type == 'upgrades'
                    });

                $scope.gameObjects = objects;

                $scope.now = (new Date()).getTime();

                $scope.freeEnergy = Calculator.freeEnergy(objects);
                $scope.freeSupply = Calculator.freeSupply(objects);
                $scope.mineralsPerMinute = Calculator.mineralsPerMinute(objects);
                $scope.gasPerMinute = Calculator.gasPerMinute(objects);

                refreshButtons();
            })
        }

        function refreshButtons() {
            $scope.btnClass = [];
            $scope.btnText = [];
            $scope.btnDisabled = [];

            for (var i = 0; i < UpgradesModel.multiplier.length; i++) {
                if (BuildingsModel[6].amount[$scope.gameObjects.buildings[6]] == 0) {
                    $scope.btnClass.push('btn-danger');
                    $scope.btnText.push('Build ' + $scope.raceModel.buildings[6].name);
                    $scope.btnDisabled.push(true);
                }
                else if ($scope.gameObjects.upgrades[i] == UpgradesModel.multiplier.length - 1) {
                    $scope.btnClass.push('btn-success');
                    $scope.btnText.push('Max level');
                    $scope.btnDisabled.push(true);
                }
                else if ($scope.filteredTasks.length >= BuildingsModel[6].amount[$scope.gameObjects.buildings[6]]) {
                    $scope.btnClass.push('btn-danger');
                    $scope.btnText.push('Upgrade in progress');
                    $scope.btnDisabled.push(true);
                }
                else {
                    var canAfford = Calculator.canAffordUpgrade($scope.gameObjects, i);

                    if (canAfford.answer) {
                        $scope.btnClass.push('btn-success');
                        $scope.btnText.push('Upgrade');
                        $scope.btnDisabled.push(false);
                    }
                    else {
                        $scope.btnClass.push('btn-danger');
                        $scope.btnText.push(canAfford.reason);
                        $scope.btnDisabled.push(true);
                    }
                }
            }
        }

        var upgradesIndex = -1;
        $scope.confirm = function (index) {
            upgradesIndex = index;
            $scope.confirmerText = 'Upgrading the ' + $scope.upgradesModel.names[index].name +
                Calculator.requiredResourcesMessage($scope.gameObjects, 'upgrades', index);
        };

        $scope.confirmerAccept = function () {
            GameRequests.createTask('upgrades', upgradesIndex).then(function (response) {
                if (response.success) {
                    notifier.success('Upgrade started');
                    GameObjectsCache.refresh();
                    queryGameObjects();
                }
                else {
                    notifier.error('Not enough minerals or gas');
                }
            }, function (error) {
                console.log(error)
            })
        };
    });