// require.js looks for the following global when initializing
var require = {
    baseUrl: ".",
    paths: {
        "bootstrap":            "bower_modules/components-bootstrap/js/bootstrap.min",
        "icheck":               "bower_modules/icheck/icheck.min",
        "crossroads":           "bower_modules/crossroads/dist/crossroads.min",
        "hasher":               "bower_modules/hasher/dist/js/hasher.min",
        "jquery":               "bower_modules/jquery/dist/jquery",
        "jquery-ui":             "bower_modules/jqueryui/ui/jquery-ui",
        "knockout":             "bower_modules/knockout/dist/knockout",
        "knockout-projections": "bower_modules/knockout-projections/dist/knockout-projections",
        "signals":              "bower_modules/js-signals/dist/signals.min",
        "text":                 "bower_modules/requirejs-text/text",
        "punches":              "bower_modules/knockout.punches/knockout.punches.min",

        "layout-config":        "app/layout.config.min",
        "require":              "app/require"
    },
    shim: {
        "bootstrap": { deps: ["jquery"] }
    }
};
