$(document).ready(function(){
    $("#loadCons").click(function() {
        $("#content").attr("data", "consulta.html");
    });
    $("#loadLabs").click(function() {
        $("#content").attr("data", "labs.html");
    });
    $("#loadNews").click(function() {
        $("#content").attr("data", "news.html");
    });
    $("#loadAbout").click(function() {
        $("#content").attr("data", "about.html");
    });

    $(".clickable").mouseover(function () {
        $(this).css("background-color", "rgb(77, 77, 255)");
    });
    $(".clickable").mouseleave(function () {
        $(this).css("background-color", "rgb(255, 153, 102)");
    });
});
