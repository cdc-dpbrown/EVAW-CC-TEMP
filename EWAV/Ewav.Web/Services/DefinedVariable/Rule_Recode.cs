using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EWAV.Web.EpiDashboard;
using EWAV.Web.EpiDashboard.Rules;
using System.Runtime.Serialization;

namespace EWAV.Web.Services
{
    [DataContract]
    public class EWAVRule_Recode : EWAVRule_Base
    {
        private string friendlyrule;

        [DataMember]
        public string Friendlyrule
        {
            get
            {
                return friendlyrule;
            }
            set
            {
                friendlyrule = value;
            }
        }

        private string sourceColumnName;

        [DataMember]
        public string SourceColumnName
        {
            get
            {
                return sourceColumnName;
            }
            set
            {
                sourceColumnName = value;
            }
        }

        private string sourceColumnType;

        [DataMember]
        public string SourceColumnType
        {
            get
            {
                return sourceColumnType;
            }
            set
            {
                sourceColumnType = value;
            }
        }

        private string txtDestinationField;

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

        private DashboardVariableType destinationFieldType;

        [DataMember]
        public DashboardVariableType DestinationFieldType
        {
            get
            {
                return destinationFieldType;
            }
            set
            {
                destinationFieldType = value;
            }
        }

        private List<EWAVRuleRecodeDataRow> recodeTable;

        [DataMember]
        public List<EWAVRuleRecodeDataRow> RecodeTable
        {
            get
            {
                return recodeTable;
            }
            set
            {
                recodeTable = value;
            }
        }

        private string txtElseValue;

        [DataMember]
        public string TxtElseValue
        {
            get
            {
                return txtElseValue;
            }
            set
            {
                txtElseValue = value;
            }
        }

        private bool checkboxMaintainSortOrderIndicator;

        [DataMember]
        public bool CheckboxMaintainSortOrderIndicator
        {
            get
            {
                return checkboxMaintainSortOrderIndicator;
            }
            set
            {
                checkboxMaintainSortOrderIndicator = value;
            }
        }

        private bool checkboxUseWildcardsIndicator;

        [DataMember]
        public bool CheckboxUseWildcardsIndicator
        {
            get
            {
                return checkboxUseWildcardsIndicator;
            }
            set
            {
                checkboxUseWildcardsIndicator = value;
            }
        }

        public EWAVRule_Recode()
        {
        }
    }

}