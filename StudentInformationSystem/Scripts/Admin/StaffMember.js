$.ajaxSetup({ cache: false });

$(function () {
    objFullName = $('#FullName');
    objIsTeacher = $('#IsTeacher');
    objDivTeacherCategory = $('#divTeacherCategory');

    objFullName.change(function () {
        var initials = "";
        var x = objFullName.val().split(' ');
        var a = x.length;
        $('#LastName').val(x[a - 1].toString());

        for (var i = 0; i < a - 1; i++) { initials += x[i].charAt(0).toUpperCase() + " "; }

        $('#Initials').val(initials);
    });

    objIsTeacher.change(function (event) {
        var checkbox = event.target;
        if (checkbox.checked) {
            objDivTeacherCategory.show();
        } else {
            objDivTeacherCategory.hide();
        }
    });
    objIsTeacher.trigger("change");
});