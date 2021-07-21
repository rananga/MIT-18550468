$.ajaxSetup({ cache: false });

$(function () {
    var objGradeId = $('#GradeId');
    var objName = $('#Name');
    var objCode = $('#Code');

    objGradeId.add(objName).change(function () {
        objCode.val(objGradeId.val() + '.' + $("#Name option:selected").text());
    });

    objGradeId.change(function () {
        var objAddSubject = $('#btnAddSubject');
        //objGradeId.prop("readonly", $('#tblSubjects tbody tr').length);
        $('#GradeId option:not(:selected)').prop('disabled', $('#tblSubjects tbody tr').length);

        if (objGradeId.val()) {
            var dat = $("#GradeId option:selected").data("info");

            var url = new URL(objAddSubject[0].href);
            var search_params = url.searchParams;
            search_params.set('sectionId', dat.SectionId);
            url.search = search_params.toString();

            objAddSubject[0].href = url.toString();
            objAddSubject.show();
        }
        else {
            objAddSubject.hide();
        }
    });
    objGradeId.trigger('change');

});