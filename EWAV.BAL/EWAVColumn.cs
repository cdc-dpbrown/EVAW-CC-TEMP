using System;
using System.Linq;
using EWAV.Web.EpiDashboard;

namespace EWAV.BAL
{
    public class EWAVColumn        //: IEnumerable
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string NoCamelName { get; set; }
        //public string NoCamelName(  )  
        //{
        //    Regex r = new Regex("(?<=[a-z])(?<x>[A-Z])|(?<=.)(?<x>[A-Z])(?=[a-z]) ");
        //    return r.Replace( Name,  " ${x}");
        //}
        public ColumnDataType SqlDataTypeAsString { get; set; }
        public bool IsInUse { get; set; }
        public string ChildVariableName { get; set; }
        public bool IsUserDefined { get; set; }
    }
}