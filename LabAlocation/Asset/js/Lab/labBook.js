$(document).ready(function () {
    loadLessonList();
});
$(document).ready(function () {
    loadLessonList();
});
function loadLessonList() {
    $('#lesson_list').datagrid({
        queryParams: getParams(),
        url: '/LessonTableSub/getTempLessonList',
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

function save() {
    var params = saveParams();
    $.DoAjax("/LessonTableSub/saveTempLesson", params, function (jsonData) {
        alert(jsonData.msg);
        $("#win").window('close');
        loadLessonList();
    }, "post", true);
}

function saveParams() {
    var lessonName=$("#lesson_name").val();
    var lessonNo=$("#lesson_no").val();
    var lessonTeacher= $("#lesson_teacher").val();
    var lessonArrange= $("#lesson_arrange").val();
    var lessonRemark= $("#lesson_remark").val();
    var lessonLab = $("#labSelect").combobox("getValue");
    var lessonDay = $("#lessonDay").datebox('getValue');
    var params = { lessonName: lessonName, lessonNo: lessonNo, lessonTeacher: lessonTeacher, lessonArrange: lessonArrange, lessonRemark: lessonRemark, lessonLab: lessonLab, lessonDay: lessonDay };
    return params;
}

function Operate(value, rowData, rowIndex) {
    var link = "<a href=# onclick=deleteTempLesson('" + rowIndex + "')>删除</a>";
    return link;
}
function deleteTempLesson(rowIndex) {
    var rows = $('#lesson_list').datagrid('getRows');
    var lesson_id = rows[rowIndex].ID;
    var params = { lesson_id: lesson_id };
    $.DoAjax("/LessonTableSub/delTempLesson", params, function (jsonData) {
        alert(jsonData.msg);
        loadLessonList();
    }, "post", true);
}


function getParams() { }