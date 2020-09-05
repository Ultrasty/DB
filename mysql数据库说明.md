#连接方式
ip地址：121.199.77.139
用户名：test
密码：123

#table更改说明：

1. 时间类型从int(20)修改为int(10)，便于时间存储和转化
1. 日期统一为date
1. pandemic_situation中，place拆分为province和city，risk_level改为tinyint，0-无风险，1-低风险，2-中风险，3-高风险
1. student中的currenthealth_status和clockin_record中的health_status改为tinyint，0-健康，1-发热，2-疑似，3-确诊
1. clockin_record中去掉了体温
1. facilities中start_day, end_day改为int，数字1~7表示周一到周日
1. 去掉了default_record中的time
1. department添加phone_number

ps：~~大多数外码尚未添加~~  
修改日期：2020.9.4

[2020-09-05 17:33]外码已经全部加上了，还加了一些初始数据，healthsystem.sql文件为数据库的备份
