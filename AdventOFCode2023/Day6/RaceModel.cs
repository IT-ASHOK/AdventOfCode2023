/* -------------------------------------------------------------------------------------------------
   Restricted. Copyright (C) Siemens Healthcare GmbH, 2023. All rights reserved.
   ------------------------------------------------------------------------------------------------- */
   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    internal class RaceModel
    {
        public RaceModel(long time, long distance)
        {
            Time = time;
            Distance = distance;
            PossibleWaysToWin = new List<long>();
        }

        internal long Time { get; set; }
        internal long Distance { get; set; }

        internal List<long> PossibleWaysToWin { get; set; }
    }
}
