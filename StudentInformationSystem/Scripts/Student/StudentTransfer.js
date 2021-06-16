$.ajaxSetup({ cache: false });

$(function () {

    var objLastClass = $('#LastProClassID');
    var objNewClass = $('#NewProClassID');
    var objStudent = $('#ClStdID');
    var objLastTeacherInCharge = $('#LastTeacherInCharge');
    var objNewTeacherInCharge = $('#NewTeacherInCharge');
    

    objLastClass.change(function () {
        var para = objStudent.data("para-json");
        para.promoteClassID = Number(objLastClass.val());
        objStudent.attr("data-para-json", JSON.stringify(para));
        objStudent.empty().append('<option selected="selected" value="">' + objStudent.data("empty-text") + '</option>');

        $.getJSON(AppRoot + "Student/StudentTransfers/GetClassTeacherDetails", { ProClassID: Number(objLastClass.val()) }, function (jsn) {
            objLastTeacherInCharge.val(jsn.TeacherName);
        }).error(function (data, status, jqXHR) {
            if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
            else { AlertIt("ERROR: " + data.statusText); }
        });

    });
    objNewClass.change(function () {
        $.getJSON(AppRoot + "Student/StudentTransfers/GetClassTeacherDetails", { ProClassID: Number(objNewClass.val()) }, function (jsn) {
            objNewTeacherInCharge.val(jsn.TeacherName);
        }).error(function (data, status, jqXHR) {
            if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
            else { AlertIt("ERROR: " + data.statusText); }
        });
    });

    objStudent.change(function () {
        $.getJSON(AppRoot + "Student/StudDropouts/GetStudentDetails", { StudID: Number(objStudent.val()) }, function (jsn) {
            var jsnIndexNo = jsn.IndexNo;
            $('#IndexNo').val(jsnIndexNo);
        }).error(function (data, status, jqXHR) {
            if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
            else { AlertIt("ERROR: " + data.statusText); }
        });
    });
});