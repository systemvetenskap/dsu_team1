function scrolltoTop() {
    $('html, body').animate({
        scrollTop: $(".header-logo").offset().top
    }, 1000);
};
function scrolltoNews() {
    $('html, body').animate({
        scrollTop: $(".News").offset().top - 70
    }, 1000);
};
function scrolltoRegister() {
    $('html, body').animate({
        scrollTop: $(".registerbox").offset().top
    }, 1000);
};