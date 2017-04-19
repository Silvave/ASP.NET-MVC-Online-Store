$(document).ready(function () {
    $(".display-img").on("error", function () {
        $(this).attr('src', '../../images/no-photo.png');
    });
});