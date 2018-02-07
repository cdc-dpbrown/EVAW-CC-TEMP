using System.Collections.Generic;


namespace EWAV.DTO
{
    public class EWAVFrequencyControlInputTableDto
    {
        public int RowsCount { get; set; }

        public string TableName { get; set; }
          
        public Dictionary<string, string> InputTable { get; set; }
    }
}