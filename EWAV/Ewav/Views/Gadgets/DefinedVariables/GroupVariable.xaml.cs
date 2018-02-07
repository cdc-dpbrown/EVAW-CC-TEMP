using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EWAV.Web.EpiDashboard;
using EWAV.BAL;
using EWAV.ViewModels;
using EWAV.Web.Services;
using System.Text;

namespace EWAV
{
    public partial class GroupVariable : ChildWindow, IEWAVDashboardRule
    {
        bool editMode = false;
        public ApplicationViewModel applicationViewModel = ApplicationViewModel.Instance;
        EWAVRule_Format formatRule = null;
        public ListBoxItemSource SelectedItem { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public GroupVariable()
        {
            InitializeComponent();
            FillListBox();
        }

        public GroupVariable(bool editMode, ListBoxItemSource selectedItem = null)
        {
            SelectedItem = selectedItem;
            this.editMode = editMode;

           ClientCommon.Common cmnClass = new ClientCommon.Common();

            InitializeComponent();
            FillListBox();
            if (editMode)
            {
                EWAVRule_GroupVariable rule = (EWAVRule_GroupVariable)selectedItem.Rule;
                txtDestinationField.Text = rule.VaraiableName;
                txtDestinationField.IsEnabled = false;

                foreach (var item in rule.Items)
                {
                    //cbxField.SelectedIndex = cmnClass.FindIndexToSelect(cmnClass.GetItemsSource(GetFieldPrimaryDataType), child.Value.ToString().Replace("&lt;", "<"));
                    //int index = -1;
                    //lbxFieldName.ItemsSource
                    lbxFieldName.SelectedItems.Add( cmnClass.FindEWAVColumn(item.VarName, ReadColumns()));
                }
            }
            

            

        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            EWAVRule_GroupVariable rule = new EWAVRule_GroupVariable();

            if (txtDestinationField.Text.Trim().Length == 0)
            {
                MessageBox.Show("Group Field Name must be entered.");
                return;
            }

            if (lbxFieldName.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select items to include in the group.");
                return;
            }

            List<MyString> lbxItems = new List<MyString>();

            StringBuilder listOfColumnNamesSelected = new StringBuilder();

            foreach (var item in lbxFieldName.SelectedItems)
            {
                MyString itemValue = new MyString();
                itemValue.VarName = ((EWAVColumn)item).Name.ToString();
                lbxItems.Add(itemValue);
                listOfColumnNamesSelected.Append(itemValue.VarName + ",");
            }

            string friendlyLabel = "Create a variable group called " + txtDestinationField.Text + " and include: " + listOfColumnNamesSelected.ToString().Substring(0, listOfColumnNamesSelected.ToString().Length - 1);

            rule.Items = lbxItems;
            rule.VaraiableName = txtDestinationField.Text;
            rule.VaraiableDataType = ColumnDataType.GroupVariable.ToString();
            rule.FriendlyLabel = friendlyLabel;

      



            ListBoxItemSource listBoxItem = new ListBoxItemSource();
            listBoxItem.RuleString = friendlyLabel;
            //listBoxItem.SourceColumn = sourceColumn.Name;
            listBoxItem.DestinationColumn = txtDestinationField.Text;
            listBoxItem.NewColumn = txtDestinationField.Text;
            listBoxItem.RuleType = EWAVRuleType.GroupVariable;
            listBoxItem.SourceColumn = null;
            listBoxItem.Rule = rule;

            EWAVColumn newcolumn = new EWAVColumn();
            newcolumn.Name = txtDestinationField.Text;
            newcolumn.SqlDataTypeAsString = ColumnDataType.GroupVariable;
            newcolumn.NoCamelName = txtDestinationField.Text;
            newcolumn.IsUserDefined = true;

            applicationViewModel.InvokePreColumnChangedEvent();

            List<EWAVRule_Base> rules = new List<EWAVRule_Base>();
            rules = applicationViewModel.EWAVDefinedVariables;

            //Shows the error message if name already exists.
            if (!editMode)
            {
                for (int i = 0; i < applicationViewModel.EWAVDefinedVariables.Count; i++)
                {
                    if (applicationViewModel.EWAVDefinedVariables[i].VaraiableName == rule.VaraiableName)
                    {
                        MessageBox.Show("Rule Name already exists. Select another name.");
                        return;
                    }
                }
            }


            for (int i = 0; i < rules.Count; i++)
            {
                if (rule.VaraiableName == rules[i].VaraiableName)
                {
                    rules.RemoveAt(i);
                    applicationViewModel.ListOfRules.RemoveAt(i);
                    break;
                }
            }

            if (!editMode)
            {
                applicationViewModel.EWAVSelectedDatasource.AllColumns.Add(newcolumn);
            }
            applicationViewModel.ListOfRules.Add(listBoxItem);
            List<EWAVRule_Base> listOfRules = new List<EWAVRule_Base>();
            listOfRules = applicationViewModel.EWAVDefinedVariables;
            listOfRules.Add(rule);

            applicationViewModel.EWAVDefinedVariables = listOfRules;
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        public void CreateFromXml(System.Xml.Linq.XElement element)
        {
            throw new NotImplementedException();
        }

        private void FillListBox()
        {
            lbxFieldName.Items.Clear();

            //List<string> fieldNames = new List<string>();

            // ColumnDataType columnDataType = ColumnDataType.DateTime;

            List<EWAVColumn> colsList = ReadColumns();

            //colsList.Insert(0, new EWAVColumn() { Name = " ", Index = -1 });
            lbxFieldName.ItemsSource = colsList;
            lbxFieldName.SelectedValue = "Index";
            lbxFieldName.DisplayMemberPath = "Name";
            //lbxFieldName.SelectedIndex = 0;

            if (editMode)
            {
                lbxFieldName.SelectedItem = null;
            }
        }

        private List<EWAVColumn> ReadColumns()
        {
            List<EWAVColumn> SourceColumns = this.applicationViewModel.EWAVSelectedDatasource.AllColumns;

            List<ColumnDataType> columnDataType = new List<ColumnDataType>();
            columnDataType.Add(ColumnDataType.DateTime);
            columnDataType.Add(ColumnDataType.Boolean);
            columnDataType.Add(ColumnDataType.Numeric);
            columnDataType.Add(ColumnDataType.Text);
            columnDataType.Add(ColumnDataType.UserDefined);

            IEnumerable<EWAVColumn> CBXFieldCols = from cols in SourceColumns
                                                   where columnDataType.Contains(cols.SqlDataTypeAsString)
                                                   orderby cols.Name
                                                   select cols;

            List<EWAVColumn> colsList = CBXFieldCols.ToList();
            return colsList;
        }
    }
}