jQuery(function($) {

    if ($('#imageGallery').length) {
        $('#imageGallery').multislider({
            interval: 3000,
            duration: 750
        });
    }
    if ($('#reviewsTable').length) {
        //$('#reviewsTable').DataTable();
    } 
});