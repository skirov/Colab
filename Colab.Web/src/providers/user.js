define(['jquery', 'request', 'knockout'], function($, Request, ko) {
    function UserProvider(params) {
    }

    UserProvider.prototype.get = function(id) {
    };

    UserProvider.prototype.getAll = function() {
    };

    UserProvider.prototype.create = function() {
    };

    UserProvider.prototype.delete = function() {
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
