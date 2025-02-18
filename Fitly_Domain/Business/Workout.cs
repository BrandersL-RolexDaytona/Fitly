using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitly_Domain.Business
{
    public class Workout
    {
        private int _idWorkout;
        private string _naamWorkout;
        
        public int IdWorkout { get; set; }
        public string Naamworkout { get; set; }
        

        public Workout(int idWorkout, string naamWorkout)
        {
            IdWorkout = idWorkout;
            _naamWorkout = naamWorkout;
            
            
        }

        

        public override string ToString()
        {
            return _naamWorkout;
        }
    
}
    }
