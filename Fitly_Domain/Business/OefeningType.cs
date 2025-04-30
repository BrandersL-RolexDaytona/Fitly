using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitly_Domain.Business
{
    public class OefeningType
    {
        public int IdType { get; set; }
        public string Spieren { get; set; }

        public OefeningType(int idType, string spieren)
        {
            IdType = idType;
            Spieren = spieren;
        }

        public OefeningType(string spieren)
        {
            IdType = 0;
            Spieren = spieren;
        }
        public OefeningType()
        {
            
        }

        public override string ToString()
        {
            return $"{IdType}: {Spieren}";
        }
    }

}
