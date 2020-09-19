using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Health.Models
{
    public class return18
    {
        public status[] unhealths=new status[50];
    }

    public class status
    {
        public string student_ID;
        //健康码颜色
        public string healthcode_color;  
        //目前健康状况
        //
         public string currenthealth_status;
        //

          //病假ID
          //
        public string sickleave_ID;

        public string terminate_time;
    }

    public class outStudent
    {
        //学生id
        public string s_id;
        //最近打卡省份
        public string outProvince;
    }

    public class return17
    {
        public outStudent[] outStudents=new outStudent[50];
    }

    public class return16
    {
        public string s_id;
        public string date;
        //
          public string health_situation;
        public string current_province;
        public string current_city;
    }

    public class return15
    {
        public return14[] arr=new return14[30];
    }

    public class return14
    {
        public string student_ID;
        //public string record_ID;
        public string destination;
        public string date;
        public string transport;
        public string trip_num;
        public string date_back;
        public string transport_back;
        public string back_num;

        //
        public string record_ID;

    }

    public class leave
    {
        public string student_ID;
        //public string record_ID;
        public string destination;
        public string date;
        public string transport;
        public string trip_num;
    }

    public class back
    {
        public string date_back;
        public string transport_back;
        public string back_num;
        public string student_ID;

    }

    public class return13
    {
        public string student_ID;
        public string teacher_ID;
        public string application_time;
        public string approval_time;


        public string allowedays;
        public string terminate_time;
        public string reason;
    }

    public class application12_s
    {
        public string student_ID;
        public string reason="不舒服";
        public string application_time="2020-01-01";
    }  

    public class application12_t
    {
        public string approval_time="未批准";
        public string terminate_time="2020-01-01"; 
        public string teacher_ID="00000";

        public string student_ID;

        public string application_time;

        public string reason;

        //
        public string allowedays;

        //
        public string sickleave_ID;
    }

    public class return12
    {
        public application12_t[] applications=new application12_t[50];
    } 


    public class agree
    {
        public string sickleave_ID;
        public string approval_time="2020-01-01";
        public string teacher_ID;
        public string allowedays;
    }

    public class end
    {
        public string sickleave_ID;
        public string terminate_time="2020-01-01";

    }

    public class Message
    {
        public string sender_id;
        public string receiver_id;
        public string content;
    }
}