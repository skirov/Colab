define(['knockout', 'text!./add-issue.html', 'knockout', 'issueProvider'], function (ko, templateMarkup, ko, IssueProvider) {

    function AddIssue(params) {
        var that = this;

        this.teamId = ko.observable(params.id);
        this.title = ko.observable();
        this.description = ko.observable();
        this.status = ko.observable();
        this.priority = ko.observable();
        this.reporter = ko.observable();
        this.assignee= ko.observable();
    }

    AddIssue.prototype.addIssue = function () {
        var that = this;

        IssueProvider.create(that)
            .done(function (issue) {
                alert("Issue successfully created.");

                window.location.href = "/#team/" + issue.teamId;
            });
    };

    return {viewModel: AddIssue, template: templateMarkup};
});
