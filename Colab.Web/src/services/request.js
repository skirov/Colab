define(['jquery', 'session'], function($, Session) {
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
            var headers = {},
                token = Session.getItem('access_token');
            if(url == "/token") {
                baseUrl = "http://localhost:1250";
                headers = {
                    "Content-Type" : "x-www-form-urlencoded"
                }
                data = $.param(JSON.parse(data));
            } else {
                headers = {
                    "Content-Type" : "application/json"
                };

                if(token) {
                    headers["Authorization"] = "Bearer " + token
                }
            }

            var deferred = $.Deferred();
            $.ajax({
                url: baseUrl + url,
                type: "post",
                headers: headers,
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