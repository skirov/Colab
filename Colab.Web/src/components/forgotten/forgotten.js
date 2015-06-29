define(['knockout', 'text!./forgotten.html'], function (ko, templateMarkup) {

    function Forgotten(params) {
        $(document).ready(function () {
            $('body').addClass('login-page');
        });

        $('input').iCheck({
            checkboxClass: 'icheckbox_square-blue',
            radioClass: 'iradio_square-blue',
            increaseArea: '20%' // optional
        });
    }

    // This runs when the component is torn down. Put here any logic necessary to clean up,
    // for example cancelling setTimeouts or disposing Knockout subscriptions/computeds.
    Forgotten.prototype.dispose = function () {
    };

    return {viewModel: Forgotten, template: templateMarkup};

});
