$.ajaxSetup({ cache: false });
var objStudent = $("#StudID");
var objStdentName = $("#StudentName");
var objSchool = $("#School");
var objPeriod = $("#PeriodID");
var objPeriodTO = $("#PeriodTo");
var objPeriodFrom = $("#PeriodFrom");
var objPromotion = $("#PrClID");

$(function () {
    objStudent.change(function () {

        $.getJSON(AppRoot + "Student/ClassRegistration/GetStudentDetails", { StudID: Number(objStudent.val()) }, function (jsn) {
            objStdentName.val(jsn.StName);
            objSchool.val(jsn.School);
        }).error(function (data, status, jqXHR) {
            if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
            else { AlertIt("ERROR: " + data.statusText); }
        });
    });
    objPeriod.change(function () {

        $.getJSON(AppRoot + "Student/ClassRegistration/GetPeriodDetails", { PeriodID: Number(objPeriod.val()) }, function (jsn) {
            objPeriodTO.val(jsn.periodTo);
            objPeriodFrom.val(jsn.periodFrom);
        }).error(function (data, status, jqXHR) {
            if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
            else { AlertIt("ERROR: " + data.statusText); }
            });

        var para = objPromotion.data("para-json");
        para.PeriodID = Number(objPeriod.val());
        objPromotion.attr("data-para-json", JSON.stringify(para));
        objPromotion.empty().append('<option selected="selected" value="">' + objPromotion.data("empty-text") + '</option>');

    });

    
});