define(['knockout', 'text!./dashboard.html', 'userProvider', 'noteProvider'], function (ko, templateMarkup, UserProvider, NoteProvider) {

    function Dashboard(params) {
        var that = this;
        this.newProjectTitle = ko.observable();

        this.noteTitle = ko.observable();
        this.noteBody = ko.observable();
        this.notes = ko.observableArray();

        NoteProvider.getAll()
            .done(function (data) {
                that.notes(data);
            });
    }

    Dashboard.prototype.createProject = function () {
        var that = this;

        UserProvider.createProject(that)
            .done(function (projectId) {
                alert("Project successfully created.");

                window.location.href = "/#feed/" + projectId;
            });
    };

    Dashboard.prototype.createNote = function () {
        var that = this;

        NoteProvider.create(that)
            .done(function (note) {
                var newNote = {
                    body: note.Body,
                    title: note.Title,
                    id: note.Id
                };

                that.notes.push(newNote);
                that.noteTitle('');
                that.noteBody('');
            });
    };

    Dashboard.prototype.deleteNote = function (id) {
        var that = this;

        NoteProvider.delete(id)
            .done(function (note) {
            });
    };

    // This runs when the component is torn down. Put here any logic necessary to clean up,
    // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
    Dashboard.prototype.dispose = function () {
    };

    return {viewModel: Dashboard, template: templateMarkup};

});
