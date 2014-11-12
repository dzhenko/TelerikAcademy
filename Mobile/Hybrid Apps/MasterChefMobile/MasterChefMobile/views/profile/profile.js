var app = app || {};

app.profile = app.profile || {};

(function (app) {
    document.addEventListener("deviceready", function () {
        app.profile.init = function() {
            var username = window.localStorage.getItem("username"); 
            var viewModel = kendo.observable({
                                                 username: username,
                                                 lat: '',
                                                 long: '',
                                                 location: '',
                                                 connectionType: app.connectionApi.getConnectionDescription(),
                                                 logout : function() {
                                                     app.auth.logout();
                                                     app.notifier.success('Logout');
                                                     app.main.navigate('views/login/login.html');
                                                 }
                                             });

            startWatchingGeolocation();
            
            app.profile.model = viewModel;
            kendo.bind($("#profile-view"), viewModel);
            
            function setLocation(location) {
                viewModel.location = location;
                kendo.bind($("#profile-view"), viewModel);
            }
            
            function setLatAndLong(lat, long) {
                viewModel.lat = lat;
                viewModel.long = long;
                kendo.bind($("#profile-view"), viewModel);
            }
            
            function startWatchingGeolocation() {
                navigator.geolocation.watchPosition(geoWatchSuccess, geoWatchError, {
                                                        enableHighAccuracy: true,
                                                        maximumAge: 1000
                                                    });
            
                navigator.geolocation.getCurrentPosition(onGetCurrentPositionSuccess, geoWatchError);
            }
            
            function onGetCurrentPositionSuccess(position) {
                geocoder = new google.maps.Geocoder();
                var lat = parseFloat(position.coords.latitude);
                var lng = parseFloat(position.coords.longitude);
                                    
                var latlng = new google.maps.LatLng(lat, lng);
                geocoder.geocode({'latLng': latlng}, function(results, status) {
                    if (status === google.maps.GeocoderStatus.OK) {
                        if (results[0]) {
                            var arrAddress = results[0].address_components;
                            $.each(arrAddress, function (i, address_component) {
                                if (address_component.types[0] === "locality") {
                                    setLocation(address_component.long_name);
                                    return false; 
                                }
                            });
                        } else {
                            viewModel.location = "No results found";
                        }
                    } else {
                        app.notifier.error("Cannot get your location!", 5000)
                    }
                });
            }
            
            function geoWatchSuccess(position) {
                var lat = position.coords.latitude;
                var long = position.coords.longitude;
                setLatAndLong(lat, long);
                
                var mapsBaseUrl = "http://maps.googleapis.com/maps/api/staticmap";
                var centerPar = "center=" + lat + "," + long;
                var sizePar = "size=500x500";

                var locationViz = document.getElementById("location-viz");
                locationViz.src = mapsBaseUrl + "?" + centerPar + "&" + sizePar + "&" + "&sensor=true&zoom=15";
            }

            function geoWatchError() {
                app.notifier.error("Couldn't get geo coords from device", 5000)
            }
            
            var compassHelpter;

            function onDeviceReady() {
                //navigator.splashscreen.hide();
                compassHelpter = new CompassHelper();
                compassHelpter.run();
                compassHelpter._handleWatch();
            }

            function CompassHelper() {
            }

            CompassHelper.prototype = {
                watchID : null,
    
                run: function() {
                    var that = this,
                        refreshButton = document.getElementById("refreshButton"),
                        buttonWatch = document.getElementById("watchButton");
		
                    //buttonWatch.addEventListener("click", 
                    //                             function() {
                    //                                 that._handleWatch.apply(that, arguments);
                    //                             }, 
                    //                             false);
		
                    //refreshButton.addEventListener("click", 
                    //                               function() {
                    //                                   that._handleRefresh.apply(that, arguments)
                    //                               }, 
                    //                               false);
                },
    
                _handleRefresh: function() {
                    var that = this;
                    navigator.compass.getCurrentHeading(function() { 
                        that._rotateCompassImage.apply(that, arguments);
                        that._displayHeading.apply(that, arguments)
                    },
                                                        function() {
                                                            that._onCompassWatchError.apply(that, arguments)
                                                        });
                },
    
                _handleWatch: function() {
                    var that = this,
                        button = document.getElementById("watchButton");

                    if (that.watchID !== null) {
                        navigator.compass.clearWatch(that.watchID);
                        that.watchID = null;
                       // button.innerHTML = "Start Compass";
                        that._clearCurrentNotification();
                    } else {
                        var options = { frequency: 1000 };
			
                        that._clearCurrentNotification();
                        that._writeNotification("Waiting for compass information...");
                       // button.innerHTML = "Stop Compass";
            
                        that.watchID = navigator.compass.watchHeading(function() { 
                            that._displayHeading.apply(that, arguments)
                            that._rotateCompassImage.apply(that, arguments);
                        }, 
                                                                      function() {
                                                                          that._onCompassWatchError.apply(that, arguments)
                                                                      }, 
                                                                      options);
                    }
                },
    
                _displayHeading: function(heading) {
                    var that = this,
                        magneticHeading = heading.magneticHeading,
                        timestamp = heading.timestamp;
        
                    var informationMessage = 'Magnetic field: ' + magneticHeading + '<br />' +
                                             'Timestamp: ' + timestamp + '<br />' 
        
                    that._clearCurrentNotification();
                    that._writeNotification(informationMessage);
                },
    
                _onCompassWatchError: function(error) {
                    var that = this,
                        errorMessage,
                        button = document.getElementById("watchButton");
                    switch (error.code) {
                        case 20:
                            errorMessage = "Compass not supported";
                            break;
                        case 0:
                            errorMessage = "Compass internal error";
                            break;
                        default:
                            errorMessage = "Compass error";
                    }
        
                    button.innerHTML = "Start Compass";
                    that.watchID = null;
                    that._clearCurrentNotification();
                    that._writeNotification(errorMessage);
                },
    
                _writeNotification: function(text) {
                    var result = document.getElementById("result");
                    result.innerHTML = text;
                },
    
                _clearCurrentNotification: function() {
                    var result = document.getElementById("result");
                    result.innerText = "";
                }, 
      
                _rotateCompassImage : function(heading) {
                    var compassDiv = document.getElementById("compass"),
                        magneticHeading = magneticHeading = 360 - heading.magneticHeading;
        
                    var rotation = "rotate(" + magneticHeading + "deg)";
              
                    compassDiv.style.webkitTransform = rotation;
                }
            }
        
            onDeviceReady();
            
        }
    });
}(app));