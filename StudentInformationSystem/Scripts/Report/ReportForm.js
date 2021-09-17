$.ajaxSetup({ cache: false });

$(function () {

    var objOcr = $('#OCR_Id');
    var objOcrTeacher = $('#OCR_TeacherId');

    objOcr.change(function () {
        var para = objOcrTeacher.data("para-json");
        para.OCR_ID = Number(objOcr.val());
        objOcrTeacher.attr("data-para-json", JSON.stringify(para));

        var selItem = JSON.parse(objOcr.data("selected-item"));
        objOcrTeacher.empty().append('<option selected="selected" value="' + selItem.Class_Teacher_Id + '">' + selItem.Class_Teacher + '</option>');
    });
});