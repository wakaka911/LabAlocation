$(document).ready(function () {
    loadLabSelect();
});


function loadLabSelect() {
    $("#labName").combobox({
        url: '/Selection/getLabs',
        valueField: 'value',
        textField: 'text'
    });
}

function addRepair() {
    var params = { labName: $("#labName").combobox("getValue"), repairName: $("#repairName").val() };
    $.DoAjax("/RepairSub/saveRepair", params, function (jsonData) {
        alert(jsonData.msg);
    }, "post", true);
}