define(['knockout', 'text!./login.html', 'jquery', 'icheck', 'crossroads', 'authProvider', 'session'],
    function (ko, templateMarkup, $, iCheck, crossroads, AuthProvider, Session) {

    function Login(params) {
        $(document).ready(function () {
            $('body').addClass('login-page');
        });

        $('input').iCheck({
            checkboxClass: 'icheckbox_square-blue',
            radioClass: 'iradio_square-blue',
            increaseArea: '20%' // optional
        });

        this.username = ko.observable();
        this.password = ko.observable();
        this.rememberMe = ko.observable();
    }

    Login.prototype.login = function()
    {
        var that = this;

        AuthProvider.login(that)
            .done(function(data) {
                Session.setItem('access_token', data.access_token);
                window.location.href = '/#dashboard';
            })
            .fail(function() {
                alert("Unsuccessful login")
            });
    };

    // This runs when the component is torn down. Put here any logic necessary to clean up,
    // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
    Login.prototype.dispose = function () {
    };

    return {viewModel: Login, template: templateMarkup};

});
