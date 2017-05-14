$(document).ready(function () {

    function GetProducts() {
        $.ajax({
            type: 'GET',
            url: '/Product/ListProducts',
            async: false,
            cache: false,
            success: function (data) {
                $('#dvListProducts').html(data);
            },
            error: function () {
                alert('Error occurred while getting the list of products');
            }
        });
    }

    GetProducts();
});