define(['jquery', 'request', 'knockout'], function($, Request, ko) {
    function AuthProvider(params) {
    }

    AuthProvider.prototype.login = function(data) {
        var deferred = $.Deferred(),
            params = {};

        params.username = ko.unwrap(data.username);
        params.password = ko.unwrap(data.password);
        params.grant_type = 'password';

        Request.post('/token', ko.toJSON(params))
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

        params.email = ko.unwrap(data.username);
        params.password = ko.unwrap(data.password);
        params.confirmPassword = ko.unwrap(data.confirmPassword);

        Request.post('/account/register', ko.toJSON(params))
            .done(function(r) {
                deferred.resolve(r);
            })
            .fail(function(r) {
                deferred.reject(r);
            });

        return deferred.promise();
    };

    return new AuthProvider();
});
