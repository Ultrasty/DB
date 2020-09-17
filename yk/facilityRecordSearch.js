var abc = new Vue({
    el: "#app",
    data: {
        message: "hello",
        facilityID:"",
        date:"",
        result:"",
        name:"",
        startDate:"",
        endDate:"",
        startTime:"",
        endTime:"",
        capacity:"",
        periodLeft:[]
    },
    methods: {
        submit: function () {
                var url = "http://121.199.77.139:8090/facility/check";
                var that=this;
                console.log("123");
                axios.post(
                    url, {
                        "facility":this.facilityID,
                        "date":this.date,
                    }).then(function (response) {
                    console.log(response.data);
                    that.result=response.data.result;
                    that.name=response.data.name;
                    that.startDate=response.data.startdate;
                    that.endDate=response.data.enddate;
                    that.startTime=response.data.starttime;
                    that.endTime=response.data.endtime;
                    that.capacity=response.data.capacity;
                    that.periodLeft=response.data.periodleft;
                    if(that.result==="success")
                    alert("查询成功");
                    else
                    alert("查询失败");

                }, function (err) {
                    console.log(err);
                })
            }
        
    }
})