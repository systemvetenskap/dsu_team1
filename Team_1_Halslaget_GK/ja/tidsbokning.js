$(function () {
    $("#buttonDiv").click(function (e) {
        e.preventDefault();
        $("#hours, #confirmButton").slideDown("fast", function () {
        });
    });
});