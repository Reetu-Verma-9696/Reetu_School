var _Id = '0';
function AddServices() {
    debugger;
    var Service = $('#txtServicename').val();
    var DisplayName = $('#txtDisplayNames').val();
    var IsActive = $('#ddlisactive').is(':checked') ? 1 : 0;

    if (Service === '') {
        alert('#txtServicename').focus();
        return;
    }
    if (DisplayName === '') {
        alert('#txtDisplayNames').focus();
        return;
    }
    if (IsActive === '') {
        alert('#ddlisactive').focus();
        return;
    }
    var obj = new Object();
    obj.Id = _Id;
    obj.Service = Service;
    obj.DisplayName = DisplayName;
    obj.IsActive = IsActive;
    Swal.fire({
        title: 'Are you sure?',
        text: "You want to submit detail!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                url: '/Home/AddServices',
                type: 'POST',
                data: JSON.stringify(obj),
                contentType: 'application/json; charset=UTF-8',
                success: function (data) {
                    if (data.responseCode === 200) {
                        swal.fire(
                            'Success!',
                            data.responseMessage,
                            'success').then(function () {
                                location.reload();
                            });
                    }
                    else {
                        console.log(data);
                        alert(data.responseMessage);
                    }
                },
                error: function (xhr) {
                    console.log(xhr);
                    Swal.fire('Exception!', 'INTERNAL SERVER ERROR.', 'error');
                }
            });
        }
    });
}
function Cancel() {
    window.location.reload();
}
function GetServiceDetails(Id) {
    $.ajax({
        url: '/Home/GetServiceDetails?Id=' + Id,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=UTF-8',
        success: function (data) {
            if (data.responseCode === 200) {
                var responseData = data.responseResult;
                console.log(responseData);
                $('#tableServicelist').DataTable({
                    data: responseData,
                    destroy: true,
                    lengthMenu: [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
                    columns: [
                        {
                            data: null,
                            searchable: false,
                            sortable: false,
                            className: "text-center",
                            render: function (data, type, row, meta) {
                                return meta.row + meta.settings._iDisplayStart + 1;
                            }
                        },
                        { data: "Service" },
                        { data: "DisplayName" },
                        {
                            data: "IsActive",
                            render: function (data, type, row) {
                                return data === 0 ? "False" : "True";
                            },
                        },
                        { data: "CreatedDate" },
                        {
                            data: null,
                            searchable: false,
                            sortable: false,
                            className: "text-center",
                            render: function (data, type, row) {
                                return `
                                   <a onclick="EditService(${row.Id})" class="btn btn-success btn-sm">Edit</a>
                                   <a onclick="DeleteService(${row.Id})" class="btn btn-danger btn-sm">Delete</a>
                                   `;
                            }
                        }
                    ]
                });
            } else {
                console.error("Unexpected response code:", data.responseCode);
            }
        },
        error: function (xhr, status, error) {
            console.error("Error in AJAX request:", status, error);
        }
    });
}
function EditService(Id) {
    _Id = Id;
    $.ajax({
        url: '/Home/GetServiceDetails?Id=' + Id,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=UTF-8',
        success: function (data) {
            console.log(data);
            if (data.responseCode === 200) {
                data = data.responseResult;
                if (data && data.length > 0) {
                    $('#txtServicename').val(data[0].Service);
                    $('#txtDisplayNames').val(data[0].DisplayName);
                    $('#ddlisactive').val(data[0].IsActive);
                }
                else {
                    alert('hey');
                }
            }
        },
        error: function (xhr) {
            console.log(xhr);
        }
    });
}
function DeleteService(Id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You want to submit detail!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.isConfirmed) {
            var obj = { Id: Id };
            $.ajax({
                url: '/Home/DeleteService',
                type: 'Delete',
                data: JSON.stringify(obj),
                contentType: 'application/json; charset=UTF-8',
                success: function (data) {
                    if (data.responseCode === 200) {
                        swal.fire(
                            'Success!',
                            data.responseMessage,
                            'success').then(function () {
                                location.reload();
                            });
                    }
                    else {
                        console.log(data);
                        alert(data.responseMessage);
                    }
                },
                error: function (xhr) {
                    console.log(xhr);
                    Swal.fire('Exception!', 'INTERNAL SERVER ERROR.', 'error');
                }
            });
        }
    });
}