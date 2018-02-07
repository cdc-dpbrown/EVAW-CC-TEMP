using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EWAV.Web.EpiDashboard;
using EWAV.BAL;
using EWAV.ViewModels;
using EWAV.Web.Services;


//Serialize Method is written in Extensions.cs
namespace EWAV
{
    public partial class AssignedExpression : ChildWindow, IEWAVDashboardRule
    {
        public ApplicationViewModel applicationViewModel = ApplicationViewModel.Instance;

        List<EWAVColumn> CBXFieldCols = new List<EWAVColumn>();
        //private string childColumn;
        private bool editMode;
        //int index = -1;
        //private EWAVColumn sourceColumn;
        //List<EWAVColumn> SourceColumns;

        public AssignedExpression(bool editMode, ListBoxItemSource selectedItem = null)
        {
            SelectedItem = selectedItem;
            this.editMode = editMode;

            InitializeComponent();

            if (editMode)
            {
                txtDestinationField.Text = selectedItem.NewColumn;
                txtExpression.Text = selectedItem.AssignExpression;
           
            }
            //else
            //{
            CBXFieldCols.Add(new EWAVColumn { Name = "Text", SqlDataTypeAsString = ColumnDataType.Text });
            CBXFieldCols.Add(new EWAVColumn { Name = "Numeric", SqlDataTypeAsString = ColumnDataType.Numeric });


            cbxDataType.ItemsSource = CBXFieldCols;
            cbxDataType.DisplayMemberPath = "Name";

            if (editMode)
            {
                if (selectedItem.DataType == "Text")
                {
                    cbxDataType.SelectedIndex = 0;
                }
                else
                {
                    cbxDataType.SelectedIndex = 1;
                }
            }
            else
            {
                cbxDataType.SelectedIndex = 0;
            }


            //}
        }

        public ListBoxItemSource SelectedItem { get; set; }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            // add data to new rule add to  list       
            // add new rule to listbox item source   kk      
            //  add column to Allcolumns  

            List<ListBoxItemSource> TempList = applicationViewModel.ListOfRules.Where(t => t.DestinationColumn.ToLower() == txtDestinationField.Text.ToLower()).ToList();
            if (TempList.Count > 0 && !editMode)
            {
                MessageBox.Show("Variable name already exists.");
                return;
            }


            EWAVRule_ExpressionAssign ea = new EWAVRule_ExpressionAssign();
            ea.Expression = txtExpression.Text;

            if (((EWAVColumn)cbxDataType.SelectedItem).SqlDataTypeAsString.ToString() == "Text")
            {
                ea.DataType = "System.String";

            }
            else if (((EWAVColumn)cbxDataType.SelectedItem).SqlDataTypeAsString.ToString() == "Numeric")
            {
                ea.DataType = "System.Decimal";
            }

            //   "System.String";
            ea.FriendlyRule = string.Format("Assign {0} the expression: {1}", txtDestinationField.Text, txtExpression.Text);
            ea.DestinationColumnName = txtDestinationField.Text;
            ea.VaraiableName = txtDestinationField.Text;

            List<EWAVRule_Base> rules = new List<EWAVRule_Base>();
            rules = applicationViewModel.EWAVDefinedVariables;

            //Shows the error message if name already exists.
            if (!editMode)
            {
                for (int i = 0; i < applicationViewModel.EWAVDefinedVariables.Count; i++)
                {
                    if (applicationViewModel.EWAVDefinedVariables[i].VaraiableName == ea.VaraiableName)
                    {
                        MessageBox.Show("Rule Name already exists. Select another name.");
                        return;
                    }
                }
            }

            for (int i = 0; i < rules.Count; i++)
            {
                if (ea.DestinationColumnName == rules[i].VaraiableName)
                {
                    rules.RemoveAt(i);
                    applicationViewModel.ListOfRules.RemoveAt(i);
                    break;
                }
            }

            //EWAVRule_ExpressionAssign ea = new EWAVRule_ExpressionAssign();
            //ea.Expression = txtExpression.Text;

            //ea.DataType = "System.String";
            //ea.FriendlyRule = "Assign " + txtDestinationField.Text + " the expression: " + txtExpression.Text;
            //ea.DestinationColumnName = txtDestinationField.Text;

            applicationViewModel.InvokePreColumnChangedEvent();



          //   applicationViewModel.EWAVDefinedVariables.Add(ea);

            ListBoxItemSource listBoxItem = new ListBoxItemSource();
            listBoxItem.RuleString = ea.FriendlyRule;
            listBoxItem.NewColumn = txtDestinationField.Text;
            listBoxItem.AssignExpression = txtExpression.Text;
            listBoxItem.DataType = ((EWAVColumn)cbxDataType.SelectedItem).SqlDataTypeAsString.ToString();
            listBoxItem.DestinationColumn = txtDestinationField.Text;
            listBoxItem.SourceColumn = null;
            listBoxItem.RuleType = EWAVRuleType.Assign;

            ea.VaraiableDataType = ((EWAVColumn)cbxDataType.SelectedItem).SqlDataTypeAsString.ToString();

            listBoxItem.Rule = ea;
            EWAVColumn newColumn = new EWAVColumn();
            newColumn.Name = txtDestinationField.Text;
            newColumn.SqlDataTypeAsString = ((EWAVColumn)cbxDataType.SelectedItem).SqlDataTypeAsString;
            newColumn.NoCamelName = txtDestinationField.Text;
            newColumn.IsUserDefined = true;

            if (editMode == false)
            {
                applicationViewModel.EWAVSelectedDatasource.AllColumns.Add(newColumn);
            }

            applicationViewModel.ListOfRules.Add(listBoxItem);

            List<EWAVRule_Base> tempList = applicationViewModel.EWAVDefinedVariables;
            tempList.Add(ea);

            applicationViewModel.EWAVDefinedVariables = tempList;

            this.DialogResult = true;
        }

        void IEWAVDashboardRule.CreateFromXml(System.Xml.Linq.XElement element)
        {
            throw new NotImplementedException();
        }
    }
}