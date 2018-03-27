using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using CDC.ISB.EIDEV.Web.EpiDashboard.Rules;

namespace CDC.ISB.EIDEV.Web.Services
{
    [DataContract]
    public class EWAVRule_Format : EWAVRule_Base
    {
        string friendlyLabel;
        [DataMember]
        public string FriendlyLabel
        {
            get { return friendlyLabel; }
            set { friendlyLabel = value; }
        }

        string cbxFieldName;
        [DataMember]
        public string CbxFieldName
        {
            get
            {
                return cbxFieldName;
            }
            set
            {
                cbxFieldName = value;
            }
        }

        string txtDestinationField;

        [DataMember]
        public string TxtDestinationField
        {
            get
            {
                return txtDestinationField;
            }
            set
            {
                txtDestinationField = value;
            }
        }

        string cbxFormatOptions;
        [DataMember]
        public string CbxFormatOptions
        {
            get
            {
                return cbxFormatOptions;
            }
            set
            {
                cbxFormatOptions = value;
            }
        }

        FormatTypes formatTypes;
        [DataMember]
        public FormatTypes FormatTypes
        {
            get
            {
                return formatTypes;
            }
            set
            {
                formatTypes = value;
            }
        }
    }
}