$.ajaxSetup({ cache: false });

$(function () {
    var objGradeId = $('#GradeId');
    var objName = $('#Name');
    var objCode = $('#Code');

    objGradeId.add(objName).change(function () {
        objCode.val(objGradeId.val() + '.' + $("#Name option:selected").text());
    });

});