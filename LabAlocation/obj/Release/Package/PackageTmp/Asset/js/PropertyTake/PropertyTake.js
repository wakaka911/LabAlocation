$(document).ready(function () {
    loadTakeList();
});


function showDialog() {
    $("#win").window('open');
}

function loadTakeList() {
    $('#take_list').datagrid({
        queryParams: getParams(),
        url: '/PropertySub/getTakeList',
        fitColumns: true,
        singleSelect: true,
        rownumbers: true,
        pagination: true,
        height: ($(window).height()),
        striped: true
    });
}

function getParams() { }

function Operate(value, rowData, rowIndex) {
    var link;
    if (rowData.type == 1) {
        if (rowData.status == 1)
            link = "<a href=# onclick=operationReturn('" + rowIndex + "')>归还</a>";
        if (rowData.status == 0)
            link = "<a href=# onclick=operationReturn('" + rowIndex + "')>归还</a>";
        if (rowData.status == 2)
            link = "已经归还";
    }
    if (rowData.type == 0) {
        if (rowData.status == 0)
            link = "无需归还";
        if (rowData.status == 1)
            link = "无需归还";
        if (rowData.status == 2)
            link = "无需归还";
    }
    return link;
}

function addTake() {
    var params = { takeUnit: $("#takeUnit").val(), type: $("#type").val(), propertyName: $("#propertyName").val(), qty: $("#qty").val() };
    $.DoAjax("/PropertySub/savePropertyTake", params, function (jsonData) {
        alert(jsonData.msg);
        $("#win").window('close');
        loadTakeList();
    }, "post", true);
}

function operationReturn(rowIndex) {
    var rows = $('#take_list').datagrid('getRows');
    var propertyID = rows[rowIndex].ID;
    var params = { propertyID: propertyID };
    $.DoAjax("/PropertySub/returnTake", params, function (jsonData) {
        alert(jsonData.msg);
        loadTakeList();
    }, "post", true);
}