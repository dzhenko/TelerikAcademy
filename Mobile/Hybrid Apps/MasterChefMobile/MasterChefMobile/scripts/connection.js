var app = app || {};
app.connectionApi = app.connectionApi || {};

(function(app) {
    document.addEventListener("deviceready", function () {
        var states = null;
        
        function initStates() {
            states = {};
            states[Connection.UNKNOWN] = 'Unknown connection';
            states[Connection.ETHERNET] = 'Ethernet connection';
            states[Connection.WIFI] = 'WiFi connection';
            states[Connection.CELL_2G] = 'Cell 2G connection';
            states[Connection.CELL_3G] = 'Cell 3G connection';
            states[Connection.CELL_4G] = 'Cell 4G connection';
            states[Connection.CELL] = 'Cell generic connection';
            states[Connection.NONE] = 'No network connection';
        }
        
        if (!states) {
            initStates();
        }
        
        app.connectionApi = {
            hasConnection: function() {
                var connectionType = navigator.connection.type;
                
                if (!connectionType || 
                    [/*'unknown',*/ 'cell', 'none'].indexOf(connectionType.toLowerCase()) !== -1) {
                    return false;
                }
                return true;
            },
            getConnectionType: function() {
                 return networkState = navigator.connection.type;
            },
            getConnectionDescription: function() {
                var connectionType = navigator.connection.type;
                return states[connectionType]
            }
        }
    });
}(app));