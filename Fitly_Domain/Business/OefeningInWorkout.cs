using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitly_Domain.Business
{
    internal class OefeningInWorkout
    {
        private int _fkOefening;
        private int _fkWorkout;
        private double _duur;
        private int _aantalHerhalingen;

        public int FkOefening {  get { return _fkOefening; } set { _fkOefening = value; } }
        public int FkWorkout { get { return _fkWorkout; } set { _fkWorkout = value; } }
        public double Duur { get { return _duur; } set { _duur = value; } }
        public int AantalHerhalingen { get {  return _aantalHerhalingen;} set { _aantalHerhalingen = value; } }

        public OefeningInWorkout( int fkOefening, int fkWorkout, double duur, int aantalherhalingen)
        {
            _aantalHerhalingen= aantalherhalingen;
            _duur= duur;
            _fkOefening= fkOefening;
            _fkWorkout= fkWorkout;

        }




    }
}
