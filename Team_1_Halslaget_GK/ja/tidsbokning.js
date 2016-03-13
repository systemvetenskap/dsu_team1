$(function () {
    $("#buttonDiv").click(function (e) {
        e.preventDefault();
        $("#hours, #confirmButton").slideDown("fast", function () {
        });
    });
});

function openOverlayInfoBox() {
    $('.page-overlay-info-box').fadeIn('slow');

}

function closeOverlayInfoBox() {
    $('.page-overlay-info-boc').fadeOut('slow');
}
