var abc = new Vue({
  el: "#app",
  data: {
      message: "hello",
      id:"",
      result:"",
      building:"",
      name:"",
      phonenumber:""
  },
  methods: {
      submit: function () {
              var url = "http://121.199.77.139:8090/department/check";
              var that=this;
              axios.post(
                  url, {
                      "id":this.id
                  }).then(function (response) {
                  console.log(response.data.result);
                 that.result=response.data.result;
                 var alert_msg="查找成功\n"+"学院："+response.data.building+"\n"+"负责人："+response.data.name+"\n"+"联系方式："+response.data.phonenumber;
                 if(that.result==="wrong id")
                 alert("id不存在");
                 if(that.result==="success")
                 alert("查找成功");
                 console.log(response.data.building);
                 that.building=response.data.building;
                 console.log(response.data.name);
                 that.name=response.data.name;
                 console.log(response.data.phonenumber);
                 that.phonenumber=response.data.phonenumber;
              }, function (err) {
                  console.log(err);
              })
          }
      
  }
})
