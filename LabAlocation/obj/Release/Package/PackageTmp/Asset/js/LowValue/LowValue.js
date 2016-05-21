$(document).ready(function () {
    loadSheetList();
    getSheetNo();
});

function showDialog() {
    getSheetNo();
    $("#lowValueSheet").window('open');
}
function loadSheetList() {
    $('#sheet_list').datagrid({
        queryParams: getParams(),
        url: '/LowValueSub/getLowValueList',
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
    var link = "<a href=# onclick=openLowValue('" + rowIndex + "')>查看</a>";
    return link;
}

function getSheetNo() {

    $.DoAjax("/LowValueSub/getSheetNo", null, function (jsonData) {
        if (jsonData.status == true)
            $("#sheetNo").html(jsonData.obj);
        else
            alert("单号获取错误，请联系管理员。错误信息：" + jsonData.msg);
    }, "post", true)
}

function saveLowValue() {
    var params = getLowValueParams();
    $.DoAjax("/LowValueSub/saveLowValue", params, function (jsonData) {
        alert(jsonData.msg);
        $("#lowValueSheet").window('close');
        loadSheetList();
    }, "post", true);
}

function getLowValueParams() {
    var params = {
        sheetNo: $("#sheetNo").html(),
        takeUnit: $("#takeUnit").val(),
        checkTime: $("#checkTime").datebox("getValue"),

        no1: $("#no1").val(),
        name1: $("#name1").val(),
        model1: $("#model1").val(),
        unit1: $("#unit1").val(),
        qty1: $("#qty1").val(),
        price1: $("#price1").val(),
        totalPrice1: $("#totalPrice1").val(),

        no2: $("#no2").val(),
        name2: $("#name2").val(),
        model2: $("#model2").val(),
        unit2: $("#unit2").val(),
        qty2: $("#qty2").val(),
        price2: $("#price2").val(),
        totalPrice2: $("#totalPrice2").val(),

        no3: $("#no3").val(),
        name3: $("#name3").val(),
        model3: $("#model3").val(),
        unit3: $("#unit3").val(),
        qty3: $("#qty3").val(),
        price3: $("#price3").val(),
        totalPrice3: $("#totalPrice3").val(),

        no4: $("#no4").val(),
        name4: $("#name4").val(),
        model4: $("#model4").val(),
        unit4: $("#unit4").val(),
        qty4: $("#qty4").val(),
        price4: $("#price4").val(),
        totalPrice4: $("#totalPrice4").val(),

        sumPrice: $("#sumPrice").val(),
        attachmentTotalPrice: $("#attachmentTotalPrice").val(),
        chairman: $("#chairman").val(),
        buyer: $("#buyer").val(),
        taker: $("#taker").val(),
        checker: $("#checker").val(),
    }
    return params;
}

function openLowValue(rowIndex) {
    var rows = $('#sheet_list').datagrid('getRows');
    var data = rows[rowIndex];

    $("#sheetNo2").html(data.sheet_No);
    $("#takeUnit2").html(data.takeUnit);
    $("#checkTime2").html(data.checkTime);

    $("#no12").html(data.no1);
    $("#name12").html(data.name1);
    $("#model12").html(data.model1);
    $("#unit12").html(data.unit1);
    $("#qty12").html(data.qty1);
    $("#price12").html(data.price1);
    $("#totalPrice12").html(data.totalPrice1);

    $("#no22").html(data.no2);
    $("#name22").html(data.name2);
    $("#model22").html(data.model2);
    $("#unit22").html(data.unit2);
    $("#qty22").html(data.qty2);
    $("#price22").html(data.price2);
    $("#totalPrice22").html(data.totalPrice2);

    $("#no32").html(data.no3);
    $("#name32").html(data.name3);
    $("#model32").html(data.model3);
    $("#unit32").html(data.unit3);
    $("#qty32").html(data.qty3);
    $("#price32").html(data.price3);
    $("#totalPrice32").html(data.totalPrice3);

    $("#no42").html(data.no4);
    $("#name42").html(data.name4);
    $("#model42").html(data.model4);
    $("#unit42").html(data.unit4);
    $("#qty42").html(data.qty4);
    $("#price42").html(data.price4);
    $("#totalPrice42").html(data.totalPrice4);

    $("#sumPrice2").html(data.sumPrice);
    $("#attachmentTotalPrice2").html(data.attachmentTotalPrice);
    $("#chairman2").val(data.chairman);
    $("#buyer2").val(data.buyer);
    $("#taker2").val(data.taker);
    $("#checker2").val(data.checker);
    $("#lowValueSheet2").window('open');
}

function ExportExcel() {
    var url = '/LowValueSub/getExport';
    $('#excelFrame').attr("src", url);
}