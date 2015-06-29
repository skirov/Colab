define(['knockout', 'text!./right-sidebar.html'], function(ko, templateMarkup) {

  function RightSidebar(params) {
    this.message = ko.observable('Hello from the right-sidebar component!');
  }

  // This runs when the component is torn down. Put here any logic necessary to clean up,
  // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
  RightSidebar.prototype.dispose = function() { };
  
  return { viewModel: RightSidebar, template: templateMarkup };

});
