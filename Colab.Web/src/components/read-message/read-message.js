define(['knockout', 'text!./read-message.html'], function(ko, templateMarkup) {

  function ReadMessage(params) {
    this.message = ko.observable('Hello from the read-message component!');
  }

  // This runs when the component is torn down. Put here any logic necessary to clean up,
  // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
  ReadMessage.prototype.dispose = function() { };
  
  return { viewModel: ReadMessage, template: templateMarkup };

});
