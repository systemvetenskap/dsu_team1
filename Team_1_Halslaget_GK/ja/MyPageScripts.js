$(document).ready(function () {
    var bookingid = document.getElementById('ContentPlaceHolder1_lblTempBookingID').innerText;
    var date = document.getElementById('ContentPlaceHolder1_lblTempDate').innerText;
    var starttime = document.getElementById('ContentPlaceHolder1_lblTempStartTime').innerText;

    if(bookingid === "Empty" && date === "Empty" && starttime === "Empty")
    {
        $('#btnCancelBooking').removeAttr("onclick");
        $('#btnCancelBooking').css("background", "#818181");
        $('#btnCancelBooking').css("cursor", "not-allowed");
    }
});

function openOverlayEditInfo() {
    $('.page-overlay-edit-info').fadeIn('slow');

}

function closeOverlayEditInfo() {
    $('.page-overlay-edit-info').fadeOut('slow');
}

function openCancelBookingOverlay() {
    var bookingid = document.getElementById('ContentPlaceHolder1_lblTempBookingID').innerText;
    var date = document.getElementById('ContentPlaceHolder1_lblTempDate').innerText;
    var starttime = document.getElementById('ContentPlaceHolder1_lblTempStartTime').innerText;

    document.getElementById("ContentPlaceHolder1_lblBookingID").innerHTML = bookingid;
    document.getElementById("ContentPlaceHolder1_lblDate").innerHTML = date;
    document.getElementById("ContentPlaceHolder1_lblStartTime").innerHTML = starttime;

    $('.page-overlay-cancel-booking').fadeIn('slow');
}

function closeCancelBookingOverlay() {
    $('.page-overlay-cancel-booking').fadeOut('slow');
}
