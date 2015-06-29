define(['knockout', 'text!./add-issue.html'], function(ko, templateMarkup) {

  function AddIssue(params) {
    this.message = ko.observable('Hello from the add-issue component!');
  }

  // This runs when the component is torn down. Put here any logic necessary to clean up,
  // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
  AddIssue.prototype.dispose = function() { };
  
  return { viewModel: AddIssue, template: templateMarkup };

});
