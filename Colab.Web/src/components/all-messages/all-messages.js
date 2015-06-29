define(['knockout', 'text!./all-messages.html'], function(ko, templateMarkup) {

  function AllMessages(params) {
    this.message = ko.observable('Hello from the all-messages component!');
  }

  // This runs when the component is torn down. Put here any logic necessary to clean up,
  // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
  AllMessages.prototype.dispose = function() { };
  
  return { viewModel: AllMessages, template: templateMarkup };

});
