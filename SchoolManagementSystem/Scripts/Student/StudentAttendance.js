$.ajaxSetup({ cache: false });

function PostData() {
    var objAttendanceListJson = $('#AttendanceListJson');
    var objTable = $('#prefStudentTbl');
    var arrJsn = [];
    var i = 1;

    objTable.find('tbody tr').each(function () {
        var objJsn = new Object();
        objJsn.id = $(this).data('pid');

        objJsn.ClassStudID = $(this).find('td#studID input[type="hidden"]').val();
        objJsn.DaysCount = $(this).find('td#daysCount input').val();
        objJsn.Percentage = $(this).find('td#percentage input').val();

        arrJsn.push(objJsn);
    });
    objAttendanceListJson.val(JSON.stringify(arrJsn));
    classJson = JSON.stringify(arrJsn);
}

$(function () {

    var objClass = $('#ClassID');
    var objStudent = $('#StudID');
    var objPeriodID = $("#PeriodID");
    var objAttID = $('#AttID');
    var objTotalDays = $('#TotalDays');
    var TotalDays = 0;
    var objTable = $('#prefStudentTbl');

    objClass.change(function () {
        loadGrids();
    });

    objPeriodID.change(function () {
        $.getJSON(AppRoot + "Student/StudentPromotion/GetDatePeriod", { datePeriodID: Number(objPeriodID.val()) }, function (jsn) {

            var jsnfDate = new Date(jsn.fDate);
            var jsntDate = new Date(jsn.tDate);
            var fDate = new Date(jsnfDate.getFullYear(), jsnfDate.getMonth() + 1, 1);
            var tDate = new Date(jsntDate.getFullYear(), jsntDate.getMonth() + 1, 1);

            $('#PeriodStartDate').val(fDate.toISOString().slice(0, 10));
            $('#PeriodEndDate').val(tDate.toISOString().slice(0, 10));


        }).error(function (data, status, jqXHR) {
            if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
            else { AlertIt("ERROR: " + data.statusText); }
            });

        var para = objClass.data("para-json");
        para.PeriodID = Number(objPeriodID.val());
        objClass.attr("data-para-json", JSON.stringify(para));
        objClass.empty().append('<option selected="selected" value="">' + objClass.data("empty-text") + '</option>');
    });

       
    function loadGrids() {
        var alg = $('#ChildContent');
        var classID = objClass.val();
        var periodID = objPeriodID.val();
        var attID = objAttID.val();
        alg.empty();

        var algUrl = alg.data('url');

        showProgress = false;

        if (algUrl) {
            algUrl += "?id=" + attID + "&isToEdit=" + true + "&periodId=" + periodID + "&classID=" + classID;

            alg.load(algUrl, function (response, status, xhr) {
                if (status == "error") {
                    AlertIt("ERROR: " + xhr.status + "-" + xhr.statusText);
                }
            });
        }

        showProgress = true;
    }

    //var objTotalDays = $('#TotalDays');
    //var TotalDays = 0;
    //TotalDays = objTotalDays.val();

    //objTotalDays.on('keyup', function () {
    //    TotalDays = objTotalDays.val();
    //    calc();

    //});

    //var ActualDays = 0;
    //var first = 0;

    //$('#prefStudentTbl').find('tbody tr td#addDays').on('keyup', function () {
    //    var addDaysCount = $(this).find('input').val();
    //    var daysCount = $(this).parent().find('td#daysCount input').val();

    //    if ((first == 0) || isNaN(addDaysCount)) {
    //        ActualDays = $(this).parent().find('td#daysCount input').val();
    //        first++;
    //    }

    //    var totPercentage = 0;
    //    var studTotDays = 0;

    //    studTotDays = Number(daysCount) + Number(addDaysCount);
    //    totPercentage = (((Number(studTotDays) / Number(TotalDays)) * 100).toFixed(2) + " %");

    //    if (isNaN(studTotDays)) {
    //        studTotDays = Number(ActualDays);
    //        totPercentage = (((Number(studTotDays) / Number(TotalDays)) * 100).toFixed(2) + " %");
    //    }

    //    $(this).parent().find('td#daysCount input').val(studTotDays);
    //    $(this).parent().find('td#percentage input').val(totPercentage);
    //});

    //function calc() {
    //    var i = 0;
    //    $('#prefStudentTbl').find('tbody tr td#daysCount').each(function () {
    //        var daysCount = $(this).find('input').val();
    //        var addDaysCount = $(this).parent().find('td#addDays input').val();

    //        if ((first == 0) || isNaN(addDaysCount)) {
    //            ActualDays = $(this).parent().find('td#daysCount input').val();
    //            first++;
    //        }

    //        var totPercentage = 0;
    //        var studTotDays = 0;

    //        studTotDays = Number(daysCount);
    //        totPercentage = (((Number(studTotDays) / Number(TotalDays)) * 100).toFixed(2) + " %");

    //        if (isNaN(studTotDays)) {
    //            studTotDays = Number(ActualDays);
    //            totPercentage = (((Number(studTotDays) / Number(TotalDays)) * 100).toFixed(2) + " %");
    //        }

    //        $(this).parent().find('td#daysCount input').val(studTotDays);
    //        $(this).parent().find('td#percentage input').val(totPercentage);
    //    });
    //};
});

