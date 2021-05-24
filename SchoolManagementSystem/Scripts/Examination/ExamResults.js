$.ajaxSetup({ cache: false });

var candiddateJson;

function PostData() {
    var objCandidListJson = $('#CandidateListJson');
    var objTable = $('#examResultsTbl');
    var arrJsn = [];
    var i = 1;

    objTable.find('tbody tr').each(function () {
        var objJsn = new Object();
        objJsn.id = $(this).data('pid');

        objJsn.ClassStudID = $(this).find('td#clsStudID input[type="hidden"]').val();
        objJsn.MRID = $(this).find('td#medRepID input[type="hidden"]').val();
        objJsn.Grade = $(this).find('td#grade select').val();
        if (objJsn.Grade == undefined) { objJsn.Grade = ""; }
        arrJsn.push(objJsn);
    });

    objCandidListJson.val(JSON.stringify(arrJsn));
    candiddateJson = JSON.stringify(arrJsn);

    var failCount = 0;
    var passCount = 0;
    arrJsn.forEach(function (element) {        
        if (element.Grade == "3")
        { failCount++; }
        else if ((element.Grade == "0") || (element.Grade == "1") || (element.Grade == "2"))
        { passCount++; }

        $('#PassCount').val(passCount);
        $('#FailCount').val(failCount);
    });

}


$(function () {

    var objExID = $("#ExID");
    var objExamAttendance = $("#ExamAttendance");
    var objTable = $('#examResultsTbl');


    objTable.find('tbody tr td#grade select').change(function () {
        var paraGrade = $(this).val();

        if (paraGrade == 0) {
            $(this).parent().css("background-color", "#9effa1");
            $(this).parent().siblings().css("background-color", "#9effa1");
        }
        else if (paraGrade == 3) {
            $(this).parent().css("background-color", "#fca6a6");
            $(this).parent().siblings().css("background-color", "#fca6a6");
        }
        else {
            $(this).parent().css("background-color", "white");
            $(this).parent().siblings().css("background-color", "white");
        }
        PostData();
    });

});