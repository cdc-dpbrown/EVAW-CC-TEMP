using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using CDC.ISB.EIDEV.Web.EpiDashboard.Rules;

namespace CDC.ISB.EIDEV.Web.Services
{
    [DataContract]
    public class EWAVRule_SimpleAssignment : EWAVRule_Base
    {
        private string friendlyLabel;

        [DataMember]
        public string FriendlyLabel
        {
            get { return friendlyLabel; }
            set { friendlyLabel = value; }
        }

        private string txtDestinationField;
        [DataMember]
        public string TxtDestinationField
        {
            get { return txtDestinationField; }
            set { txtDestinationField = value; }
        }

        private SimpleAssignType assignmentType;
        [DataMember]
        public SimpleAssignType AssignmentType
        {
            get { return assignmentType; }
            set { assignmentType = value; }
        }

        private List<MyString> parameters;
        [DataMember]
        public List<MyString> Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }
    }
}