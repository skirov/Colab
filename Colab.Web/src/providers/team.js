define(['jquery', 'request', 'knockout', 'feedProvider'], function($, Request, ko, FeedProvider) {
    function TeamProvider(params) {
    }

    TeamProvider.prototype.get = function(id) {
        var deferred = $.Deferred();

        Request.get('/team/get/'+id)
            .done(function(r) {
                deferred.resolve(r);
            })
            .fail(function(r) {
                deferred.reject(r);
            });

        return deferred.promise();
    };

    TeamProvider.prototype.getAllMembers = function(id) {
        var deferred = $.Deferred();

        Request.get('/team/allMembers/'+id)
            .done(function(r) {
                deferred.resolve(r);
            })
            .fail(function(r) {
                deferred.reject(r);
            });

        return deferred.promise();
    };

    TeamProvider.prototype.create = function(data) {
        var deferred = $.Deferred(),
            params = {};

        params.title = ko.unwrap(data.teamTitle);
        params.description = ko.unwrap(data.description);
        params.projectId = ko.unwrap(data.projectId);

        Request.post('/team/create', ko.toJSON(params))
            .done(function(r) {
                deferred.resolve(r);
            })
            .fail(function(r) {
                deferred.reject(r);
            });

        return deferred.promise();
    };

    TeamProvider.prototype.addMember = function(data) {
        var deferred = $.Deferred(),
            params = {};

        params.username = ko.unwrap(data.memberToAdd);
        params.teamId = ko.unwrap(data.teamId);

        Request.post('/team/addMember', ko.toJSON(params))
            .done(function(r) {
                deferred.resolve(r);
            })
            .fail(function(r) {
                deferred.reject(r);
            });

        return deferred.promise();
    };

    TeamProvider.prototype.update = function() {
    };

    return new TeamProvider();
});
