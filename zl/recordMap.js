var abc = new Vue({
  el: "#app",
  data: {
      message: "hello",
      province: "",
      city: "",
      risk_level: "",
      result: ""
  },
  methods: {
      submit: function () {
          var url = "http://49.234.96.221:82/api/25";
          var that=this;
          axios.post(
              url, [{
                  "province": this.province,
                  "city": this.city,
                  "risk_level": this.risk_level
              }]).then(function (response) {
              console.log(response.data);
            if(response.data==="更新成功")
              alert("更新成功");

              if(response.data==="更新失败,输入错误")
              alert("更新失败，输入错误");
          }, function (err) {
              console.log(err);
          })
      }
  }
})
