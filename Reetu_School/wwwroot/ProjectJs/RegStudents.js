var Id = '0';

function SaveRegdata() {
    var FirstName = $('#StudentFirstname').val();
    var MiddleName = $('#StudentMiddlename').val();
    var LastName = $('#StudentLastname').val();
    var FatherFirstName = $('#FatherFirstname').val();
    var FatherMiddleName = $('#FatherMiddlename').val();
    var FatherLastName = $('#FatherLastname').val();
    var DateofBirth = $('#txt_dob').val();
    var Gender = $('#txt_Gender').val();
    var Category = $('#txt_Category').val();
    var Email = $('#txt_Email').val();
    var Mobile = $('#txt_Mobile').val();
    var AdharNo = $('#txt_Adhar').val();
    var Address = $('#txt_address').val();
    var FullAddress = $('#txt_fulladdress').val();
    var PinCode = $('#txt_pincode').val();
    var Idproof = $('#txt_idproof').val();
    if (FirstName === '') {
        alert('#StudentFirstname').focus();
        return;
    }
    if (MiddleName === '') {
        alert('#StudentFirstname').focus();
        return;
    }
    if (LastName === '') {
        alert('#StudentFirstname').focus();
        return;
    }
    if (FatherFirstName === '') {
        alert('#StudentFirstname').focus();
        return;
    }
    if (FatherMiddleName === '') {
        alert('#StudentFirstname').focus();
        return;
    }
    if (FatherLastName === '') {
        alert('#StudentFirstname').focus();
        return;
    }
    if (DateofBirth === '') {
        alert('#txt_dob').focus();
        return;
    }
    if (Gender === '') {
        alert('#txt_Gender').focus();
        return;
    }
    if (Category === '') {
        alert('#txt_Category').focus();
        return;
    }
    if (Email === '') {
        alert('#txt_Email').focus();
        return;
    }
    if (Mobile === '') {
        alert('#txt_Mobile').focus();
        return;
    }
    if (AdharNo === '') {
        alert('#txt_Adhar').focus();
        return;
    }
    if (Address === '') {
        alert('#txt_address').focus();
        return;
    }
    if (FullAddress === '') {
        alert('#txt_fulladdress').focus();
        return;
    }
    if (PinCode === '') {
        alert('#txt_pincode').focus();
        return;
    }
    if (Idproof === '') {
        alert('#txt_idproof').focus();
        return;
    }
    var obj = new Object();
    obj.Id = Id;
    obj.FirstName = FirstName;
    obj.MiddleName = MiddleName;
    obj.LastName = LastName;
    obj.FatherFirstName = FatherFirstName;
    obj.FatherMiddleName = FatherMiddleName;
    obj.FatherLastName = FatherLastName;
    obj.DateofBirth = DateofBirth;
    obj.Gender = Gender;
    obj.Category = Category;
    obj.Email = Email;
    obj.Mobile = Mobile;
    obj.AdharNo = AdharNo;
    obj.Address = Address;
    obj.FullAddress = FullAddress;
    obj.PinCode = PinCode;
    obj.Idproof = Idproof;
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
                url: '/Home/SaveRegdata',
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


