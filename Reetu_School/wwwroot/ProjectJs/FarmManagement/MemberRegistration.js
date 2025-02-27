var _Id = 0;

function SaveMemberDetails() {
    var FirstName = $('#txt_firstName').val();
    var MiddleName = $('#txt_middleName').val();
    var LastName = $('#txt_lastName').val();
    var FFirstName = $('#txt_FatherfirstName').val();
    var FMiddleName = $('#txt_fathermiddleName').val();
    var FLastName = $('#txt_FatherlastName').val();
    var Land = $('#txt_Land').val();
    var UOM = $('#txt_Uom').val();
    var Gender = parseInt($('#ddlGender').val()) || 0;
    var Qualification = $('#ddlQualification').val();
    var Dob = $('#txt_dob').val();
    var MobileNo = $('#txt_mobile').val();
    var Adhar = $('#txt_Adhar').val();
    var Email = $('#txt_email').val();
    var Address = $('#txt_Address').val();
    var PermanantAddress = $('#txt_PermaAddress').val();
    var Pincode = $('#txt_Pincode').val();
    if (FirstName === '') {
        $('#txt_firstName').focus();
        return;
    }

    if (MiddleName === '') {
        $('#txt_middleName').focus();
        return;
    }
    if (LastName === '') {
        $('#txt_lastName').focus();
        return;
    }
    if (FFirstName === '') {
        $('#txt_FatherfirstName').focus();
        return;
    }
    if (FMiddleName === '') {
        $('#txt_fathermiddleName').focus();
        return;
    }
    if (FLastName === '') {
        $('#txt_FatherlastName').focus();
        return;
    }
    if (Land === '') {
        $('#txt_Land').focus();
        return;
    }
    if (UOM === '') {
        $('#txt_Uom').focus();
        return;
    }
    if (Gender === '') {
        $('#ddlGender').focus();
        return;
    }
    if (Qualification === '') {
        $('#ddlQualification').focus();
        return;
    }
    if (Dob === '') {
        $('#txt_dob').focus();
        return;
    }
    if (MobileNo === '') {
        $('#txt_mobile').focus();
        return;
    }
    if (Email === '') {
        $('#txt_email').focus();
        return;
    }
    if (Adhar === '') {
        $('#txt_Adhar').focus();
        return;
    }
    var obj = new Object();
    obj.Id = _Id;
    obj.FirstName = FirstName;
    obj.MiddleName = MiddleName;
    obj.LastName = LastName;
    obj.FFirstName = FFirstName;
    obj.FMiddleName = FMiddleName;
    obj.FLastName = FLastName;
    obj.Land = Land;
    obj.UOM = UOM;
    obj.Gender = Gender;
    obj.Qualification = Qualification;
    obj.Dob = Dob
    obj.MobileNo = MobileNo;
    obj.Email = Email;
    obj.Adhar = Adhar;
    obj.Address = Address;
    obj.PermanantAddress = PermanantAddress;
    obj.Pincode = Pincode;
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
                url: '/FarmManagement/SaveMemberDetails',
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
$('body').on('click', '#cancel', function () {
    window.location.reload();
});
function GetMemberDetails(Id) {
    let obj = {
        Id: Id
    };
    $.post('/FarmManagement/GetMemberDetails', obj).done(function (res) {
        if (res.responseCode == 200) {
            let data = res.responseResult;
            let html = '';
            if (Array.isArray(data) && data.length > 0) {
                data.forEach((v, i) => {
                    html += `<tr>
                    <td style="text-align:center;">${i + 1}</td>
                    <td style="text-align:center;">${v.MemberName}</td>
                    <td style="text-align:center;">${v.FatherName}</td>
                    <td style="text-align:center;">${v.Gender === 1 ? "Male" : "Female"}</td>
                    <td style="text-align:center;">${v.DOB}</td>
                    <td style="text-align:center;">${v.MobileNo}</td>
                    <td style="text-align:center;">${v.Email}</td>
                    <td style="text-align:center;">${v.Adhar}</td>
                    <td style="text-align:center;">${v.Pincode}</td>
                    <td><button class="btn btn-sm btn-success" onclick="Edit(${v.Id})"><i class="fa fa-edit"></i></button>&nbsp;
                    <button class="btn btn-sm btn-danger" onclick="DeleteMember(${v.Id})"><i class="fa fa-trash"></i></button></td>
                    </tr>`;
                })
            }
            else {
                html = '<tr><td colspan="5" style="color:red;">Record Not Found</td></tr>';
            }
            $('#memberdetails').html(html);
        }
        else {
            console.error('ResponseCode is not 200', res.responseCode, res.responseMessage);
        }
    }).fail(function (xhr) {
        console.log('Error', xhr);
    });
}
function Edit(Id) {
    _Id = Id;
    $.ajax({
        url: '/FarmManagement/GetMemberDetails?Id=' + Id,
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json; charset=UTF-8',
        success: function (data) {
            console.log(data);
            if (data.responseCode === 200) {
                data = data.responseResult;
                if (data && data.length > 0) {
                    $('#txt_firstName').val(data[0].FirstName);
                    $('#txt_middleName').val(data[0].MiddleName);
                    $('#txt_lastName').val(data[0].LastName);
                    $('#txt_FatherfirstName').val(data[0].FFirstName);
                    $('#txt_fathermiddleName').val(data[0].FMiddleName);
                    $('#txt_FatherlastName').val(data[0].FLastName);
                    $('#txt_Land').val(data[0].Land);
                    $('#txt_Uom').val(data[0].UOM);
                    $('#ddlGender').val(data[0].Gender);
                    $('#ddlQualification').val(data[0].Qualification);
                    $('#txt_dob').val(data[0].DOB);
                    $('#txt_mobile').val(data[0].MobileNo);
                    $('#txt_Adhar').val(data[0].Adhar);
                    $('#txt_email').val(data[0].Email);
                    $('#txt_Address').val(data[0].Address);
                    $('#txt_PermaAddress').val(data[0].PermanantAddress);
                    $('#txt_Pincode').val(data[0].Pincode);
                }
                else {
                }
            }
        },
        error: function (xhr) {
            console.log(xhr);
        }
    });
}
function DeleteMember(Id) {
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
                url: '/FarmManagement/DeleteMember',
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
