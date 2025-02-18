var _Id = '0';
function InsertUserRole() {
    var UserRole = $('#txtUserRole').val();
    var IsActive = $('#txtisactive').val();
    var Optionaldata = $('#ddloptional').val();

    if (UserRole === '') {
        alert('#txtUserRole').focus();
        return;
    }
    if (IsActive === '') {
        alert('#txtisactive').focus();
        return;
    }
    if (Optionaldata === '') {
        alert('#ddloptional').focus();
        return;
    }
    var obj = new Object();
    obj.Id = _Id;
    obj.UserRole = UserRole;
    obj.IsActive = IsActive;
    obj.Optionaldata = Optionaldata;
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
                url: '/Home/InsertUserRole',
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
function GetUserRoleDetails(Id) {
    $.ajax({
        url: '/Home/GetUserRoleDetails?Id=' + Id,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=UTF-8',
        success: function (data) {
            if (data.responseCode === 200) {
                var responseData = data.responseResult;
                console.log(responseData);
                $('#tablelist').DataTable({
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
                        { data: "UserRole" },
                        {
                            data: "IsActive",
                            render: function (data, type, row) {
                                return data === "True" ? "True" : "False";
                            },
                        },
                        { data: "OptionalData" },
                        { data: "CreatedDate" },
                        {
                            data: null,
                            searchable: false,
                            sortable: false,
                            className: "text-center",
                            render: function (data, type, row) {
                                return `
                                   <button onclick="EditUserRole(${row.Id})" class="btn btn-success btn-sm"><i class="fa fa-edit"></i></button>
                                   <button onclick="DeleteUserRole(${row.Id})" class="btn btn-danger btn-sm"><i class="fa fa-trash"></i></button>
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
function EditUserRole(Id) {
    _Id = Id;
    $.ajax({
        url: '/Home/GetUserRoleDetails?Id=' + Id,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=UTF-8',
        success: function (data) {
            console.log(data);
            if (data.responseCode === 200) {
                data = data.responseResult;
                if (data && data.length > 0) {
                    $('#txtUserRole').val(data[0].UserRole);
                    $('#txtisactive').val(data[0].IsActive);
                    $('#ddloptional').val(data[0].OptionalData);
                    $('#staticBackdrop').modal('show');
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
function DeleteUserRole(Id) {
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
                url: '/Home/DeleteUserRole',
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