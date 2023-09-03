$.ajaxSetup({ cache: false });
var objDonationID = $("#DonationID");
var objStdentAdmissionNo = $("#AdmissionNo");
var objStdentName = $("#StudentName");
var objAmount = $("#Amount");

$(function () {
    objDonationID.change(function () {

        $.getJSON(AppRoot + "Cashier/DonationReceipt/GetStudentDetails", { DonationID: Number(objDonationID.val()) }, function (jsn) {
            objStdentName.val(jsn.StName);
            objStdentAdmissionNo.val(jsn.StAdmissionNo);
            objAmount.val(jsn.amount.toFixed(2));
        }).error(function (data, status, jqXHR) {
            if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
            else { AlertIt("ERROR: " + data.statusText); }
        });
    });

});