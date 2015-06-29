define(['knockout', 'text!./left-sidebar.html'], function(ko, templateMarkup) {

  function LeftSidebar(params) {
    this.message = ko.observable('Hello from the left-sidebar component!');
  }

  // This runs when the component is torn down. Put here any logic necessary to clean up,
  // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
  LeftSidebar.prototype.dispose = function() { };
  
  return { viewModel: LeftSidebar, template: templateMarkup };

});
