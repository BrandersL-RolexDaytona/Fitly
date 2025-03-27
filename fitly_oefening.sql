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
  `Naam` varchar(45) DEFAULT NULL,
  `Omschrijving` longtext,
  `Calorieen` longtext,
  `Type_idType` int NOT NULL,
  `Herhalingen` int DEFAULT NULL,
  `Duur` double DEFAULT NULL,
  `workout_idWorkout` int NOT NULL,
  PRIMARY KEY (`idOefening`,`Type_idType`,`workout_idWorkout`),
  UNIQUE KEY `idOefening_UNIQUE` (`idOefening`),
  KEY `fk_Oefening_Type_idx` (`Type_idType`),
  KEY `fk_oefening_workout1_idx` (`workout_idWorkout`),
  CONSTRAINT `fk_Oefening_Type` FOREIGN KEY (`Type_idType`) REFERENCES `type` (`idType`),
  CONSTRAINT `fk_oefening_workout1` FOREIGN KEY (`workout_idWorkout`) REFERENCES `workout` (`idWorkout`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `oefening`
--

LOCK TABLES `oefening` WRITE;
/*!40000 ALTER TABLE `oefening` DISABLE KEYS */;
INSERT INTO `oefening` VALUES (1,'Squat','Een oefening voor de beenspieren waarbij je door je knieën zakt en weer omhoog komt.','50',8,12,30,1),(2,'Deadlift','Een oefening waarbij je een gewicht van de grond tilt, goed voor de hele achterkant van het lichaam.','70',3,10,45,2),(3,'Bench Press','Een oefening waarbij je liggend een halterstang naar je borst brengt en weer omhoog duwt.','60',1,10,35,3),(4,'Pull-up','Een oefening waarbij je jezelf optrekt aan een stang, gericht op de rug en armen.','40',3,8,20,4),(5,'Lunges','Een beenoefening waarbij je een grote stap zet en je knie naar de grond laat zakken.','45',8,12,30,1),(6,'Plank','Een core-oefening waarbij je je lichaam in een rechte lijn houdt terwijl je op je onderarmen steunt.','30',7,1,2,5),(7,'Bicep Curl','Een oefening waarbij je gewichten optilt door je elleboog te buigen, gericht op de biceps.','25',5,12,25,6),(8,'Tricep Dips','Een oefening waarbij je je lichaam laat zakken en weer omhoog duwt met de triceps.','35',6,12,20,7),(9,'Leg Press','Een oefening waarbij je een gewicht wegduwt met je benen terwijl je zit.','55',8,10,30,1),(10,'Shoulder Press','Een oefening waarbij je gewichten boven je hoofd drukt, gericht op de schouders.','50',4,10,25,1);
/*!40000 ALTER TABLE `oefening` ENABLE KEYS */;
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
