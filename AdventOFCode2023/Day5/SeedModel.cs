using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    internal class SeedModel
    {
        internal List<long> Seeds { get; set; }
        internal Dictionary<long, long> Seed2SoilMap { get; set; }

        internal Dictionary<long, long> Soil2FertilizerMap { get; set; }

        internal Dictionary<long, long> Fertilizer2Water { get; set; }

        internal Dictionary<long, long> Water2Light { get; set; }

        internal Dictionary<long, long> Light2Temp { get; set; }

        internal Dictionary<long, long> Temp2Humidity { get; set; }

        internal Dictionary<long, long> Humidity2Location { get; set; }
    }

    internal class SeedToSoilMap
    {
        internal long Destination { get; set; }
        internal long Source { get; set; }
        internal long Range { get; set; }

        private Dictionary<long, long> seed2SoilMap = new Dictionary<long, long>();
    }

    
}
