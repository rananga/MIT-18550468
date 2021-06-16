$.ajaxSetup({ cache: false });

$(function () {
    var objEmployeeID = $('#EmployeeID');
    var objBranchID = $('#BranchID');
    var objDept = $('#DepartmentID');
        
    objEmployeeID.change(function () {
        if (objEmployeeID.val() == null) {
            objBranchID.prop('disabled', false);
            objDept.prop('disabled', false);
        }
        else {
            objBranchID.prop('disabled', true);
            objDept.prop('disabled', true);
        }

        
    });

});