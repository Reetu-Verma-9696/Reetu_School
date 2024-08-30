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
        //alertError('Enter StudentName !');
        $('#txtName').focus();
        return;
    }
    if (FatherName === '') {
        //alertError('Enter FatherName!');
        $('#txtFatherName').focus();
        return;
    }
    if (MotherName === '') {
        //alertError('Enter MotherName!');
        $('#txtMotherName').focus();
        return;
    }
    if (Email === '') {
        //alertError('Enter Email!');
        $('#txtEmail').focus();
        return;
    }
    if (DOB === '') {
       // alertError('Enter DOB!');
        $('#txtDate').focus();
        return;
    }
    if (MobileNumber === '') {
        //alertError('Enter MobileNumber');
        $('#txtMobileNumber').focus();
        return;
    }
    if (Courses === '') {
       // alertError('Enter Courses');
        $('#DDLCourses').focus();
        return;
    }
    if (Password === '') {
       // alertError('Enter Password');
        $('#txtpassword').focus();
        return;
    }
    if (ConfirmPassword === '') {
        //alertError('Enter ConfirmPassword');
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
        contentType: 'application/json; charset=UTF-8',
        success: function (data) {
            if (data && data.responseCode === 200) {
                var result = data.responseResult;
                console.log(result); // For debugging

                $('#ordertable').DataTable({
                    data: result,
                    ordering: false,
                    destroy: true,
                    lengthMenu: [[-1, 10, 25, 50, 100], ["All", 10, 25, 50, 100]],
                    columns: [
                        {
                            data: null,
                            sortable: false,
                            align: "center",
                            render: function (data, type, row, meta) {
                                return meta.row + meta.settings._iDisplayStart + 1;
                            },
                            className: "text-center"
                        },
                        { data: "StudentName", searchable: true, sortable: false, align: "center", className: "text-center" },
                        { data: "FatherName", searchable: true, sortable: false, align: "center", className: "text-center" },
                        { data: "MotherName", searchable: true, sortable: false, align: "center", className: "text-center" },
                        { data: "Email", searchable: true, sortable: false, align: "center", className: "text-center" },
                        { data: "DOB", searchable: true, sortable: false, align: "center", className: "text-center" },
                        { data: "MobileNumber", searchable: true, sortable: false, align: "center", className: "text-center" },
                        { data: "Courses", searchable: true, sortable: false, align: "center", className: "text-center" },
                        { data: "Password", searchable: true, sortable: false, align: "center", className: "text-center" },
                        { data: "ConfirmPassword", searchable: true, sortable: false, align: "center", className: "text-center" },
                        {
                            data: null,
                            searchable: false,
                            sortable: false,
                            align: "center",
                            render: function (data, type, row) {
                                // Directly create a link to redirect with the row.Id
                                return '<a class="btn btn-success btn-sm" href="/Account/SignUp?Id=' + row.Id + '">Edit</a>';
                            },
                            className: "text-center"
                        }
                    ]
                });
            }
        },
        error: function (xhr) {
            console.error('Error fetching data:', xhr);
        }
    });
}


$(document).ready(function () {
    // Fetch Id from URL
    const urlParams = new URLSearchParams(window.location.search);
    const Id = urlParams.get('Id');

    // Check if Id exists in the URL
    if (Id) {
        fetchSignUpDetails(Id);
    }
});

function fetchSignUpDetails(Id) {
    $.ajax({
        url: '/Account/GetSignUpDetail?Id=' + Id,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=UTF-8',
        success: function (data) {
            if (data && data.responseCode === 200) {
                const result = data.responseResult;
                if (result && result.length > 0) {
                    $('#txtName').val(result[0].StudentName);
                    $('#txtFatherName').val(result[0].FatherName);
                    $('#txtMotherName').val(result[0].MotherName);
                    $('#txtEmail').val(result[0].Email);
                    $('#txtDate').val(result[0].DOB);
                    $('#txtMobileNumber').val(result[0].MobileNumber);
                    $('#DDLCourses').val(result[0].Courses);
                    $('#txtpassword').val(result[0].Password);
                    $('#txtconfirmpassword').val(result[0].ConfirmPassword);
                }
            } else {
                console.error('Failed to fetch data for Id:', Id);
            }
        },
        error: function (xhr) {
            console.error('Error fetching data:', xhr);
        }
    });
}


