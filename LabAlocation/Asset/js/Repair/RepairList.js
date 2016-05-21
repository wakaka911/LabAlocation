
$(document).ready(function () {
    loadList();
});
function loadList() {
    $('#repair_list').datagrid({
        queryParams: getParams(),
        url: '/RepairSub/getRepairList',
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
    if(rowData.isDone==0)
        var link = "<a href=# onclick=repairFinish('" + rowData.ID + "')>提交维修完成</a>";
    else
        var link = "维修完成";
    return link;
}

function repairFinish(repairID) {
    var params = { ID: repairID };
    $.DoAjax('/RepairSub/repairFinished', params, function (jsonData) {
        alert(jsonData.msg);
        loadList();
    }, "post", true);
}