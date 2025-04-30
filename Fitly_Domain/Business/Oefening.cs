using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitly_Domain.Business
{
    public class Oefening
    {
        

        public int IdOefening { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public double Calorieën { get; set; }
        public int FKType { get; set; }
        public int Herhalingen { get; set; }  
        public double Duur {  get; set; }


        public Oefening()
        {
        }
        public Oefening(int idOefening, string naam, string omschrijving, double calorieën, int fkType, int herhalingen, double duur)
        {
            IdOefening = idOefening;
            Naam = naam;
            Omschrijving = omschrijving;
            Calorieën = calorieën;
            FKType = fkType;
            Herhalingen = herhalingen;
            Duur = duur;
        }

       
        public Oefening(string naam, string omschrijving, double calorieën, int fkType, int herhalingen, double duur)
        {
            IdOefening = 0; 
            Naam = naam;
            Omschrijving = omschrijving;
            Calorieën = calorieën;
            FKType = fkType;
            Herhalingen = herhalingen;
            Duur = duur;
        }

        public override string ToString()
        {
            return $"{IdOefening}: {Naam} - {Omschrijving} | {Calorieën} kcal | Type: {FKType}";
        }
    }
    }
