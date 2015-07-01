define(['knockout', 'text!./feed.html', 'feedProvider', 'teamProvider', 'moment'], function (ko, templateMarkup, FeedProvider, TeamProvider, moment) {

    function Feed(params) {
        var that = this;

        that.isInitialized = ko.observable(false);
        that.projectId = params.id;
        that.posts = ko.observableArray();
        that.members = ko.observableArray();
        that.title = ko.observable();
        that.createdOn = ko.observable();
        that.creator = ko.observable();

        that.postBody = ko.observable();
        that.teamTitle = ko.observable();
        that.teamDescription = ko.observable();

        FeedProvider.get(params.id)
            .done(function (data) {
                that.title(data.title);
                that.createdOn(moment(data.createdOn).format('LLL'));
                that.posts(data.posts);
                that.creator(data.creator.username);
                that.members(data.members);

                that.isInitialized(true);
            });
    }

    Feed.prototype.addPost = function () {
        var that = this;

        FeedProvider.addPost(that)
            .done(function (post) {
                that.postBody('');
                post.createdOn = moment().format('LLL');
                that.posts.unshift(post);
            });
    };

    Feed.prototype.addTeam = function () {
        var that = this;

        TeamProvider.create(that)
            .done(function (teamId) {
                alert("Project successfully created.");

                window.location.href = "/#team/" + teamId;
            });
    };

    // This runs when the component is torn down. Put here any logic necessary to clean up,
    // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
    Feed.prototype.dispose = function () {
    };

    return {viewModel: Feed, template: templateMarkup};

});
