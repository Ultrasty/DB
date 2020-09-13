-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: 121.199.77.139    Database: healthsystem
-- ------------------------------------------------------
-- Server version	8.0.21

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `healthsystem`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `healthsystem` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `healthsystem`;

--
-- Table structure for table `administrator`
--

DROP TABLE IF EXISTS `administrator`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `administrator` (
  `administrator_ID` varchar(20) NOT NULL,
  `administrator_name` varchar(20) DEFAULT NULL,
  `password` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`administrator_ID`),
  CONSTRAINT `administrator_teacher` FOREIGN KEY (`administrator_ID`) REFERENCES `teacher` (`teacher_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `administrator`
--

LOCK TABLES `administrator` WRITE;
/*!40000 ALTER TABLE `administrator` DISABLE KEYS */;
INSERT INTO `administrator` VALUES ('6','钟老师','123456');
/*!40000 ALTER TABLE `administrator` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `advisor`
--

DROP TABLE IF EXISTS `advisor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `advisor` (
  `teacher_ID` varchar(20) NOT NULL,
  `student_ID` varchar(20) NOT NULL,
  PRIMARY KEY (`teacher_ID`,`student_ID`),
  KEY `student_ID_idx` (`student_ID`),
  CONSTRAINT `student_ID` FOREIGN KEY (`student_ID`) REFERENCES `student` (`student_ID`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `teacher_ID` FOREIGN KEY (`teacher_ID`) REFERENCES `teacher` (`teacher_ID`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `advisor`
--

LOCK TABLES `advisor` WRITE;
/*!40000 ALTER TABLE `advisor` DISABLE KEYS */;
INSERT INTO `advisor` VALUES ('2','1650001'),('6','1650002'),('1','1750001'),('1','1750002'),('6','1750003'),('6','1850001'),('6','1850002'),('6','1850003'),('6','1850004'),('6','1850005');
/*!40000 ALTER TABLE `advisor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `application`
--

DROP TABLE IF EXISTS `application`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `application` (
  `applicant_ID` varchar(45) NOT NULL,
  `facility_ID` varchar(10) NOT NULL,
  `date` date NOT NULL,
  `start_time` int NOT NULL,
  `end_time` int DEFAULT NULL,
  `enter_time` datetime DEFAULT NULL,
  `left_time` datetime DEFAULT NULL,
  PRIMARY KEY (`applicant_ID`,`facility_ID`,`start_time`,`date`),
  KEY `application_student_idx` (`applicant_ID`),
  KEY `application_facilities_idx` (`facility_ID`),
  CONSTRAINT `application_facilities` FOREIGN KEY (`facility_ID`) REFERENCES `facilities` (`facility_ID`),
  CONSTRAINT `application_student` FOREIGN KEY (`applicant_ID`) REFERENCES `student` (`student_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `application`
--

LOCK TABLES `application` WRITE;
/*!40000 ALTER TABLE `application` DISABLE KEYS */;
INSERT INTO `application` VALUES ('1850001','1','2020-09-15',8,10,NULL,NULL),('1850001','1','2020-10-12',28,14,NULL,NULL),('1850001','3','2020-09-20',14,16,NULL,NULL),('1850001','5','2020-10-12',12,14,NULL,NULL),('1850002','1','2020-09-15',10,11,NULL,NULL),('1850003','1','2020-09-15',9,14,NULL,NULL),('1850004','1','2020-09-15',9,13,NULL,NULL),('1850004','5','2020-09-12',22,23,NULL,'2020-09-12 22:41:48');
/*!40000 ALTER TABLE `application` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `back_info`
--

DROP TABLE IF EXISTS `back_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `back_info` (
  `student_ID` varchar(20) NOT NULL,
  `date` date NOT NULL,
  `transport` varchar(45) DEFAULT NULL,
  `trip_num` varchar(45) DEFAULT NULL,
  `batch_num` int DEFAULT NULL,
  `semester` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`student_ID`,`date`),
  KEY `batch_idx` (`batch_num`,`semester`),
  CONSTRAINT `back_info_student` FOREIGN KEY (`student_ID`) REFERENCES `student` (`student_ID`),
  CONSTRAINT `batch` FOREIGN KEY (`batch_num`, `semester`) REFERENCES `batch` (`batch_num`, `semester`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `back_info`
--

LOCK TABLES `back_info` WRITE;
/*!40000 ALTER TABLE `back_info` DISABLE KEYS */;
INSERT INTO `back_info` VALUES ('1650001','2020-09-12','plane','HU7451',5,'2020-9'),('1650002','2020-09-11','plane','YM8229',4,'2020-9'),('1750003','2020-09-13','train','G1024',6,'2020-9'),('1850001','2020-09-08','train','G685',1,'2020-9'),('1850002','2020-09-09','train','D1733',2,'2020-9'),('1850004','2020-09-12','train','D3142',5,'2020-9'),('1850005','2020-09-12','train','D3142',5,'2020-9');
/*!40000 ALTER TABLE `back_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `batch`
--

DROP TABLE IF EXISTS `batch`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `batch` (
  `batch_num` int NOT NULL,
  `semester` varchar(45) NOT NULL,
  `date` date DEFAULT NULL,
  PRIMARY KEY (`batch_num`,`semester`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `batch`
--

LOCK TABLES `batch` WRITE;
/*!40000 ALTER TABLE `batch` DISABLE KEYS */;
INSERT INTO `batch` VALUES (1,'2020-9','2020-09-08'),(2,'2020-9','2020-09-09'),(3,'2020-9','2020-09-10'),(4,'2020-9','2020-09-11'),(5,'2020-9','2020-09-12'),(6,'2020-9','2020-09-13');
/*!40000 ALTER TABLE `batch` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chat_record`
--

DROP TABLE IF EXISTS `chat_record`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chat_record` (
  `student_id` varchar(20) NOT NULL,
  `teacher_id` varchar(20) NOT NULL,
  `sender` int NOT NULL,
  `chat_time` date NOT NULL,
  `content` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`student_id`,`teacher_id`,`chat_time`,`sender`),
  KEY `chat_record_teacher_idx` (`teacher_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chat_record`
--

LOCK TABLES `chat_record` WRITE;
/*!40000 ALTER TABLE `chat_record` DISABLE KEYS */;
INSERT INTO `chat_record` VALUES ('1850001','1',1,'2020-09-12','Hello World!'),('6','1850001',1,'2020-09-05',NULL);
/*!40000 ALTER TABLE `chat_record` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `class`
--

DROP TABLE IF EXISTS `class`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `class` (
  `department` varchar(20) NOT NULL,
  `grade` varchar(20) NOT NULL,
  `class_num` int NOT NULL,
  `teacher_ID` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`department`,`grade`,`class_num`),
  KEY `class_teacher_idx` (`teacher_ID`),
  CONSTRAINT `class_department` FOREIGN KEY (`department`) REFERENCES `department` (`dept_name`),
  CONSTRAINT `class_teacher` FOREIGN KEY (`teacher_ID`) REFERENCES `teacher` (`teacher_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `class`
--

LOCK TABLES `class` WRITE;
/*!40000 ALTER TABLE `class` DISABLE KEYS */;
INSERT INTO `class` VALUES ('CAUP','17',1701,'1'),('CAUP','17',1702,'1'),('DI','16',1601,'2'),('SSE','16',1601,'6'),('SSE','17',1701,'6'),('SSE','18',1801,'6'),('SSE','18',1802,'6'),('SSE','18',1803,'6'),('SSE','18',1804,'6'),('SSE','18',1805,'6');
/*!40000 ALTER TABLE `class` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clockin_record`
--

DROP TABLE IF EXISTS `clockin_record`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clockin_record` (
  `student_ID` varchar(20) NOT NULL,
  `date` date NOT NULL,
  `health_situation` tinyint(1) DEFAULT NULL,
  `current_province` varchar(45) DEFAULT NULL,
  `current_city` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`student_ID`,`date`),
  KEY `clockin_record_pademic_idx` (`current_province`,`date`,`current_city`),
  CONSTRAINT `clockin_record_pademic` FOREIGN KEY (`current_province`, `date`, `current_city`) REFERENCES `pandemic_situation` (`province`, `date`, `city`),
  CONSTRAINT `clockin_record_student` FOREIGN KEY (`student_ID`) REFERENCES `student` (`student_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clockin_record`
--

LOCK TABLES `clockin_record` WRITE;
/*!40000 ALTER TABLE `clockin_record` DISABLE KEYS */;
INSERT INTO `clockin_record` VALUES ('1650001','2020-09-05',1,'浙江','杭州'),('1650001','2020-09-06',1,'浙江','杭州'),('1650002','2020-09-06',1,'四川','成都'),('1750001','2020-09-05',1,'安徽','合肥'),('1750002','2020-09-05',1,'新疆','乌鲁木齐'),('1750002','2020-09-06',1,'浙江','杭州'),('1750003','2020-09-05',1,'浙江','宁波'),('1850001','2020-09-05',1,'浙江','温州'),('1850002','2020-09-05',1,'贵州','贵阳'),('1850003','2020-09-05',1,'湖南','长沙'),('1850004','2020-09-05',1,'辽宁','大连'),('1850005','2020-09-05',1,'青海','西宁');
/*!40000 ALTER TABLE `clockin_record` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `default_record`
--

DROP TABLE IF EXISTS `default_record`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `default_record` (
  `applicant_ID` varchar(20) NOT NULL,
  `count` int NOT NULL,
  `facility_ID` varchar(45) DEFAULT NULL,
  `date` date DEFAULT NULL,
  PRIMARY KEY (`applicant_ID`,`count`),
  KEY `default_record_facilities_idx` (`facility_ID`),
  CONSTRAINT `default_record_facilities` FOREIGN KEY (`facility_ID`) REFERENCES `facilities` (`facility_ID`),
  CONSTRAINT `default_record_student` FOREIGN KEY (`applicant_ID`) REFERENCES `student` (`student_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `default_record`
--

LOCK TABLES `default_record` WRITE;
/*!40000 ALTER TABLE `default_record` DISABLE KEYS */;
INSERT INTO `default_record` VALUES ('1850001',1,'1','2020-09-16'),('1850003',1,'2','2020-09-01'),('1850003',2,'3','2020-09-05'),('1850003',3,'3','2020-09-10');
/*!40000 ALTER TABLE `default_record` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `department`
--

DROP TABLE IF EXISTS `department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `department` (
  `dept_name` varchar(45) NOT NULL,
  `building` varchar(45) DEFAULT NULL,
  `person_in_charge` varchar(20) DEFAULT NULL,
  `phone_number` varchar(13) DEFAULT NULL,
  PRIMARY KEY (`dept_name`),
  KEY `department_teacher_idx` (`person_in_charge`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `department`
--

LOCK TABLES `department` WRITE;
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department` VALUES ('CAUP','A','张老师','13800000000'),('DI','B','赵老师','13811111111'),('IS','C','王老师','13822222222'),('SEE','D','李老师','13833333333'),('SESE','E','孙老师','13844444444'),('SSE','F','钟老师','13855555555');
/*!40000 ALTER TABLE `department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `facilities`
--

DROP TABLE IF EXISTS `facilities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `facilities` (
  `facility_ID` varchar(10) NOT NULL,
  `facility_name` varchar(45) DEFAULT NULL,
  `start_time` int DEFAULT NULL,
  `end_time` int DEFAULT NULL,
  `max_capacity` int DEFAULT NULL,
  `start_day` int DEFAULT NULL,
  `end_day` int DEFAULT NULL,
  PRIMARY KEY (`facility_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `facilities`
--

LOCK TABLES `facilities` WRITE;
/*!40000 ALTER TABLE `facilities` DISABLE KEYS */;
INSERT INTO `facilities` VALUES ('1','篮球场',7,20,100,1,6),('2','足球场',8,20,100,1,7),('3','图书馆',8,20,1000,1,7),('4','羽毛球场',8,20,20,1,7),('5','test',8,24,10,1,6);
/*!40000 ALTER TABLE `facilities` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `leaving_record`
--

DROP TABLE IF EXISTS `leaving_record`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `leaving_record` (
  `student_ID` varchar(20) NOT NULL,
  `record_ID` int NOT NULL,
  `destination` varchar(45) DEFAULT NULL,
  `date` date DEFAULT NULL,
  `transport` varchar(45) DEFAULT NULL,
  `trip_num` varchar(45) DEFAULT NULL,
  `date_back` date DEFAULT NULL,
  `transport_back` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`student_ID`,`record_ID`),
  CONSTRAINT `leaving_record_student` FOREIGN KEY (`student_ID`) REFERENCES `student` (`student_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `leaving_record`
--

LOCK TABLES `leaving_record` WRITE;
/*!40000 ALTER TABLE `leaving_record` DISABLE KEYS */;
INSERT INTO `leaving_record` VALUES ('1650001',1,'北京','2020-09-20','train','D3142','2020-09-25','D1733'),('1650001',2,'外滩','2020-10-06','汽车','none','2020-10-07','汽车'),('1850001',1,'上海外滩','2020-09-16','公交车','北安跨','2020-09-16','北安跨');
/*!40000 ALTER TABLE `leaving_record` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pandemic_situation`
--

DROP TABLE IF EXISTS `pandemic_situation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pandemic_situation` (
  `province` varchar(45) NOT NULL,
  `city` varchar(45) NOT NULL,
  `risk_level` tinyint DEFAULT NULL,
  `date` date NOT NULL,
  PRIMARY KEY (`province`,`date`,`city`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pandemic_situation`
--

LOCK TABLES `pandemic_situation` WRITE;
/*!40000 ALTER TABLE `pandemic_situation` DISABLE KEYS */;
INSERT INTO `pandemic_situation` VALUES ('上海','bb定',2,'2020-09-12'),('上海','嘉定',2,'2020-09-12'),('四川','成都',0,'2020-09-05'),('四川','成都',1,'2020-09-06'),('安徽','合肥',0,'2020-09-05'),('新疆','乌鲁木齐',1,'2020-09-05'),('浙江','宁波',0,'2020-09-05'),('浙江','杭州',0,'2020-09-05'),('浙江','温州',0,'2020-09-05'),('浙江','杭州',0,'2020-09-06'),('浙江','aa',1,'2020-09-12'),('浙江','杭州',1,'2020-09-12'),('湖南','长沙',0,'2020-09-05'),('贵州','贵阳',0,'2020-09-05'),('辽宁','大连',2,'2020-09-05'),('青海','西宁',0,'2020-09-05');
/*!40000 ALTER TABLE `pandemic_situation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `quarantine_record`
--

DROP TABLE IF EXISTS `quarantine_record`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `quarantine_record` (
  `student_ID` varchar(20) NOT NULL,
  `quarantine_ID` varchar(20) NOT NULL,
  `start_day` date DEFAULT NULL,
  `end_day` date DEFAULT NULL,
  `quarantine_place` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`student_ID`,`quarantine_ID`),
  CONSTRAINT `quarantine_record_student` FOREIGN KEY (`student_ID`) REFERENCES `student` (`student_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `quarantine_record`
--

LOCK TABLES `quarantine_record` WRITE;
/*!40000 ALTER TABLE `quarantine_record` DISABLE KEYS */;
INSERT INTO `quarantine_record` VALUES ('1850001','1','2020-09-01','2020-09-15','同济迎宾馆'),('1850001','2','2020-10-01','2020-10-07','同济迎宾馆');
/*!40000 ALTER TABLE `quarantine_record` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sick_leave`
--

DROP TABLE IF EXISTS `sick_leave`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sick_leave` (
  `sickleave_ID` varchar(20) NOT NULL,
  `student_ID` varchar(20) NOT NULL,
  `teacher_ID` varchar(20) NOT NULL,
  `application_time` date DEFAULT NULL,
  `approval_time` date DEFAULT NULL,
  `allowed_time` date DEFAULT NULL,
  `terminate_time` date DEFAULT NULL,
  `reason` varchar(45) DEFAULT NULL,
  KEY `sickleave_teacher_idx` (`teacher_ID`),
  KEY `sickleave_student_idx` (`student_ID`),
  CONSTRAINT `sickleave_student` FOREIGN KEY (`student_ID`) REFERENCES `student` (`student_ID`),
  CONSTRAINT `sickleave_teacher` FOREIGN KEY (`teacher_ID`) REFERENCES `teacher` (`teacher_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sick_leave`
--

LOCK TABLES `sick_leave` WRITE;
/*!40000 ALTER TABLE `sick_leave` DISABLE KEYS */;
INSERT INTO `sick_leave` VALUES ('1','1850001','6','2020-09-18','2020-09-18','2020-09-19','2020-09-20',NULL);
/*!40000 ALTER TABLE `sick_leave` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student`
--

DROP TABLE IF EXISTS `student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `student` (
  `student_ID` varchar(20) NOT NULL,
  `Gender` tinyint DEFAULT NULL,
  `student_name` varchar(20) DEFAULT NULL,
  `password` varchar(20) DEFAULT NULL,
  `department` varchar(20) DEFAULT NULL,
  `grade` varchar(20) DEFAULT NULL,
  `class_num` int DEFAULT NULL,
  `dorm_num` varchar(20) DEFAULT NULL,
  `healthcode_color` varchar(10) DEFAULT NULL,
  `contact_way` varchar(20) DEFAULT NULL,
  `emergency_contact` varchar(20) DEFAULT NULL,
  `currenthealth_status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`student_ID`),
  KEY `class_idx` (`department`,`grade`,`class_num`),
  CONSTRAINT `class` FOREIGN KEY (`department`, `grade`, `class_num`) REFERENCES `class` (`department`, `grade`, `class_num`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student`
--

LOCK TABLES `student` WRITE;
/*!40000 ALTER TABLE `student` DISABLE KEYS */;
INSERT INTO `student` VALUES ('1650001',1,'吴九','1234','DI','16',1601,'1-102','green','19988888888','19988888888',1),('1650002',1,'郑十','1234','SSE','16',1601,'1-506','green','19999999999','19999999999',1),('1750001',0,'赵六','1234','CAUP','17',1701,'15-309','green','19955555555','19955555555',1),('1750002',1,'孙七','1234','CAUP','17',1702,'3-511','green','19966666666','19966666666',1),('1750003',1,'周八','1234','SSE','17',1701,'3-511','green','19977777777','19977777777',1),('1850001',1,'刘一','1234','SSE','18',1801,'8-317','green','18600001111','19900000000',0),('1850002',1,'陈二','1234','SSE','18',1802,'8-318','green','19911111111','19911111111',1),('1850003',0,'张三','1234','SSE','18',1803,'19-207','green','19922222222','19922222222',0),('1850004',0,'李四','1234','SSE','18',1804,'19-317','green','19933333333','19933333333',0),('1850005',0,'王五','1234','SSE','18',1805,'19-307','green','19944444444','19944444444',1);
/*!40000 ALTER TABLE `student` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teacher`
--

DROP TABLE IF EXISTS `teacher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `teacher` (
  `teacher_ID` varchar(20) NOT NULL,
  `password` varchar(20) DEFAULT NULL,
  `teacher_name` varchar(20) DEFAULT NULL,
  `department` varchar(20) DEFAULT NULL,
  `title` varchar(20) DEFAULT NULL,
  `contact_way` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`teacher_ID`),
  KEY `teacher_department_idx` (`department`),
  CONSTRAINT `teacher_department` FOREIGN KEY (`department`) REFERENCES `department` (`dept_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teacher`
--

LOCK TABLES `teacher` WRITE;
/*!40000 ALTER TABLE `teacher` DISABLE KEYS */;
INSERT INTO `teacher` VALUES ('00000',NULL,NULL,NULL,NULL,NULL),('1','123456','张老师','CAUP','教授','13800000000'),('2','123456','赵老师','DI','副教授','13811111111'),('3','123456','王老师','IS','教授','13822222222'),('4','123456','李老师','SEE','副教授','13833333333'),('5','123456','孙老师','SESE','教授','13844444444'),('55555','123','邓布利多','SESE','教授','18600001111'),('6','123456','钟老师','SSE','辅导员','13855555555'),('7','1234','格林德沃','SSE','研究员','19900000000');
/*!40000 ALTER TABLE `teacher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usage_record`
--

DROP TABLE IF EXISTS `usage_record`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usage_record` (
  `applicant_ID` varchar(10) NOT NULL,
  `facility_ID` varchar(45) DEFAULT NULL,
  `date` date DEFAULT NULL,
  `end_time` int DEFAULT NULL,
  `start_time` int DEFAULT NULL,
  `enter_time` datetime DEFAULT NULL COMMENT '打卡进入时间',
  `left_time` datetime DEFAULT NULL COMMENT '打卡离开时间',
  PRIMARY KEY (`applicant_ID`),
  KEY `facilities_idx` (`facility_ID`),
  CONSTRAINT `facilities` FOREIGN KEY (`facility_ID`) REFERENCES `facilities` (`facility_ID`),
  CONSTRAINT `student` FOREIGN KEY (`applicant_ID`) REFERENCES `student` (`student_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usage_record`
--

LOCK TABLES `usage_record` WRITE;
/*!40000 ALTER TABLE `usage_record` DISABLE KEYS */;
INSERT INTO `usage_record` VALUES ('1850001','1','2020-09-15',10,8,NULL,NULL);
/*!40000 ALTER TABLE `usage_record` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-09-13 13:52:31
