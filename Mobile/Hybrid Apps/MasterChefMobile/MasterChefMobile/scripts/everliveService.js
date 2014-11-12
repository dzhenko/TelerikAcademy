var app = app || {};

(function(app) {
    document.addEventListener("deviceready", function () {
        var apiKey = app.constants.everliveApiKey;
        var everlive = new Everlive(apiKey);
        var picturesCollection = "Pictures";
        
        app.everlive = {
            uploadImage: function(data, success, error) {
                return everlive.Files.create({
                    Filename: app.utility.getRandomString() + ".jpg",
                    ContentType: "image/jpeg",
                    base64: data
                },
                function (picData) {
                    everlive.data(picturesCollection).create({
                        'Uri' : picData.result.Id
                    }, success, error);
                }, error);
            },
            getImageData: function(id, success) {
                return everlive.data(picturesCollection).get({ Id: id });
            }
        }
    });
}(app));