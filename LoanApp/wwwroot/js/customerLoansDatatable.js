

$(document).ready(function () {


    var table = $("#customerLoansDatatable");


    $("#customerLoansDatatable").on("click", ".js-delete", function () {
        var button = $(this);
        bootbox.confirm("Are you sure you want to delete this customer loan?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/customerloans/" + button.attr("data-customerloan-id"),
                    method: "DELETE",
                    success: function () {
                        button.closest('tr').remove()
                    }
                });
            }
        });
    });
});