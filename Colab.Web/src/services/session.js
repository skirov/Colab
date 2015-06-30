define([], function()
{
    var Session = Class.extend(function()
    {
        this.clear = function(callback)
        {
            localStorage.clear();

            // Delete all cookies
            document.cookie.split(';').forEach(function (c) {
                document.cookie = c.trim().split('=').shift() + '=;expires=Thu, 21 Sep 1979 00:00:01 UTC;';
            });

            if (typeof callback === 'function') {
                callback(true);
            }
            return true;
        }

        this.getItem = function(key, callback)
        {
            if(!key || key == '') return null;

            var data = localStorage.getItem(key);
            var parsed;

            try {
                parsed = $.parseJSON(data);
            }
            catch (ignore) {
            }

            if (typeof callback === 'function') {
                callback(parsed || data);
            }

            return (parsed || data);
        }

        this.setItem = function(key, value, callback)
        {
            if (typeof value !== 'string') {
                value = JSON.stringify(value);
            }

            localStorage.setItem(key, value);

            if (typeof callback === 'function') {
                callback(true);
            }
            return true;
        }

        this.removeItem = function(key, callback)
        {
            localStorage.removeItem(key);

            if (typeof callback === 'function') {
                callback(true);
            }
            return true;
        }

        this.getAll = function(callback)
        {
            var value = {}, i, key, val, parsed;

            for (i = 0; i < localStorage.length; i++) {
                key = localStorage.key(i);
                val = localStorage.getItem(key);

                if (typeof val === 'string' && val !== '') {
                    try {
                        parsed = $.parseJSON(val);
                        if (parsed) {
                            val = parsed;
                        }
                    }
                    catch (ignore) {
                    }
                }

                value[key] = val;
            }

            if (typeof callback === 'function') {
                callback(value);
            }
            return value;
        }

        this.setAll = function(data, callback)
        {
            $.each(data, function (i, val) {
                var value = val;
                if (typeof value !== 'string') {
                    value = JSON.stringify(value);
                }

                localStorage.setItem(i, value);
            });

            if (typeof callback === 'function') {
                callback(true);
            }
            return true;
        }
    });

    return new Session();
});