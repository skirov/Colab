define(['knockout', 'text!./my-issues.html', 'issueProvider'], function (ko, templateMarkup, IssuesProvider) {

    function MyIssues(params) {
        var that = this;
        that.isInitialized = ko.observable();
        that.allIssues = ko.observable();

        IssuesProvider.getForUser()
            .done(function (data) {
                that.allIssues(data);
                that.isInitialized(true);
            });
    }

    // This runs when the component is torn down. Put here any logic necessary to clean up,
    // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
    MyIssues.prototype.dispose = function () {
    };

    return {viewModel: MyIssues, template: templateMarkup};

});
