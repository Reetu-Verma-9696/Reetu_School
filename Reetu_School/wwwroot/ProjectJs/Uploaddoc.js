var Id = 0;
function SaveDocDetails() {
    var Name = $('#txt_FirstName').val();
    var Photo = $('#txt_photo').val();

    var obj = new Object();
    obj.Id = Id;
    obj.Name = Name;
    obj.Photo = Photo;

    var formData = new FormData();
    formData.append('File', $('#txt_photo').prop('files')[0]);
    formData.append('JsonData', JSON.stringify(obj));
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
                url: '/Home/SaveDocDetails',
                type: 'POST',
                processData: false,
                contentType: false,
                data: formData,
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