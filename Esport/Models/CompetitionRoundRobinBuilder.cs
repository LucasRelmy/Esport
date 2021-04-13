using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esport.Models
{
    public class CompetitionRoundRobinBuilder : CompetitionBuilder
    {
        public override void buildPhase()
        {
            competition.Phase = new RoundRobin();
        }
    }
}
