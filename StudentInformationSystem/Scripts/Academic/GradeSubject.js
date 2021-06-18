$.ajaxSetup({ cache: false });

$(function () {
    var objGradeId = $('#GradeId');
    var objSubject = $('#SubjectId');

    objGradeId.change(function () {
        if (objGradeId.val()) {
            objSubject.prop("disabled", false);
            var dat = $("#GradeId option:selected").data("info");

            var obj = { sectionId: dat.SectionId };
            objSubject.data("para-json", obj);
        }
        else {
            objSubject.prop("disabled", true);
        }
    });
    objGradeId.trigger('change');
});