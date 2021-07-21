$.ajaxSetup({ cache: false });

$(function () {
    $('#btnSearch').click(function (e) {
        e.preventDefault();
        ReloadData();
    });
    $('#btnSave').click(function (e) {
        SaveMarks();
    });
    SetGridBindings();
});

function ReloadData() {
    var data = $("#ttIndex").find("select, textarea, input").serialize();
    $.get(AppRoot + "Student/StudentMark/StudentMarksIndex?" + data)
        .done(function (result) {
            var divGrid = $('#ChildContent');
            divGrid.html(result);
            SetGridBindings(divGrid);
        })
        .fail(function () {
            alert("Error!");
        });
}

function SetGridBindings(divGrid) {
    var btnSave = $('#btnSave');
    if ($('table > tbody > tr', divGrid).length)
        btnSave.show();
    else
        btnSave.hide();

    $('input.marks', divGrid).keydown(function (e) {
        switch (e.which) {
            case 38: // up
            case 40: // down
                break;
            default: return;
        }
        e.preventDefault();
    });

    $('input.marks', divGrid).keyup(function () {
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
    setTimeout(() => SaveMarks(), 1000);
}

function SaveMarks() {
    var btnSave = $('#btnSave');
    $('i', btnSave).show();

    showProgress = false;
    var data = [];

    $('input.marksChanged').each(function () {
        var $inp = $(this);
        var obj = { studentId: $inp.data("stud-id"), marks: $inp.val() };
        data.push(obj);
    });

    var masterData = $("#ttIndex").find("select, textarea, input").serialize();
    var act = AppRoot + "Student/StudentMark/StudentMarkUpdate?" + masterData + "&jsonData=" + JSON.stringify(data);

    $.post(act)
        .done(function () {
            $('input.marksChanged').each(function () {
                var $inp = $(this);
                var arr = data.filter(function (e) { return e.studentId == $inp.data("stud-id"); });
                if (arr.length > 0) {
                    if ($inp.val() == arr[0].marks) {
                        $inp.data("db-val", arr[0].marks)
                        $inp.removeClass("marksChanged");
                    }
                }
            });
            btnSave.prop('disabled', $('input.marksChanged').length == 0);
        })
        .always(function () {
            $('i', btnSave).hide();
            showProgress = true;
        });
}