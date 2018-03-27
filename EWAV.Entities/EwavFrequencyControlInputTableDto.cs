using System.Collections.Generic;


namespace CDC.ISB.EIDEV.DTO
{
    public class EWAVFrequencyControlInputTableDto
    {
        public int RowsCount { get; set; }

        public string TableName { get; set; }
          
        public Dictionary<string, string> InputTable { get; set; }
    }
}