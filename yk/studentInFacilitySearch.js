var abc = new Vue({
    el: "#app",
    data: {
        message: "hello",
        facility:"",
        date:"",
        startTime:"",
        endTime:"",
        result:"",
        student:[]
    },
    methods: {
        submit: function () {
                var url = "http://121.199.77.139:8090/facility/student";
                var that=this;
                axios.post(
                    url, {
                        "facility": this.facility,
                        "date":this.date,
                        "starttime":this.startTime,
                        "endtime":this.endTime
                    }).then(function (response) {
                    console.log(response.data.result);
                   that.result=response.data.result;
                   if(that.result==="fail")
                   alert("查询失败");
                   if(that.result==="success")
                   alert("查询成功");
                   console.log(response.data.student);
                   that.student=response.data.student;
                }, function (err) {
                    console.log(err);
                })
            }
        
    }
})