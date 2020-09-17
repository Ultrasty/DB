
  var abc = new Vue({
    el: "#app",
    data: {
        message: "hello",
        id:"",
        result:"",
        detail:[]
    },
    methods: {
        submit: function () {
                var url = "http://121.199.77.139:8090/facility/default";
                var that=this;
                axios.post(
                    url, {
                        "id":this.id
                    }).then(function (response) {
                    console.log(response.data.result);
                   that.result=response.data.result;
                   if(that.result==="fail")
                   alert("查询失败");
                   if(that.result==="success")
                   alert("查询成功");
                   if(that.result==="none")
                   alert("无违约记录");
                   console.log(response.data.detail);
                   that.detail=response.data.detail;
                }, function (err) {
                    console.log(err);
                })
            }
        
    }
})
