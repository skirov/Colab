define(["knockout", "crossroads", "hasher"], function(ko, crossroads, hasher) {

    // This module configures crossroads.js, a routing library. If you prefer, you
    // can use any other routing library (or none at all) as Knockout is designed to
    // compose cleanly with external libraries.
    //
    // You *don't* have to follow the pattern established here (each route entry
    // specifies a 'page', which is a Knockout component) - there's nothing built into
    // Knockout that requires or even knows about this technique. It's just one of
    // many possible ways of setting up client-side routes.

    return new Router({
        routes: [
            { url: '',              params: { page: 'login', needLogin: false } },
            { url: 'login',              params: { page: 'login', needLogin: false } },
            { url: 'register',      params: { page: 'register', needLogin: false} },
            { url: 'forgotten',     params: { page: 'forgotten', needLogin: false} },
            { url: 'dashboard',     params: { page: 'dashboard', needLogin: true} },
            { url: 'about',         params: { page: 'about-page', needLogin: true} },
            { url: 'team',          params: { page: 'team', needLogin: true} },
            { url: 'feed',          params: { page: 'feed', needLogin: true } },
            { url: 'add-issue',     params: { page: 'add-issue', needLogin: true} },
            { url: 'all-issues',    params: { page: 'all-issues', needLogin: true} },
            { url: 'all-members',   params: { page: 'all-members', needLogin: true} },
            { url: 'forgotten',     params: { page: 'forgotten', needLogin: true} },
            { url: 'change-password', params: { page: 'change-password', needLogin: true} },
            { url: 'all-messages',  params: { page: 'all-messages', needLogin: true} },
            { url: 'read-message',  params: { page: 'road-message', needLogin: true} },
            { url: 'new-message',   params: { page: 'new-message', needLogin: true} }
        ]
    });

    function Router(config) {
        var currentRoute = this.currentRoute = ko.observable({});

        ko.utils.arrayForEach(config.routes, function(route) {
            crossroads.addRoute(route.url, function(requestParams) {
                currentRoute(ko.utils.extend(requestParams, route.params));
            });
        });

        activateCrossroads();
    }

    function activateCrossroads() {
        function parseHash(newHash, oldHash) { crossroads.parse(newHash); }
        crossroads.normalizeFn = crossroads.NORM_AS_OBJECT;
        hasher.initialized.add(parseHash);
        hasher.changed.add(parseHash);
        hasher.init();
    }
});