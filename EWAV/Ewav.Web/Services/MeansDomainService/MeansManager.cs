using System.Collections.Generic;
using System.Data;
using CDC.ISB.EIDEV.Web.EpiDashboard;
using CDC.ISB.EIDEV.DTO;
using CDC.ISB.EIDEV.Web.Services;

namespace CDC.ISB.EIDEV.Web
{
    public class MeansManager
    {
        public static List<CrossTabResponseObjectDto>
        ConvertCrossTabDictToDto(Dictionary<DataTable, List<DescriptiveStatistics>> dataTableDictionary, GadgetParameters gadgetParameters)
        {
            //bool columnNamesRead = false;
           
            List<CrossTabResponseObjectDto> crossTabDtoList = new List<CrossTabResponseObjectDto>();
            //KeyValuePair<DataTable, List<DescriptiveStatistics>> kvp = dataTableDictionary;

            foreach (KeyValuePair<DataTable, List<DescriptiveStatistics>> khp in dataTableDictionary)
            {
                CrossTabResponseObjectDto CrossTabDto = new CrossTabResponseObjectDto();
                DataTable dt = khp.Key;
                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    CrossTabDto.ColumnNames.Add(dt.Columns[i].ColumnName);
                    
                }
                CrossTabDto.DsList= khp.Value;
               // columnNamesRead = true;
                
                crossTabDtoList.Add(CrossTabDto);
            }

            
            return crossTabDtoList;
        }
    }
}