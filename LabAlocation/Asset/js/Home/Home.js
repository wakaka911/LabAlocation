$(document).ready(function () {
    $("#lessonsForLabs").click(function () {
        addPanel("0001", "实验室课表查询", "/LessonTable/LessonTable");
    });
    $("#labAdd").click(function () {
        addPanel("0002", "实验室管理", "/Lab/Lab");
    });
    $("#lessonAdd").click(function () {
        addPanel("0003", "实验室课程管理", "/LessonTable/LessonAdd");
    });
    $("#labBook").click(function () {
        addPanel("0004", "预约实验室", "/Lab/labBook");
    });
});