using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitly_Domain.Business
{
    internal class WorkoutDatum
    {
        private int _fkWorkout;
        private int _fkSporter;
        private DateTime _datum;

        public int FkSporter { get { return _fkSporter; } set { _fkSporter = value; } }
        public int FkWorkout { get { return _fkWorkout; } set { _fkWorkout = value; } }
        public DateTime Datum { get { return _datum; } set { _datum = value; } }

        public WorkoutDatum(int fkSporter, int fkWorkout, DateTime datum)
        {
            _fkSporter= fkSporter;
            _fkWorkout = fkWorkout;
            _datum = datum;

        }
    }
}
