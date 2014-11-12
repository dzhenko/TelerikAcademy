app.factory('GameObjectsCache', function (GameRequests) {
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
});