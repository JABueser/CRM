function submitWith() {
    var chDays = document.getElementsByName("SelectedDays");
    var chDays1 = Array.prototype.slice.call(chDays).some(x => x.checked);
    if (!chDays1) {
        document.getElementById("Avail-error").innerHTML = "Please select a day.";
    } else {
        document.getElementById("Avail-error").innerHTML = "";
    }
    var chCats = document.getElementsByName("SelectedCategories");
    var chCats1 = Array.prototype.slice.call(chCats).some(x => x.checked);
    if (!chCats1) {
        document.getElementById("Cats-error").innerHTML = "Please select a category.";
    } else {
        document.getElementById("Cats-error").innerHTML = "";
    }
    return chDays1 && chCats1;
}

var Popup, dataTable;

$('#btnSelectedRows').on('click', function () {
    let tblData = dataTable.rows('.selected').data();
    let tmpData;
    let emailList = [];
    $.each(tblData, function (i, val) {
        tmpData = tblData[i];
        emailList.push(tmpData[4]);
    });
    $('#emailList').text(emailList.join(", "));
    $('#myModal').modal();
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
            selector: 'td:first-child'
        },
        order: [[1, 'desc']],
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
    document.getElementById("modalVolunteerName").innerHTML = `${firstname} ${lastname}`;
    document.getElementById("VolID").value = id;
}

$('#copyToClipboard').on('click', function () {
    let copyText = document.getElementById("emailList");
    copyTextToClipboard(copyText.innerHTML);
    alert("Copied the emails");
});

function fallbackCopyTextToClipboard(text) {
    var textArea = document.createElement("textarea");
    textArea.value = text;
    document.body.appendChild(textArea);
    textArea.focus();
    textArea.select();

    try {
        var successful = document.execCommand('copy');
        var msg = successful ? 'successful' : 'unsuccessful';
        console.log('Fallback: Copying text command was ' + msg);
    } catch (err) {
        console.error('Fallback: Oops, unable to copy', err);
    }

    document.body.removeChild(textArea);
}
function copyTextToClipboard(text) {
    if (!navigator.clipboard) {
        fallbackCopyTextToClipboard(text);
        return;
    }
    navigator.clipboard.writeText(text).then(function () {
        console.log('Async: Copying to clipboard was successful!');
    }, function (err) {
        console.error('Async: Could not copy text: ', err);
    });
}
        
$(".checkbox-menu").on("change", "input[type='checkbox']", function () {
    $(this).closest("li").toggleClass("active", this.checked);
});

$(document).on('click', '.allow-focus', function (e) {
    e.stopPropagation();
});
