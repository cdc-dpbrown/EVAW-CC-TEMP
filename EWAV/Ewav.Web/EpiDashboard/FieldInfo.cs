using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CDC.ISB.EIDEV.Web.EpiDashboard
{
    public class FieldInfo
    {
        public string RelationName;
        public string FieldName;	//sourceObject table fields name
        public string FieldAlias;	//destination table fields name
        public string Aggregate;
    }
}