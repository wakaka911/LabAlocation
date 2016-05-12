$(document).ready(function () {
    loadList();
});

function loadList()
{
    $('#lab_list').datagrid({
        queryParams: getParams(),
        url: '/LabSub/getLabList',
        fitColumns: true,
        singleSelect: true,
        rownumbers: true,
        pagination: true,
        height: ($(window).height()),
        striped: true
    });
}

function showDialog() {
    $("#win").window('open');
}

function addLab() {
    var params = { lab_name: $("#lab_name").val() };
    $.DoAjax("/LabSub/labAdd", params, function (jsonData) {
        alert(jsonData.msg);
        loadList();
    }, "post", true);
    $("#lab_name").val("");
    $("#win").window('close');
    
}

function Operate(value, rowData, rowIndex) {
    var link = "<a href=# onclick=deleteLab('" + rowIndex + "')>删除</a>";
    return link;
}
function deleteLab(rowIndex) {
    var rows = $('#lab_list').datagrid('getRows');
    var lab_id = rows[rowIndex].ID;
    var params = { lab_id: lab_id };
    $.DoAjax("/LabSub/labDel", params, function (jsonData) {
        alert(jsonData.msg);
        loadList();
    }, "post", true);
    
}

function getParams() { }