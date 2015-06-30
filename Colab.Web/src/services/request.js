define(['jquery'], function($) {
    var baseUrl = "http://localhost:1250/api";

    var get = function (url, data) {
            var deferred = $.Deferred();
            $.ajax({
                url: baseUrl + url,
                type: "get",
                contentType: 'application/json',
                data: data,
                success: function (r) {
                    return deferred.resolve(r);
                }
            });
            return deferred;
        },

        post = function (url, data) {
            if(url == "/token") {
                baseUrl = "http://localhost:1250";
            }

            var deferred = $.Deferred();
            $.ajax({
                url: baseUrl + url,
                type: "post",
                contentType: 'application/json',
                data: data,
                success: function (r) {
                    return deferred.resolve(r);
                }
            });
            return deferred;
        };

    return {
        get: get,
        post: post
    }
});