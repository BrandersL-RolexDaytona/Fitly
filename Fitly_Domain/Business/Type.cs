using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitly_Domain.Business
{
    internal class Type
    {

        public int IdType { get; set; }
        public string Spieren { get; set; }

        // Constructor met ID (bijvoorbeeld uit database)
        public Type(int idType, string spieren)
        {
            IdType = idType;
            Spieren = spieren;
        }

        // Constructor zonder ID (voor nieuwe objecten)
        public Type(string spieren)
        {
            IdType = 0; // Default waarde
            Spieren = spieren;
        }

        public override string ToString()
        {
            return $"{IdType}: {Spieren}";
        }
    }
}
