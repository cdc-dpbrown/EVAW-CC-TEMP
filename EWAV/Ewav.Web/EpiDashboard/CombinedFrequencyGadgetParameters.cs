using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDC.ISB.EIDEV.Web.EpiDashboard
{
    public class EWAVCombinedFrequencyGadgetParameters
    {
        public CombineModeTypes CombineMode { get; set; }
        public bool SortHighToLow { get; set; }
        public bool ShowDenominator { get; set; }
        public string TrueValue { get; set; } 
    }
}