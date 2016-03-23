$(document).ready(function () {
    tinymce.init({
        selector: 'textarea',
        language_url: '/langs/sv_SE.js'
    }); 
});

var prm = Sys.WebForms.PageRequestManager.getInstance();
prm.add_endRequest(function () {
    tinymce.init({
        selector: 'textarea',
        language_url: '/langs/sv_SE.js'
    });
});