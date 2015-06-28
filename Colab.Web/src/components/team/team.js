define(['knockout', 'text!./team.html'], function(ko, templateMarkup) {

  function Team(params) {
    this.message = ko.observable('Hello from the team component!');
  }

  // This runs when the component is torn down. Put here any logic necessary to clean up,
  // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
  Team.prototype.dispose = function() { };
  
  return { viewModel: Team, template: templateMarkup };

});
