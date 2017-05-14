$(document).ready(function () {
    $('#btnSaveProduct').click(function () {

        if ($('#frmProduct').valid()) {
            $.ajax({
                type: 'post',
                url: '/Product/SaveProduct',
                data: $('#frmProduct').serialize(),
                async: false,
                cache: false,
                success: function (result) {
                    if (result.success) {
                        alert('Product details saved successfully');
                        $('#btnReset').trigger('click');
                        GetProducts();
                    }
                    else {
                        alert('Error occurred while processing your request.');
                    }
                },
                error: function () {

                }
            });
        }
        else {
            return false;
        }
    });

    $('#btnUpdateProduct').click(function () {

        if ($('#frmProduct').valid()) {
            $.ajax({
                type: 'post',
                url: '/Product/UpdateProduct',
                data: $('#frmProduct').serialize(),
                async: false,
                cache: false,
                success: function (result) {
                    if (result.success) {
                        alert('Product details updated successfully');
                        $('#btnReset').trigger('click');
                        CreateProduct();
                        GetProducts();
                    }
                    else {
                        alert('Error occurred while processing your request.');
                    }
                },
                error: function () {

                }
            });
        }
        else {
            return false;
        }
    });

    function CreateProduct()
    {
        $.ajax({
            type: 'get',
            url: '/Product/CreateProduct',
            async: false,
            cache: false,
            success: function (result) {
                $('#dvCreateProduct').html(result);
            },
            error: function () {

            }
        });
    }
});