define(['knockout', 'text!./team.html', 'feedProvider', 'teamProvider', 'moment', 'issueProvider'],
    function (ko, templateMarkup, FeedProvider, TeamProvider, moment, IssueProvider) {

    function Team(params) {
        var that = this;

        that.teamId = ko.observable(params.id);

        that.isInitialized = ko.observable();
        that.feedItems = ko.observableArray();
        that.postBody = ko.observable();

        that.projectId = ko.observable();
        that.title = ko.observable();
        that.description = ko.observable();
        that.members = ko.observableArray();
        that.issues = ko.observableArray();
        that.issuesForUser = ko.observableArray();

        that.memberToAdd = ko.observable();


        TeamProvider.get(params.id)
            .done(function (data) {
                that.projectId(data.projectId);
                that.title(data.title);
                that.description(data.description);
                that.issues(data.issues);

                FeedProvider.get(data.projectId)
                    .done(function (data) {
                        that.feedItems(data.posts);

                        IssueProvider.getForUser(params.id)
                            .done(function (data) {
                                that.issuesForUser(data);

                                TeamProvider.getAllMembers(params.id)
                                    .done(function (data) {
                                        that.members(data);
                                        that.isInitialized(true);
                                    });
                            });
                    });

            });
    }

        Team.prototype.addPost = function () {
            var that = this;

            FeedProvider.addPost(that)
                .done(function (post) {
                    that.postBody('');
                    post.createdOn = moment().format('LLL');
                    that.feedItems.unshift(post);
                });
        };

        Team.prototype.addMember = function () {
            var that = this;

            TeamProvider.addMember(that)
                .done(function () {
                    alert("User is added successfully.")
                });
        };

return {viewModel: Team, template: templateMarkup};

});
