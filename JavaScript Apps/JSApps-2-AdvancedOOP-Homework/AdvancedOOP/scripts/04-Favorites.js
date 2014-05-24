function createClass(properties) {
    var f = function () {
        if (this._superConstructor) {
            this._super = new this._superConstructor();
        }
        this.init.apply(this, arguments);
    }

    for (var prop in properties) {
        f.prototype[prop] = properties[prop];
    }

    if (!f.prototype.init) {
        f.prototype.init = function () { }
    }

    return f;
}

Function.prototype.inherit = function (parent) {
    var oldPrototype = this.prototype;
    this.prototype = new parent();
    this.prototype._superConstructor = parent;
    for (var prop in oldPrototype) {
        this.prototype[prop] = oldPrototype[prop];
    }
}

var TitleHolder = createClass({
    init: function (title) {
        this.title = title;
    }
});

var FUrl = createClass({
    init: function (title, url) {
        this._super.init(title);
        this.url = url;
        this.innerFolders = [];
    },
});
FUrl.inherit(TitleHolder);

FUrl.prototype.getURLElement = function () {
    var currElement = document.createElement('div');
    currElement.className = 'url';
    var anchor = document.createElement('a');
    anchor.href = this.url;
    anchor.target = "_blank";
    anchor.innerHTML = this._super.title;

    currElement.appendChild(anchor);

    if (this.innerFolders.length > 0) {
        var nestedFolders = document.createElement('ul');
        nestedFolders.className = 'nestedFolders';
        nestedFolders.style.listStyle = 'none';

        for (var i = 0; i < this.innerFolders.length; i++) {
            nestedFolders.appendChild(this.innerFolders[i].getFolderElement());
        }

        currElement.appendChild(nestedFolders);
    }

    return currElement;
}

var FFolder = createClass({
    init: function (title) {
        this._super.init(title);
        this.urls = [];

        this.innerFolders = [];
    },
});
FFolder.inherit(TitleHolder);

FFolder.prototype.getFolderElement = function () {
    var currElement = document.createElement('div');
    currElement.className = 'folder';

    var title = document.createElement('div');
    title.innerHTML = this._super.title;
    currElement.appendChild(title);

    if (this.urls.length > 0) {
        var ownUrls = document.createElement('ul');
        ownUrls.className = 'nestedURLs';
        ownUrls.style.listStyle = 'none';

        for (var i = 0; i < this.urls.length; i++) {
            ownUrls.appendChild(this.urls[i].getURLElement());
        }

        currElement.appendChild(ownUrls);
    }

    if (this.innerFolders.length > 0) {
        var nestedFolders = document.createElement('ul');
        nestedFolders.className = 'nestedFolders';

        nestedFolders.style.listStyle = 'none';

        for (var i = 0; i < this.innerFolders.length; i++) {
            nestedFolders.appendChild(this.innerFolders[i].getFolderElement());
        }

        currElement.appendChild(nestedFolders);
    }

    return currElement;
}

var FavoritesBar = (function () {
    'use strict';
    var holder = document.createElement('div');
    var mainUrls = document.createElement('div');
    mainUrls.id = 'mainUrls';
    var folders = document.createElement('div');
    folders.id = 'mainFolders';
    holder.appendChild(mainUrls);
    holder.appendChild(folders);

    var allUrls = [];
    var allFolders = [];

    return {
        addUrl: function (currUrl) {
            allUrls.push(currUrl);
        },

        addFolder: function (currFolder) {
            allFolders.push(currFolder);
        },

        render : function (mainHolder) {
            for (var i = 0; i < allUrls.length; i++) {
                mainUrls.appendChild(allUrls[i].getURLElement());
            }

            for (var i = 0; i < allFolders.length; i++) {
                folders.appendChild(allFolders[i].getFolderElement());
            }

            mainHolder.appendChild(holder);
        }
    }
}());