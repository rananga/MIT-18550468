$.ajaxSetup({ cache: false });

$(function () {
    objFullName = $('#FullName');

    objFullName.change(function () {
        var initials = "";
        var x = objFullName.val().split(' ');
        var a = x.length;
        $('#LastName').val(x[a - 1].toString());

        for (var i = 0; i < a - 1; i++) { initials += x[i].charAt(0).toUpperCase() + " "; }

        $('#Initials').val(initials);
    });
});