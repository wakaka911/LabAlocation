$(document).ready(function () {
    loadStudentList();
});

function loadStudentList() {
    $('#student_list').datagrid({
        queryParams: getParams(),
        url: '/StudentSub/getStudentList',
        fitColumns: true,
        singleSelect: true,
        rownumbers: true,
        pagination: true,
        height: ($(window).height()),
        striped: true
    });


}

function Operate(value, rowData, rowIndex) {
    var link = "<a href=# onclick=deleteStudent('" + rowIndex + "')>删除</a>";
    return link;
}

function deleteStudent(rowIndex) {
    var rows = $('#student_list').datagrid('getRows');
    var params = { student_id: rows[rowIndex].ID, account: rows[rowIndex].account };
    $.DoAjax("/StudentSub/studentDel", params, function (jsonData) {
        alert(jsonData.msg);
        loadStudentList();
    }, "post", true);
}

function getParams() { }

function studentAddView() {
    $("#studentAdd").window('open');
}

function addStudent() {
    var params = {
        studentName: $("#student_name").val(),
        studentNo: $("#student_no").val(),
        studentSex: $("input[name='student_sex']:checked").val(),
        studentSession: $("#student_session").val(),
        studentProfession: $("#student_profession").val(),
        studentClass: $("#student_class").val(),
        account: $("#account").val(),
        password: $("#password").val(),
        role: $("#role").val()
    }

    $.DoAjax("/StudentSub/studentAdd", params, function (jsonData) {
        alert(jsonData.msg);
        loadStudentList();
        $("#studentAdd").window('close');
    }, 'post', true);
    $("#studentName").val("");
    $("#studentNo").val("");
    $("#studentSex").val("");
    $("#studentSession").val("");
    $("#studentProfession").val("");
    $("#studentClass").val("");
    $("#account").val("");
    $("#password").val("");
}


