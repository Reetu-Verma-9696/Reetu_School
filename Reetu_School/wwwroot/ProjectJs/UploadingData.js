﻿var _Id='0'
function btnSubmit() {
    var Name = $('#textName').val();
    var About = $('#textAbout').val();
    var Marks = $('#textMarks').val();
    var Subject = $('#textSubject').val();
    var Description = $('#textDescription').val();
    var ImageFile = $('#txt-file').val();

    if (Name === '') {
        alert('#textName').focus();
        return;
    }
    if (About === '') {
        alert('#textAbout').focus();
        return;
    }
    if (Marks === '') {
        alert('#textMarks').focus();
        return;
    }
    if (Subject === '') {
        alert('#textSubject').focus();
        return;
    }
    if (Description === '') {
        alert('#textDescription').focus();
        return;
    }
    if (ImageFile === '') {
        alert('#txt-file').focus();
        return;
    }
    var obj = new Object();
    obj.Id = _Id;
    obj.Name = Name;
    obj.About = About;
    obj.Marks = Marks;
    obj.Subject = Subject;
    obj.Description = Description;
    obj.ImageFile = ImageFile;
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
                url: '/Home/UploadingData',
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
function GetUploadingData() {
    $.ajax({
        url: '/Home/GetUploadingData?Id=0',
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
                        { data: "Name" },
                        { data: "About" },
                        { data: "Marks" },
                        { data: "Subject" },
                        { data: "Description" },
                        {
                            data: "ImageFile",
                            render: function (data, type, row) {
                                return `<a href="${data}" target="_blank">View Document</a>`;
                            }
                        },
                        {
                            data: null,
                            searchable: false,
                            sortable: false,
                            className: "text-center",
                            render: function (data, type, row) {
                                var icon = row.IsActive === false ? "fa-unlock" : "fa-lock";
                                return `
                                   <a class="btn btn-success btn-sm" href="/Home/UploadingData?Id=${row.Id}" onclick="EditUploadingData();">Edit</a>
                                   <a class="btn btn-danger btn-sm" href="/Account/Delete?Id=${row.Id}">Delete</a> `;
                               
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

function EditUploadingData(Id) {
    Id = Id;
    $.ajax({
        url: '/Home/GetUploadingData?Id=' + Id,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=UTF-8',
        success: function (data) {
            if (data.responseCode === 200) {
                data = data.responseResult;
                $('#textName').val(data[0].Name);
                $('#textAbout').val(data[0].About);
                $('#textMarks').val(data[0].Marks);
                $('#textSubject').val(data[0].Subject);
                $('#textDescription').val(data[0].Description);
            }
        },
        error: function (xhr) {
            console.log(xhr);
        }
    });
}

function UpdateStatusGroup(Id) {
   
}

