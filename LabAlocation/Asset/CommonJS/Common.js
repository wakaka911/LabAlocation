$(function(){
    /**
     * ajax封装
     * url 发送请求的地址
     * dataParams 发送到服务器的数据，数组存储，如：{"date": new Date().getTime(), "state": 1}
     * typeAsync 默认值: true。默认设置下，所有请求均为异步请求。如果需要发送同步请求，请将此选项设置为 false。
     *       注意，同步请求将锁住浏览器，用户其它操作必须等待请求完成才可以执行。
     * typeAction 请求方式("POST" 或 "GET")， 默认为 "post"
     * //dataType 预期服务器返回的数据类型，常用的如：xml、html、json、text
     * successFunction 成功回调函数
     * errorFuncton 失败回调函数
     */
    jQuery.DoAjax = function (url, dataParams, successFunction, typeAction, typeAsync) {
        dataParams = dataParams == null ? {} : dataParams;
        typeAction = typeAction == undefined || null ? 'post' : typeAction;
        typeAsync = typeAsync == undefined || null ? true : typeAsync;
        //errorFuncton = errorFuncton == undefined || null ? function (errorData) { alert('系统异常'); } : errorFuncton;
        $.ajax({
            url: url,
            type: typeAction,
            data: dataParams,
            success: successFunction,
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                if (XMLHttpRequest.status == '0')
                    return;
                else
                    alert('系统异常');
            },
            async: typeAsync,
            cache: false
        });
    }
})