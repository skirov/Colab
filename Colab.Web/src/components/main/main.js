define(['knockout', 'text!./main.html'], function(ko, templateMarkup) {

  function Main(params) {
    this.message = ko.observable('Hello from the main component!');
  }

  // This runs when the component is torn down. Put here any logic necessary to clean up,
  // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
  Main.prototype.dispose = function() { };
  
  return { viewModel: Main, template: templateMarkup };

});
