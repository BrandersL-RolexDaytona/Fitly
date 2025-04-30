using System.Collections.Generic;
using Fitly_Domain.Business;
using Microsoft.EntityFrameworkCore;
namespace WebAppFitly.Models
{
    public class BeheerWorkoutsViewModel
    {
        public IEnumerable<Workout> Workouts { get; set; }
        public IEnumerable<OefeningType> OefeningTypes { get; set; }

        public IEnumerable<Oefening> Oefenings { get; set; }
    }
}
