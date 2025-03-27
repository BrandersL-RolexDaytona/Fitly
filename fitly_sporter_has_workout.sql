-- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: fitly
-- ------------------------------------------------------
-- Server version	8.4.2

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
-- Table structure for table `sporter_has_workout`
--

DROP TABLE IF EXISTS `sporter_has_workout`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sporter_has_workout` (
  `PKSporter` int NOT NULL,
  `PKWorkout` int NOT NULL,
  `Datum` date DEFAULT NULL,
  PRIMARY KEY (`PKSporter`,`PKWorkout`),
  UNIQUE KEY `PKSporter_UNIQUE` (`PKSporter`),
  UNIQUE KEY `PKWorkout_UNIQUE` (`PKWorkout`),
  KEY `fk_Sporter_has_Workout_Workout1_idx` (`PKWorkout`),
  KEY `fk_Sporter_has_Workout_Sporter1_idx` (`PKSporter`),
  CONSTRAINT `fk_Sporter_has_Workout_Sporter1` FOREIGN KEY (`PKSporter`) REFERENCES `sporter` (`idSporter`),
  CONSTRAINT `fk_Sporter_has_Workout_Workout1` FOREIGN KEY (`PKWorkout`) REFERENCES `workout` (`idWorkout`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sporter_has_workout`
--

LOCK TABLES `sporter_has_workout` WRITE;
/*!40000 ALTER TABLE `sporter_has_workout` DISABLE KEYS */;
/*!40000 ALTER TABLE `sporter_has_workout` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-03-17 14:34:04
