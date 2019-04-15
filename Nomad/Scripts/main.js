jQuery(function($) {

    if ($('#imageGallery').length) {
        $('#imageGallery').multislider({
            interval: 5000,
            slideAll: true
        });
    }

});