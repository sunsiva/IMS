$(document).ready(function () {
    var unsaved = false;
    
    $('#btnSave').click(function () {
        unsaved = false;
    });
    
    // Monitor dynamic inputs
    $(document).on('change', ':input', function () { //triggers change in all input fields including text type
        unsaved = true;
    });

    $(window).bind('beforeunload', function (e) {
        if (unsaved) {
            return "You have unsaved changes on this page. Do you want to leave this page and discard your changes or stay on this page?";
        }
    });

    //TYPE:1 Another way to bind the event
    //var initial_form_state = $('#custcreateform').serialize();
    //$('#custcreateform').submit(function () {
    //    initial_form_state = $('#custcreateform').serialize();
    //});
    //$(window).bind('beforeunload', function (e) {
    //    var form_state = $('#custcreateform').serialize();
    //    if (initial_form_state != form_state) {
    //        var message = "You have unsaved changes on this page. Do you want to leave this page and discard your changes or stay on this page?";
    //        e.returnValue = message; // Cross-browser compatibility (src: MDN)
    //        return message;
    //    }
    //});

    //TYPE:2 Another way to bind the event
    //window.thisPage = window.thisPage || {};
    //window.thisPage.isDirty = false;

    //window.thisPage.closeEditorWarning = function (event) {
    //    if (window.thisPage.isDirty)
    //        return 'It looks like you have been editing something' +
    //               ' - if you leave before saving, then your changes will be lost.'
    //    else
    //        return undefined;
    //};

    //$("form").on('keyup', 'textarea', // You can use input[type=text] here as well.
    //             function () {
    //                 window.thisPage.isDirty = true;
    //             });

    //$("form").submit(function () {
    //    QC.thisPage.isDirty = false;
    //});
    //window.onbeforeunload = window.thisPage.closeEditorWarning;

    //REF: http://stackoverflow.com/questions/11844256/alert-for-unsaved-changes-in-form
});