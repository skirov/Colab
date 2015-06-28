define(['knockout', 'text!./feed.html'], function(ko, templateMarkup) {

  function Feed(params) {
    this.message = ko.observable('Hello from the feed component!');
  }

  // This runs when the component is torn down. Put here any logic necessary to clean up,
  // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
  Feed.prototype.dispose = function() { };
  
  return { viewModel: Feed, template: templateMarkup };

});
