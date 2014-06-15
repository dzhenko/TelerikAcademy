(function () {
    $.fn.messageBox = function () {
        var $this = $(this).hide();
        
        return {
            success: function (txt) {
                showText(txt, false);
            },

            error: function (txt) {
                showText(txt, true);
            }
        }

        function showText(text, error) {
            if (error) {
                $this.css('background-color', '#F00');
            }
            else {
                $this.css('background-color', '#0F0');
            }

            $this.html(text);
            $this.fadeIn(1000);
            $this.fadeOut(3000);
        }
    }
}());