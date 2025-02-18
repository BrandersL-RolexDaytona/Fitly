using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitly_Domain.Business
{
    public class Sporter
    {

        // Velden
        private int _idSporter;
        private string _naamSporter;
        private string _voornaamSporter;
        private string _mailSporter;
        private string _wachtwoord;
        private DateTime _geboortedatumSporter;
        private double _lengte;
        private string _geslacht;

        // Properties
        public int IdSporter
        { get { return _idSporter; } }

        public string NaamSporter
        { get { return _naamSporter; } }

        public string VoornaamSporter
        { get { return _voornaamSporter ; } }

        public string MailSporter
        { get { return _mailSporter; } }

        public string Wachtwoord
        { get { return _wachtwoord; } }

        public DateTime GeboortedatumSporter
        { get { return _geboortedatumSporter; } } 

        public double Lengte
        { get { return _lengte; } }
        public string Geslacht
        { get { return _geslacht; } }

        // Constructor met ID (bijv. voor bestaande databaseobjecten)
        public Sporter(int idSporter, string naamSporter, string voornaamSporter, string mailSporter,string wachtwoord, DateTime geboortedatumSporter,string geslacht, double lengte)
        {
            _idSporter = idSporter;
            _naamSporter = naamSporter;
            _voornaamSporter = voornaamSporter;
            _mailSporter = mailSporter;
            _wachtwoord = wachtwoord;
            _geboortedatumSporter = geboortedatumSporter;
            _lengte = lengte;
            _geslacht = geslacht; 
        }

        // Constructor zonder ID (bijv. voor nieuwe objecten)
        public Sporter(string naamSporter, string voornaamSporter, string mailSporter,string wachtwoord, DateTime geboortedatumSporter,string geslacht, double lengte)
        {
            _idSporter = 0; // Default ID
            _naamSporter = naamSporter;
            _voornaamSporter = voornaamSporter;
            _mailSporter = mailSporter;
            _wachtwoord = wachtwoord;
            _geboortedatumSporter = geboortedatumSporter;
            _lengte = lengte;
            _geslacht = geslacht;
        }

        // ToString methode
        public override string ToString()
        {
            return $"{_idSporter}: {_voornaamSporter} {_naamSporter}";
        }
    }
   }

