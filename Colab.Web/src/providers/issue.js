define(['jquery', 'request', 'knockout'], function($, Request, ko) {
    function IssueProvider(params) {
    }

    IssueProvider.prototype.get = function(id) {
        var deferred = $.Deferred();

        Request.get('/issues/get/' + id)
            .done(function(r) {
                deferred.resolve(r);
            })
            .fail(function(r) {
                deferred.reject(r);
            });

        return deferred.promise();
    };

    IssueProvider.prototype.getAll = function(teamId) {
        var deferred = $.Deferred();

        Request.get('/issues/getAll/' + teamId)
            .done(function(r) {
                deferred.resolve(r);
            })
            .fail(function(r) {
                deferred.reject(r);
            });

        return deferred.promise();
    };

    IssueProvider.prototype.create = function(data) {
        var deferred = $.Deferred(),
            params = {};

        params.title = ko.unwrap(data.title);
        params.description = ko.unwrap(data.description);
        params.status = ko.unwrap(data.status);
        params.priority = ko.unwrap(data.priority);
        params.reporterEmail = ko.unwrap(data.reporter);
        params.assigneeEmail = ko.unwrap(data.assignee);
        params.teamId = ko.unwrap(data.teamId);

        Request.post('/issues/create', ko.toJSON(params))
            .done(function(r) {
                deferred.resolve(r);
            })
            .fail(function(r) {
                deferred.reject(r);
            });

        return deferred.promise();
    };

    IssueProvider.prototype.delete = function() {
    };

    IssueProvider.prototype.getForUser = function(teamId) {
        var deferred = $.Deferred();

        Request.get('/issues/getIssuesForUsers/' + teamId)
            .done(function(r) {
                deferred.resolve(r);
            })
            .fail(function(r) {
                deferred.reject(r);
            });

        return deferred.promise();
    };

    return new IssueProvider();
});
