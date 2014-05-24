function generateSliderControl() {
    if (!Object.create) {
        Object.create = function (obj) {
            function f() { };
            f.prototype = obj;
            return new f();
        }
    }

    if (!Object.prototype.extend) {
        Object.prototype.extend = function (properties) {
            function f() { };
            f.prototype = Object.create(this);
            for (var prop in properties) {
                f.prototype[prop] = properties[prop];
            }
            return new f();
        }
    }

    var ClickableElement = {
        init: function (element, handler) {
            this.element = element;
            this.element.addEventListener('click', handler, false);
        }
    }

    var Image = ClickableElement.extend({
        init: function (title, smallURL, largeURL,handler) {
            this.title = title;
            this.smallURL = smallURL;
            this.largeURL = largeURL;

            var currElement = document.createElement('img');
            currElement.className = 'smallImage';
            currElement.src = this.smallURL;

            ClickableElement.init.call(this, currElement, handler);
        }
    });

    var Button = ClickableElement.extend({
        init: function (url,handler) {
            var currElement = document.createElement('div');
            currElement.className = 'button';
            currElement.style.backgroundImage = 'url(' + url + ')';
            currElement.style.width = '40px';
            currElement.style.height = '40px';
            currElement.style.display = 'inline-block';

            ClickableElement.init.call(this, currElement, handler);
        }
    })

    var Slider = {
        init: function (holder) {
            var self = this;
            self.images = [];
            self.currIndex = 0;

            self.thumbs = document.createElement('div');
            self.thumbs.id = 'thumbs';

            self.enlarged = document.createElement('div');
            self.enlarged.id = 'enlarged';
            self.enlarged.style.width = '600px';
            self.enlarged.style.height = '600px';

            self.buttons = document.createElement('div');
            self.buttons.id = 'buttons';

            self.prevBut = Object.create(Button);
            self.prevBut.init('prev.png', function () {
                self.currIndex--;
                if (self.currIndex == 0) {
                    self.currIndex = self.images.length - 1;
                }
                self.enlarged.style.backgroundImage = 'url(' + self.images[self.currIndex].largeURL + ')';
            });

            self.nextBut = Object.create(Button);
            self.nextBut.init('next.png', function () {
                self.currIndex++;
                if (self.currIndex == self.images.length) {
                    self.currIndex = 0;
                }
                self.enlarged.style.backgroundImage = 'url(' + self.images[self.currIndex].largeURL + ')';
            });

            self.buttons.appendChild(self.prevBut.element);
            self.buttons.appendChild(self.nextBut.element);

            self.sliderBody = document.createElement('div');
            self.sliderBody.id = 'sliderbody';

            self.sliderBody.appendChild(self.enlarged);
            self.sliderBody.appendChild(self.buttons);
            self.sliderBody.appendChild(self.thumbs);

            holder.appendChild(self.sliderBody);
        },

        changeImage: function (index) {
            self.enlarged.style.backgroundImage = 'url(' + self.images[index].largeURL + ')';
            self.currIndex = index;
        },
    };

    (function () {
        'use strict';
        var currHolder = document.getElementById('holder');

        var currSlider = Object.create(Slider);
        currSlider.init(currHolder);

        for (var i = 1; i < 10; i++) {
            var currImg = Object.create(Image);
            currImg.init('Image ' + i, i + '.jpg', 'l' + i + '.jpg', function (ev) {
                var targetimg = ev.target;
                var index = 0;
                for (var j = 0; j < currSlider.images.length; j++) {
                    
                    if (currSlider.images[j].element == targetimg) {
                        index = j;
                        break;
                    }
                }
                currSlider.enlarged.style.backgroundImage = 'url(' + currSlider.images[j].largeURL + ')';
                currSlider.currIndex = index;
            });
            currSlider.images.push(currImg);
            currSlider.thumbs.appendChild(currImg.element);
        }
    }());
};
