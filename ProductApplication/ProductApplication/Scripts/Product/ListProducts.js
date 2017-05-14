$(document).ready(function () {
    function EditProduct(productId) {
        $.ajax({
            type: 'GET',
            url: '/Product/EditProduct?productId=' + productId,
            async: false,
            cache: false,
            success: function (data) {
                $('#dvCreateProduct').html(data);
                $('#btnReset').trigger('click');
            },
            error: function () {
                alert('Error occurred while getting the product details');
            }
        });
    }

    function DeleteProduct(productId) {
        $.ajax({
            type: 'DELETE',
            url: '/Product/DeleteProduct?productId=' + productId,
            async: false,
            cache: false,
            success: function (data) {
                alert('Product details deleted successfully');
                GetProducts();
            },
            error: function () {
                alert('Error occurred while getting the product details');
            }
        });
    }

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
});