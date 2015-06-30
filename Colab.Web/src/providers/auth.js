define(['jquery', 'request'], function($, Request) {
    function AuthProvider(params) {
    }

    AuthProvider.prototype.login = function(data) {
        var deferred = $.Deferred(),
            params = {};

        params.username = ko.unwrap(data.username);
        params.password = ko.unwrap(data.password);

        Request.get('/account/login', ko.toJSON(params))
            .done(function(r) {
                deferred.resolve(r);
            })
            .fail(function(r) {
                deferred.reject(r);
            });

        return deferred.promise();
    };

    AuthProvider.prototype.register = function(data) {
        var deferred = $.Deferred(),
            params = {};

        params.username = ko.unwrap(data.username);
        params.password = ko.unwrap(data.password);
        params.confirmPassword = ko.unwrap(data.confirmPassword);

        Request.get('/account/register', ko.toJSON(params))
            .done(function(r) {
                deferred.resolve(r);
            })
            .fail(function(r) {
                deferred.reject(r);
            });

        return deferred.promise();
    };

    return AuthProvider;
});
