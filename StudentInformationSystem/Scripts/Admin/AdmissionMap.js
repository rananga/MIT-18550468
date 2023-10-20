$.ajaxSetup({ cache: false });

$(function () {
    var cbs = $('table > tbody > tr > td > input[type="checkbox"]');

    cbs.change(function () {
        var $this = $(this);
        var objChangesJson = $('#ActivityChangesJson');
        var changesJson = objChangesJson.val();
        var changes = JSON.parse(changesJson || "[]");

        var schoolId = $this.data("school-id");
        var existingItem = changes.find((o) => { return o["Id"] === schoolId })
        var dbVal = $this.data("db-val");
        var newVal = $this.is(":checked") ? "True" : "False";

        if (dbVal != newVal) {
            if (existingItem)
                existingItem["IsActive"] = newVal;
            else
                changes.push({ Id: schoolId, IsActive: newVal });
        }
        else if (existingItem) {
            changes = changes.filter(itm => itm.Id != schoolId);
        }

        objChangesJson.val(JSON.stringify(changes));
    });
});