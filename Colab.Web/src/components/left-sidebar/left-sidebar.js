define(['knockout', 'text!./left-sidebar.html', 'feedProvider'], function (ko, templateMarkup, FeedProvider) {

    function LeftSidebar(params) {
        var that = this;
        that.currentUser = ko.observable();
        that.projects = ko.observable();
        
        FeedProvider.getAll()
            .done(function(data) {
                that.projects(data);
            })
            .fail(function() {

            });
    }

    // This runs when the component is torn down. Put here any logic necessary to clean up,
    // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
    LeftSidebar.prototype.dispose = function () {
    };

    return {viewModel: LeftSidebar, template: templateMarkup};
});
