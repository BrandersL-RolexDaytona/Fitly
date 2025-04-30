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
        //private int _idSporter;
        //private string _naamSporter;
        //private string _voornaamSporter;
        //private string _mailSporter;
        //private string _wachtwoord;
        //private DateTime _geboortedatumSporter;
        //private double _lengte;
        //private string _geslacht;

        // Properties
        public int Id
        { get;  set; }

        public string NaamSporter
        { get; set; }

        public string VoornaamSporter
        { get; set; }
        public string MailSporter
        { get; set; }
        public string Wachtwoord
        { get; set; }
        public DateTime GeboortedatumSporter
        { get; set; }
        public double Lengte
        { get; set; }
        public string Geslacht
        { get; set; }
        public double TotaleCalorieën 
        { get; set; }
     
        public Sporter()
        {

        }
        public Sporter(int idSporter, string naamSporter, string voornaamSporter, string mailSporter,string wachtwoord, DateTime geboortedatumSporter,string geslacht, double lengte)
        {
            Id = idSporter;
            NaamSporter = naamSporter;
            VoornaamSporter = voornaamSporter;
            MailSporter = mailSporter;
            
            Wachtwoord = wachtwoord;
            GeboortedatumSporter = geboortedatumSporter;
            Lengte = lengte;
            Geslacht = geslacht; 
        }
        public Sporter(int idSporter, string naamSporter, string voornaamSporter, string mailSporter, string wachtwoord, DateTime geboortedatumSporter, string geslacht, double lengte,double totaleCalorieën)
        {
            Id = idSporter;
            NaamSporter = naamSporter;
            VoornaamSporter = voornaamSporter;
            MailSporter = mailSporter;
            TotaleCalorieën = totaleCalorieën;
            Wachtwoord = wachtwoord;
            GeboortedatumSporter = geboortedatumSporter;
            Lengte = lengte;
            Geslacht = geslacht;
        }

       
        public Sporter(string naamSporter, string voornaamSporter, string mailSporter,string wachtwoord, DateTime geboortedatumSporter,string geslacht, double lengte)
        {
            Id = 0;
            NaamSporter = naamSporter;
            VoornaamSporter = voornaamSporter;
            MailSporter = mailSporter;
            Wachtwoord = wachtwoord;
            GeboortedatumSporter = geboortedatumSporter;
            Lengte = lengte;
            Geslacht = geslacht;
        }

        public override string ToString()
        {
            return $"{Id}: {VoornaamSporter} {NaamSporter}";
        }
    }
   }

