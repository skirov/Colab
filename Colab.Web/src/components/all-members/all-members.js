define(['knockout', 'text!./all-members.html'], function(ko, templateMarkup) {

  function AllMembers(params) {
    this.message = ko.observable('Hello from the all-members component!');
  }

  // This runs when the component is torn down. Put here any logic necessary to clean up,
  // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
  AllMembers.prototype.dispose = function() { };
  
  return { viewModel: AllMembers, template: templateMarkup };

});
