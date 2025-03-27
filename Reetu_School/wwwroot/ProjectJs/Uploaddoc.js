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

function BindDocsData(Id) {
    let obj = { Id: Id };
    $.post('/Home/BindDocsData', obj)
        .done(function (res) {
            if (res.responseCode === 200) {
                let data = res.responseResult;
                let html = '';

                if (Array.isArray(data) && data.length > 0) {
                    data.forEach((v, i) => {
                        html += `
                                    <tr>
                                        <td style="text-align:center;">${i + 1}</td>
                                       <td style="text-align:center;">${v.Name}</td>
                    <td><img src="/upload/Doc/${v.Photo}" style="width:100px;height:100px;"></td>
                                    </tr>`;
                    });
                } else {
                    html = '<tr><td colspan="5" style="text-align:center;">No data found</td></tr>';
                }

                $('#docdetails').html(html);
            } else {
                console.error('Response code not 200:', res.responseCode, res.responseMessage);
                Swal.fire('Error', 'Failed to load city details.', 'error');
            }
        })
        .fail(function (xhr) {
            console.error('Request failed:', xhr);
            Swal.fire('Error', 'Unable to fetch data from the server.', 'error');
        });
}
