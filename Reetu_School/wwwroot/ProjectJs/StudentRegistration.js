var Id = '0';

function SaveStudentRegistration() {
    var StudentFirstName = $('#txtFirstName').val();
    var StudentMiddleName = $('#txtMiddleName').val();
    var StudentLastName = $('#txtLastName').val();
    var FatherFirstName = $('#txtFatherFirstName').val();
    var FatherMiddleName = $('#txtFatherMiddleName').val();
    var FatherLastName = $('#txtFatherLastName').val();
    var Gender = $('#ddlGender').val();
    var DOB = $('#txtDate').val();
    var Nationality = $('#ddlNationality').val();
    var PlaceofBirth = $('#txtplaceofbirth').val();
    var PAN = $('#txtPAN').val();
    var Category = $('#ddlcategory').val();
    var Adhar = $('#txtAdhar').val();
    var MobNumber = $('#txtnumber').val();
    var Email = $('#txtemail').val();
    var Address = $('#txtaddress').val();
    var PermaAddress = $('#txtpaddress').val();
    if (StudentFirstName === '') {
        $('#txtFirstName').focus();
        return;
    }
   
    if (StudentLastName === '') {
        $('#txtLastName').focus();
        return;
    }
    if (FatherFirstName === '') {
        $('#txtFatherFirstName').focus();
        return;
    }
    if (FatherMiddleName === '') {
        $('#txtFatherMiddleName').focus();
        return;
    }
    if (FatherLastName === '') {
        $('#txtFatherLastName').focus();
        return;
    }
    if (Gender === '') {
        $('#ddlGender').focus();
        return;
    }
    if (Nationality === '') {
        $('#ddlNationality').focus();
        return;
    }
    if (PlaceofBirth === '') {
        $('#PlaceofBirth').focus();
        return;
    }
    if (PAN === '') {
        $('#txtPAN').focus();
        return;
    }
    if (Category === '') {
        alertError('Slect Category');
        $('#ddlcategory').focus();
        return;
    }
    if (Adhar === '') {
        $('#txtAdhar').focus();
        return;
    }
    if (MobNumber === '') {
        $('#txtnumber').focus();
        return;
    }
    if (Address === '') {
        alertError('Enter Address');
        $('#txtaddress').focus();
        return;
    }
    if (PermaAddress === '') {
        $('#txtpaddress').focus();
        return;
    }
    var obj = new Object();
    obj.Id = Id;
    obj.StudentFirstName = StudentFirstName;
    obj.StudentMiddleName = StudentMiddleName;
    obj.StudentLastName = StudentLastName;
    obj.FatherFirstName = FatherFirstName;
    obj.FatherMiddleName = FatherMiddleName;
    obj.FatherLastName = FatherLastName;
    obj.Gender = Gender;
    obj.DOB = DOB;
    obj.Nationality = Nationality;
    obj.PlaceofBirth = PlaceofBirth;
    obj.PAN = PAN;
    obj.Category = Category;
    obj.Adhar = Adhar;
    obj.MobNumber = MobNumber;
    obj.Email = Email;
    obj.Address = Address;
    obj.PermaAddress = PermaAddress;
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
                url: '/StudentMgmt/SaveStudentRegistration',
                type: 'POST',
                data: JSON.stringify(obj),
                contentType: 'application/json; charset=UTF-8',
                success: function (data) {
                    if (data.responseCode === 200) {
                        Swal.fire(
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
    })
}
function StudentCommandList(Id) {
    $.ajax({
        url: '/StudentMgmt/StudentCommandList?Id=' + Id,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=UTF-8',
        success: function (data) {
            if (data.responseCode === 200) {
                var responseData = data.responseResult;
                $('#ordertable').DataTable({
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
                        { data: "FullName" },
                        { data: "FatherFullName" },
                        { data: "Gender" },
                        { data: "DOB" },
                        { data: "Nationality" },
                        { data: "PlaceOfBirth" },
                        { data: "PAN" },
                        { data: "Category" },
                        { data: "Adhar" },
                        { data: "Mobile" },
                        { data: "Email" },
                        { data: "Address" },
                        { data: "PermanentAddress" },
                        {
                            "data": null,
                            "searchable": false,
                            "sortable": false,
                            "aling": "center",
                            "render": function (data, type, row) {
                                if (row.IsActive == false) {
                                    return '<span class="label label-danger label-bordered label-ghost">BLOCK</span>';
                                } else {
                                    return '<span class="label label-success label-bordered label-ghost">ACTIVE</span>';
                                }
                            }, className: "text-center"
                        },
                        {
                            data: null,
                            searchable: false,
                            sortable: false,
                            className: "text-center",
                            render: function (data, type, row) {
                                var icon = row.IsActive === false ? "fa-unlock" : "fa-lock";
                                var btnclr = row.IsActive === false ? "btn-success":"btn-danger";
                                return `
                                   <a onclick="EditUploadingData(${row.Id})" class="btn btn-success btn-sm"></a><a><button onclick="UpdateStatusList(${row.Id})" class="btn ' + btnclr + ' btn-xs"><span class="fa ' + icon + '"></span></button></a>
                                   <a onclick="DeleteUploadingData(${row.Id})" class="btn btn-danger btn-sm"><i class="fa fa-trash"></i></a>
                                   <a class="btn btn-info btn-sm"><i class="fa fa-envelope"></i></a>
                                   
                                   `;

                            }
                        }
                    ],

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

function UpdateStatusList() {
    var obj = new Object();
    obj.Id = Id.toString();
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
                url: '/StudentMgmt/UpdateStatusList',
                type: 'POST',
                data: JSON.stringify(obj),
                contentType: 'application/json; charset=UTF-8',
                success: function (data) {
                    if (data.responseCode === 200) {
                        Swal.fire(
                            'Success!',
                            data.responseMessage,
                            'success').then(function () {
                                StudentCommandList();
                                window.location.reload();
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
    })
}



