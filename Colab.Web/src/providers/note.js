define(['jquery', 'request', 'knockout'], function($, Request, ko) {
    function NoteProvider(params) {
    }

    NoteProvider.prototype.get = function(id) {
    };

    NoteProvider.prototype.getAll = function() {
        var deferred = $.Deferred();

        Request.get('/notes/getAll')
            .done(function(r) {
                deferred.resolve(r);
            })
            .fail(function(r) {
                deferred.reject(r);
            });

        return deferred.promise();
    };

    NoteProvider.prototype.create = function(data) {
        var deferred = $.Deferred(),
            params = {};

        params.title = ko.unwrap(data.noteTitle);
        params.body = ko.unwrap(data.noteBody);

        Request.post('/notes/create', ko.toJSON(params))
            .done(function(r) {
                deferred.resolve(r);
            })
            .fail(function(r) {
                deferred.reject(r);
            });

        return deferred.promise();
    };

    NoteProvider.prototype.delete = function(id) {
        var deferred = $.Deferred();

        Request.post('/notes/delete', ko.toJSON({id: id}))
            .done(function(r) {
                deferred.resolve(r);
            })
            .fail(function(r) {
                deferred.reject(r);
            });

        return deferred.promise();
    };

    NoteProvider.prototype.update = function() {
    };

    return new NoteProvider();
});
