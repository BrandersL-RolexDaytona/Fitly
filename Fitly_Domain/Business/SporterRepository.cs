using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitly_Domain.Business
{
    static internal class SporterRepository
    {
        private static List<Sporter> _sporterLijst;
        public static List<Sporter> SporterLijst
        {
            get { return _sporterLijst; }
            set { _sporterLijst = value; }
        }
    }
}
