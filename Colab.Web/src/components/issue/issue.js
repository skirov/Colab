define(['knockout', 'text!./issue.html', 'issueProvider', 'moment'], function (ko, templateMarkup, IssueProvider, moment) {

    function Issue(params) {
        var that = this;
        that.isInitialized = ko.observable(false);

        that.id = parseInt(params.id);
        that.teamId =
        that.title = ko.observable();
        that.description = ko.observable();
        that.createdOn = ko.observable();
        that.priority = ko.observable();
        that.status = ko.observable();
        that.reporter = ko.observable();
        that.assignee = ko.observable();

        IssueProvider.get(params.id)
            .done(function (data) {
                that.title(data.title);
                that.description(data.description);
                that.createdOn(moment(data.createdOn).format('LLL'));
                that.priority(data.priority);
                that.status(data.status);
                that.reporter(data.reporter.username);
                that.assignee(data.reporter.username);
                that.teamId(data.teamId);
                that.isInitialized(true);
            });
    }

    // This runs when the component is torn down. Put here any logic necessary to clean up,
    // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
    Issue.prototype.dispose = function () {
    };

    return {viewModel: Issue, template: templateMarkup};

});
