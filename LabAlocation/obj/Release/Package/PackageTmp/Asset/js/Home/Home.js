$(document).ready(function () {
    $.DoAjax("/HomeSub/GetMenu", null, function (jsonData) {
        $("#west").html(jsonData.obj);
    }, "post", true);

});


function LessonTable() {
    addPanel("0001", "实验室课表查询", "/LessonTable/LessonTable");
}
function Lab() {
    addPanel("0002", "实验室管理", "/Lab/Lab");
}
function LessonAdd() {
    addPanel("0003", "实验室课程管理", "/LessonTable/LessonAdd");
}
function labBook() {
    addPanel("0004", "预约实验室", "/Lab/labBook");
}
function labBookApprove() {
    addPanel("0005", "预约实验室审核", "/Lab/labBookApprove");
}
function LowValue() {
    addPanel("0006", "低值耐用品登记", "/LowValue/LowValue");
}
function PropertyTake() {
    addPanel("0007", "实验室物品领用", "/Property/PropertyTake");
}
function Repair() {
    addPanel("0008", "报修", "/Repair/Repair");
}
function RepairList() {
    addPanel("0008", "维修报告", "/Repair/RepairList");
}
function TeacherAdd() {
    addPanel("0009", "教师账户管理", "/Teacher/TeacherAdd");
}
function StudentAdd() {
    addPanel("0009", "学生账户管理", "/Student/StudentAdd");
}
function YearRepair() {
    addPanel("0010", "实验室维修绩效", "/Repair/YearRepair");
}
function PasswordChange() {
    addPanel("0011", "修改密码", "/Home/PasswordChange");
}
function PropertyReg() {
    addPanel("0012", "固定资产登记表", "/Property/PropertyReg");
}

function logout() {
    location.href = "/Home/LogOff";
}