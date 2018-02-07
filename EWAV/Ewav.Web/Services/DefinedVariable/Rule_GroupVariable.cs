using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace EWAV.Web.Services
{
    [DataContract]
    public class EWAVRule_GroupVariable : EWAVRule_Base
    {
        string friendlyLabel;
        [DataMember]
        public string FriendlyLabel
        {
            get { return friendlyLabel; }
            set { friendlyLabel = value; }
        }

        private string groupName;
        [DataMember]
        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; }
        }

        private List<MyString> items;
        [DataMember]
        public List<MyString> Items
        {
            get { return items; }
            set { items = value; }
        }

    }
}