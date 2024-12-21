var Id = '0';
function SaveRegistrationData() {
    var UserName = $('#txtFullName').val();
    var Email = $('#txtEmail').val();
    var MobileNo = $('#txtMobile').val();
    var Password = $('#password').val();
    var CountryId = $('#DDLCountry').val();
    var StateId = $('#DDLState').val();
    var CityId = $('#DDLCity').val();
    if (UserName === '') {
        alertError('Enter UserName');
        $('#txtFullName').focus();
        return;
    }
    if (Email === '') {
        alertError('Enter Email');
        $('#txtEmail').focus();
        return;
    }
    if (MobileNo === '') {
        alertError('Enter MobileNo');
        $('#txtMobile').focus();
        return;
    }
    if (Password === '') {
        alertError('Enter Password');
        $('#password').focus();
        return;
    }

    var obj = new Object();
    obj.Id = Id;
    obj.UserName = UserName;
    obj.Email = Email;
    obj.MobileNo = MobileNo;
    obj.Password = Password;
    obj.CityId = CityId;
    obj.StateId = StateId;
    obj.CountryId = CountryId;
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
                url: '/Account/RegistrationCommand',
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
function BindCountry() {
    $.post('/Home/BindCountry').done(function (data) {
        if (data.responseCode === 200) {
            data = data.responseResult;
            console.log(data);
            $("#DDLCountry").empty().append('<option value="0">::Select::</option>');
            for (var i = 0; i < data.length; i++) {
                $("#DDLCountry").append('<option value="' + data[i].CountryId + '">' + data[i].Country + '</option>');

            }

        }
        else {
            alert(data.responseMessage);
        }
    }).fail(function (xhr) {
        console.log(xhr);
    });
}

function BindState() {
    var CountryId = $("#DDLCountry").val();
    if (CountryId === "0") {
        $("#DDLState").empty().append('<option value="0">::Select::</option>');
        return;
    }
    $.post('/Home/BindState', { CountryId: CountryId }).done(function (data) {
        if (data.responseCode === 200) {
            data = data.responseResult;
            console.log(data);
            $("#DDLState").empty().append('<option value="0">::Select::</option>');
            for (var i = 0; i < data.length; i++) {
                $("#DDLState").append('<option value="' + data[i].StateId + '">' + data[i].State + '</option>');

            }

        }
        else {
            alert(data.responseMessage);
        }
    }).fail(function (xhr) {
        console.log(xhr);
    });
}


function BindCity() {
    var StateId = $("#DDLState").val();
    if (StateId === "0") {
        $("#DDLCity").empty().append('<option value="0">::Select::</option>');
        return;
    }
    $.post('/Home/BindCity', { StateId: StateId }).done(function (data) {
        if (data.responseCode === 200) {
            data = data.responseResult;
            console.log(data);
            $("#DDLCity").empty().append('<option value="0">::Select::</option>');
            for (var i = 0; i < data.length; i++) {
                $("#DDLCity").append('<option value="' + data[i].CityId + '">' + data[i].City + '</option>');

            }

        }
        else {
            alert(data.responseMessage);
        }
    }).fail(function (xhr) {
        console.log(xhr);
    });
}


function GetParameterValues(param) {

    var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < url.length; i++) {
        var urlparam = url[i].split('=');
        if (urlparam[0] == param) {
            return urlparam[1];
        }
    }
}
function SaveLogin() {
    var Email = $('#txtEmail').val();
    var Password = $('#password').val();
    var _url = GetParameterValues('ReturnUrl');

    if (Email === '') {
        alertError('Enter Username');
        $('#txtEmail').focus();
        return;
    }
    if (Password === '') {
        alertError('Enter Password');
        $('#password').focus();
        return;
    }
    var obj = new Object();
    obj.Id = Id;
    obj.Password = Password;
    obj.Email = Email;
    $.ajax({
        url: '/Account/Login?returnUrl=' + _url,
        type: 'POST',
        data: JSON.stringify(obj),
        contentType: 'application/json; charset=UTF-8',
        success: function (data) {
            if (data.responseCode === 200) {
                var returnURL = data.responseResult.returnURL;
                var ResultData = data.responseResult.data;

                if (ResultData !== null) {
                    if (ResultData.redirectURL != '0') {
                        var DisplayData = new Array();
                        var obj = new Object();

                        obj.loginid = ResultData.Id;
                        obj.DisplayName = ResultData.Name;
                        obj.UserRoleId = ResultData.UserRoleId;
                        obj.UserRoleName = ResultData.UserRoleName;
                        obj.Email = ResultData.Email;
                        obj.Mobile = ResultData.Mobile;

                        DisplayData.push(obj);
                        if (window.sessionStorage) {
                            localStorage.clear();
                            sessionStorage.clear();
                            localStorage.setItem("civhgnIS", btoa(JSON.stringify(DisplayData)));
                            sessionStorage.setItem("civhgnIS", btoa(JSON.stringify(DisplayData)));
                        }
                        if (!window.sessionStorage) {
                            createCookie("civhgnIS", btoa(JSON.stringify(DisplayData)), 1);
                        }

                        console.log(DisplayData);
                        window.location.href = returnURL == "0" ? ResultData.redirectURL : returnURL;
                    }
                    else {
                        $('#login_Spinner').hide();
                        $('#btnSignin').removeAttr('disabled', 'disabled');
                        alert('YOU ARE NOT AUTHORIZED USER.');
                    }
                }
            }
            else {
                $('#login_Spinner').hide();
                $('#btnSignin').removeAttr('disabled', 'disabled');
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