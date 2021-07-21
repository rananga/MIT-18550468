$.ajaxSetup({ cache: false });

$(function () {

    var objYear = $('#Year');
    var objStudent = $('#StudentId');
    var objStudErr = $('#errStudentId');
    
    objYear.add(objStudent).change(function () {
        objStudErr.text('');
        $.getJSON(AppRoot + "Student/TransferStudent/GetStudentLastClassInfo", { year: Number(objYear.val()), studentId: Number(objStudent.val()) }, function (jsn) {
            if (jsn.errmsg)
                objStudErr.text(jsn.errmsg);
            else {
                $('#FromCR_Id').empty().append('<option selected="selected" value="' + jsn.Id + '">' + jsn.Code + '</option>');
            }
        }).error(function (data, status, jqXHR) {
            if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
            else { AlertIt("ERROR: " + data.statusText); }
        });
    });
});