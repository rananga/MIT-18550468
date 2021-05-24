$.ajaxSetup({ cache: false });

$(function () {

    var objClass = $('#ClassID');
    var objStudent = $('#ClassStudID');
    
    objStudent.change(function () {
        $.getJSON(AppRoot + "Examination/MediRepeatCandidate/GetStudInfo", { classStudID: Number(objStudent.val()) }, function (jsn) {
            $('#IndexNo').val(jsn.IndexNo);
        }).error(function (data, status, jqXHR) {
            if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
            else { AlertIt("ERROR: " + data.statusText); }
        });
    });

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