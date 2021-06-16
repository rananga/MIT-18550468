$.ajaxSetup({ cache: false });

var classJson;
var objTeacherID = $('#TeacherID');
var objClassID = $("#ClassID");
var objPeriodID = $('#PeriodID');

function PostData() {
    var objClassListJson = $('#ClassListJson');
    var objTable = $('#classStudentTbl');
    var arrJsn = [];
    var i = 1;

    objTable.find('tbody tr').each(function () {
        var objJsn = new Object();
        objJsn.id = $(this).data('pid');

        objJsn.StudentID = $(this).find('td#studID input[type="hidden"]').val();
        objJsn.IsMonitor = $(this).find('td#isMonitor input[type="hidden"]').val();
        objJsn.IsCurrentMonitor = $(this).find('td#isCurMonitor input[type="hidden"]').val();
        objJsn.periodStart = $(this).find('td#perStart input[type="text"]').val();
        objJsn.periodEnd = $(this).find('td#perEnd input[type="text"]').val();
        arrJsn.push(objJsn);
    });
    $("#NoOfStud").val(arrJsn.length);
    objClassListJson.val(JSON.stringify(arrJsn));
    $('#ClassListJson').val(JSON.stringify(arrJsn));
    classJson = JSON.stringify(arrJsn);
}

function getPostData() {
    PostData();
}

function ClassStudDocReadyFunc() {
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

                getPostData();
                var objClassListJsonDlg = $('#ClassListJson', dlg);
                objClassListJsonDlg.val(classJson);

                var objTeachIDDlg = $('#TeachID', dlg);
                objTeachIDDlg.val(objTeacherID.val());

                var objPeriodIDDlg = $('#PeriodID', dlg);
                objPeriodIDDlg.val(objPeriodID.val());
                                                
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
                                else
                                {
                                    getPostData();
                                    ClassStudDocReadyFunc();
                                }
                            });
                            ClassStudDocReadyFunc();
                            //SetHeaderValues(result.hdrData);
                        } else {
                            dlg.html(result);
                            ClassStudDocReadyFunc();
                            bindDlgEvents();
                        }
                    }
                });
                return false;
            });

            $('input[type="button"][value="Cancel"]', dlg).click(function () {
                closeDialogModal(dlg);
            });

            var objStudID = $('#StudID', dlg);
            var objIndexNo = $('#IndexNo', dlg);
            var objStudentName = $('#StudentName', dlg);

            objStudID.change(function () {
                $.getJSON(AppRoot + "Student/StudentPromotion/GetStudInfo", { studID: Number(objStudID.val()) }, function (jsn) {
                    objIndexNo.val(jsn.IndexNo);
                    objStudentName.val(jsn.InitName);
                    $('#StudID', dlg).val(objStudID.val());
                }).error(function (data, status, jqXHR) {
                    if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
                    else { AlertIt("ERROR: " + data.statusText); }
                });
            });
        }

        $this.off(".ChildPopUp");
        $this.on("click.ChildPopUp", function (e) {
            e.preventDefault();

            if ($this.attr("title") == "Add") {
                if (!objClassID.val()) {
                    AlertIt("Please select a Class to add students.");
                    return;
                }
            }

            dlg.load(this.href, function (response, status, xhr) {
                if (status == "error") {
                    AlertIt("ERROR: " + xhr.status + "-" + xhr.statusText);
                }
                else {
                    ClassStudDocReadyFunc();
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
                            else { ClassStudDocReadyFunc(); }
                        });
                        //SetHeaderValues(result.hdrData);
                    }
                    else { AlertIt("ERROR: " + result.msg); }
                },
                error: function (data, status, jqXHR) {
                    if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
                    else { AlertIt("ERROR: " + data.statusText); }
                }
            });
            objProg.hide();
            return false;
        });
    });
}

$(function () {
    ClassStudDocReadyFunc();

    var objTable = $('#classStudentTbl');    
    var objPeriodID = $("#PeriodID");

    objPeriodID.change(function () {
        $.getJSON(AppRoot + "Student/StudentPromotion/GetDatePeriod", { datePeriodID: Number(objPeriodID.val()) }, function (jsn) {

            var jsnfDate = new Date(jsn.fDate);
            var jsntDate = new Date(jsn.tDate);
            var fDate = new Date(jsnfDate.getFullYear(), jsnfDate.getMonth() + 1, 1);
            var tDate = new Date(jsntDate.getFullYear(), jsntDate.getMonth() + 1, 1);

            $('#PeriodStartDate').val(fDate.toISOString().slice(0, 10));
            $('#PeriodEndDate').val(tDate.toISOString().slice(0, 10));

        }).error(function (data, status, jqXHR) {
            if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
            else { AlertIt("ERROR: " + data.statusText); }
        });
    });

    objClassID.change(function () {
        var periodID = objPeriodID.val();
        $.get(AppRoot + "Student/StudentPromotion/Create?classID=" + objClassID.val() + "&periodID=" + periodID, null,
            function (data, textStatus, jqXHR) {
                var w = document.open("text/html", "replace");
                w.write(data);
                objPeriodID.trigger('change');
                w.close();
            });

        objPeriodID.trigger('change');    
    });

    

    objTable.find('tbody tr').each(function () {

        var IsMonitor = $(this).find('td#isMonitor input[type="hidden"]').val();
        var IsCurrentMonitor = $(this).find('td#isCurMonitor input[type="hidden"]').val();
        if (IsMonitor == "1" && IsCurrentMonitor == "1") {
            $(this).find('td#perStart input').prop('disabled', false);
            $(this).find('td#perEnd input').prop('disabled', false);
        }
        else {
            $(this).find('td#perStart input').prop('disabled', true);
            $(this).find('td#perEnd input').prop('disabled', true);
        }       
    });

    objTable.find('tbody tr td#isCurMonitor input[type="checkbox"]').click(function () {

        var cb = $(this);
        var studID = $(this).closest('tr').data('pid');
        cb.siblings('input[type="hidden"]').val(cb.prop('checked') ? 1 : 0);
                
        if (cb.prop('checked')) {

            $(this).parent().parent().find('td#isMonitor input[type="checkbox"]').prop("checked", true);
            $(this).parent().parent().find('td#isMonitor input[type="hidden"]').val(1);
            var checkCount = 0;
            $('#classStudentTbl').find('tbody tr td#isCurMonitor input[type="checkbox"]').not($(this)).each(function () {
                var checkVal = $(this).prop('checked');
                if (checkVal == true) { checkCount++; }
            })

            if (checkCount < 2)
            {
                $(this).val(1);
                $(this).prop('checked', true);
                $(this).parent().parent().find('td#perStart input').prop('disabled', false);
                $(this).parent().parent().find('td#perEnd input').prop('disabled', false);

            }
            else
            {
                $(this).removeAttr("checked");
                $(this).parent().parent().find('td#isMonitor input[type="checkbox"]').removeAttr("checked");
                $(this).parent().parent().find('td#isMonitor input[type="hidden"]').val(1);
                $(this).parent().parent().find('td#perStart input').prop('disabled', true);
                $(this).parent().parent().find('td#perEnd input').prop('disabled', true);
            }
        }
        else {
            $(this).removeAttr("checked");
        }

    });

    $('.datepicker').datepicker(
        {
            dateFormat: 'yy-mm-dd',
            changeMonth: true,
            changeYear: true
        });

    function loadGrids() {
        var alg = $('#ChildContent');
        var classID = objClassID.val();
        var periodID = objPeriodID.val();
        alg.empty();
        
        var algUrl = alg.data('url');

        showProgress = false;

        if (algUrl) {
            algUrl += "?id=" + classID + "&isToEdit=" + true + "&periodId=" + periodID;

            alg.load(algUrl, function (response, status, xhr) {
                if (status == "error") {
                    AlertIt("ERROR: " + xhr.status + "-" + xhr.statusText);
                }
            });
        }

        showProgress = true;
    }

    function getCount() {
        var periodID = objPeriodID.val();
        var classID = objClassID.val();
        $.getJSON(AppRoot + "Student/StudentPromotion/GetStudCount", { classID: Number(classID), periodID: Number(periodID) }, function (jsn) {

            var jsnCount = jsn.count;

            $('#NoOfStud').val(jsnCount);

        }).error(function (data, status, jqXHR) {
            if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
            else { AlertIt("ERROR: " + data.statusText); }
        });
    }
    
});