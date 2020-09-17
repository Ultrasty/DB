var abc = new Vue({
    el: "#app",
    data: {
        message: "hello",
        ID: "",
        facilityNumber: "",
        applyDate: "",
        startTime: "",
        endTime: "",
        result: ""
    },
    methods: {
        submit: function () {
            var url = "http://121.199.77.139:8090/facility/apply";
            var that=this;
            axios.post(
                url, {
                    "id": this.ID,
                    "facility": this.facilityNumber,
                    "date": this.applyDate,
                    "starttime": this.startTime,
                    "endtime": this.endTime
                }).then(function (response) {

                console.log(response.data);
               that.result=response.data;
               if(that.result.result==="invalid date")
               alert("申请日期不是允许日期");
               if(that.result.result==="success")
               alert("申请成功");
               if(that.result.result==="fail")
               alert("申请失败");
               if(that.result.result==="no left")
               alert("该时间段设施已满");
               if(that.result.result==="invalid time")
               alert("申请时间不在开放时间以内");
               if(that.result.result==="wrong id")
               alert("该ID不存在");
               if(that.result.result==="wrong facility")
               alert("设施序号错误");
               if(that.result.result==="time overlap")
               alert("与其他预约时间重复");
               if(that.result.result==="unqualified")
               alert("健康状况不符合申请要求");

            }, function (err) {
                console.log(err);
            })
        }
    }
})