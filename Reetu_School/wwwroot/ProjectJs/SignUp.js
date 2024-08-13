var Id = '0';

function SignUp() {
    var StudentName = $('#txtName').val();
    var FatherName = $('#txtFatherName').val();
    var MotherName = $('#txtMotherName').val();
    var Email = $('#txtEmail').val();
    var DOB = $('#txtDate').val();
    var MobileNumber = $('#txtMobileNumber').val();
    var Courses = $('#DDLCourses').val();
    var Password = $('#txtpassword').val(); 
    var ConfirmPassword = $('#txtconfirmpassword').val();

    if (StudentName === '') {
        alertError('Enter StudentName !');
        $('#txtName').focus();
        return;
    }
    if (FatherName === '') {
        alertError('Enter FatherName!');
        $('#txtFatherName').focus();
        return;
    }
    if (MotherName === '') {
        alertError('Enter MotherName!');
        $('#txtMotherName').focus();
        return;
    }
    if (Email === '') {
        alertError('Enter Email!');
        $('#txtEmail').focus();
        return;
    }
    if (DOB === '') {
        alertError('Enter DOB!');
        $('#txtDate').focus();
        return;
    }
    if (MobileNumber === '') {
        alertError('Enter MobileNumber');
        $('#txtMobileNumber').focus();
        return;
    }
    if (Courses === '') {
        alertError('Enter Courses');
        $('#DDLCourses').focus();
        return;
    }
    if (Password === '') {
        alertError('Enter Password');
        $('#txtpassword').focus();
        return;
    }
    if (ConfirmPassword === '') {
        alertError('Enter ConfirmPassword');
        $('#txtconfirmpassword').focus();
        return;
    }
    var obj = new Object();
    obj.Id = Id;
    obj.StudentName = StudentName;
    obj.FatherName = FatherName;
    obj.MotherName = MotherName;
    obj.Email = Email;
    obj.DOB = DOB;
    obj.MobileNumber = MobileNumber;
    obj.Courses = Courses;
    obj.Password = Password;
    obj.ConfirmPassword = ConfirmPassword;
    console.log(obj);
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
                url: '/Account/SignUp', 
                type: 'POST',
                data: JSON.stringify(obj),
                contentType: 'application/json; charset=UTF-8',
                success: function (data) {
                    if (data.responseCode === 200) {
                        Swal.fire('Success!', data.responseMessage, 'success');
                    } else {
                        Swal.fire('Failed!', data.responseMessage, 'error');
                    }
                },
                error: function (xhr) {
                    console.log(xhr);
                    Swal.fire('Exception!', 'INTERNAL SERVER ERROR.', 'error');
                }
            });
        }
    })
}
function GetSignUpDetail() {
    $.ajax({
        url: '/Account/GetSignUpDetail',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json charset=UTF-8',
        success: function (data) {
            if (data.responseCode === 200) {
                data = data.responseResult;
                $('#ordertable').DataTable({
                    data: data,
                    ordering: false,
                    "bDestroy": true,
                    "lengthMenu": [[-1, 10, 25, 50, 100], ["All", 10, 25, 50, 100]],
                    "columns": [
                        {
                            "data": null,
                            "sortable": false,
                            "aling": "center",
                            "render": function (data, type, row, meta) {
                                return meta.row + meta.settings._iDisplayStart + 1;
                            }, className: "text-center"
                        },
                        {
                            "data": null,
                            "searchable": true,
                            "sortable": false,
                            "aling": "center",
                            "render": function (data, type, row) {
                                var a = row.StudentName;
                                return a;
                            }, className: "text-center"
                        },
                        {
                            "data": null,
                            "searchable": true,
                            "sortable": false,
                            "aling": "center",
                            "render": function (data, type, row) {
                                var a = row.FatherName;
                                return a;
                            }, className: "text-center"
                        },
                        {
                            "data": null,
                            "searchable": true,
                            "sortable": false,
                            "aling": "center",
                            "render": function (data, type, row) {
                                var a = row.MotherName;
                                return a;
                            }, className: "text-center"
                        },
                        {
                            "data": null,
                            "searchable": true,
                            "sortable": false,
                            "aling": "center",
                            "render": function (data, type, row) {
                                var a = row.Email;
                                return a;
                            }, className: "text-center"
                        },
                        {
                            "data": null,
                            "searchable": true,
                            "sortable": false,
                            "aling": "center",
                            "render": function (data, type, row) {
                                var a = row.DOB;
                                return a;
                            }, className: "text-center"
                        },
                        {
                            "data": null,
                            "searchable": true,
                            "sortable": false,
                            "aling": "center",
                            "render": function (data, type, row) {
                                var a = row.MobileNumber;
                                return a;
                            }, className: "text-center"
                        },
                        {
                            "data": null,
                            "searchable": true,
                            "sortable": false,
                            "aling": "center",
                            "render": function (data, type, row) {
                                var a = row.Courses;
                                return a;
                            }, className: "text-center"
                        },
                        {
                            "data": null,
                            "searchable": true,
                            "sortable": false,
                            "aling": "center",
                            "render": function (data, type, row) {
                                var a = row.Password;
                                return a;
                            }, className: "text-center"
                        },
                        {
                            "data": null,
                            "searchable": true,
                            "sortable": false,
                            "aling": "center",
                            "render": function (data, type, row) {
                                var a = row.ConfirmPassword;
                                return a;
                            }, className: "text-center"
                        },

                    ]
                });

            }
        },
        error: function (xhr) {
            console.log(xhr);
        }
    })
}