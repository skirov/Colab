define(['knockout', 'text!./new-message.html'], function(ko, templateMarkup) {

  function NewMessage(params) {
    this.message = ko.observable('Hello from the new-message component!');
  }

  // This runs when the component is torn down. Put here any logic necessary to clean up,
  // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
  NewMessage.prototype.dispose = function() { };
  
  return { viewModel: NewMessage, template: templateMarkup };

});
