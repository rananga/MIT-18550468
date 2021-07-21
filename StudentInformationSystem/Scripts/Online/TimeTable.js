$.ajaxSetup({ cache: false });

$(function () {

    $('#btnSearch').click(function () {
        ReloadTimeTable();
    });

    var $objMain = $('#rep_Main');
    var $rep_type = $('#rep_type', $objMain);
    var $rep_WeekMain = $('#rep_WeekMain', $objMain);
    var $rep_WeekDots = $('#rep_WeekDots', $objMain);
    var $rep_endDate = $('#rep_endDate', $objMain);
    var $rep_endOccurCount = $('#rep_endOccurCount', $objMain);

    $('div.dot', $rep_WeekDots).click(function () {
        $dotObj = $(this);
        if ($dotObj.attr('data-checked')) {
            $dotObj.removeAttr("data-checked");
        }
        else {
            $dotObj.attr('data-checked', 'true');
        }
    });

    $rep_type.change(function () {
        if ($rep_type.val() == 'w') {
            $rep_WeekMain.show();
        }
        else {
            $rep_WeekMain.hide();
        }
    });

    $('input[name=rep_endType]').change(function () {
        $objEndRadio = $(this);
        if ($objEndRadio.val() == "Never") {
            $rep_endDate.prop('disabled', true);
            $rep_endOccurCount.prop('disabled', true);
        }
        else if ($objEndRadio.val() == "On") {
            $rep_endDate.prop('disabled', false);
            $rep_endOccurCount.prop('disabled', true);
        }
        else {
            $rep_endDate.prop('disabled', true);
            $rep_endOccurCount.prop('disabled', false);
        }
    });

    $rep_type.trigger('change');
    $('#rep_endTypeNever', $objMain).prop('checked', true).trigger('change');
});

function ReloadTimeTable() {
    var data = $("#ttIndex").find("select, textarea, input").serialize()
    $.get(window.location.href + "?" + data)
        .done(function (result) {
            $('body').html(result);
        })
        .fail(function () {
            alert("Error!");
        });
}

function CustomPopupBinder(dlg) {
    btn = $('#btnSetRepeat', dlg);
    objVal = $('#RepeatPattern', dlg);
    $('#rep_endDate').val((new Date()).yyyymmdd('-'));
    var objDisplay = btn.find('#repeatText');
    var jsn = objVal.val();
    if (jsn) {
        var data = JSON.parse(objVal.val());
        objDisplay.text(GetRepeatText(data));
    }
    else {
        objDisplay.text("Does not repeat");
    }

    btn.click(function () {
        ShowRepeatDialog(objVal, objDisplay);
    });
    SetPopupBindings(dlg);
}

function SetPopupBindings(dlg) {
    var objOcr = $('#OCR_Id', dlg);
    var objOcrTeacher = $('#OCR_TeacherId', dlg);

    objOcr.change(function () {
        var para = objOcrTeacher.data("para-json");
        para.OCR_ID = Number(objOcr.val());
        objOcrTeacher.attr("data-para-json", JSON.stringify(para));

        var selItem = JSON.parse(objOcr.data("selected-item"));
        objOcrTeacher.empty().append('<option selected="selected" value="' + selItem.Class_Teacher_Id + '">' + selItem.Class_Teacher + '</option>');
    });
}

function ShowRepeatDialog(objValue, objDisplay) {
    var $rep_Main = $('#rep_Main');
    var $rep_count = $('#rep_count', $rep_Main);
    var $rep_type = $('#rep_type', $rep_Main);
    var $rep_WeekDotSun = $('#rep_WeekDotSun', $rep_Main);
    var $rep_WeekDotMon = $('#rep_WeekDotMon', $rep_Main);
    var $rep_WeekDotTue = $('#rep_WeekDotTue', $rep_Main);
    var $rep_WeekDotWed = $('#rep_WeekDotWed', $rep_Main);
    var $rep_WeekDotThu = $('#rep_WeekDotThu', $rep_Main);
    var $rep_WeekDotFri = $('#rep_WeekDotFri', $rep_Main);
    var $rep_WeekDotSat = $('#rep_WeekDotSat', $rep_Main);
    var $rep_endTypeNever = $('#rep_endTypeNever', $rep_Main);
    var $rep_endTypeOn = $('#rep_endTypeOn', $rep_Main);
    var $rep_endTypeAfter = $('#rep_endTypeAfter', $rep_Main);
    var $rep_endDate = $('#rep_endDate', $rep_Main);
    var $rep_endOccurCount = $('#rep_endOccurCount', $rep_Main);
    var data;

    try {
        data = JSON.parse(objValue.val());
    } catch (e) {
        data = {
            repeatOccurence: 1,
            repeatType: "daily",
            weekDays: {
                sun: true,
                mon: true,
                tue: true,
                wed: true,
                thu: true,
                fri: true,
                sat: true
            },
            end: {
                type: "Never",
                endDate: (new Date((new Date()).setDate((new Date()).getDate() + 30))).yyyymmdd('-'),
                endAfter: 2
            }
        };
    }

    $rep_count.val(data.repeatOccurence);
    if (data.repeatType == 'daily')
        $rep_type.val('d');
    else
        $rep_type.val('w');

    if (data.weekDays.sun) $rep_WeekDotSun.attr('data-checked', 'true'); else $rep_WeekDotSun.removeAttr("data-checked");
    if (data.weekDays.mon) $rep_WeekDotMon.attr('data-checked', 'true'); else $rep_WeekDotMon.removeAttr("data-checked");
    if (data.weekDays.tue) $rep_WeekDotTue.attr('data-checked', 'true'); else $rep_WeekDotTue.removeAttr("data-checked");
    if (data.weekDays.wed) $rep_WeekDotWed.attr('data-checked', 'true'); else $rep_WeekDotWed.removeAttr("data-checked");
    if (data.weekDays.thu) $rep_WeekDotThu.attr('data-checked', 'true'); else $rep_WeekDotThu.removeAttr("data-checked");
    if (data.weekDays.fri) $rep_WeekDotFri.attr('data-checked', 'true'); else $rep_WeekDotFri.removeAttr("data-checked");
    if (data.weekDays.sat) $rep_WeekDotSat.attr('data-checked', 'true'); else $rep_WeekDotSat.removeAttr("data-checked");

    $rep_endDate.val(data.end.endDate);
    $rep_endOccurCount.val(data.end.endAfter);

    if (data.end.type == "Never")
        $rep_endTypeNever.prop('checked', true);
    if (data.end.type == "On")
        $rep_endTypeOn.prop('checked', true);
    if (data.end.type == "After")
        $rep_endTypeAfter.prop('checked', true);

    var dlg = $rep_Main;

    function winResFunc() { dlgOnResize(dlg, 300); }

    dlg.dialog({
        height: "auto",
        show: "clip",
        modal: true,
        autoOpen: false,
        open: function (event, ui) {
            var dlgParent = dlg.closest('.ui-dialog');
            var closeBtn = $('.ui-dialog-titlebar-close', dlgParent);
            closeBtn.html('<span><i class="fas fa-times"></i></span>');
            dlg_z_index++;
            dlgParent.css("z-index", dlg_z_index.toString());
            dlg.dialog("option", "position", { my: "center", at: "center", of: window });

            $("body").css({
                overflow: 'hidden'
            });
            $(".ui-dialog", dlg.parent().parent()).find(".ui-widget-header").css("background", "#e9e9e9");
            $(".ui-dialog", dlg.parent().parent()).find(".ui-widget-header").css("color", "#333333");

            dlgOnResize(dlg, 300);
            window.addEventListener("resize", winResFunc);
        },
        beforeClose: function (event, ui) {
            $("body").css({ overflow: 'inherit' })
            window.removeEventListener("resize", winResFunc);
        }
    });

    $('input[type="button"][value="Ok"]', dlg).click(function () {

        data = {
            repeatOccurence: $rep_count.val(),
            repeatType: $rep_type.val() == 'd' ? "daily" : "weekly",
            weekDays: {
                sun: $rep_WeekDotSun.attr('data-checked'),
                mon: $rep_WeekDotMon.attr('data-checked'),
                tue: $rep_WeekDotTue.attr('data-checked'),
                wed: $rep_WeekDotWed.attr('data-checked'),
                thu: $rep_WeekDotThu.attr('data-checked'),
                fri: $rep_WeekDotFri.attr('data-checked'),
                sat: $rep_WeekDotSat.attr('data-checked')
            },
            end: {
                type: $rep_endTypeNever.is(':checked') ? "Never" : $rep_endTypeOn.is(':checked') ? "On" : "After",
                endDate: $rep_endDate.val(),
                endAfter: $rep_endOccurCount.val()
            }
        };

        var str = GetRepeatText(data);
        objDisplay.text(str);
        objValue.val(JSON.stringify(data));

        closeDialogModal(dlg);
    });

    $('input[type="button"][value="Cancel"]', dlg).click(function () { closeDialogModal(dlg); });

    $('input[type="button"][value="Clear"]', dlg).click(function () {
        objDisplay.val("Does not repeat");
        objValue.val("");
        closeDialogModal(dlg);
    });

    if (objProg.length > 0) { objProg.hide(); }

    dlg.dialog("option", "title", "Configure Recurrence");
    dlgOnResize(dlg, 300);
    dlg.dialog("open");
}

function GetRepeatText(data) {
    var str = "Once";
    if (data.end.type != "After" || data.end.endAfter != "1") {
        str = data.repeatOccurence > 1 ? "Every " + data.repeatOccurence + " " + (data.repeatType == "daily" ? "days" : "weeks") : data.repeatType == "daily" ? "Daily" : "Weekly";

        if (data.repeatType == "weekly") {
            if (data.weekDays.sun && data.weekDays.mon && data.weekDays.tue && data.weekDays.wed && data.weekDays.thu && data.weekDays.fri && data.weekDays.sat)
                str += " on all days";
            else {
                var weekDays = [];
                if (data.weekDays.sun) weekDays.push("Sunday");
                if (data.weekDays.mon) weekDays.push("Monday");
                if (data.weekDays.tue) weekDays.push("Tuesday");
                if (data.weekDays.wed) weekDays.push("Wednesday");
                if (data.weekDays.thu) weekDays.push("Thursday");
                if (data.weekDays.fri) weekDays.push("Friday");
                if (data.weekDays.sat) weekDays.push("Saturday");
                str += " on " + weekDays.join(', ');
            }
        }
        if (data.end.type == "On")
            str += ", until " + data.end.endDate;
        else if (data.end.type == "After")
            str += ", " + data.end.endAfter + " times ";
    }
    return str;
}