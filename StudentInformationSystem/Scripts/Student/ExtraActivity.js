$.ajaxSetup({ cache: false });

$(function () {
    var $teacher = $('#Id');

    $teacher.change(function () {
        var $this = $(this);
        if (!$this.val())
            return;

        $('div.AcheivementContent').load(AppRoot + "Student/StudentExtraActivities/AcheivementIndex?id=" + $this.val(), function (response, status, xhr) {
            if (status == "error") {
                AlertIt("ERROR: " + xhr.status + "-" + xhr.statusText);
            }
            else { PopupDocReadyFunc(); }
        });

        $('div.PositionContent').load(AppRoot + "Student/StudentExtraActivities/PositionIndex?id=" + $this.val(), function (response, status, xhr) {
            if (status == "error") {
                AlertIt("ERROR: " + xhr.status + "-" + xhr.statusText);
            }
            else { PopupDocReadyFunc(); }
        });
    });
});