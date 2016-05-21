$(document).ready(function () {
    loadList();
})

function caculate() {
    if (confirm("确定计算今年的维修数量？计算完成将保存进数据库。")) {
        $.DoAjax("/RepairSub/caculate", null, function (jsonData) {
            alert(jsonData.msg);
            loadList();
        }, "post", true);
    }
}

function loadList() {
    $('#year_list').datagrid({
        queryParams: getParams(),
        url: '/RepairSub/getYearList',
        fitColumns: true,
        singleSelect: true,
        rownumbers: true,
        pagination: true,
        height: ($(window).height()),
        striped: true
    });

}
function getParams() { }