$.ajaxSetup({ cache: false });

var classJson;
var objTeacherID = $('#TeacherID');
var objPeriodStartDate = $("#PeriodStartDate");
var objPeriodEndDate = $("#PeriodEndDate");
var objStudID = $("#StudID");
var objJuniorCount = $("#JuniorCount");
var objSeniorCount = $("#SeniorCount");
var objType = $('#Type');
var objStatus = $("#Status");
var objInactiveDate = $("#InactiveDate");
var objInactiveReason = $("#InactiveReason");
var objPromotedDate = $("#PromotedDate");
var objIsPromoted = $("#IsPromoted");
var objIsHP = $("#IsHP");
var objIsDHP = $("#IsDHP");


function PostData() {
    var objPrefGuildJson = $('#PrefGuildJson');
    var arrJsn = [];
    var i = 1;

    $("#InactiveReason").val(objInactiveReason.val());
    $("#InactiveDate").val(objPromotedDate.val());

    var objJsn = new Object();
    objJsn.id = objStudID.val();
    objJsn.InactiveReason = $("#InactiveReason").val();
    objJsn.InactiveDate = $("#InactiveDate").val();

    arrJsn.push(objJsn);

    objPrefGuildJson.val(JSON.stringify(arrJsn));
}


$(function () {

    objStatus.val(1);
    if (objType.val() == 0) {
        objType.prop('disabled', false);
        objInactiveDate.prop('disabled', true);
        objIsHP.prop('disabled', true);
        objIsDHP.prop('disabled', true);
        objIsPromoted.prop('disabled', false);
        objPromotedDate.prop('disabled', true);
    } else if (objType.val() == 1) {
        objType.prop('disabled', false);
        objInactiveDate.prop('disabled', true);
        objInactiveReason.prop('disabled', true);
        objInactiveReason.val("");
        objIsHP.prop('disabled', false);
        objIsDHP.prop('disabled', false);
        objIsPromoted.prop('disabled', true);
        objPromotedDate.prop('disabled', true);
    }
    else if (objType.val() == 2) {
        objType.prop('disabled', false);
        objInactiveDate.prop('disabled', true);
        objIsHP.prop('disabled', true);
        objIsDHP.prop('disabled', true);
        objIsPromoted.prop('disabled', false);
        objPromotedDate.prop('disabled', true);
    }

    objType.change(function () {
        if (objType.val() == 0) {
            objType.prop('disabled', false);
            objInactiveDate.val("");
            objInactiveDate.prop('disabled', true);
            objIsHP.prop('disabled', true);
            objIsDHP.prop('disabled', true);
            objIsPromoted.prop("checked", false);
            objIsPromoted.prop('disabled', false);
            objInactiveReason.val("");
            objPromotedDate.prop('disabled', true);
            objPromotedDate.val("");
        } else if (objType.val() == 1) {
            objType.prop('disabled', false);
            objInactiveDate.val("");
            objInactiveDate.prop('disabled', true);
            objInactiveReason.prop('disabled', true);
            objInactiveReason.val("");
            objIsHP.prop('disabled', false);
            objIsDHP.prop('disabled', false);
            objIsPromoted.prop("checked", false);
            objIsPromoted.prop('disabled', true);
            objPromotedDate.prop('disabled', true);
            objPromotedDate.val("");
        }
        else if (objType.val() == 2) {
            objType.prop('disabled', false);
            objInactiveDate.val("");
            objInactiveDate.prop('disabled', true);
            objIsHP.prop('disabled', true);
            objIsDHP.prop('disabled', true);
            objIsPromoted.prop("checked", false);
            objIsPromoted.prop('disabled', false);
            objInactiveReason.val("");
            objPromotedDate.prop('disabled', true);
            objPromotedDate.val("");
        }
    });

    objPromotedDate.prop('disabled', true);
    var ischecked = objIsPromoted.is(':checked');    
    if (ischecked) {
        objPromotedDate.prop('disabled', false);
        objStatus.val(0);
        objStatus.prop('disabled', true);
        objInactiveReason.val("Promoted");
        objInactiveReason.prop('disabled', true);
        objInactiveDate.prop('disabled', true);
        objInactiveDate.val(objPromotedDate.val());
    } else {
        objPromotedDate.prop('disabled', true);
        objStatus.val(1);
        objInactiveReason.prop('disabled', true);
        if (objStatus.val() == 0) {
            objInactiveReason.prop('disabled', false);
            objInactiveDate.prop('disabled', false);
        } else {
            objInactiveReason.prop('disabled', true);
            objInactiveDate.prop('disabled', true);
        }
    }

    objIsPromoted.change(function () {
        var ischecked = $(this).is(':checked');
        if (ischecked) {
            objPromotedDate.prop('disabled', false);
            objStatus.val(0);
            objStatus.prop('disabled', true);
            objInactiveReason.prop('disabled', true);
            objInactiveReason.val("Promoted");
            objInactiveDate.val(objPromotedDate.val());
        } else {
            objPromotedDate.prop('disabled', true);
            objStatus.val(1);
            objStatus.prop('disabled', false);
            objInactiveReason.prop('disabled', true);
            objInactiveReason.val("");
            objInactiveDate.val("");
            objPromotedDate.val("");
        }
    });

    objPromotedDate.change(function () {
        objInactiveDate.val(objPromotedDate.val());
    });
        

    objStatus.change(function () {
        if (objStatus.val() == 0) {
            objInactiveReason.prop('disabled', false);
            objInactiveDate.prop('disabled', false);
        } else {
            objInactiveReason.prop('disabled', true);
            objInactiveDate.prop('disabled', true);
        }
    });

    objStudID.change(function () {

        $.getJSON(AppRoot + "Student/PrefectGuild/GetStudClass", { studID: Number(objStudID.val()) }, function (jsn) {

            var jsnClassGrade = jsn.ClassGrade;
            var jsnClass = jsn.ClassID;
            $('#ClassGrade').val(jsnClassGrade);
            $('#PrefClassID').val(jsnClass);

        }).error(function (data, status, jqXHR) {
            if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
            else { AlertIt("ERROR: " + data.statusText); }
        });        
    });


});