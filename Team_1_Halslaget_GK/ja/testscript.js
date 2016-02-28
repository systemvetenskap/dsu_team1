function alertusert()
{
    var x = document.getElementById('ContentPlaceHolder1_Label1').innerText;
    alert(x);
}

function testClick() {
    $('.page-overlay-edit-info').fadeIn('slow');

}

function closeOverlay() {
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

$(document).on("click", "[id*=lnkView]", function () {
    $("[id*=Label1]").html($(".id", $(this).closest("tr")).html());
    $("[id*=Label2]").html($(".date", $(this).closest("tr")).html());
    $("[id*=Label3]").html($(".starttime", $(this).closest("tr")).html());

    $('.page-overlay-cancel-booking').fadeIn('slow');

    return false;
});