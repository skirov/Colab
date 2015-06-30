define(['jquery', 'knockout', './router', 'punches', 'layout-config', 'bootstrap'], function ($, ko, router, punches) {

    // Components can be packaged as AMD modules, such as the following:
    ko.components.register('nav-bar', {require: 'components/nav-bar/nav-bar'});
    ko.components.register('home-page', {require: 'components/home-page/home'});

    // ... or for template-only components, you can just point to a .html file directly:
    ko.components.register('about-page', {
        template: {require: 'text!components/about-page/about.html'}
    });

    ko.components.register('login', {require: 'components/login/login'});

    ko.components.register('register', {require: 'components/register/register'});

    ko.components.register('dashboard', {require: 'components/dashboard/dashboard'});

    ko.components.register('team', {require: 'components/team/team'});

    ko.components.register('feed', {require: 'components/feed/feed'});

    ko.components.register('right-sidebar', {require: 'components/right-sidebar/right-sidebar'});

    ko.components.register('left-sidebar', {require: 'components/left-sidebar/left-sidebar'});

    ko.components.register('top-menu', {require: 'components/top-menu/top-menu'});

    ko.components.register('main', {require: 'components/main/main'});

    ko.components.register('add-issue', {require: 'components/add-issue/add-issue'});

    ko.components.register('all-issues', {require: 'components/all-issues/all-issues'});

    ko.components.register('all-members', {require: 'components/all-members/all-members'});

    ko.components.register('forgotten', {require: 'components/forgotten/forgotten'});

    ko.components.register('change-password', {require: 'components/change-password/change-password'});

    ko.components.register('all-messages', {require: 'components/all-messages/all-messages'});

    ko.components.register('read-message', {require: 'components/read-message/read-message'});

    ko.components.register('new-message', {require: 'components/new-message/new-message'});

    // [Scaffolded component registrations will be inserted here. To retain this feature, don't remove this comment.]

    // Start the application
    punches.enableAll();
    ko.applyBindings({route: router.currentRoute});
});

var isUserLogged = false;