$(document).ready(function () {
    loadTeacherList();
});


function loadTeacherList() {
    $('#teacher_list').datagrid({
        queryParams: getParams(),
        url: '/TeacherSub/getTeacherList',
        fitColumns: true,
        singleSelect: true,
        rownumbers: true,
        pagination: true,
        height: ($(window).height()),
        striped: true
    });
}

function getParams() { }

function teacherAddView() {
    $("#teacherAdd").window('open');
}

function Operate(value, rowData, rowIndex) {
    var link = "<a href=# onclick=deleteTeacher('" + rowIndex + "')>删除</a>";
    return link;
}

function deleteTeacher(rowIndex) {
    var rows = $('#teacher_list').datagrid('getRows');
    var params = { teacher_id: rows[rowIndex].ID, account: rows[rowIndex].account };
    $.DoAjax("/TeacherSub/teacherDel", params, function (jsonData) {
        alert(jsonData.msg);
        loadTeacherList();
    }, "post", true);
}

function addTeacher() {
    var params = {
        teacherName: $("#teacherName").val(),
        teacherNo: $("#teacherNo").val(),
        teacherSex: $("input[name='teacherSex']:checked").val(),
        teacherDep: $("#teacherDep").val(),
        account: $("#account").val(),
        password: $("#password").val(),
        role:$("#role").val()
    }

    $.DoAjax("/TeacherSub/teacherAdd", params, function (jsonData) {
        alert(jsonData.msg);
        loadTeacherList();
        $("#teacherAdd").window('close');
    }, 'post', true);
    $("#teacherName").val("");
    $("#teacherNo").val("");
    $("#teacherSex").val("");
    $("#teacherDep").val("");
    $("#account").val("");
    $("#password").val("");
}






