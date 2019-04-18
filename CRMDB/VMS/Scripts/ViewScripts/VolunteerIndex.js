var Popup, dataTable;

$('#btnSelectedRows').on('click', function () {
    let tblData = dataTable.rows('.selected').data();
    let tmpData;
    let emailList = [];
    $.each(tblData, function (i, val) {
        tmpData = tblData[i];
        emailList.push(tmpData[4]);
    });
    alert(emailList.join(", "));
})

$(function () {
    dataTable = $("#volunteerTable").DataTable({
        columnDefs: [
            {
                targets: 0,
                data: null,
                defaultContent: '',
                orderable: false,
                className: 'select-checkbox'
            }
        ],
        select: {
            style: 'multi',
            selector: 'td:not(:last-child)'

        },
        order: [[1, 'asc']],
    });

    $("#datepicker_from").change(function () {
        minDateFilter = new Date(format(this.value)).getTime();
        dataTable.draw();
    });

    $("#datepicker_to").change(function () {
        maxDateFilter = new Date(format(this.value)).getTime();
        dataTable.draw();
    });

});

$('#checkBox').on('click', function () {
    if ($('#checkBox').is(':checked')) {
        dataTable.rows().select();
    }
    else {
        dataTable.rows().deselect();
    }
});

minDateFilter = "";
maxDateFilter = "";

$.fn.dataTableExt.afnFiltering.push(
    function (oSettings, aData, iDataIndex) {
        if (typeof aData._date == 'undefined') {
            aData._date = new Date(aData[1]).getTime();
        }

        if (minDateFilter && !isNaN(minDateFilter)) {
            if (aData._date < minDateFilter) {
                return false;
            }
        }

        if (maxDateFilter && !isNaN(maxDateFilter)) {
            if (aData._date > maxDateFilter) {
                return false;
            }
        }

        return true;
    }
);

function format(inputDate) {
    var array = inputDate.split("-");
    return array[1] + "/" + array[2] + "/" + array[0];
}


function addHoursModal(id, firstname, lastname) {
    document.getElementById("modalVolunteerName").innerHTML = firstname + " " + lastname;
    document.getElementById("VolID").value = id;
}
