var abc = new Vue({
    el: "#app",
    data: {
        message: "hello",
        id:"",
        facilityID:"",
        inOut:"",
        result:""
    },

    mounted() {
        this.id=location.search.split("?")[1];
    },

    methods: {
        submit: function () {
                var url = "http://121.199.77.139:8090/facility/sign";
                var that=this;
                console.log("123");
                axios.post(
                    url, {
                        "id": this.studentID,
                       "facility":this.facilityID,
                       "inout":this.inOut
                    }).then(function (response) {
                    console.log(response.data);
                    that.result=response.data;
                    if(that.result==="打卡成功")
                    alert("打卡成功");
                    else
                    alert("打卡失败");

                }, function (err) {
                    console.log(err);
                })
            }
        
    }
})