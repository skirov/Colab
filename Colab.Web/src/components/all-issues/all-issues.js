define(['knockout', 'text!./all-issues.html'], function(ko, templateMarkup) {

  function AllIssues(params) {
    this.message = ko.observable('Hello from the all-issues component!');
  }

  // This runs when the component is torn down. Put here any logic necessary to clean up,
  // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
  AllIssues.prototype.dispose = function() { };
  
  return { viewModel: AllIssues, template: templateMarkup };

});
