'use strict';
module.exports = function (grunt) {

  grunt.initConfig({
    watch: {
      // If any .less file changes in directory "build/less/" run the "less"-task.
      files: ["build/less/*.less", "build/less/skins/*.less", "dist/js/app.js"],
        tasks: ["less"]
        //tasks: ["less", "uglify"]
    },
    // "less"-task configuration
    // This task will compile all less files upon saving to create both Colab.css and Colab.min.css
    less: {
      // Development not compressed
      development: {
        options: {
          // Whether to compress or not
          compress: false
        },
        files: {
          // compilation.css  :  source.less          
          "dist/css/Colab.css": "build/less/Colab.less",
          //Non minified skin files
          "dist/css/skins/skin-blue.css": "build/less/skins/skin-blue.less"
        }
      },
      // Production compresses version
      production: {
        options: {
          // Whether to compress or not          
          compress: true
        },
        files: {
          // compilation.css  :  source.less
          "dist/css/Colab.min.css": "build/less/Colab.less",
          // Skins minified
          "dist/css/skins/skin-blue.min.css": "build/less/skins/skin-blue.less"
        }
      }
    },
    // Uglify task info. Compress the js files.
    uglify: {
      options: {
        mangle: true,
        preserveComments: 'some'
      },
      my_target: {
        files: {
          'dist/js/app.min.js': ['dist/js/app.js']
        }
      }
    },
    // Build the documentation files
    includes: {
      build: {
        src: ['*.html'], // Source files 
        dest: 'documentation/', // Destination directory 
        flatten: true,
        cwd: 'documentation/build',
        options: {
          silent: true,
          includePath: 'documentation/build/include'
        }
      }
    },
    cssjanus: {
      build: {
        files: {
          'dist/css/Colab-rtl.css': 'dist/css/Colab.css',
          'dist/css/Colab-rtl.min.css': 'dist/css/Colab.min.css',
          'bootstrap/css/bootstrap-rtl.css': 'bootstrap/css/bootstrap.css',
          'bootstrap/css/bootstrap-rtl.min.css': 'bootstrap/css/bootstrap.min.css'
        }
      }
    }
  });

  // Load all grunt tasks

  // LESS Compiler
  grunt.loadNpmTasks('grunt-contrib-less');
  // Watch File Changes
  grunt.loadNpmTasks('grunt-contrib-watch');
  // Compress JS Files
  grunt.loadNpmTasks('grunt-contrib-uglify');
  // Include Files Within HTML
  grunt.loadNpmTasks('grunt-includes');
  // Convert CSS to RTL
  grunt.loadNpmTasks('grunt-cssjanus');

  // The default task (running "grunt" in console) is "watch"
  grunt.registerTask('default', ['watch']);
};