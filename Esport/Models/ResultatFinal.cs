using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esport.Models
{
    public class ResultatFinal : ResultatCompet
    {
        public List<ResultatCompet> resultatCompets;
        public override bool Add(ResultatCompet r)
        {
            return false;

        }

        public override bool Remove(ResultatCompet r)
        {
            return false;
        }
    }
    }
}
