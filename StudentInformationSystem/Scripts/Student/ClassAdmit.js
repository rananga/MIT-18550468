$.ajaxSetup({ cache: false });

$(function () {

    $('#btnSearch').click(function () {
        var $frm = $(this).closest('form');
        $.get($frm.attr("action") + "?" + $frm.serialize())
            .done(function (result) {
                var divGrid = $('#ChildContent');
                divGrid.html(result);
                bindGridEvents(divGrid);
            })
            .fail(function () {
                alert("Error!");
            });
    });

    $('#btnAdmitAll').click(function (e) {
        e.preventDefault();
        var $btnAdmit = $(this);
        ConfirmIt("Are you sure you want to admit all these students?",
            "Confirm Admit All", "Yes", "No", false,
            function () {
                var divGrid = $('#ChildContent');
                var info = [];

                $('a[name=btnAdmit]', divGrid).each(function (e) {
                    
                    var $this = $(this);
                    var tr = $this.closest('tr');
                    var studentId = $this.data("stud-id");
                    var CR_Id = tr.find('select').val();

                    info.push({ CR_Id: CR_Id, studentId: studentId });
                });

                var act = $btnAdmit.attr("href");

                $.post(act, { info: JSON.stringify(info) })
                    .done(function () {
                        $('#btnSearch').trigger('click');
                    })
                    .fail(function () {
                        alert("Error!");
                    });
            });
    });
});

function bindGridEvents(divGrid) {
    var btnAdmitAll = $('#btnAdmitAll');
    if ($('table > tbody > tr', divGrid).length)
        btnAdmitAll.show();
    else
        btnAdmitAll.hide();

    $('a[name=btnAdmit]', divGrid).click(function (e) {
        e.preventDefault();
        var $this = $(this);
        var tr = $this.closest('tr');
        var studentId = $this.data("stud-id");
        var CR_Id = tr.find('select').val();

        var act = $this.attr("href") + "?studentId=" + studentId + "&CR_Id=" + CR_Id;

        $.post(act)
            .done(function () {
                $('#btnSearch').trigger('click');
            })
            .fail(function () {
                alert("Error!");
            });
    });
}