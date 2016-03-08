$(document).ready(function () {
    var memberID = document.getElementById('ContentPlaceHolder1_lblMedlemsID').textContent;
    var firstName = document.getElementById('ContentPlaceHolder1_TextBoxFornamn').value;
    var lastName = document.getElementById('ContentPlaceHolder1_TextBoxEfternamn').value;

    if (memberID == "0" && firstName == "" && lastName == "") {
        $('#btnOpenDeleteMemberModal').removeAttr("onclick");
        $('#btnOpenDeleteMemberModal').css("background", "#818181");
        $('#btnOpenDeleteMemberModal').css("cursor", "not-allowed");
    }


});

function openOverlayDeleteMember() {
    var memberID = document.getElementById('ContentPlaceHolder1_lblMedlemsID').textContent;
    var firstName = document.getElementById('ContentPlaceHolder1_TextBoxFornamn').value;
    var lastName = document.getElementById('ContentPlaceHolder1_TextBoxEfternamn').value;

    document.getElementById('ContentPlaceHolder1_lblMemberID').innerHTML = memberID;
    document.getElementById('ContentPlaceHolder1_lblFirstName').innerHTML = firstName;
    document.getElementById('ContentPlaceHolder1_lblLastName').innerHTML = lastName;

    $('.page-overlay-delete-member').fadeIn('slow');

}

function closeOverlayDeleteMember() {
    $('.page-overlay-delete-member').fadeOut('slow');
}

function closeOverlaySaved() {
    $('.page-overlay-saved').fadeOut('slow');
}