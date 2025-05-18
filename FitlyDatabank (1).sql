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
-- Table structure for table `oefening`
--

DROP TABLE IF EXISTS `oefening`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `oefening` (
  `idOefening` int NOT NULL AUTO_INCREMENT,
  `Naam` varchar(45) NOT NULL,
  `Omschrijving` longtext,
  `Calorieen` longtext,
  `fkType` int NOT NULL,
  `Herhalingen` int DEFAULT NULL,
  `Duur` double DEFAULT NULL,
  PRIMARY KEY (`idOefening`),
  UNIQUE KEY `idOefening_UNIQUE` (`idOefening`),
  KEY `fk_Oefening_Type_idx` (`fkType`),
  CONSTRAINT `fk_Oefening_Type` FOREIGN KEY (`fkType`) REFERENCES `type` (`idType`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `oefening`
--

LOCK TABLES `oefening` WRITE;
/*!40000 ALTER TABLE `oefening` DISABLE KEYS */;
INSERT INTO `oefening` VALUES (1,'Push-ups','Een oefening waarbij je jezelf omhoog duwt vanuit een plankpositie, gericht op de borst, triceps en core.','8',1,12,2),(2,'Squats','Sta rechtop, buig door de knieën en kom weer omhoog voor sterke benen en billen.','10',8,12,1),(3,'Deadlifts','Til een halterstang vanaf de grond omhoog voor een volledige lichaamsoefening.','12',3,5,1),(4,'Jump Rope','Springtouw oefening die het uithoudingsvermogen en de coördinatie verbetert.','12',7,NULL,1),(5,'Burpees','Een explosieve beweging met springen, planken en push-ups voor een full-body workout.','10',1,10,1),(6,'Mountain Climbers','In plankpositie snel je knieën naar de borst trekken voor een intensieve cardio-oefening.','9',7,NULL,1),(7,'Running op de plaats','Hardlopen zonder vooruit te bewegen, ideaal voor indoor cardio.','11',8,NULL,1),(8,'Yoga Poses','Rustige houdingen zoals Downward Dog en Cobra Stretch om flexibiliteit te verbeteren.','4',7,NULL,1),(9,'Dynamic Stretching','Bewegende stretches zoals beenzwaaien en armcirkels voor warming-up.','4',8,NULL,1),(10,'Plank to Cobra Stretch','Een vloeiende overgang van plank naar cobra stretch voor flexibiliteit en core.','4',7,NULL,1),(11,'Kettlebell Swings','Een dynamische oefening waarbij een kettlebell heen en weer wordt gezwaaid.','12',3,NULL,10),(12,'Battle Ropes','Snelle bewegingen met zware touwen om kracht en conditie te verbeteren.','10',6,NULL,7),(13,'Box Jumps','Spring op een verhoogd platform en land gecontroleerd voor explosieve kracht.','9',8,8,7),(14,'Farmer’s Carry','Loop een bepaalde afstand met zware gewichten in elke hand om grip en kracht te verbeteren.','8',9,NULL,7),(15,'Sprints','Ren op maximale snelheid voor korte afstanden voor kracht en uithoudingsvermogen.','14',8,NULL,1),(16,'Agility Ladder Drills','Snelle voetbewegingen door een ladder op de grond voor snelheid en coördinatie.','10',8,NULL,1),(17,'Medicine Ball Slams','Gooi een medicine bal krachtig op de grond en vang hem opnieuw.','9',4,10,1),(18,'Shadow Boxing','Slaan in de lucht met snelle bewegingen om reactievermogen en cardio te verbeteren.','10',3,NULL,1),(19,'Zumba','Dans-gebaseerde workout met hoge energie en ritmische bewegingen.','9',8,NULL,1),(20,'Aerobics','Lichaamsbeweging op muziek met veel beweging voor conditie en coördinatie.','9',8,NULL,1),(21,'Step-ups','Stap op een verhoging en wissel af met de benen voor beenkracht en balans.','8',8,NULL,1),(22,'Foam Rolling','Zelfmassage techniek met een foam roller om spierherstel te bevorderen.','3',8,NULL,1),(23,'Stretching','Statische rekoefeningen om de spieren te verlengen en herstel te versnellen.','3',7,NULL,1),(24,'Ademhalingsoefeningen','Diepe ademhaling en meditatie voor ontspanning en stressvermindering.','2',7,NULL,1);
/*!40000 ALTER TABLE `oefening` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sporter`
--

DROP TABLE IF EXISTS `sporter`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sporter` (
  `idSporter` int NOT NULL AUTO_INCREMENT,
  `Naam` tinytext,
  `Voornaam` tinytext,
  `Email` varchar(45) DEFAULT NULL,
  `Wachtwoord` varchar(45) DEFAULT NULL,
  `Geboortedatum` date DEFAULT NULL,
  `Geslacht` varchar(45) DEFAULT NULL,
  `Lengte` double DEFAULT NULL,
  `TotaleCalorieën` double DEFAULT NULL,
  PRIMARY KEY (`idSporter`),
  UNIQUE KEY `idSporter_UNIQUE` (`idSporter`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sporter`
--

LOCK TABLES `sporter` WRITE;
/*!40000 ALTER TABLE `sporter` DISABLE KEYS */;
INSERT INTO `sporter` VALUES (2,'Van Doninck','Yorben','Yorben.VD4@gmail.com','Yorben123','2007-02-09','man',182,231),(11,'Branders','Lander','mail','ww','2007-02-09','vrouw',182,12),(12,'De Peuter','Tibe','Tibe.DP7@gmail.com','TIBE123','2007-02-09','man',182,1211),(13,'Vonckx','Seppe','Seppe.Vonckx@gmail.com','SeppeVonckx','2007-02-07','man',182,NULL),(14,'Branders','Lander','mail','ww','2007-02-09','test',182,NULL),(22,'Lander','Branders','Lander.branders@gmail.com','Lander123','2007-09-02','Man',180,1245);
/*!40000 ALTER TABLE `sporter` ENABLE KEYS */;
UNLOCK TABLES;

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

--
-- Table structure for table `type`
--

DROP TABLE IF EXISTS `type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `type` (
  `idType` int NOT NULL AUTO_INCREMENT,
  `Spieren` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idType`),
  UNIQUE KEY `idType_UNIQUE` (`idType`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `type`
--

LOCK TABLES `type` WRITE;
/*!40000 ALTER TABLE `type` DISABLE KEYS */;
INSERT INTO `type` VALUES (1,'Borstspieren'),(3,'Rugspieren'),(4,'Schouderspieren'),(5,'Biceps'),(6,'Triceps'),(7,'Buikspieren'),(8,'Beenspieren'),(9,'Onderarmspieren');
/*!40000 ALTER TABLE `type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `workout`
--

DROP TABLE IF EXISTS `workout`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `workout` (
  `idWorkout` int NOT NULL AUTO_INCREMENT,
  `Herhalingen` int DEFAULT NULL,
  `NaamWorkout` varchar(45) NOT NULL,
  PRIMARY KEY (`idWorkout`),
  UNIQUE KEY `idWorkout_UNIQUE` (`idWorkout`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workout`
--

LOCK TABLES `workout` WRITE;
/*!40000 ALTER TABLE `workout` DISABLE KEYS */;
INSERT INTO `workout` VALUES (1,NULL,'Krachttraining'),(2,NULL,'Cardiotraining'),(3,NULL,'Flexibiliteit en mobiliteit'),(4,NULL,'Functionele training'),(5,NULL,'Sport-specifieke training'),(6,NULL,'Groepslessen en dans'),(7,NULL,'Hersteltraining');
/*!40000 ALTER TABLE `workout` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `workout_has_oefening`
--

DROP TABLE IF EXISTS `workout_has_oefening`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `workout_has_oefening` (
  `FKWorkout` int NOT NULL,
  `FKoefening` int NOT NULL,
  PRIMARY KEY (`FKWorkout`,`FKoefening`),
  KEY `fk_workout_has_oefening_oefening1_idx` (`FKoefening`),
  KEY `fk_workout_has_oefening_workout1_idx` (`FKWorkout`),
  CONSTRAINT `fk_workout_has_oefening_oefening1` FOREIGN KEY (`FKoefening`) REFERENCES `oefening` (`idOefening`),
  CONSTRAINT `fk_workout_has_oefening_workout1` FOREIGN KEY (`FKWorkout`) REFERENCES `workout` (`idWorkout`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workout_has_oefening`
--

LOCK TABLES `workout_has_oefening` WRITE;
/*!40000 ALTER TABLE `workout_has_oefening` DISABLE KEYS */;
INSERT INTO `workout_has_oefening` VALUES (2,6),(2,7),(3,8),(3,10),(1,12),(2,12),(1,13),(1,14),(1,15),(1,17),(2,18),(2,19),(6,19),(2,20),(6,20),(1,21),(7,22),(7,23);
/*!40000 ALTER TABLE `workout_has_oefening` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-18 17:39:55
