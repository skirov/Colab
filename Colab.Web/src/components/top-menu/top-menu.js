define(['knockout', 'text!./top-menu.html'], function(ko, templateMarkup) {

  function TopMenu(params) {
    this.message = ko.observable('Hello from the top-menu component!');
  }

  // This runs when the component is torn down. Put here any logic necessary to clean up,
  // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
  TopMenu.prototype.dispose = function() { };
  
  return { viewModel: TopMenu, template: templateMarkup };

});
