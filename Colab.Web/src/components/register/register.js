define(['knockout', 'text!./register.html', 'icheck', 'authProvider', 'crossroads'],
    function (ko, templateMarkup, iCheck, AuthProvider, crossroads) {

    function Register(params) {
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
        this.confirmPassword = ko.observable();
        this.iAgree = ko.observable();
    }

    Register.prototype.register = function()
    {
        var that = this;

        AuthProvider.register(that)
            .done(function(data) {
                debugger;
                crossroads.parse('login');
            })
            .fail(function() {
                alert("Unsuccessful registration")
            });
    };

    // This runs when the component is torn down. Put here any logic necessary to clean up,
    // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
    Register.prototype.dispose = function () {
    };

    return {viewModel: Register, template: templateMarkup};

});
