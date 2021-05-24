$.ajaxSetup({ cache: false });


$(function () {

    var objExID = $("#ExamScheduleID");

    $("form").submit(function (e) {
        var frm = $(this);

        $.ajax({
            type: "POST",
            url: frm[0].action,
            data: frm.serialize(),
            success: function (data, textStatus, jqXHR) {
                var ct = jqXHR.getResponseHeader("content-type") || "";
                if (ct.indexOf('ms-excel') > -1) {
                    objProg.hide();
                    var win = window.open(frm[0].action + '?' + frm.serialize(), '_blank');
                    if (win) {
                        win.focus();
                    }
                }
                else if (ct.indexOf('json') > -1) {
                    objProg.hide();
                    var win = window.open(frm[0].action + '?' + $.param(data), '_blank');
                    if (win) {
                        win.focus();
                    }
                }
                else {
                    var w = document.open("text/html", "replace");
                    w.write(data);
                    w.close();
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                AlertIt(textStatus);
            }
        });

        e.preventDefault();
    });

    objExID.change(function () {
        $.getJSON(AppRoot + "Examination/Reports/GetExamSchedule", { examID: Number(objExID.val()) }, function (jsn) {

            $('#NoOfCandidates').val(jsn.EligibleCount);
            $('#NoOfRepeaters').val(jsn.RepeatCount);
            $('#NoOfMedicals').val(jsn.MedicalCount);
            $('#TotalCandidates').val(jsn.TotalCandidates);

        }).error(function (data, status, jqXHR) {
            if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
            else { AlertIt("ERROR: " + data.statusText); }
        });
    });

});