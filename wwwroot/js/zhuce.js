
alert("起飞")

function dianji() {
    var zhanghao = ""
    var mima1 = ""
    var mima2 = ""
    var zidian = {}
    zhanghao = document.getElementById("zhanghao").value
    mima1 = document.getElementById("mima1").value
    mima2 = document.getElementById("mima2").value

    //获取json文件的内容，并放入到“字典”中
    

    //将字典中的内容发送到后台文件
    
    $.ajax({
        url: "http://localhost:5079/api/Houtaijiekou/endpoint", 
        type: "POST",
        data: JSON.stringify({ zhanghao: zhanghao, mima: mima1 }),
        contentType: 'application/json',
        //sync: true,
        success: function (response) {
            if (response == 1) {
                alert('该账号已经存在，请重新注册或者登录')
            } else {
                alert('注册成功！')
            }
            console.log('成功接收数据:', response);
            
            // 处理数据           
        },
        error: function (xhr, status, error) {
            console.error('请求失败:', status, error);
        }
    })

}
