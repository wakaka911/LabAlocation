function login() {
    var params = { account: $("#account").val(), password: $("#password").val() };
    $.DoAjax("/Home/Login", params, function (jsonData) {
        alert(jsonData.msg);
    }, "post", true);
}