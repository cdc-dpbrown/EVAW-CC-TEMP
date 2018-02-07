using System.Windows.Controls;
using EWAV.Web.Services;

namespace EWAV.ViewModels
{
    public class ListBoxItemSource
    {
        /// <summary>
        /// Gets or sets the new column.
        /// </summary>
        /// <value>The new column.</value>
        public string NewColumn { get; set; }

        /// <summary>
        /// Gets or sets the assign expression.
        /// </summary>
        /// <value>The assign expression.</value>
        public string AssignExpression { get; set; }

        public string RuleString { get; set; }

        public string SourceColumn { get; set; }

        public string DestinationColumn { get; set; }

        public string DataType;

        public EWAVRuleType RuleType { get; set; }

        public EWAVRule_Base Rule { get; set; }

        public Panel FilterConditionsPanel { get; set; }
    }
}