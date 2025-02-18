using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitly_Domain.Business
{
    public class Oefening
    {
        private int _idOefening;
        private string _naam;
        private string _omschrijving;
        private double _calorieën;
        private int _fkType;
        private int _herhalingen;
        private double _duur;


        public int IdOefening { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public double Calorieën { get; set; }
        public int FKType { get; set; }
        public int Herhalingen { get; set; }  
        public double Duur {  get; set; }

        public Oefening(int idOefening, string naam, string omschrijving, double calorieën, int fkType, int herhalingen, double duur)
        {
            _idOefening = idOefening;
            _naam = naam;
            _omschrijving = omschrijving;
            _calorieën = calorieën;
            _fkType = fkType;
            _herhalingen = herhalingen;
            _duur = duur;
        }

        // Constructor zonder ID (bijv. voor nieuwe objecten)
        public Oefening(string naam, string omschrijving, double calorieën, int fkType, int herhalingen, double duur)
        {
            _idOefening = 0; // Default waarde, kan later aangepast worden
            _naam = naam;
            _omschrijving = omschrijving;
            _calorieën = calorieën;
            _fkType = fkType;
            _herhalingen = herhalingen;
            _duur = duur;
        }

        public override string ToString()
        {
            return $"{IdOefening}: {Naam} - {Omschrijving} | {Calorieën} kcal | Type: {FKType}";
        }
    }
    }
