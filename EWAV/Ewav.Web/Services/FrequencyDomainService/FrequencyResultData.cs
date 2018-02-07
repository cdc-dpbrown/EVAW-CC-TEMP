using System.Collections.Generic;

namespace EWAV.Web.Services
{
    public class FrequencyResultData
    {
        private List<EWAV.DTO.EWAVFrequencyControlDto> frequencyControlDtoList;
        private List<EpiDashboard.DescriptiveStatistics> descriptiveStatisticsList;

        public FrequencyResultData()
        {
        }

        public List<EWAV.DTO.EWAVFrequencyControlDto> FrequencyControlDtoList
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