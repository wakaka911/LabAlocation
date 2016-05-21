$(document).ready(function () {
    loadLessonList();
});
function loadLessonList() {
    $('#lesson_list').datagrid({
        queryParams: getParams(),
        url: '/LessonTableSub/getLessonList',
        fitColumns: true,
        singleSelect: true,
        rownumbers: true,
        pagination: true,
        height: ($(window).height()),
        striped: true
    });

    $("#labSelect").combobox({
        url: '/Selection/getLabs',
        valueField: 'value',
        textField: 'text'
    });
}
function showDialog() {
    $("#win").window('open');
}

function addLesson() {
    var params = {
        lesson_name: $("#lesson_name").val(),
        lesson_no: $("#lesson_no").val(),
        lesson_teacher: $("#lesson_teacher").val(),
        lesson_weekday: $("#lesson_weekday").val(),
        lesson_arrange: $("#lesson_arrange").val(),
        lesson_remark: $("#lesson_remark").val(),
        lessonLab: $("#labSelect").combobox("getValue")
    }
    $.DoAjax("/LessonTableSub/LessonAdd", params, function (jsonData) {
        alert(jsonData.msg);
        loadLessonList();
        $("#win").window('close');
    }, "post", true);
}

function getParams() { }
function Operate(value, rowData, rowIndex) {
    var link = "<a href=# onclick=deleteLesson('" + rowIndex + "')>删除</a>";
    return link;
}

function deleteLesson(rowIndex) {
    var rows = $('#lesson_list').datagrid('getRows');
    var lesson_id = rows[rowIndex].ID;
    var params = { lesson_id: lesson_id };
    $.DoAjax("/LessonTableSub/LessonDel", params, function (jsonData) {
        alert(jsonData.msg);
        loadList();
    }, "post", true);
}