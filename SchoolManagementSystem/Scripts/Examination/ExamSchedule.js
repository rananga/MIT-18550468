$.ajaxSetup({ cache: false });

$(function () {

    var objPeriodID = $("#PeriodID");

    objPeriodID.change(function () {
        $.getJSON(AppRoot + "Student/StudentPromotion/GetDatePeriod", { datePeriodID: Number(objPeriodID.val()) }, function (jsn) {

            var jsnfDate = new Date(jsn.fDate);
            var jsntDate = new Date(jsn.tDate);
            var fDate = new Date(jsnfDate.getFullYear(), jsnfDate.getMonth() + 1, 1);
            var tDate = new Date(jsntDate.getFullYear(), jsntDate.getMonth() + 1, 1);

            $('#PeriodFrom').val(fDate.toISOString().slice(0, 10));
            $('#PeriodTo').val(tDate.toISOString().slice(0, 10));

        }).error(function (data, status, jqXHR) {
            if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
            else { AlertIt("ERROR: " + data.statusText); }
        });
    });

});