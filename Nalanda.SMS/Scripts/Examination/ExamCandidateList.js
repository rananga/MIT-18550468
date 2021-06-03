$.ajaxSetup({ cache: false });

var objClassID = $("#ClassID");
var objGrade = $("#Grade");
var objClassStudID = $("#ClassStudID");

$(function () {

    var objExID = $("#ExID");
        
    objExID.change(function () {
        $.getJSON(AppRoot + "Examination/MediRepeatCandidate/GetExamSchedule", { examID: Number(objExID.val()) }, function (jsn) {

            $('#ExamName').val(jsn.ExamName);
            $('#ExamDate').val(jsn.ExamDate);
            $('#ExamTimeFrom').val(jsn.ExamTimeFrom);
            $('#ExamTimeTo').val(jsn.ExamTimeTo);
            $('#ExamType').val(jsn.ExamType);
            $('#ExamTypeDesc').val(jsn.ExamTypeDesc);
            $('#Venue').val(jsn.Venue);
            objGrade.change();

        }).error(function (data, status, jqXHR) {
            if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
            else { AlertIt("ERROR: " + data.statusText); }
        });
    });


    objGrade.change(function () {
        var dd = objGrade.val();
        loadGridEmpKPI();

    });

    function loadGridEmpKPI() {
        var grade = objGrade.val();
        var numGrade = Number(grade);
        var isOnlyCreate = true;
        var examID = objExID.val();

        var emp = $('#ChildContent');

        emp.empty();

        var empUrl = emp.data('url');

        showProgress = false;

        if (empUrl) {
            empUrl += "?id=" + examID + "&isOnlyCreate=" + isOnlyCreate + "&grade=" + numGrade;

            emp.load(empUrl, function (response, status, xhr) {
                if (status == "error") {
                    AlertIt("ERROR: " + xhr.status + "-" + xhr.statusText);
                }
            });
        }
        showProgress = true;
    }


});