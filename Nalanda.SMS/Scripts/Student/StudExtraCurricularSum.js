$.ajaxSetup({ cache: false });

$(function () {
    var objClass = $('#ClassID');
    var objStudent = $('#StudentID');

    objClass.change(function () {
        var para = objStudent.data("para-json");
        para.promoteClassID = Number(objClass.val());
        objStudent.attr("data-para-json", JSON.stringify(para));
        objStudent.empty().append('<option selected="selected" value="">' + objStudent.data("empty-text") + '</option>');
    });

    $("form").submit(function (e) {
        var frm = $(this);

        $.ajax({
            type: "POST",
            url: frm[0].action,
            data: frm.serialize(),
            success: function (data, textStatus, jqXHR) {
                var ct = jqXHR.getResponseHeader("content-type") || "";
                if (ct.indexOf('ms-excel') > -1)
                {
                    objProg.hide();
                    var win = window.open(frm[0].action + '?' + frm.serialize(), '_blank');
                    if (win) {
                        win.focus();
                    }
                }
                else if (ct.indexOf('json') > -1) {
                    objProg.hide();
                    var win = window.open(frm[0].action + '?' + $.param(data), '_blank');
                    if (win) {
                        win.focus();
                    }
                }
                else {
                    var w = document.open("text/html", "replace");
                    w.write(data);
                    w.close();
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                AlertIt(textStatus);
            }
        });

        e.preventDefault();
    });
});