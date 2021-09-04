﻿$.ajaxSetup({ cache: false });

$(function () {
    var $teacher = $('#Id');

    $teacher.change(function () {
        var $this = $(this);
        if (!$this.val())
            return;

        $('div.ChildContent').load(AppRoot + "Teacher/TeacherOffTime/OffTimeIndex?id=" + $this.val(), function (response, status, xhr) {
            if (status == "error") {
                AlertIt("ERROR: " + xhr.status + "-" + xhr.statusText);
            }
            else { PopupDocReadyFunc(); }
        });
    });
});