$.ajaxSetup({ cache: false });

$(function () {

    var objStudID = $('#StudID');

    objStudID.change(function () {
        $.getJSON(AppRoot + "Student/LeavingCertificate/GetStudInfo", { studID: Number(objStudID.val()) }, function (jsn) {
            $('#AdmissionNo').val(jsn.IndexNo);
        }).error(function (data, status, jqXHR) {
            if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
            else { AlertIt("ERROR: " + data.statusText); }
        });
    });
});