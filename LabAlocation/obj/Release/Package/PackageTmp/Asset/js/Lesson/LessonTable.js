$(document).ready(function () {
    loadData();
});


function loadData() {
    $("#labSelect").combobox({
        url: '/Selection/getLabs',
        valueField: 'value',
        textField: 'text',
        onSelect:onLabSelected
    });
}

function onLabSelected() {
    setTableClean();
    var lab_id=$("#labSelect").combobox("getValue");
    var params={lab_id:lab_id};
    $.DoAjax("/LessonTableSub/labSchedule", params, function (jsonData) {
        if(jsonData.status==false)
            alert(jsonData.msg);
        else
            setSchedule(jsonData);
    }, "post", true);
    $.DoAjax("/LessonTableSub/labTempSchedule", params, function (jsonData) {
        if (jsonData.status == false)
            alert(jsonData.msg);
        else
            setSchedule(jsonData);
    }, "post", true);
}

function setSchedule(jsonData) {
    
    $.each(jsonData.obj,function(index,item){
        $("#"+item.lessonWeekday+item.lessonArrange).html("["+item.lessonNo+"]"+item.lessonName+"<br/>"+item.teacherName+"<br/>"+item.lessonRemark);
    });
}

function setTableClean() {
    for (var i = 1; i < 8; i++)
    {
        for (var j = 1; j < 7; j++)
        {
            $("#" + i + j).html("");
        }
    }
}