$(document).ready(function () {
    loadList();
})

function save() {
    var params = getParams();
    $.DoAjax("/PropertySub/savePropertyReg", params, function (jsonData) {
        alert(jsonData.msg);
        $("#win").window('close');
        loadList();
    }, "post", true);
}

function showDialog() {
    $("#win").window('open');
}

function loadList() {
    $('#property_list').datagrid({
        queryParams: {},
        url: '/PropertySub/getRegList',
        fitColumns: true,
        singleSelect: true,
        rownumbers: true,
        pagination: true,
        height: ($(window).height()),
        striped: true
    });
}
function Operate(value, rowData, rowIndex) {
    var link = "<a href=# onclick=opendetail('" + rowIndex + "')>查看</a>";
    return link;
}
function getParams() {
    var params = {
        takeUnit: $("#takeUnit").val(),
        perPrice: $("#perPrice").val(),
        name: $("#name").val(),
        producer: $("#producer").val(),
        model: $("#model").val(),
        guige: $("#guige").val(),
        buyTime: $("#buyTime").datebox('getValue'),
        chuchangTime: $("#chuchangTime").datebox('getValue'),
        invoiceNo: $("#invoiceNo").val(),
        taker: $("#taker").val(),
        passer: $("#passer").val()
    };
    return params;
}

function opendetail(rowIndex) {

    var rows = $('#property_list').datagrid('getRows');
    var data = rows[rowIndex];
    $("#takeUnit2").val(data.takeUnit);
    $("#perPrice2").val(data.perPrice);
    $("#name2").val(data.name);
    $("#producer2").val(data.producer);
    $("#model2").val(data.model);
    $("#guige2").val(data.guige);
    $("#buyTime2").val(data.buyTime);
    $("#chuchangTime2").val(data.chuchangTime);
    $("#invoiceNo2").val(data.invoiceNo);
    $("#taker2").val(data.taker);
    $("#passer2").val(data.passer);
    $("#win2").window('open');
}