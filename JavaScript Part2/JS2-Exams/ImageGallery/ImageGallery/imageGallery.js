function escapeTag(currString) {
    if (typeof (currString) != 'string') {
        return currString;
    }
    var indexOfBR = currString.indexOf('<br/>');
    if (indexOfBR > -1) {
        return currString.substr(0, indexOfBR) + '&lt' + 'br' + '/' + '&gt' + currString.substr(indexOfBR + 5);
    }
    else {
        return currString;
    }
}

function Image(title, source) {
    this.title = title;
    this.src = source;

    this.imgHtmlEl = document.createElement('div');
    this.imgHtmlEl.style.border = '2px solid gray';
    this.imgHtmlEl.style.borderRadius = '15px';
    this.imgHtmlEl.style.padding = '10px';
    this.imgHtmlEl.style.margin = '20px';
    var curImg = document.createElement('img');
    curImg.src = this.src;
    var currTitle = document.createElement('div');
    currTitle.innerHTML = escapeTag(this.title);
    currTitle.style.textAlign = 'center';

    this.imgHtmlEl.style.display = 'inline-block';
    this.imgHtmlEl.appendChild(currTitle);
    this.imgHtmlEl.appendChild(curImg);
}

function Album(title) {
    this.title = title;
    this.images = [];
    this.nestedAlbums = [];
    this.sortAlphDescending = true;

    this.albHtmlEl = document.createElement('div');
    this.albHtmlEl.style.border = '2px solid grey';
    this.albHtmlEl.style.borderRadius = '15px';
    this.albHtmlEl.style.margin = '10px';
    this.albHtmlEl.style.padding = '10px';

    this.contentHolder = document.createElement('div');
    this.imgHolder = document.createElement('div');
    this.nestedAlbumsHolder = document.createElement('div');

    this.currTitle = document.createElement('div');
    var text = document.createElement('span');
    text.innerHTML = 'Album '+escapeTag(this.title);
    var sortBut = document.createElement('button');
    sortBut.innerHTML = 'Sort Inner Albums';
    var self = this;
    sortBut.onclick = function (ev) {
        self.sortNestedAlbums();
        ev.stopPropagation();
    }
    this.currTitle.appendChild(text);
    this.currTitle.appendChild(sortBut);
    this.currTitle.style.textAlign = 'center';

    this.currTitle.onclick = function (ev) {
        var content = ev.target.nextElementSibling;
        if (content.style.display == 'none') {
            content.style.display = 'block';
        }
        else {
            content.style.display = 'none';
        }
    }
    this.contentHolder.appendChild(this.imgHolder);
    this.contentHolder.appendChild(this.nestedAlbumsHolder);

    this.albHtmlEl.appendChild(this.currTitle);
    this.albHtmlEl.appendChild(this.contentHolder);
}

Album.prototype.addImg = function (image) {
    if (image instanceof Image) {
        var imgToAdd = new Image(image.title, image.src);
        this.images.push(imgToAdd);
        var imgEl = imgToAdd.imgHtmlEl;
        this.imgHolder.appendChild(imgEl);
        imgEl.onclick = function (ev) {
            enlargeImg(ev);
        }
    }
}

Album.prototype.addInnerAlbum = function (album) {
    if (album instanceof Album) {
        this.nestedAlbums.push(album);
        this.nestedAlbumsHolder.appendChild(album.albHtmlEl);
    }
}

Album.prototype.sortNestedAlbums = function () {
    while (this.nestedAlbumsHolder.firstElementChild) {
        this.nestedAlbumsHolder.removeChild(this.nestedAlbumsHolder.firstElementChild);
    }

    var self = this;
    self.sortAlphDescending = !self.sortAlphDescending;

    this.nestedAlbums.sort(function (a, b) {
        if (a.title < b.title) {
            return self.sortAlphDescending ? -1 : 1;
        }
        else if (a.title > b.title) {
            return self.sortAlphDescending ? 1 : -1;
        }
        else {
            return 0;
        }
    });

    for (var i = 0; i < self.nestedAlbums.length; i++) {
        self.nestedAlbumsHolder.appendChild(self.nestedAlbums[i].albHtmlEl);
    }
}

function ImageGallery() {
    this.images = [];
    this.albums = [];
    this.sortAlphDescending = true;

    this.IGHtmlEl = document.createElement('div');
    this.imgHolder = document.createElement('div');
    this.albumsSection = document.createElement('div');
    this.albumsHolder = document.createElement('div');

    var albTitle = document.createElement('div');
    var albText = document.createElement('span');
    albTitle.innerHTML = 'Gallery Albums:';
    var albSortBut = document.createElement('button');
    albSortBut.innerHTML = 'Sort All Albums';
    var self = this;
    albSortBut.onclick = function () {
        self.SortAlbums();
    }
    albTitle.appendChild(albText);
    albTitle.appendChild(albSortBut);
    albTitle.style.margin = '10px';
    albTitle.style.fontSize = '2em';
    albTitle.style.fontWeight = '800';
    albTitle.style.borderBottom = '3px solid black';
    albTitle.style.textAlign = 'center';
    this.albumsSection.appendChild(albTitle);
    this.albumsSection.appendChild(this.albumsHolder);

    this.albumsSection.style.padding = '10px';

    this.galery = document.createElement('div');
    this.galery.style.border = '2px solid blue';
    this.galery.appendChild(this.imgHolder);
    this.galery.appendChild(this.albumsSection);
    this.galery.style.width = '580px';
    this.galery.style.position = 'relative';
    this.galery.style.margin = '15px';

    this.expander = document.createElement('div');
    this.expander.style.position = 'fixed';
    this.expander.style.left = '650px';
    this.expander.style.top = '50px';
    this.expander.style.padding = '10px';

    this.expanderImg = document.createElement('div');
    this.expanderImg.id = 'expanderImg';
    this.expanderText = document.createElement('div');
    this.expanderText.id = 'expanderText';
    this.expanderText.style.fontSize = '2em';
    this.expanderText.style.fontWeight = '800';
    this.expanderText.style.textAlign = 'center';
    this.expanderImg.style.margin = '10px';

    this.expander.appendChild(this.expanderText);
    this.expander.appendChild(this.expanderImg);

    this.IGHtmlEl.appendChild(this.galery);
    this.IGHtmlEl.appendChild(this.expander);
}

ImageGallery.prototype.AddImg = function (image) {
    if (image instanceof Image) {
        var imgToAdd = new Image(image.title, image.src);
        this.images.push(imgToAdd);
        var imgEl = imgToAdd.imgHtmlEl;
        this.imgHolder.appendChild(imgEl);
        imgEl.onclick = function (ev) {
            enlargeImg(ev);
            ev.stopPropagation();
        }
    }
}

ImageGallery.prototype.AddAlbum = function (album) {
    if (album instanceof Album) {
        this.albums.push(album);
        this.albumsHolder.appendChild(album.albHtmlEl);
    }
}

ImageGallery.prototype.SortAlbums = function () {
    while (this.albumsHolder.firstElementChild) {
        this.albumsHolder.removeChild(this.albumsHolder.firstElementChild);
    }

    var self = this;
    self.sortAlphDescending = !self.sortAlphDescending;

    self.albums.sort(function (a, b) {
        if (a.title < b.title) {
            return self.sortAlphDescending ? -1 : 1;
        }
        else if (a.title > b.title) {
            return self.sortAlphDescending ? 1 : -1;
        }
        else {
            return 0;
        }
    });

    for (var i = 0; i < self.albums.length; i++) {
        self.albumsHolder.appendChild(self.albums[i].albHtmlEl);
    }
}

function enlargeImg(ev) {
    var imgTarget = ev.target;
    if (!(imgTarget instanceof HTMLImageElement)) {
        return false;
    }
    var textOfImg = imgTarget.parentElement.firstElementChild;

    var textItem = document.getElementById('expanderText');
    var imgItem = document.getElementById('expanderImg');

    var newImg = document.createElement('img');
    newImg.src = imgTarget.src;
    newImg.width = imgTarget.width * 2;
    newImg.height = imgTarget.height * 2;

    if (imgItem.firstElementChild) {
        imgItem.removeChild(imgItem.firstElementChild);
    }

    imgItem.appendChild(newImg);
    textItem.innerHTML = textOfImg.innerHTML;
}

var controls = (function () {

    function innerAlbumAdd(album) {
        return {
            addImage: function (title,source) {
                album.addImg(new Image(title, source));
            },
            addAlbum: function (title) {
                var createdAlbum = new Album(title);
                album.addInnerAlbum(createdAlbum);
                return innerAlbumAdd(createdAlbum);
            }
        }
    } 
    return {
        getImageGallery: function (qSelect,galleryToUse) {
            var imgGal = new ImageGallery();
            if (galleryToUse) {
                imgGal = galleryToUse;
            }
            document.querySelector(qSelect).appendChild(imgGal.IGHtmlEl);
            return {
                addImage: function (title,source) {
                    imgGal.AddImg(new Image(title, source));
                },

                addAlbum : function (title) {
                    var newCreatedAlbum = new Album(title);
                    imgGal.AddAlbum(newCreatedAlbum);
                    return innerAlbumAdd(newCreatedAlbum);
                },

                getImageGalleryData: function () {
                    var objToReturn = {
                        images: innerGetImagesFromArray(imgGal.images),

                        albums: innerGetAlbums(imgGal.albums),
                    }

                    return objToReturn;
                }
            }

            function innerGetAlbums(albums) {
                var albumsToReturn = [];

                for (var i = 0; i < albums.length; i++) {
                    albumsToReturn.push({
                        title: albums[i].title,

                        images: innerGetImagesFromArray(albums[i].images),

                        innerAlbums: innerGetAlbums(albums[i].nestedAlbums),
                    });
                }

                return albumsToReturn;
            }

            function innerGetImagesFromArray(imgArray) {
                var imagesToReturn = [];

                for (var i = 0; i < imgArray.length; i++) {
                    imagesToReturn.push({
                        title: imgArray[i].title,
                        source: imgArray[i].src,
                    });
                }

                return imagesToReturn;
            }
        },

        buildImageGallery: function (qSelect,data) {
            var newGal = new ImageGallery();

            for (var i = 0; i < data.images.length; i++) {
                newGal.AddImg(new Image(data.images[i].title, data.images[i].source));
            }

            for (var i = 0; i < data.albums.length; i++) {
                newGal.AddAlbum(innerGenerateAlbum(data.albums[i]));
            }

            function innerGenerateAlbum(albObj) {
                var curAlbum = new Album(albObj.title);

                for (var i = 0; i < albObj.images.length; i++) {
                    curAlbum.addImg(new Image(albObj.images[i].title, albObj.images[i].source));
                }

                if (albObj.innerAlbums.length > 0) {
                    for (var i = 0; i < albObj.innerAlbums.length; i++) {
                        curAlbum.addInnerAlbum(innerGenerateAlbum(albObj.innerAlbums[i]));
                    }
                }

                return curAlbum;
            }

            return this.getImageGallery(qSelect, newGal);
        }
    }
})();

var imageGalleryRepository = (function () {
    (function () {
        if (!Storage.prototype.setObject) {
            Storage.prototype.setObject = function setObject(key, obj) {
                var jsonObj = JSON.stringify(obj);
                this.setItem(key, jsonObj);
            }

        }
        if (!Storage.prototype.getObject) {
            Storage.prototype.getObject = function getObject(key) {
                var jsonObj = this.getItem(key);
                var obj = JSON.parse(jsonObj);
                return obj;
            }
        }
    })();

    return {
        save: function (key, value) {
            localStorage.setObject(key, value);
        },
        load: function (key) {
            return localStorage.getObject(key);
        }
    }
})();