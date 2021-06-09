$.ajaxSetup({ cache: false });

$(function () {
    objFullName = $('#FullName');
    objStatus = $('#Status');
    objInactiveReason = $('#InactiveReason');

    objFullName.change(function () {
        var initials = "";
        var x = objFullName.val().split(' ');
        var a = x.length;
        $('#LastName').val(x[a - 1].toString());

        for (var i = 0; i < a - 1; i++) { initials += x[i].charAt(0).toUpperCase() + " "; }

        $('#Initials').val(initials);
    });

    if (objStatus.val() == 0) {
        objInactiveReason.val("");
        SetComboReadonly(objInactiveReason, true);
    }
    else {
        SetComboReadonly(objInactiveReason, false);
    }

    objStatus.change(function () {
        if (objStatus.val() == 0) {
            objInactiveReason.val("");
            SetComboReadonly(objInactiveReason, true);
        }
        else {
            SetComboReadonly(objInactiveReason, false);
        }
    });

});