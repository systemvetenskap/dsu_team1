function OpenOverlaySearchMemberMessage() {
    $('.page-overlay-search-member').fadeIn('slow');
}

function CloseOverlaySearchMemberMessage() {
    $('.page-overlay-search-member').fadeOut('slow');
}


$(function scrollToConversationBottom() {
    var wtf = $('#message-box');
    var height = wtf[0].scrollHeight;
    wtf.scrollTop(height);
});