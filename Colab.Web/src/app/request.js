define(['jquery'], function($) {

    var get = function (url, data) {
            var deferred = $.Deferred();
            $.ajax({
                url: url,
                type: "get",
                data: data,
                success: function (r) {
                    return deferred.resolve(r);
                }
            });
            return deferred;
        },

        post = function (url, data) {
            var deferred = $.Deferred();
            $.ajax({
                url: url,
                type: "post",
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