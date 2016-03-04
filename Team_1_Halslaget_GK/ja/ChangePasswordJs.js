$(document).ready(function () {

    $('#ContentPlaceHolder1_txtNewPasswordTwo').on('input', function () {
        var valueTxtBox1 = document.getElementById('ContentPlaceHolder1_txtNewPasswordOne').value;
        var valueTxtBox2 = document.getElementById('ContentPlaceHolder1_txtNewPasswordTwo').value;

        if (valueTxtBox1 === valueTxtBox2)
        {
            $('.pass-error-msg').fadeOut('fast');
        }
        else
        {
            $('.pass-error-msg').fadeIn('fast');
        }
    });
});

function openOverlayPasswordChange() {
    $('.page-overlay-password-change').fadeIn('slow');

}

function closeOverlayPasswordChange() {
    $('.page-overlay-password-change').fadeOut('slow');
}

