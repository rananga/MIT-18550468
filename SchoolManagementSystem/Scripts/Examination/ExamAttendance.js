$.ajaxSetup({ cache: false });

var candiddateJson;

function PostData() {
    var objCandidListJson = $('#CandidateListJson');
    var objTable = $('#examCandidateTbl');
    var arrJsn = [];
    var i = 1;

    objTable.find('tbody tr').each(function () {
        var objJsn = new Object();
        objJsn.id = $(this).data('pid');

        objJsn.ClassStudID = $(this).find('td#clsStudID input[type="hidden"]').val();
        objJsn.ExamAttendance = $(this).find('td#exAttend input[type="hidden"]').val();

        arrJsn.push(objJsn);
    });

    objCandidListJson.val(JSON.stringify(arrJsn));
    candiddateJson = JSON.stringify(arrJsn);
}


$(function () {

    var objExID = $("#ExID");
    var objExamAttendance = $("#ExamAttendance");
    var objTable = $('#examCandidateTbl');
              
   

    objTable.find('tbody tr').each(function () {
        var objStatus = $(this).find('td#studStatus input[type="hidden"]').val();
        var dd = $(this).find('td#exAttend select').val();
        if (objStatus == "OnLeave") {
            $(this).find('td#exAttend input[type="hidden"]').val(0);
            $(this).find('td#exAttend input[type="checkbox"]').prop("disabled", true);
        }       
    });

    objTable.find('tbody tr td#exAttend input[type="checkbox"]').click(function () {

        var cb = $(this);

        if (cb.prop('checked')) {

            $(this).parent().parent().find('td#exAttend input[type="checkbox"]').prop("checked", true);
            $(this).parent().parent().find('td#exAttend input[type="hidden"]').val(1);

            $(this).parent().css("background-color", "White");
            $(this).parent().siblings().css("background-color", "White");
        }
        else {
            $(this).parent().css("background-color", "#fca6a6");
            $(this).parent().siblings().css("background-color", "#fca6a6");
            $(this).parent().parent().find('td#exAttend input[type="hidden"]').val(0);
        }

    });

});