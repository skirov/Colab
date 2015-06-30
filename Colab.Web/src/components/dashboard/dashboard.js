define(['knockout', 'text!./dashboard.html', 'userProvider'], function (ko, templateMarkup, UserProvider) {

    function Dashboard(params) {
        this.newProjectTitle = ko.observable();
    }

    Dashboard.prototype.createProject = function () {
        var that = this;

        UserProvider.createProject(that)
            .done(function (projectId) {

            })
            .fail(function () {

            });
    };

    // This runs when the component is torn down. Put here any logic necessary to clean up,
    // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
    Dashboard.prototype.dispose = function () {
    };

    return {viewModel: Dashboard, template: templateMarkup};

});
