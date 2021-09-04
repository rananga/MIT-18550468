$.ajaxSetup({ cache: false });

$(function () {
    $('#btnSave').click(function (e) {
        SaveChanges();
    });
    SetGridBindings();
});

function SetGridBindings() {
    var btnSave = $('#btnSave');
    if ($('table > tbody > tr').length)
        btnSave.show();
    else
        btnSave.hide();

    $('select.newClass').change(function () {
        var $inp = $(this);
        if ($inp.data("db-val") != $inp.val()) {
            $inp.addClass("marksChanged")
            btnSave.prop('disabled', false);
            triggerSave();
        }
        else {
            $inp.removeClass("marksChanged")
        }
    });
}

function triggerSave() {
    setTimeout(() => SaveChanges(), 1000);
}

function SaveChanges() {
    var btnSave = $('#btnSave');
    $('i', btnSave).show();

    showProgress = false;
    var data = [];

    $('select.marksChanged').each(function () {
        var $inp = $(this);
        var obj = { studentId: $inp.data("stud-id"), toClassId: $inp.val() };
        data.push(obj);
    });

    var masterData = $("#ttIndex").find("select, textarea, input").serialize();
    var act = AppRoot + "Student/ClassPromotion/StudentClassUpdate?" + masterData + "&jsonData=" + JSON.stringify(data);

    $.post(act)
        .done(function () {
            $('select.marksChanged').each(function () {
                var $inp = $(this);
                var arr = data.filter(function (e) { return e.studentId == $inp.data("stud-id"); });
                if (arr.length > 0) {
                    if ($inp.val() == arr[0].toClassId) {
                        $inp.data("db-val", arr[0].toClassId)
                        $inp.removeClass("marksChanged");
                    }
                }
            });
            btnSave.prop('disabled', $('select.marksChanged').length == 0);
        })
        .always(function () {
            $('i', btnSave).hide();
            showProgress = true;
        });
}