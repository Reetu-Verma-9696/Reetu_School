var Id = 0;
function AddRow() {
    $('#nodata').remove();
    let i = $('#tbodydetails tr').length + 1;
    $('#tbodydetails').append(
        '<tr id="tr' + i + '"></tr>'
        + ' <td>' + i + '</td>'
        + '<td>'
        + ' <select type="text" class="form-control form-control-sm" id="ddlFinancialyear">'
        + ' <option value="0">Select</option>'
        + ' <option value="1">2023-2024</option>'
        + ' <option value="2">2024-2025</option>'
        + ' </select > '
        + '</td>'

        + ' <td>'
        + ' <select type="text" class="form-control form-control-sm" id="ddlMonth">'
        + '<option value="0">Select</option>'
        + ' <option value="1">January</option>'
        + ' <option value="2">February</option>'
        + ' <option value="3">March</option>'
        + ' <option value="4">April</option>'
        + ' <option value="5">May</option>'
        + ' <option value="6">June</option>'
        + ' <option value="7">July</option>'
        + ' <option value="8">August</option>'
        + ' <option value="9">September</option>'
        + ' <option value="10">October</option>'
        + ' <option value="11">November</option>'
        + ' <option value="12">December</option>'
        + '</select > '
        + '</td>'

        + '<td>'
        + '<select type="text" class="form-control form-control-sm" id="ddlCropSeason">'
        + '<option value="0">Select</option>'
        + '</select >'
        + '</td>'

        + '<td>'
        + '<select type="text" class="form-control form-control-sm" id="ddlCropName">'
        + '<option value="0">Select</option>'
        + '</select> '
        + '</td>'

        + '<td>'
        + '<select type="text" class="form-control form-control-sm" id="ddlCropDiversity">'
        + '<option value="0">Select</option>'
        +'</select > '
        + '</td>'

        +'</tr>'
    )
}
$('body').on('click', '#additem', function () {
    AddRow();
});