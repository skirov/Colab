define(['knockout', 'text!./all-members.html', 'teamProvider'], function(ko, templateMarkup, TeamProvider) {

  function AllMembers(params) {
      var that = this;

      that.isInitialized = ko.observable();
      that.membersForTeam = ko.observableArray();

      TeamProvider.getAllMembers(params.id)
          .done(function (data) {
              that.membersForTeam(data);
              that.isInitialized(true);
          });
  }

  // This runs when the component is torn down. Put here any logic necessary to clean up,
  // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
  AllMembers.prototype.dispose = function() { };
  
  return { viewModel: AllMembers, template: templateMarkup };

});
