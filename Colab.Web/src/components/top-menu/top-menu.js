define(['knockout', 'text!./top-menu.html', 'userProvider'], function (ko, templateMarkup, UserProvider) {

    function TopMenu(params) {
        var that = this;
        that.userEmail = ko.observable();

        UserProvider.get()
            .done(function (data) {
                that.userEmail(data.Email);
            });
    }

    TopMenu.prototype.logout = function () {
        UserProvider.logout();
    };

    // This runs when the component is torn down. Put here any logic necessary to clean up,
    // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
    TopMenu.prototype.dispose = function () {
    };

    return {viewModel: TopMenu, template: templateMarkup};

});
