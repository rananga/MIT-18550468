$.ajaxSetup({ cache: false });

var objClassID = $("#ClassID");
var objClassStudID = $("#ClassStudID");

$(function () {

    var objExID = $("#ExID");

    objExID.change(function () {
        $.getJSON(AppRoot + "Examination/MediRepeatCandidate/GetExamSchedule", { examID: Number(objExID.val()) }, function (jsn) {
                        
            $('#ExamName').val(jsn.ExamName);
            $('#ExamDate').val(jsn.ExamDate);
            $('#DhammaTimeFrom').val(jsn.DhammaExamTimeFrom);
            $('#DhammaTimeTo').val(jsn.DhammaExamTimeTo);
            $('#AbidhammaTimeFrom').val(jsn.AbidhammaExamTimeFrom);
            $('#AbidhammaTimeTo').val(jsn.AbidhammaExamTimeTo);
            $('#ExamType').val(jsn.ExamType);
            $('#ExamTypeDesc').val(jsn.ExamTypeDesc);
            $('#Venue').val(jsn.Venue);

        }).error(function (data, status, jqXHR) {
            if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
            else { AlertIt("ERROR: " + data.statusText); }
        });
    });

    objClassID.change(function () {
        var para = objClassStudID.data("para-json");
        para.classID = Number(objClassID.val());
        objClassStudID.attr("data-para-json", JSON.stringify(para));
        objClassStudID.empty().append('<option selected="selected" value="">' + objClassStudID.data("empty-text") + '</option>');
        //objClassStudID.trigger('change');
    });


    objClassStudID.change(function () {
        $.getJSON(AppRoot + "Examination/MediRepeatCandidate/GetStudInfo", { classStudID: Number(objClassStudID.val()) }, function (jsn) {
            $('#IndexNo').val(jsn.IndexNo);
        }).error(function (data, status, jqXHR) {
            if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
            else { AlertIt("ERROR: " + data.statusText); }
        });
    });

});