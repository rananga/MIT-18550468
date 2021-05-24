$.ajaxSetup({ cache: false });

function EnrollmentQualificationDocReadyFunc() {
    DocReadyFunc();

    $("a[data-popup-editor]").each(function () {
        var $this = $(this);
        var dlg = GetDialogObj($this);

        function winResFunc() { dlgOnResize(dlg, $this.data("popup-width")); }

        dlg.dialog({
            height: "auto",
            show: "clip",
            modal: true,
            autoOpen: false,
            open: function (event, ui) {
                var closeBtn = $('.ui-dialog-titlebar-close');
                closeBtn.html('<span class="ui-button-icon-primary ui-icon ui-icon-closethick"></span>');
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
                            $this.parents('.ChildContent').load(result.url, function (response, status, xhr) {
                                if (status == "error") {
                                    AlertIt("ERROR: " + xhr.status + "-" + xhr.statusText);
                                }
                                else { EnrollmentQualificationDocReadyFunc(); }
                            });
                            EnrollmentQualificationDocReadyFunc();
                            //SetHeaderValues(result.hdrData);
                        } else {
                            dlg.html(result);
                            EnrollmentQualificationDocReadyFunc();
                            bindDlgEvents();
                        }
                    }
                });
                return false;
            });

            $('input[type="button"][value="Cancel"]', dlg).click(function () {
                closeDialogModal(dlg);
            });

            var objSublingStudID = $('#SublingStudID', dlg);
            var objIndexNo = $('#IndexNo', dlg);
            var objTitle = $('#Title', dlg);
            var objStudWithInit = $('#StudWithInit', dlg);
            var objFullName = $('#FullName', dlg);

            objSublingStudID.change(function () {
                $.getJSON(AppRoot + "Student/Student/GetFeeInfo", { studID: Number(objSublingStudID.val()) }, function (jsn) {
                    objIndexNo.val(jsn.IndexNo);
                    objTitle.val(jsn.Title);
                    objStudWithInit.val(jsn.InitName);
                    objFullName.val(jsn.Fullname);
                }).error(function (data, status, jqXHR) {
                    if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
                    else { AlertIt("ERROR: " + data.statusText); }
                });
            });
        }

        $this.off(".ChildPopUp");
        $this.on("click.ChildPopUp", function (e) {
            e.preventDefault();
            dlg.load(this.href, function (response, status, xhr) {
                if (status == "error") {
                    AlertIt(xhr.status == 500 ? xhr.statusText : "ERROR: " + xhr.status + "-" + xhr.statusText);
                }
                else {
                    EnrollmentQualificationDocReadyFunc();
                    bindDlgEvents();

                    dlg.dialog("option", "title", $this.data("title"));
                    dlgOnResize(dlg, $this.data("popup-width"));
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
                        $this.parents('.ChildContent').load(result.url, function (response, status, xhr) {
                            if (status == "error") {
                                AlertIt("ERROR: " + xhr.status + "-" + xhr.statusText);
                            }
                            else { EnrollmentQualificationDocReadyFunc(); }
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
            return false;
        });
    });
}

$(function () {
    EnrollmentQualificationDocReadyFunc();

    var objFullName = $('#FullName');
    var objProfPic = $('#ProfilePic');
    var objStatus = $('#Status');
    var objInactiveReason = $('#InactiveReason');
    $('#IsLeavingIssued').prop("disabled", true)
    objInactiveReason.prop("disabled", true);

    if (objStatus.val() == 1)
        objInactiveReason.prop("disabled", false);
    objStatus.change(function () {
      
        if (objStatus.val() == 1)
            objInactiveReason.prop("disabled", false);
        else {
            objInactiveReason.val("");
            objInactiveReason.prop("disabled", true);
        }
            
    });


    objFullName.change(function () {
        var initials = "";
        var x = objFullName.val().split(' ');
        var a = x.length;
        $('#LName').val(x[a - 1].toString());

        for (var i = 0; i < a - 1; i++) {
            initials += x[i].charAt(0).toUpperCase() + " ";
        }

        $('#Initials').val(initials);
    });


    objProfPic.change(function () {
        var $el = $(this);

        if (this.files.length == 0) { return; }

        if (this.files[0].size > 4194304) {
            this.value = '';
            this.type = '';
            this.type = 'file';
            AlertIt("Image size is too large. Maximum size allowed is 4MB");
            return;
        }

        var frm = $el.closest("form");
        var act = frm.attr("action");
        var arr = act.substring(act.indexOf("/Student/Student")).split('/');
        var curAct = arr[3];

        $('<input />').attr('type', 'hidden')
            .attr('name', "FromAction")
            .attr('value', curAct)
            .appendTo(frm);

        frm.attr('action', AppRoot + "Student/Student/UploadPic");
        frm.validate().cancelSubmit = true;
        frm.validate().settings.ignore = "*";
        frm.submit();
    });

    //SetWebCamAccess();
});

function SetWebCamAccess() {
    var objMyCam = $('#my_camera');
    var objBtnCam = $('#btnCam');
    var objBtnCancel = $('#btnCancel');
    var objPic = $('#imgPic');

    objPic.data("org-src", objPic.attr("src"));

    Webcam.set({
        width: 240,
        height: 180,
        dest_width: 640,
        dest_height: 480,
        image_format: 'jpeg',
        jpeg_quality: 90,
        force_flash: false,
        flip_horiz: true,
        fps: 45
    });

    objBtnCam.click(function () {
        if (objBtnCam.data("mode") == "R") {
            objPic.hide();
            objMyCam.show();
            Webcam.attach('#my_camera');
            objBtnCancel.show();
            objBtnCam.val("CAPTURE");
            objBtnCam.data("mode", "C");
        }
        else {
            Webcam.snap(function (data_uri) {
                $.ajax({
                    url: AppRoot + "Student/Student/UploadPicStr",
                    type: "POST",
                    data: { imgString: data_uri },
                    success: function (result) {
                        objPic.attr("src", objPic.data("org-src") + "?timestamp=" + new Date().getTime());
                        objPic.show();
                    },
                    error: function (data, status, jqXHR) {
                        if (IsJson(data.responseText)) { AlertIt("ERROR: " + JSON.parse(data.responseText).Message); }
                        else { AlertIt("ERROR: " + data.statusText); }
                    }
                });
                objProg.hide();
                Webcam.reset();
                objMyCam.hide();
            });
            objBtnCancel.hide();
            objBtnCam.val("RETAKE");
            objBtnCam.data("mode", "R");
        }
    });

    objBtnCancel.click(function () {
        objMyCam.hide();
        objBtnCancel.hide();
        objPic.show();
        objBtnCam.data("mode", "R");
    });
}