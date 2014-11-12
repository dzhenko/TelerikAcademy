(function () {
    if (!window.jQuery) {
        var script = document.createElement("script");
        script.type = 'text/javascript';
        script.src = "resources/jquery.min.js";
        document.head.appendChild(script);
    }

    document.addEventListener("DOMContentLoaded", function () {
        function jQueryLoaded(cb) {
            if (window.jQuery) {
                cb(window.jQuery);
            }
            else {
                setTimeout(function () { jQueryLoaded(cb) }, 200);
            }
        }

        jQueryLoaded(function ($) {
            $("#ListView_itemPlaceholderContainer .HoveredItem").on("mouseenter", hoverFunc);

            var $holder = $("#hoveredWindowHolder");
            $holder.on("mouseover", function () {
                $holder.on("mouseleave", function () {
                    $holder.off("mouseleave");
                    $holder.fadeOut("fast");
                })
            })
        });
    });

    function hoverFunc(el) {
        var numberAsText = $($($(el.currentTarget).parent().children()[0]).children('span')[0])[0].innerHTML;
        $("#hoveredInfoHolder input").val(numberAsText);
        __doPostBack($('#hoveredWindowHolder > div').attr('id'));
        $("#hoveredWindowHolder").css("left", (el.clientX) + "px").css("top", (el.clientY) + "px").fadeIn("fast");
    }
}())