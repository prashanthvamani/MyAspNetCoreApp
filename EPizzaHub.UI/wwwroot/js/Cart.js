
function AddToCart(itemid, price, quantity) {
    $.ajax({
        type: "Get",
        url: "/Cart/AddToCart/" + itemid + "/" + price + "/" + quantity,
        success: function (resp)
        {
            debugger;
            $("#cartCounter").text(resp.count)


            //alert("itemadded");
        }
    });
}