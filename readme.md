# xdm冲

本项目为同济大学数据库课程设计项目，使用`GitHub`作为代码托管平台。

| NAME                      | URL                                                          |
| ------------------------- | ------------------------------------------------------------ |
| 本项目地址                | https://github.com/Ultrasty/DB/                              |
| Vue教学                   | https://www.bilibili.com/video/BV12J411m7MG?from=search&seid=1321871634702043513 |
| 快速建立.NET core Web API | https://www.bilibili.com/video/BV11E411n74a?from=search&seid=12974635524049425066 |
| bootstrap的CSS样式表      | https://v3.bootcss.com/css/                                  |

#### 开发环境

| NAME      | Edition |
| --------- | ------- |
| MySQL     | 8.0.21  |
| jQuery    | v3.5.1  |
| Bootstrap | v3.3.7  |
| Vue.js    | v2.6.11 |
| .NET core | 2.1.1   |

#### 数据库连接方式

| IP     | 121.199.77.139 |
| ------ | -------------- |
| 用户名 | test           |
| 密码   | 123            |

#### 服务器列表

| IP              | 描述                |
| --------------- | ------------------- |
| 121.199.77.139  | 数据库、接口 by LZH |
| 101.132.145.102 | 接口 by STY         |
| 49.234.96.221 | 接口 by WQ |

#### table更改说明

1. 时间类型从int(20)修改为int(10)，便于时间存储和转化
1. 日期统一为date
1. pandemic_situation中，place拆分为province和city，risk_level改为tinyint，0-无风险，1-低风险，2-中风险，3-高风险
1. student中的currenthealth_status和clockin_record中的health_status改为tinyint，0-健康，1-发热，2-疑似，3-确诊
1. clockin_record中去掉了体温
1. facilities中start_day, end_day改为int，数字1~7表示周一到周日
1. 去掉了default_record中的time
1. department添加phone_number

9. 外码已经全部加上了，还加了一些初始数据



## 接口约定

#### 1.（通用接口，方便开发）根据表名称请求数据表

备注：imsty.cn对应的IP为101.132.145.102

[POST]

http://101.132.145.102:5000/api/gettablebyname

这是一个通过表名获取一个表的所有数据的通用接口。

接口请求包括以下内容：

| 参数  | 类型   | 说明 |
| ----- | ------ | ---- |
| table | string | 表名 |

请求示例：

```json
{"table":"student"}
```

接口响应包括以下内容：

| 参数             | 类型      | 说明                       |
| ---------------- | --------- | -------------------------- |
| countofrows      | int       | 请求的数据表的行数         |
| countofcolumns   | int       | 请求的数据表的列数         |
| tableheader      | string[]  | 请求的数据表的字段名的集合 |
| tableinformation | string[,] | 请求的数据表的值的集合     |


下面的这个GET方法和上面的POST方法功能一致

[GET]

http://101.132.145.102:5000/api/gettable

接口请求包括以下内容：

| 参数  | 类型   | 说明 |
| ----- | ------ | ---- |
| table | string | 表名 |

请求示例：

```json
http://101.132.145.102:5000/api/gettable?table=student
```

接口响应内容同上。

#### 2.发送消息接口

请求示例：

```json
{
    "sender_id":"1850002",
    "receiver_id":"1850003",
    "content":"test!haha"
}
```

返回值：

"success"或"fail"