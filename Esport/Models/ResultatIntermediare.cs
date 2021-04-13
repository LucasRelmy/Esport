using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esport.Models
{
    public class ResultatIntermediare : ResultatCompet
    {
        public List<ResultatCompet> resultatCompets;

        public override bool Add(ResultatCompet r)
        {
            resultatCompets.Add(r);
            return true;
        }

        public override bool Remove(ResultatCompet r)
        {
            resultatCompets.Remove(r);
            return true;

        }
    }
}
