namespace EWAV.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    /// 
    [DataContract]    
    public class SecurityLevelDTO
    {


        public int SecurityLevelID { get; set; }
        public int SecurityLevelValue { get; set; }
        public string SecurityLevelDescription { get; set; }
			

    }
}