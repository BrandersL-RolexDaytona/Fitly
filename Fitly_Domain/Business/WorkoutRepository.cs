using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitly_Domain.Business
{
    static internal class WorkoutRepository
    {
        private static List<Workout> _workoutLijst;
        public static List<Workout> WorkoutLijst
        {
            get { return _workoutLijst; }
            set { _workoutLijst = value; }
        }
    }
}

