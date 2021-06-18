$.ajaxSetup({ cache: false });

$(function () {
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
        $('#LastName').val(x[a - 1].toString());

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
});