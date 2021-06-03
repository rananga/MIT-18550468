$.ajaxSetup({ cache: false });

$(function () {
    objMembershipType = $('#MembershipType');
    objCommiteeMemberType = $('#CommiteeMemberType');

    if (objMembershipType.val() == 1) {
        objCommiteeMemberType.prop("disabled", false);
    }
    else {
        objCommiteeMemberType.prop("disabled", true);
    }

    objMembershipType.change(function () {
        if (objMembershipType.val() == 1) {
            objCommiteeMemberType.prop("disabled", false);
        }
        else {
            objCommiteeMemberType.prop("disabled", true);
        }
    });
});