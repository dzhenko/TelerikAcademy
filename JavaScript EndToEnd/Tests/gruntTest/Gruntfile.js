module.exports = function (grunt) {
    require('load-grunt-tasks')(grunt);

    grunt.initConfig({
        // if changed the dirs used by all the grunt file will change also
        project: {
            app: 'app',
            dev: 'dev'
        },
        connect: {
            options: {
                port: 9001,
                livereload: 35729,
                hostname: 'localhost'
            },
            livereload: {
                options: {
                    open: true,
                    // where to find the index.html file (I think)
                    base: [
                        '<%= project.app %>'
                    ]
                }
            }
        },
        // sample - if you add compile to the grunt registered tasks this
        // will find all less files, convert them into css and merge
        // them together + minify them. Also used by the watch tasks array
        less: {
            compile: {
                files: {
                    '<%= project.app %>/styles/main.css' : ['<%= project.dev %>/styles/**/*.less']
                }
            }
        },
        jade: {
            compile: {
                files: {
                    // files can not be murged here (like less)
                    '<%= project.app %>/index.html' : '<%= project.dev %>/index.jade'
                },
                options: {
                    pretty: true
                }
            }
        },
        watch: {
            // sample - if a less file changes - less task is executed that
            // translates the less into css which changes the css which
            // fires event in css change and reloads the page
            less: {
                // files to watch for
                files: ['<%= project.dev %>/styles/**/*.less'],
                // task to execute if a file is changed
                tasks: ['less']
            },
            jade: {
                files: ['<%= project.dev %>/**/*.jade'],
                tasks: ['jade']
            },
            livereload: {
                options: {
                    // gets the value from this settings JSON - in the
                    // connect object options.livereload (currently 35729)
                    livereload: '<%= connect.options.livereload %>'
                },
                // basically watches changes in all html css and js files
                // saving one of those files will fire up the watch and reload
                files: [
                    'Gruntfile.js',
                    '<%= project.app %>/**/*.html',
                    '<%= project.app %>/**/*.css',
                    '<%= project.app %>/**/*.js'
                ]
            }
        }
    });
                                            // watch module is always last !!!
    grunt.registerTask('serve', ['jade', 'connect', 'watch']);
};