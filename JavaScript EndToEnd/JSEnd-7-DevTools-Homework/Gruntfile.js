module.exports = function (grunt) {

	grunt.initConfig({
		project: {
			app: 'app',
			dev: 'dev',
			dist: 'dist',
		},
		
		coffee: {
		    compile: {
			    files: {
			        '<%= project.dev %>/scripts/js.js': '<%= project.app %>/**/*.coffee'
			    }
		    },
		},
		
		jshint: {
			app: ['Gruntfile.js', '<%= project.dev %>/scripts/**/*.js']
		},
		
		csslint: {
			app: ['<%= project.dev %>/styles/*.css']
		},
		
		concat: {
			js: {
				files: {
					'<%= project.dev %>/allScripts.js': ['<%= project.dev %>/**/*.js']
				}
			},
			css: {
				files: {
					'<%= project.dev %>/styles/allStyles.css': ['<%= project.dev %>/styles/**/*.css']
				}
			}
		},
		cssmin: {
			combine: {
				files: {
					'<%= project.dist %>/styles/allStyles.min.css': '<%= project.dev %>/styles/allStyles.css'
			    }
		    }
		},
		uglify: {
			js: {
				files: {
					'<%= project.dist %>/styles/allScripts.min.js': '<%= project.dev %>/styles/allScripts.js'
				}
			},
			
		},
		
		jade: {
		    compile: {
			    files: {
			        "<%= project.dev %>index.html": '<%= project.app %>/**/*.jade'
			    }
		    }
		},
		
		stylus: {
			app: {
				files: {
					'<%= project.dev %>/styles/main.css': '<%= project.app %>/**/*.styl',
				}
			}
		},
		
		copy: {
			dev: {
				files: [{
					expand: true,
					dot: true,
					cwd: '<%= project.app %>',
					dest: '<%= project.dev %>',
					src: [
						'images/**/*',
					]
				}]
			},
            dist: {
                files: [{
                    expand: true,
                    dot: true,
                    cwd: '<%= project.dev %>',
                    dest: '<%= project.dist %>',
                    src: [
                        'images/**/*',
                    ]
                }]
            }
        },
		
		htmlmin: {                                     
			dist: {                                    
				options: {                               
					removeComments: true,
					collapseWhitespace: true
				},
				files: {                                 
					"<%= project.dist %>index.html": '<%= project.dev %>/index.html'
				}
			}
		},
		
		connect: {
			options: {
				port: 9578,
				livereload: 35729,
				hostname: 'localhost'
			},
			livereload: {
				options: {
					open: true,
					base: [
						'<%= project.app %>'
					]
				}
			}
		},
		
		watch: {
			js: {
				files: ['Gruntfile.js', '<%= project.app %>/**/*.js'],
				options: {
					livereload: true
				}
			},
			css: {
				files: ['<%= project.app %>/**/*.styl'],
				options: {
					livereload: true
				}
			},
			html: {
				files: ['<%= project.app %>/**/*.jade'],
				options: {
					livereload: true
				}
			},
			livereload: {
				options: {
					livereload: '<%= connect.options.livereload %>'
				},
				files: [
					'<%= project.app %>/**/*.coffee',
					'<%= project.app %>/**/*.styl',
					'<%= project.app %>/**/*.jade'
				]
			}
		}
	});
	
	grunt.loadNpmTasks('grunt-contrib-coffee');
	grunt.loadNpmTasks('grunt-contrib-jshint');
	grunt.loadNpmTasks('grunt-contrib-jade');
	grunt.loadNpmTasks('grunt-contrib-stylus');
	grunt.loadNpmTasks('grunt-contrib-copy');
	grunt.loadNpmTasks('grunt-contrib-connect');
	grunt.loadNpmTasks('grunt-contrib-watch');
	
	grunt.loadNpmTasks('grunt-contrib-uglify');
	grunt.loadNpmTasks('grunt-contrib-concat');
	grunt.loadNpmTasks('grunt-contrib-csslint');
	
	grunt.loadNpmTasks('grunt-contrib-cssmin');
	grunt.loadNpmTasks('grunt-contrib-htmlmin');

	grunt.registerTask('serve', ['coffee', 'jshint', 'jade', 'stylus', 'copy' ,'connect', 'watch']);
	grunt.registerTask('build', ['coffee', 'jade', 'stylus','jshint', 'csslint', 'concat', 'uglify', 'cssmin', 'htmlmin', 'copy']);
};