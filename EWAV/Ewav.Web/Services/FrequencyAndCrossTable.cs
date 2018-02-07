using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EWAV.Web.Services
{
    public class FrequencyAndCrossTable
    {
        private List<CrossTabResponseObjectDto> crossTable;

        public List<CrossTabResponseObjectDto> CrossTable
        {
            get { return crossTable; }
            set { crossTable = value; }
        }

        private List<FrequencyResultData> frequencyTable;

        public List<FrequencyResultData> FrequencyTable
        {
            get { return frequencyTable; }
            set { frequencyTable = value; }
        }
    }
}