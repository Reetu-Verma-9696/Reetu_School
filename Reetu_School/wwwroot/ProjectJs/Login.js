var Id = '0';
function SaveData() {
    debugger
    var Username = $('#username').val();
    var Password = $('#password').val();

    if (Username === '') {
        alertError('Enter Username');
        $('#username').focus();
        return;
    }
    if (Password === '') {
        alertError('Enter Password');
        $('#password').focus();
        return;
    }
    var obj = new Object();
    obj.Id = Id;
    obj.Username = Username;
    obj.Password = Password;
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
                url: '/Account/Login', // Ensure this is the correct URL for your POST endpoint
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