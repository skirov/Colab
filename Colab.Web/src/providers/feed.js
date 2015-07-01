define(['jquery', 'request', 'knockout'], function($, Request, ko) {
    function FeedProvider(params) {
    }

    FeedProvider.prototype.get = function(id) {
        var deferred = $.Deferred();

        Request.get('/project/get/'+id)
            .done(function(r) {
                deferred.resolve(r);
            })
            .fail(function(r) {
                deferred.reject(r);
            });

        return deferred.promise();
    };

    FeedProvider.prototype.getAll = function() {
        var deferred = $.Deferred();

        Request.get('/project/getAll')
            .done(function(r) {
                deferred.resolve(r);
            })
            .fail(function(r) {
                deferred.reject(r);
            });

        return deferred.promise();
    };

    FeedProvider.prototype.addPost = function(data) {
        var deferred = $.Deferred(),
            params = {};

        params.body = ko.unwrap(data.postBody);
        params.projectId = ko.unwrap(data.projectId);

        Request.post('/project/addPost', ko.toJSON(params))
            .done(function(r) {
                deferred.resolve(r);
            })
            .fail(function(r) {
                deferred.reject(r);
            });

        return deferred.promise();
    };

    FeedProvider.prototype.delete = function() {
    };

    FeedProvider.prototype.update = function() {
    };

    return new FeedProvider();
});
