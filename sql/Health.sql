-- MySQL dump 10.13  Distrib 5.5.59, for debian-linux-gnu (armv7l)
--
-- Host: localhost    Database: Health
-- ------------------------------------------------------
-- Server version	5.5.59-0+deb8u1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Gewicht`
--

DROP TABLE IF EXISTS `Gewicht`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Gewicht` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Datum` datetime NOT NULL,
  `Wert` decimal(5,2) NOT NULL,
  `MandantID` int(11) NOT NULL,
  `Bemerkung` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_Gewicht_Mandant` (`MandantID`),
  CONSTRAINT `FK_Gewicht_Mandant` FOREIGN KEY (`MandantID`) REFERENCES `Mandant` (`MandantID`)
) ENGINE=InnoDB AUTO_INCREMENT=95 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Gewicht`
--

LOCK TABLES `Gewicht` WRITE;
/*!40000 ALTER TABLE `Gewicht` DISABLE KEYS */;
INSERT INTO `Gewicht` VALUES (1,'2019-07-22 20:00:00',83.50,2,''),(2,'2019-07-23 02:00:00',84.50,2,NULL),(3,'2019-07-23 11:00:00',83.30,2,NULL),(4,'2019-07-24 01:00:00',84.20,2,NULL),(5,'2019-07-24 09:00:00',81.70,2,NULL),(6,'2019-07-24 20:00:00',84.20,2,NULL),(7,'2019-07-24 22:00:00',83.10,2,NULL),(8,'2019-07-25 12:00:00',80.00,2,NULL),(9,'2019-07-25 22:00:00',82.70,2,NULL),(10,'2019-07-26 10:00:00',82.00,2,NULL),(11,'2019-07-27 01:00:00',84.30,2,NULL),(12,'2019-07-27 11:00:00',81.50,2,NULL),(13,'2019-07-27 18:00:00',81.20,2,NULL),(18,'2019-07-28 11:00:00',81.80,2,NULL),(19,'2019-07-28 23:30:00',82.90,2,NULL),(20,'2019-07-29 09:00:00',81.50,2,NULL),(21,'2019-07-29 13:30:00',81.30,2,NULL),(22,'2019-07-30 10:00:38',82.30,2,NULL),(23,'2019-07-30 20:00:32',82.50,2,NULL),(24,'2019-07-31 13:47:13',82.40,2,NULL),(25,'2019-07-31 09:30:00',81.90,2,NULL),(26,'2019-07-31 14:30:00',82.00,2,NULL),(27,'2019-07-31 18:30:00',83.80,2,NULL),(28,'2019-08-01 12:00:00',82.60,2,NULL),(29,'2019-08-02 13:00:00',81.10,2,NULL),(30,'2019-08-02 18:00:00',83.50,2,NULL),(31,'2019-08-03 12:00:00',81.70,2,NULL),(32,'2019-08-03 18:00:00',83.70,2,NULL),(33,'2019-08-04 02:00:00',83.60,2,NULL),(34,'2019-08-04 20:30:00',83.20,2,NULL),(35,'2019-08-05 10:00:00',81.80,2,NULL),(36,'2019-08-06 12:00:00',82.00,2,NULL),(37,'2019-08-06 20:00:51',83.70,2,NULL),(38,'2019-08-10 11:00:00',83.00,2,NULL),(39,'2019-08-10 22:00:00',83.70,2,NULL),(40,'2019-08-11 12:00:00',82.50,2,NULL),(41,'2019-08-12 00:00:00',80.50,2,NULL),(42,'2019-08-13 12:00:00',82.70,2,NULL),(43,'2019-08-14 13:00:00',82.10,2,NULL),(44,'2019-08-15 11:00:00',82.60,2,'mit Klamotten, nichts gegessen'),(45,'2019-08-16 13:00:00',81.00,2,NULL),(46,'2019-08-17 11:30:00',81.90,2,NULL),(47,'2019-08-17 23:35:39',83.10,2,NULL),(48,'2019-08-18 11:36:18',81.40,2,NULL),(49,'2019-08-19 13:21:38',79.10,2,'am Vortag wenig gegessen, gerade mim Fahrrad beim B√ºrgeramt u. Gohlis-Arkaden gewesen'),(50,'2019-08-20 00:56:24',80.60,2,NULL),(51,'2019-08-20 11:05:19',81.10,2,NULL),(53,'2019-08-21 11:00:00',81.50,2,NULL),(54,'2019-08-21 15:00:00',81.60,2,NULL),(55,'2019-08-22 11:00:00',81.40,2,NULL),(56,'2019-08-23 13:00:00',81.70,2,NULL),(57,'2019-08-24 03:00:00',80.90,2,NULL),(58,'2019-08-24 11:00:00',81.70,2,NULL),(59,'2019-08-24 14:21:20',82.20,2,NULL),(60,'2019-08-25 11:00:00',80.40,2,NULL),(61,'2019-08-25 23:00:00',82.20,2,NULL),(62,'2019-08-26 11:00:00',81.70,2,NULL),(65,'2019-08-26 15:24:55',0.00,5,NULL),(66,'2019-08-26 15:25:01',999.99,5,NULL),(67,'2019-08-26 21:56:06',82.40,2,NULL),(68,'2019-08-27 10:00:00',81.50,2,'nach Blutentnahme durch Cholette und Fahrt zur Praxis Zwicker und zur√ºck, ohne Fr√ºhst√ºck'),(69,'2019-08-28 12:30:45',80.30,2,NULL),(70,'2019-08-28 17:53:30',77.60,2,'wenig gegessen heut und am Vortag'),(71,'2019-08-29 10:45:07',81.00,2,NULL),(72,'2019-08-30 13:00:00',80.60,2,NULL),(73,'2019-08-31 15:00:00',80.70,2,NULL),(74,'2019-09-01 11:00:00',80.90,2,NULL),(75,'2019-09-02 12:00:00',82.50,2,NULL),(76,'2019-09-04 16:00:00',80.90,2,NULL),(77,'2019-09-05 13:00:00',81.30,2,NULL),(78,'2019-09-05 22:00:06',82.70,2,NULL),(79,'2019-09-06 23:00:00',81.30,2,NULL),(80,'2019-09-07 13:00:00',81.10,2,'nachm Speedway'),(81,'2019-09-08 16:00:00',82.60,2,NULL),(82,'2019-09-08 22:00:00',84.20,2,NULL),(83,'2019-09-09 16:00:00',82.70,2,NULL),(84,'2019-09-10 12:00:50',81.30,2,NULL),(85,'2019-09-15 10:51:39',81.10,2,NULL),(86,'2019-09-11 12:00:00',80.80,2,NULL),(87,'2019-09-12 12:00:00',80.50,2,NULL),(88,'2019-09-13 13:00:00',81.00,2,NULL),(89,'2019-09-14 11:00:00',81.10,2,NULL),(90,'2019-09-14 22:00:00',84.60,2,NULL),(91,'2019-09-16 12:00:03',79.30,2,NULL),(92,'2019-09-16 15:32:15',83.80,2,NULL),(93,'2019-09-17 23:41:06',83.00,2,NULL),(94,'2019-09-18 20:20:32',83.40,2,NULL);
/*!40000 ALTER TABLE `Gewicht` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Login`
--

DROP TABLE IF EXISTS `Login`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Login` (
  `LoginID` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(255) NOT NULL,
  `Password` binary(255) DEFAULT NULL,
  `MandantID` int(11) NOT NULL,
  `ChangeDate` datetime NOT NULL,
  PRIMARY KEY (`LoginID`),
  UNIQUE KEY `UQ_Login_Username` (`Username`),
  KEY `FK_Login_Mandant` (`MandantID`),
  KEY `IX_Login_Username_Password` (`Username`,`Password`),
  CONSTRAINT `FK_Login_Mandant` FOREIGN KEY (`MandantID`) REFERENCES `Mandant` (`MandantID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Login`
--

LOCK TABLES `Login` WRITE;
/*!40000 ALTER TABLE `Login` DISABLE KEYS */;
INSERT INTO `Login` VALUES (1,'dunkelan','Ú]5P\Ì~ΩXcj˛ê\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0',2,'2019-08-19 17:48:49');
/*!40000 ALTER TABLE `Login` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Mandant`
--

DROP TABLE IF EXISTS `Mandant`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Mandant` (
  `MandantID` int(11) NOT NULL AUTO_INCREMENT,
  `ParentMandantID` int(11) DEFAULT NULL,
  `Des` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `SecurityToken` binary(40) DEFAULT NULL,
  `ChangeDate` datetime NOT NULL,
  PRIMARY KEY (`MandantID`),
  KEY `FK_Mandant_Mandant` (`ParentMandantID`),
  CONSTRAINT `FK_Mandant_Mandant` FOREIGN KEY (`ParentMandantID`) REFERENCES `Mandant` (`MandantID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Mandant`
--

LOCK TABLES `Mandant` WRITE;
/*!40000 ALTER TABLE `Mandant` DISABLE KEYS */;
INSERT INTO `Mandant` VALUES (1,NULL,'Root',NULL,'2019-07-28 18:48:41'),(2,1,'Andre',NULL,'2019-07-28 18:48:41'),(5,2,'Andre Test',NULL,'2019-07-28 19:33:59'),(7,2,'qwertzuio',NULL,'2019-07-28 19:37:30'),(8,2,'qwertzuio',NULL,'2019-07-28 19:37:32');
/*!40000 ALTER TABLE `Mandant` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Settings`
--

DROP TABLE IF EXISTS `Settings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Settings` (
  `SettingsID` int(11) NOT NULL,
  `MandantID` int(11) NOT NULL,
  `SettingsValue` varchar(255) CHARACTER SET utf8 NOT NULL,
  `ChangeDate` datetime NOT NULL,
  PRIMARY KEY (`SettingsID`,`MandantID`),
  KEY `FK_Settings_Mandant` (`MandantID`),
  CONSTRAINT `FK_Settings_Mandant` FOREIGN KEY (`MandantID`) REFERENCES `Mandant` (`MandantID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Settings`
--

LOCK TABLES `Settings` WRITE;
/*!40000 ALTER TABLE `Settings` DISABLE KEYS */;
INSERT INTO `Settings` VALUES (1,2,'kg','2019-08-15 15:14:49');
/*!40000 ALTER TABLE `Settings` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-09-24  6:25:06
