var specialConsole = (function () {
    function write(method, args) {
        var result = args[0];

        if (args && args.length > 1) {
            for (var i = 1; i < args.length; i += 1) {
                var regEx = new RegExp('\\{' + (i - 1) + '\\}', 'gi');
                result = result.replace(regEx, args[i]);
            }
        }

        console[method](result);
    }

    return {
        writeLine: function () {
            write('log', arguments);
        },

        writeError: function () {
            write('error', arguments);
        },

        writeWarning: function () {
            write('warn', arguments);
        },
    }
}())