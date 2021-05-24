﻿$.ajaxSetup({ cache: false });

$(function () {

    var objStudent = $('#StudID');

    objStudent.change(function () {
        $.getJSON(AppRoot + "Student/StudDropouts/GetStudentDetails", { StudID: Number(objStudent.val()) }, function (jsn) {
            var jsnIndexNo = jsn.IndexNo;
            var jsnClassId = jsn.ClassId;
            var jsnClassDesc = jsn.ClassDesc;
            $('#IndexNo').val(jsnIndexNo);
            $('#ClassID').val(jsnClassId);
            $('#ClassDesc').val(jsnClassDesc);
        }).error(function (data, status, jqXHR) {
            if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
            else { AlertIt("ERROR: " + data.statusText); }
        });
    });
});