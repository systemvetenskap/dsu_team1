function scrolltoTop() {
    $('html, body').animate({
        scrollTop: $("#head-seaction").offset().top
    }, 1000);
};
function scrolltoNews() {
    $('html, body').animate({
        scrollTop: $(".news").offset().top - 70
    }, 1000);
};
function scrolltoBookings() {
    $('html, body').animate({
        scrollTop: $(".bookings").offset().top - 70
    }, 1000);
};
function scrolltoRegister() {
    $('html, body').animate({
        scrollTop: $(".registerbox").offset().top - 70
    }, 1000);
};
