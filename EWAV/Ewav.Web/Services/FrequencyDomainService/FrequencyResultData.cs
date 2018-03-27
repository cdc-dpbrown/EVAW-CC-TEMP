using System.Collections.Generic;

namespace CDC.ISB.EIDEV.Web.Services
{
    public class FrequencyResultData
    {
        private List<CDC.ISB.EIDEV.DTO.EWAVFrequencyControlDto> frequencyControlDtoList;
        private List<EpiDashboard.DescriptiveStatistics> descriptiveStatisticsList;

        public FrequencyResultData()
        {
        }

        public List<CDC.ISB.EIDEV.DTO.EWAVFrequencyControlDto> FrequencyControlDtoList
        {
            get { return frequencyControlDtoList; }
            set { frequencyControlDtoList = value; }
        }    
   
        public List<EpiDashboard.DescriptiveStatistics> DescriptiveStatisticsList
        {
            get { return descriptiveStatisticsList; }
            set { descriptiveStatisticsList = value; }
        }
   
    }
}