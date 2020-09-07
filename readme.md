# 学生健康信息数据库/疫情打卡系统

本项目为同济大学数据库课程设计项目，使用`GitHub`作为代码托管平台。

项目地址https://github.com/Ultrasty/DB/

用jQuery是因为Bootstrap.js依赖于jQuery.js，Bootstrap.js可以提供一些动态效果。

Bootstrap.css提供了很多现成的预定义的样式，https://v3.bootcss.com/css/ 提供了使用他们的代码。

pages/lib文件夹中是官方预编译的Bootstrap.css和Bootstrap.js，以及Vue.js

index.html是左侧导航列表的模板，来自于https://github.com/gyfeng1003/management ，页面右侧是一个iframe元素，因此每个页面的开发都可以很简洁。

pages/Template文件夹中是模板index.html的一些依赖项，所以可以卜用管。

#### 一些高质量的参考资料

https://www.bilibili.com/video/BV12J411m7MG?from=search&seid=1321871634702043513 Vue教学

https://www.bilibili.com/video/BV11E411n74a?from=search&seid=12974635524049425066 快速建立.NET core Web API

https://v3.bootcss.com/css/ bootstrap的CSS样式表


#### 开发环境
> MySQL 8.0.21
>
> jQuery v3.5.1
>
> Bootstrap v3.3.7
>
> Vue.js v2.6.11

#### 数据库连接方式:

> IP地址：121.199.77.139
> 
> 用户名：test
> 
> 密码：123



#### LOGS

[2020-09-04 19:56]table更改说明

1. 时间类型从int(20)修改为int(10)，便于时间存储和转化
1. 日期统一为date
1. pandemic_situation中，place拆分为province和city，risk_level改为tinyint，0-无风险，1-低风险，2-中风险，3-高风险
1. student中的currenthealth_status和clockin_record中的health_status改为tinyint，0-健康，1-发热，2-疑似，3-确诊
1. clockin_record中去掉了体温
1. facilities中start_day, end_day改为int，数字1~7表示周一到周日
1. 去掉了default_record中的time
1. department添加phone_number

ps：~~大多数外码尚未添加~~  

[2020-09-05 17:33]外码已经全部加上了，还加了一些初始数据，healthsystem.sql文件为数据库的备份，更改了一些字段的数据类型。增加了前端文件夹pages和后端文件夹api
