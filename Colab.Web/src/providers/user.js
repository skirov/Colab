define(['jquery', 'request', 'knockout', 'session'], function($, Request, ko, Session) {
    function UserProvider(params) {
    }

    UserProvider.prototype.get = function() {
        var deferred = $.Deferred();

        Request.get('/Account/UserInfo')
            .done(function(r) {
                deferred.resolve(r);
            })
            .fail(function(r) {
                deferred.reject(r);
            });

        return deferred.promise();
    };

    UserProvider.prototype.getAll = function() {
    };

    UserProvider.prototype.create = function() {
    };

    UserProvider.prototype.logout = function() {
        Session.clear();
        window.location.href= '/#login';
    };

    UserProvider.prototype.update = function() {
    };

    UserProvider.prototype.createProject = function(data) {
        var deferred = $.Deferred(),
            params = {};

        params.title = ko.unwrap(data.newProjectTitle);

        Request.post('/project/create', ko.toJSON(params))
            .done(function(r) {
                deferred.resolve(r);
            })
            .fail(function(r) {
                deferred.reject(r);
            });

        return deferred.promise();
    };

    return new UserProvider();
});
