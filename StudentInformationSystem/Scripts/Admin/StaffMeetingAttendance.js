$.ajaxSetup({ cache: false });
var objTable = $("#Attendance");
var objAttendCount = $("#attendCount");
var objAbCount = $("#AbCount");
var objExcuseCount = $("#ExcuseCount");

$(function () {

    StaffMeetingMinsDocReadyFunc();

    objTable.find('tbody tr td#IsPresent input[type="checkbox"]').click(function () {
        var cb = $(this);

        if (cb.parent().parent().find('td#IsAbsent input[type="checkbox"]').is(':checked')) { objAbCount.val(Number(objAbCount.val()) - 1); }

        if (cb.parent().parent().find('td#IsExcuse input[type="checkbox"]').is(':checked')) { objExcuseCount.val(Number(objExcuseCount.val()) - 1); }

        if (cb.parent().parent().find('td#IsPresent input[type="checkbox"]').is(':checked'))
            objAttendCount.val(Number(objAttendCount.val()) + 1);
        else
            objAttendCount.val(Number(objAttendCount.val()) - 1);

        cb.parent().parent().find('td#IsAbsent input[type="checkbox"]').prop('checked', false);
        cb.parent().parent().find('td#IsExcuse input[type="checkbox"]').prop('checked', false);
        cb.parent().parent().find('td#NotInformed input[type="checkbox"]').prop('checked', false);

       

    });

    objTable.find('tbody tr td#IsAbsent input[type="checkbox"]').click(function () {
        var cb = $(this);

        if (cb.parent().parent().find('td#IsPresent input[type="checkbox"]').is(':checked')) { objAttendCount.val(Number(objAttendCount.val()) - 1); }

        if (cb.parent().parent().find('td#IsExcuse input[type="checkbox"]').is(':checked')) { objExcuseCount.val(Number(objExcuseCount.val()) - 1); }
        
        if (cb.parent().parent().find('td#IsAbsent input[type="checkbox"]').is(':checked'))
            objAbCount.val(Number(objAbCount.val()) + 1);
        else
            objAbCount.val(Number(objAbCount.val()) - 1);

        cb.parent().parent().find('td#IsPresent input[type="checkbox"]').prop('checked', false);
        cb.parent().parent().find('td#IsExcuse input[type="checkbox"]').prop('checked', false);
        cb.parent().parent().find('td#NotInformed input[type="checkbox"]').prop('checked', false);

      
    });

    objTable.find('tbody tr td#IsExcuse input[type="checkbox"]').click(function () {
        var cb = $(this);

        if (cb.parent().parent().find('td#IsPresent input[type="checkbox"]').is(':checked')) { objAttendCount.val(Number(objAttendCount.val()) - 1); }

        if (cb.parent().parent().find('td#IsAbsent input[type="checkbox"]').is(':checked')) { objAbCount.val(Number(objAbCount.val()) - 1); }

        if (cb.parent().parent().find('td#IsExcuse input[type="checkbox"]').is(':checked'))
            objExcuseCount.val(Number(objExcuseCount.val()) + 1);
        else
            objExcuseCount.val(Number(objExcuseCount.val()) - 1);

        cb.parent().parent().find('td#IsAbsent input[type="checkbox"]').prop('checked', false);
        cb.parent().parent().find('td#IsPresent input[type="checkbox"]').prop('checked', false);
        cb.parent().parent().find('td#NotInformed input[type="checkbox"]').prop('checked', false);

       
    });

    objTable.find('tbody tr td#NotInformed input[type="checkbox"]').click(function () {
        var cb = $(this);

        if (cb.parent().parent().find('td#IsPresent input[type="checkbox"]').is(':checked')) { objAttendCount.val(Number(objAttendCount.val()) - 1); }

        if (cb.parent().parent().find('td#IsAbsent input[type="checkbox"]').is(':checked')) { objAbCount.val(Number(objAbCount.val()) - 1); }

        if (cb.parent().parent().find('td#IsExcuse input[type="checkbox"]').is(':checked')) { objAbCount.val(Number(objAbCount.val()) - 1); }

        //if (cb.parent().parent().find('td#IsExcuse input[type="checkbox"]').is(':checked'))
        //    objExcuseCount.val(Number(objExcuseCount.val()) + 1);
        //else
        //    objExcuseCount.val(Number(objExcuseCount.val()) - 1);

        cb.parent().parent().find('td#IsAbsent input[type="checkbox"]').prop('checked', false);
        cb.parent().parent().find('td#IsPresent input[type="checkbox"]').prop('checked', false);
        cb.parent().parent().find('td#IsExcuse input[type="checkbox"]').prop('checked', false);


    });
   
});
function SaveData() {

    var objAttendanceDataJson = $("#AttendanceDataJson");
    var objTable = $('#Attendance');
    var arrJsn = [];
    var i = 1;
  
    objTable.find('tbody tr').each(function () {
        var objJsn = new Object();

        objJsn.id = i++;
        objJsn.TeacherID = $(this).find('td#TeacherID input[type="hidden"]').val();
        objJsn.AttnID = $(this).data('pid');
        if ($(this).find('td#IsPresent input[type="checkbox"]').is(':checked')) { objJsn.isPresent = true;}
        else { objJsn.isPresent = false; }
        if ($(this).find('td#IsAbsent input[type="checkbox"]').is(':checked')) { objJsn.IsAbsent = true; }
        else { objJsn.IsAbsent = false; }
        if ($(this).find('td#IsExcuse input[type="checkbox"]').is(':checked')) { objJsn.IsExcuse = true; }
        else { objJsn.IsExcuse = false; }
        if ($(this).find('td#NotInformed input[type="checkbox"]').is(':checked')) { objJsn.IsNotInformed = true; }
        else { objJsn.IsNotInformed = false; }
        objJsn.Description = $(this).find('td#Description input').val();
            
        arrJsn.push(objJsn);
    });
    objAttendanceDataJson.val(JSON.stringify(arrJsn));

}

function StaffMeetingMinsDocReadyFunc() {
    DocReadyFunc();

    $("a[data-popup-editor]").each(function () {
        var $this = $(this);
        var dlg = GetDialogObj($this);
        
        function winResFunc() { dlgOnResize(dlg, 500); }

        dlg.dialog({
            height: "auto",
            show: "clip",
            modal: true,
            autoOpen: false,
            open: function (event, ui) {
                var closeBtn = $('.ui-dialog-titlebar-close');
                closeBtn.html('<span><i class="fas fa-times"></i></span>');
                dlg_z_index++;
                $(".ui-dialog").css("z-index", dlg_z_index.toString());
                dlg.dialog("option", "position", { my: "center", at: "center", of: window });

                $("body").css({
                    overflow: 'hidden'
                });

                $(".ui-widget-overlay").bind('click', function () { dlg.dialog("close"); });

                winResFunc();
                window.addEventListener("resize", winResFunc);
            },
            beforeClose: function (event, ui) {
                $("body").css({ overflow: 'inherit' });
                window.removeEventListener("resize", winResFunc);
            }
        });

        function bindDlgEvents() {
            $('input[type="submit"][value="Save"]', dlg).closest("form").submit(function () {
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (result) {
                        if (result.success) {
                            closeDialogModal(dlg);
                            $('#ChildContent').load(result.url, function (response, status, xhr) {
                                if (status == "error") {
                                    AlertIt("ERROR: " + xhr.status + "-" + xhr.statusText);
                                }
                                else { StaffMeetingMinsDocReadyFunc(); }
                            });
                            StaffMeetingMinsDocReadyFunc();
                            //SetHeaderValues(result.hdrData);
                        } else {
                            dlg.html(result);
                            StaffMeetingMinsDocReadyFunc();
                            bindDlgEvents();
                        }
                    }
                });
                return false;
            });

            $('input[type="button"][value="Cancel"]', dlg).click(function () {
                closeDialogModal(dlg);
            });
        }


        $this.off(".ChildPopUp");
        $this.on("click.ChildPopUp", function (e) {
            e.preventDefault();
            dlg.load(this.href, function (response, status, xhr) {
                if (status == "error") {
                    AlertIt("ERROR: " + xhr.status + "-" + xhr.statusText);
                }
                else {
                    StaffMeetingMinsDocReadyFunc();
                    bindDlgEvents();

                    dlg.dialog("option", "title", $this.data("title"));
                    dlgOnResize(dlg);
                    dlg.dialog("open");
                }
            });
        });
    });

    $("button[data-popup-delete]").each(function () {
        var $this = $(this);
        var dlg = GetDialogObj($this);

        $this.closest("form").off(".ChildPopUp");
        $this.closest("form").on("submit.ChildPopUp", function () {
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    closeDialogModal(dlg);
                    if (result.url) {
                        $('#ChildContent').load(result.url, function (response, status, xhr) {
                            if (status == "error") {
                                AlertIt("ERROR: " + xhr.status + "-" + xhr.statusText);
                            }
                            else { StaffMeetingMinsDocReadyFunc(); }
                        });
                       
                    }
                    else { AlertIt("ERROR: " + result.msg); }
                },
                error: function (data, status, jqXHR) {
                    if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
                    else { AlertIt("ERROR: " + data.statusText); }
                }
            });
            return false;
        });
    });
}