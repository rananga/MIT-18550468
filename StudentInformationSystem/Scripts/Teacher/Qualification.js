$.ajaxSetup({ cache: false });

$(function () {
    var $teacher = $('#Id');

    $teacher.change(function () {
        var $this = $(this);
        if (!$this.val())
            return;

        $('div.ChildContent').load(AppRoot + "Teacher/TeacherQualification/QualificationIndex?id=" + $this.val(), function (response, status, xhr) {
            if (status == "error") {
                AlertIt("ERROR: " + xhr.status + "-" + xhr.statusText);
            }
            else {
                PopupDocReadyFunc();
                QualificationsDocReadyFunc();
            }
        });
    });
});

function QualificationsGridBinder() {
    QualificationsDocReadyFunc();
}

function QualificationsDocReadyFunc() {

    var tblDiv = $('#ChildContent');

    $('#tblQualifications', tblDiv).find("button[name='toggleLecturers']").each(function () {
        var $this = $(this);

        $this.off("click");
        $this.on("click", function (e) {
            var $btn = $(this);
            var childDiv = $btn.closest("table").siblings("div");

            if ($btn.data("shown")) {
                $btn.removeData("shown");
                childDiv.hide();
                $btn.find('span').attr('class', 'bi bi-chevron-down');
            }
            else {
                var subId = $btn.data("subject-id");
                var idxUrl = AppRoot + "Teacher/TeacherQualification/SubjectIndex";
                var isToEdit = $btn.data("to-edit")

                childDiv.load(idxUrl, { id: subId, isToEdit: isToEdit }, function (response, status, xhr) {
                    if (status == "error") {
                        AlertIt("ERROR: " + xhr.status + "-" + xhr.statusText);
                    }
                    else {
                        $btn.data("shown", true);
                        $btn.find('span').attr('class', 'bi bi-chevron-up');
                        childDiv.show();
                        PopupDocReadyFunc();
                    }
                });
            }
        });
    });
}