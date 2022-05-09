$(document).ready(function () {
    $("#customerLoansDatatable").DataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/api/customerloans",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }],
        "columns": [
            { "data": "id", "name": "Id", "autoWidth": true },
            { "data": "customerFullName", "name": "Customer", "autoWidth": true },
            { "data": "date", "name": "Date", "autoWidth": true },
            { "data": "loanProductDescription", "name": "Loan product", "autoWidth": true },
            { "data": "amount", "name": "Amount", "autoWidth": true },
            { "data": "loanRepresentative", "name": "Loan Representative", "autoWidth": true },
            {
                "render": function (data, row) { return "<a href='#' class='btn btn-danger' onclick=DeleteCustomerLoan('" + row.id + "'); >Delete</a>"; }
            },
        ]
    });
});



$(document).ready(function () {
    var table = $("#customerLoansDatatable").DataTable({
        ajax: {
            url: "/api/customerLoans",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data, type, customerLoan) {
                    return "<a href='/customerloans/edit/" + customerLoan.id + "'>" + customerLoan.name + "</a>";
                }
            },
            {
                data: "genre.name"
            },
            {
                data: "id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-customerloan-id=" + data + ">Delete</button>";
                }
            }
        ]
    });


    $("#customerLoansDatatable").on("click", ".js-delete", function () {
        var button = $(this);
        bootbox.confirm("Are you sure you want to delete this customer loan?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/customerLoans/" + button.attr("data-customerloan-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });
});