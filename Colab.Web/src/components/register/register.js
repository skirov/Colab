define(['knockout', 'text!./register.html'], function(ko, templateMarkup) {

  function Register(params) {
    this.message = ko.observable('Hello from the register component!');
  }

  // This runs when the component is torn down. Put here any logic necessary to clean up,
  // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
  Register.prototype.dispose = function() { };
  
  return { viewModel: Register, template: templateMarkup };

});
