/* -------------------------------------------------------------------------------------------------
   Restricted. Copyright (C) Siemens Healthcare GmbH, 2023. All rights reserved.
   ------------------------------------------------------------------------------------------------- */
   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    internal class DataSet
    {
        public DataSet()
        {
            Numbers = new List<long>();  
        }
        public List<long> Numbers { get; set; }
    }
}
