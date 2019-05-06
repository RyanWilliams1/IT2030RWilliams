function searchFailed() {
    $("#searchresults").html("Sorry, there are no last minute deals.");
}


$(function () {
    $(".RemoveLink").click(function () {
        var id = $(this).attr("data-id");

        $.post("/OrderCart/RemoveFromCart", { "id": id }, function (data) {
            $("#update-message").text(data.Message);
            $("#cart-total").text(data.CartTotal);
        });

        if (data.ItemCount < 1) {
            $("#record-" + data.DeleteId).fadeOut();

        }
    })
});