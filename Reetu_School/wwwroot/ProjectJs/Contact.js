var _Id = '0';
function sendEnquiry() {
    var Name = $('#txtconName').val();
    var Email = $('#txtconEmail').val();
    var Mobile = $('#txtconMobile').val();
    var Message = $('#txtconMessage').val();
    if (Name === '') {
        //alertError('Enter StudentName !');
        $('#txtconName').focus();
        return;
    }
    if (Email === '') {
        //alertError('Enter Email!');
        $('#txtconEmail').focus();
        return;
    }
    if (Mobile === '') {
        // alertError('Enter DOB!');
        $('#txtconMobile').focus();
        return;
    }
    if (Message === '') {
        //alertError('Enter MobileNumber');
        $('#txtconMessage').focus();
        return;
    }
    var obj = new Object();
    obj.Id = _Id;
    obj.Name = Name;
    obj.Email = Email;
    obj.Mobile = Mobile;
    obj.Message = Message;
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
                url: '/Home/sendEnquiry',
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