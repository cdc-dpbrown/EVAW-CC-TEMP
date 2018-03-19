using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;
using CommonLibrary;
using EWAV.Web.EpiDashboard;
using EWAV.BAL;
using EWAV.Client.Application;
using EWAV.Common;
using EWAV.ExtensionMethods;
using EWAV.ViewModels;
using EWAV.Web.Services;

namespace EWAV
{
    /// <summary>
    /// Interaction logic for EpiCurve.xaml
    /// </summary>
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(UserControl))]
    [ExportMetadata("type", "chart")]
    [ExportMetadata("tabindex", "11")]
    public partial class EpiCurve : UserControl, IGadget, IEWAVGadget, IChartControl
    {
        private readonly char[] SplitTokens = " \t;".ToCharArray();
        private ApplicationViewModel applicationViewModel = ApplicationViewModel.Instance;
        private bool loadingCombos;
        private TextBlock textBlockX, textBlockY;
        private bool isBooleanWithNoStratas = false;
        private GadgetParameters gadgetOptions;
        private object syncLock = new object();
        private object objXAxisStart;
        private object objXAxisEnd;
        DatatableBag databag;
        // dpb DashboardPanel dbp;
        EpiCurveViewModel eCrvViewModel;
        List<string> dateColumnNames = new List<string>();
        List<string> numericColumnNames = new List<string>();
        List<List<StringDataValue>> dataValues = new List<List<StringDataValue>>();
        public event GadgetProcessingFinishedHandler GadgetProcessingFinished;
        public event GadgetStatusUpdateHandler GadgetStatusUpdate;
        public event GadgetCheckForCancellationHandler GadgetCheckForCancellation;
        int Index1 = -1, Index2 = -1;
        EWAVColumn Col1 = null, Col2 = null, DFInUse = null;
        // dpb XYChart epiCurveChart = null;
        // dpb CompositeSeries compositeSeries = null;
        private delegate void SetStatusDelegate(string statusMessage);
        private delegate void RequestUpdateStatusDelegate(string statusMessage);
        private delegate bool CheckForCancellationDelegate();
        private delegate void RenderFinishWithErrorDelegate(string errorMessage);
        private delegate void RenderFinishWithWarningDelegate(string errorMessage);

        private delegate void RenderFinishSingleChartDelegate(List<List<StringDataValue>> stratifiedValues);

        private delegate void SimpleCallback();
        private bool loadingDropDowns = false;

        private long recordCount;

        public long RecordCount
        {
            get { return recordCount; }
            set { recordCount = value; }
        }

        public List<EWAVDataFilterCondition> GadgetFilters { get; set; }

        public bool LoadingDropDowns
        {
            get
            {
                return loadingDropDowns;
            }
            set
            {
                loadingDropDowns = value;
            }
        }
        public class StringDataValue
        {
            public double DependentValue { get; set; }
            public string IndependentValue { get; set; }
            public string StratificationValue { get; set; }
            public double CurrentMeanValue { get; set; }
        }

        public class NumericDataValue
        {
            public decimal DependentValue { get; set; }
            public decimal IndependentValue { get; set; }
        }

        public class TypeStringTuple
        {
            public Type Item1 { get; set; }
            public string Item2 { get; set; }
            public TypeStringTuple(Type item1, string item2)
            {
                Item1 = item1;
                Item2 = item2;
            }
        }

        public bool LoadingCanvas { get; set; }

        public List<ColumnDataType> GetFieldDateDataType
        {
            get
            {
                List<ColumnDataType> columnDataType = new List<ColumnDataType>();
                columnDataType.Add(ColumnDataType.DateTime);
                return columnDataType;
            }
        }

        public List<ColumnDataType> GetFieldStatusDataType
        {
            get
            {
                List<ColumnDataType> columnDataType = new List<ColumnDataType>();

                columnDataType.Add(ColumnDataType.Numeric);
                columnDataType.Add(ColumnDataType.Boolean);
                columnDataType.Add(ColumnDataType.Text);

                return columnDataType;
            }
        }

        public EpiCurve()
        {
            InitializeComponent();

            gadgetOptions = new GadgetParameters();

            
            gadgetOptions.ShouldIncludeFullSummaryStatistics = false;
            gadgetOptions.ShouldIncludeMissing = false;
            gadgetOptions.ShouldSortHighToLow = false;
            gadgetOptions.ShouldUseAllPossibleValues = false;
            gadgetOptions.StrataVariableNames = new List<string>();

            XAxisLabel = YAxisLabel = ChartTitle = "";

            this.Loaded += new RoutedEventHandler(EpiCurve_Loaded);

            FillDropDowns();
        }

        void EpiCurve_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeControl();
        }

        private void InitializeControl()
        {
            cbxDateField.SelectionChanged += new SelectionChangedEventHandler(ConfigField_SelectionChanged);
            cbxCaseStatusField.SelectionChanged += new SelectionChangedEventHandler(ConfigField_SelectionChanged);
            try
            {
                DatatableBag eCrvData = new DatatableBag();
                eCrvViewModel = (EpiCurveViewModel)this.DataContext;

                eCrvViewModel.EpiCurveTableLoadedEvent += new EventHandler<SimpleMvvmToolkit.NotificationEventArgs<Exception>>(eCrvViewModel_EpiCurveTableLoadedEvent);
                     
                applicationViewModel.ApplyDataFilterEvent += new ApplyFilterEventHandler(applicationViewModel_ApplyDataFilterEvent);
                applicationViewModel.UnloadedEvent += new UnloadedEventHandler(applicationViewModel_UnloadedEvent);
                
                eCrvViewModel.ErrorNotice += new EventHandler<SimpleMvvmToolkit.NotificationEventArgs<Exception>>(eCrvViewModel_ErrorNotice);
            }
            catch (Exception)
            {
                throw;
            }

            this.IsProcessing = false;

            this.GadgetStatusUpdate += new GadgetStatusUpdateHandler(RequestUpdateStatusMessage);
            this.GadgetCheckForCancellation += new GadgetCheckForCancellationHandler(IsCancelled);
        }

        void applicationViewModel_PreColumnChangedEvent(object o)
        {
            SaveColumnValues();
        }

        void applicationViewModel_DefinedVariableNotInUseDeletedEvent(object o)
        {
            SearchIndex();
            LoadingDropDowns = true;
            FillDropDowns();
            LoadingDropDowns = false;
            DoEpi();
        }

        void applicationViewModel_DefinedVariableInUseDeletedEvent(object o)
        {
            if ((Col2 != null && Col2.Name == applicationViewModel.ItemToBeRemoved.Name))
            {
                Index1 = Index2 = -1;
                pnlChartContainer.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                SearchIndex();
            }
            LoadingDropDowns = true;
            FillDropDowns();
            LoadingDropDowns = false;
        }

        //<summary>
        //Searches for Selected index of all the columns
        //</summary>
        private void SearchIndex()
        {
            ClientCommon.Common cmnClass = new ClientCommon.Common();

            Index1 = cbxDateField.SelectedIndex;

            if (Col2 != null)
            {
                Index2 = cmnClass.SearchCurrentIndex(Col2, cmnClass.GetItemsSource(GetFieldStatusDataType));  //SearchCurrentIndex(Col2);
            }

        }

        /// <summary>
        /// Saves columns values
        /// </summary>
        private void SaveColumnValues()
        {
            Col1 = (EWAVColumn)cbxDateField.SelectedItem;
            Col2 = (EWAVColumn)cbxCaseStatusField.SelectedItem;
        }

        void applicationViewModel_DefinedVariableAddedEvent(object o)
        {
            SearchIndex();
            LoadingDropDowns = true;
            FillDropDowns();
            LoadingDropDowns = false;
            DoEpi();
        }

        void applicationViewModel_UnloadedEvent(object o)
        {
            applicationViewModel.ApplyDataFilterEvent -= new ApplyFilterEventHandler(applicationViewModel_ApplyDataFilterEvent);
        }

        void eCrvViewModel_ErrorNotice(object sender, SimpleMvvmToolkit.NotificationEventArgs<Exception> e)
        {
            //if (e.Message != "")
            //{
            //    RenderFinishWithError(e.Message);
            //    return;
            //}

            //if (e.Data.Message.Length > 0)
            //{
            //    ChildWindow window = new ErrorWindow(e.Data);
            //    window.Show();
            //    //return;
            //}
            RenderFinishWithError(e.Data.Message);
            this.SetGadgetToFinishedState();
        }

        void applicationViewModel_ApplyDataFilterEvent(object o)
        {
            if (epiCurveDataLoaded)
            {
                DoEpi();
            }
        }

        private void EnableDisableButton()
        {
            if (cbxDateField.SelectedIndex > 0)
            {
                btnRun.IsEnabled = true;
            }
            else
            {
                btnRun.IsEnabled = false;
            }
        }

        void applicationViewModel_ConnectionStringLoadedEvent(object o, ConnectionStringEventArgs e)
        {
            // reset tool                   
            gadgetOptions.TableName = applicationViewModel.EWAVSelectedDatasource.TableName;
            gadgetOptions.DatasourceName = applicationViewModel.EWAVSelectedDatasource.DatasourceName;
        }

        bool epiCurveDataLoaded = false;

        void eCrvViewModel_EpiCurveTableLoadedEvent(object sender, SimpleMvvmToolkit.NotificationEventArgs<Exception> e)
        {
            epiCurveDataLoaded = true;
            GenerateEpiCurve();
        }

        void FillDropDowns()   //  object sender, SimpleMvvmToolkit.NotificationEventArgs<Exception> e)
        {
            IEnumerable<EWAVColumn> CBXFieldCols = from cols in applicationViewModel.EWAVDatasources[
                applicationViewModel.EWAVDatasourceSelectedIndex].AllColumns    //  eCrvViewModel.Columns
                                                   where GetFieldDateDataType.Contains(cols.SqlDataTypeAsString)
                                                   orderby cols.Name
                                                   select cols;

            List<EWAVColumn> colsList = CBXFieldCols.ToList();

            colsList.Insert(0, new EWAVColumn() { Name = " ", Index = -1 });
            cbxDateField.ItemsSource = colsList;
            cbxDateField.SelectedValue = "Index";
            //cbxDateField.DisplayMemberPath = "NoCamelName";
            cbxDateField.DisplayMemberPath = "Name";
            cbxDateField.SelectedIndex = Index1;

            foreach (var item in CBXFieldCols)
            {
                dateColumnNames.Add(item.Name);
            }

            CBXFieldCols = from cols in applicationViewModel.EWAVDatasources[
                applicationViewModel.EWAVDatasourceSelectedIndex].AllColumns
                           where GetFieldStatusDataType.Contains(cols.SqlDataTypeAsString)
                           orderby cols.Name
                           select cols;
            List<EWAVColumn> CaseStatusField = CBXFieldCols.ToList();
            //ewc = new EWAVColumn();
            //ewc.Name = " ";
            //dateFields.Insert(0, ewc);
            CaseStatusField.Insert(0, new EWAVColumn() { Name = " ", Index = -1 });
            cbxCaseStatusField.ItemsSource = CaseStatusField;
            cbxCaseStatusField.SelectedValue = "Index";
            //cbxCaseStatusField.DisplayMemberPath = "NoCamelName";
            cbxCaseStatusField.DisplayMemberPath = "Name";
            cbxCaseStatusField.SelectedIndex = Index2;

            foreach (var item in CBXFieldCols)
            {
                numericColumnNames.Add(item.Name);
            }
        }

        /// <summary>
        /// Closes the gadget.
        /// </summary>
        void CloseGadget()
        {
            applicationViewModel.CloseGadget(this);
        }

        /// <summary>
        /// Closes the gadget after confirmation.
        /// </summary>
        void CloseGadgetOnClick()
        {
            CloseGadget confirm = new CloseGadget(this);
            confirm.Show();
        }

        SetLabels window;
        SetLabelsViewModel viewModel = null;
        public void SetChartLabels()
        {
            LoadViewModel();
            window = new SetLabels("epicurve", viewModel);// { DataContext = this.DataContext };

            window.Unloaded -= new RoutedEventHandler(window_Closed);
            window.Closed += new EventHandler(window_Closed);
            window.txtboxXaxis.Text = textBlockX.Text;
            window.txtboxYaxis.Text = textBlockY.Text;
            window.Show();
        }

        private void LoadViewModel()
        {
            // dpb 

            //viewModel = new SetLabelsViewModel();
            //viewModel.GadgetName = tbChartName.Text;
            //viewModel.GadgetDescription = tbGadgetDescription.Text;
            //viewModel.ShowLegend = this.epiCurveChart.LegendVisible;
            //viewModel.Width = this.epiCurveChart.Width;
            //viewModel.Height = this.epiCurveChart.Height;
            //viewModel.CollorPallet = this.epiCurveChart.Palette.PaletteName.ToString();
            //viewModel.ChartTitle = dbp.Title.ToString();
            //switch (this.epiCurveChart.LegendDock)
            //{
            //    case ComponentArt.Silverlight.DataVisualization.Charting.Dock.Bottom:
            //        viewModel.LegendPostion = "Bottom";
            //        break;
            //    case ComponentArt.Silverlight.DataVisualization.Charting.Dock.Left:
            //        viewModel.LegendPostion = "Left";
            //        break;
            //    case ComponentArt.Silverlight.DataVisualization.Charting.Dock.Right:
            //        viewModel.LegendPostion = "Right";
            //        break;

            //    case ComponentArt.Silverlight.DataVisualization.Charting.Dock.Top:
            //        viewModel.LegendPostion = "Top";
            //        break;
            //    default:
            //        viewModel.LegendPostion = "Top";
            //        break;
            //}

            //viewModel.UseDifferentBarColors = this.epiCurveChart.UseDifferentBarColors;
        }

        void window_Closed(object sender, EventArgs e)
        {
            if (window.DialogResult.Value)
            {
                SetValuesForAxis();
            }
        }

        public void SetChartLabels(string chartTitle, string legendTitle, string xAxisLabel, string yAxisLabel)
        {

        }

        void window_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void SetValuesForAxis()
        {
            viewModel = (SetLabelsViewModel)this.window.DataContext;
            XAxisLabel = window.txtboxXaxis.Text;
            YAxisLabel = window.txtboxYaxis.Text;    

            if (textBlockX != null && textBlockY != null) // dpb  && dbp != null)
            {
                textBlockX.Text = window.txtboxXaxis.Text;
                textBlockY.Text = window.txtboxYaxis.Text;
                ChartTitle = window.txtbxChrtTitle.Text;
                // dpb                 dbp.Title = ChartTitle;
                LoadChart(viewModel);
            }
        }
        private void LoadChart(SetLabelsViewModel viewModel)
        {
            // dpb 

            //this.tbChartName.Text = viewModel.GadgetName;
            //this.tbGadgetDescription.Text = viewModel.GadgetDescription;

            //if (dbp != null)
            //{
            //    dbp.Title = viewModel.ChartTitle;
            //}

            //if (viewModel.ShowVariableNames)
            //{
            //    Legend CLegend = new Legend();
            //    foreach (var item in this.epiCurveChart.Legend.LegendItems)
            //    {
            //        CLegend.LegendItems.Add(new LegendItem() { Data = this.textBlockX.Text + " = " + item.Data });
            //    }
            //    this.epiCurveChart.Legend = null;
            //    this.epiCurveChart.Legend = CLegend;
            //}

            //this.epiCurveChart.Palette = Palette.GetPalette(viewModel.CollorPallet);
            //this.epiCurveChart.Width = viewModel.Width;
            //this.epiCurveChart.Height = viewModel.Height;

            //switch (viewModel.LegendPostion.ToLower())
            //{
            //    case "left":
            //        this.epiCurveChart.LegendDock = ComponentArt.Silverlight.DataVisualization.Charting.Dock.Left;
            //        break;
            //    case "right":
            //        this.epiCurveChart.LegendDock = ComponentArt.Silverlight.DataVisualization.Charting.Dock.Right;
            //        break;
            //    case "bottom":
            //        this.epiCurveChart.LegendDock = ComponentArt.Silverlight.DataVisualization.Charting.Dock.Bottom;
            //        break;
            //    default:
            //        this.epiCurveChart.LegendDock = ComponentArt.Silverlight.DataVisualization.Charting.Dock.Top;
            //        break;
            //}

            //this.epiCurveChart.LegendVisible = viewModel.ShowLegend;
            //this.epiCurveChart.Legend.Orientation = ComponentArt.Silverlight.DataVisualization.Common.LegendItemOrientation.Vertical;
            //this.epiCurveChart.UseDifferentBarColors = viewModel.UseDifferentBarColors;

        }
        public void SaveAsImage()
        {
            // dpb 

            //ExportToPDF etp = new ExportToPDF();
            //DashboardPanel currentChart = dbp;
            //etp.SavePNG(currentChart, 200);
        }


        void cbxChartType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                string chartType = ((ComboBoxItem)e.AddedItems[0]).Content.ToString();
                switch (chartType)
                {
                    case "Epi Curve":
                        pnlEpiCurveConfig.Visibility = Visibility.Visible;
                        break;

                    default:
                        pnlEpiCurveConfig.Visibility = Visibility.Collapsed;

                        break;
                }
                ResetComboboxes();
            }
        }

        private void ResetComboboxes()
        {
            loadingCombos = true;

            if (cbxCaseStatusField.Items.Count > 0)
            {
                cbxCaseStatusField.SelectedIndex = -1;
            }
            if (cbxDateField.Items.Count > 0)
            {
                cbxDateField.SelectedIndex = -1;
            }


            loadingCombos = false;
        }

        void ConfigField_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!loadingCombos)
            {
                bool isDropDownList = false;
                bool isRecoded = false;

                string columnName = string.Empty; //= e.AddedItems[0].ToString();

                if (cbxDateField.SelectedIndex >= 0)
                {
                    columnName = cbxDateField.SelectedItem.ToString();
                }

                if (e.AddedItems.Count == 1 && e.AddedItems[0] is string && !string.IsNullOrEmpty(columnName))
                {
                    if (!dateColumnNames.Contains(columnName))
                    {
                        tblockDateInterval.Visibility = System.Windows.Visibility.Collapsed;
                        cbxDateInterval.Visibility = System.Windows.Visibility.Collapsed;
                    }
                    else
                    {
                        tblockDateInterval.Visibility = System.Windows.Visibility.Visible;
                        cbxDateInterval.Visibility = System.Windows.Visibility.Visible;

                        //DateTime? minDate = null;
                        //DateTime? maxDate = null;
                        //dashboardHelper.FindUpperLowerDateValues(columnName, ref minDate, ref maxDate);

                        //if (minDate.HasValue && maxDate.HasValue)
                        //{
                        //    TimeSpan timeSpan = (DateTime)maxDate - (DateTime)minDate;

                        //    if (timeSpan.TotalHours <= 24)
                        //    {
                        //        cbxDateInterval.SelectedIndex = 1; // Hours
                        //    }
                        //    else if (timeSpan.TotalDays < 32)
                        //    {
                        //        cbxDateInterval.SelectedIndex = 0; // Days
                        //    }
                        //    else if (timeSpan.TotalDays <= 366)
                        //    {
                        //        cbxDateInterval.SelectedIndex = 2; // Months
                        //    }
                        //    else
                        //    {
                        cbxDateInterval.SelectedIndex = 3; // Years
                        // }
                        // }
                    }
                }
                //}
                //else
                //{
                //    checkboxAllValues.IsChecked = false;
                //}
                //RefreshResults();
            }
            EnableDisableButton();
        }


        private void CheckAndSetPosition()
        {
            double top = Canvas.GetTop(this);
            double left = Canvas.GetLeft(this);

            if (top < 0)
            {
                Canvas.SetTop(this, 0);
            }
            if (left < 0)
            {
                Canvas.SetLeft(this, 0);
            }
        }

        /// <summary>
        /// Sends the gadget to the back of the canvas
        /// </summary>
        //private void SendToBack()
        //{
        //    Canvas.SetZIndex(this, -1);
        //}

        private void RenderFinish()
        {
            waitCursor.Visibility = System.Windows.Visibility.Collapsed;
            spContent.Visibility = System.Windows.Visibility.Visible;
            ResizeButton.Template = (ControlTemplate)Application.Current.Resources["resizebtn"];
            pnlChartContainer.Visibility = System.Windows.Visibility.Visible;
            tbNumberOfRecords.Text = Convert.ToString(RecordCount);
            pnlStatus.Visibility = System.Windows.Visibility.Collapsed;
            txtStatus.Text = string.Empty;
            HeaderButton.IsEnabled = true;
            FilterButton.IsEnabled = true;
            SetChartLabels(ChartTitle, LegendTitle, XAxisLabel, YAxisLabel);

            CheckAndSetPosition();

            if (viewModel != null)
            {
                LoadChart(viewModel);//Loads the values read from CreateFromXML. 
            }

        }

        private void RenderFinishWithWarning(string errorMessage)
        {
            waitCursor.Visibility = System.Windows.Visibility.Collapsed;
            spContent.Visibility = System.Windows.Visibility.Visible;
            ResizeButton.Template = (ControlTemplate)Application.Current.Resources["resizebtn"];
            pnlChartContainer.Visibility = System.Windows.Visibility.Visible;

            //pnlStatus.Background = Brushes.Gold;
            //pnlStatusTop.Background = Brushes.Goldenrod;

            pnlStatus.Visibility = System.Windows.Visibility.Visible;
            txtStatus.Text = errorMessage;

            SetChartLabels(ChartTitle, LegendTitle, XAxisLabel, YAxisLabel);

            CheckAndSetPosition();
        }

        private void RenderFinishWithError(string errorMessage)
        {
            waitCursor.Visibility = System.Windows.Visibility.Collapsed;
            spContent.Visibility = System.Windows.Visibility.Visible;
            ResizeButton.Template = (ControlTemplate)Application.Current.Resources["resizebtn"];
            pnlChartContainer.Visibility = System.Windows.Visibility.Collapsed;


            pnlStatus.Visibility = System.Windows.Visibility.Visible;

            txtStatus.Text = errorMessage;

            CheckAndSetPosition();
        }

        private void RequestUpdateStatusMessage(string statusMessage)
        {

            SetStatusMessage(statusMessage);
        }

        private void SetStatusMessage(string statusMessage)
        {
            pnlStatus.Visibility = System.Windows.Visibility.Visible;
            txtStatus.Text = statusMessage;
        }

        private bool IsCancelled()
        {


            return false;

        }

        private void GenerateEpiCurve()
        {
            // dpb 

            //DatatableBag dtb = eCrvViewModel.DataTableBag;
            //string dateFormat = ((ComboBoxItem)cbxDateInterval.SelectedValue).Content.ToString();
            //dbp = new DashboardPanel();
            //dbp.Theme = Defaults.THEME; //"ArcticWhite";
            //dbp.Style = Resources["DashboardPanelStyle1"] as Style;

            //epiCurveChart = new XYChart
            //{
            //    MinWidth = Defaults.MIN_CHART_WIDTH, //800,
            //    Height = Defaults.CHART_HEGHT, // 500,
            //    HighlightDataPointOnHover = true,
            //    XPath = "IndependentValue",
            //    SelectionVisualHint = ComponentArt.Silverlight.DataVisualization.Charting.SelectionVisualHint.InvertedColor,
            //    Theme = Defaults.THEME,// "ArcticWhite",
            //    Palette = Palette.GetPalette(Defaults.COLOR_PALETTE), // "VibrantC")     
            //    EnableAnimation = true,
            //    AnimationDuration = new TimeSpan(0, 0, 0, 4),
            //    EnableDataPointPopup = false,
            //    LegendVisible = Defaults.SHOW_CHART_LEGEND,// false,
            //    LegendDock = ComponentArt.Silverlight.DataVisualization.Charting.Dock.Right,
            //    CoordinatesPaddingPercentage = new Thickness(5, 5, 0, 0),
            //    DefaultAxisAnnotationsVisible = true,
            //    DefaultGridLinesVisible = true,
            //    GlareCoverVisible = false,
            //    AnimationOnLoad = false,
            //    DefaultStripesVisible = true
            //};

            //Legend EpiLegend = new Legend()
            //{
            //    BorderBrush = new SolidColorBrush(Color.FromArgb(255, 192, 207, 226)), 
            //    Margin = new Thickness(30, 0, 10, 0),
            //    FontFamily = new FontFamily("Segoe UI"),
            //};

            //AxisCoordinates XaxisCoordinates = new AxisCoordinates()
            //{
            //    AxisId = "XAxis",
            //    Angle = 70,
            //    Margin = new Thickness(0, 5, 0, 0),
            //    FontSize = 9.5,
            //    LabelGap = 1.0,
            //    Coordinates = new DateTimeCoordinates()
            //};

            //ChartLabel chartLabel = new ChartLabel()
            //{
            //    Orientation = ChartLabelOrientation.Horizontal
            //};

            //textBlockX = new TextBlock()
            //{
            //    Text = ((EWAVColumn)cbxDateField.SelectedItem).Name.FromCamelCase(),
            //    Width = 402,
            //    TextAlignment = System.Windows.TextAlignment.Center,
            //    Padding = new Thickness(0, 10, 0, 10),
            //    Margin = new Thickness(0, 40, 0, 0)
            //};

            //chartLabel.Child = textBlockX;

            //epiCurveChart.XAxisArea.Add(XaxisCoordinates);  //   axisCoordinates);
            //epiCurveChart.XAxisArea.Add(chartLabel);

            //textBlockY = new TextBlock()
            //{
            //    Text = "Count",
            //    Width = 402,
            //    VerticalAlignment = System.Windows.VerticalAlignment.Bottom,
            //    TextAlignment = System.Windows.TextAlignment.Center,
            //    Padding = new Thickness(0, 10, 0, 10),
            //    Margin = new Thickness(0, 40, 0, 0)
            //};

            //epiCurveChart.YAxisArea.Add(new AxisCoordinates());
            //epiCurveChart.YAxisArea.Add(new ChartLabel()
            //{
            //    Child = textBlockY,
            //    Orientation = ComponentArt.Silverlight.DataVisualization.Charting.ChartLabelOrientation.Vertical
            //});

            //bool byEpiWeek = false;
            //if (gadgetOptions.InputVariableList.ContainsKey("isdatecolumnnumeric"))
            //{
            //    byEpiWeek = bool.Parse(gadgetOptions.InputVariableList["isdatecolumnnumeric"]);
            //}

            //string seriesTrackerText = "";
            //int seriesCounter = 0;
            //if (dtb.ColumnNameList.Count == 0)
            //{
            //    RenderFinishWithError(SharedStrings.NO_RECORDS_SELECTED);
            //    return;
            //}
            //List<MyString> chartColsList = dtb.ColumnNameList.GetRange(1, dtb.ColumnNameList.Count - 1);

            //compositeSeries = new CompositeSeries()
            //{
            //    CompositionKind = ComponentArt.Silverlight.DataVisualization.Charting.CompositionKind.Stacked
            //};

            //foreach (MyString col in chartColsList)
            //{
            //    List<ChartDataValue> chartDataValuesList = new List<ChartDataValue>();

            //    foreach (FieldsList row in dtb.RecordList)
            //    {
            //        ChartDataValue data = new ChartDataValue()
            //        {
            //            Format = dateFormat,
            //            IndependentValue = row.Fields[0].VarName,
            //            DependentValue = dtb.GetValueAtRow(col.VarName, row)
            //        };

            //        EpiLegend.LegendItems.Add(new LegendItem()
            //        {
            //            Data = dtb.GetValueAtRow(col.VarName, row)
            //        });

            //        if (data.DependentValue.Length == 0)
            //        {
            //            data.DependentValue = "0";
            //        }
            //        chartDataValuesList.Add(data);
            //    }

            //    ColorShift topColorShift = new ColorShift();
            //    topColorShift.BrightnessShift = 70;

            //    ColorShift bottomColorShift = new ColorShift();
            //    bottomColorShift.BrightnessShift = 1;
            //    seriesCounter++;
            //    seriesTrackerText += string.Format("{0},", dtb.ColumnNameList.ElementAt<MyString>(seriesCounter).VarName);      //   "S" + seriesCounter + ",";

            //    AreaSeriesAnimator asa = AreaSeriesAnimator.Create("SwipeSmooth");

            //    epiCurveChart.Width = Defaults.CHART_WIDTH; //800.0; //chartDataValuesList.Count * 20;
            //    epiCurveChart.Height = Defaults.CHART_HEGHT; // 500.0;
            //    epiCurveChart.MaxWidth = Defaults.MAX_CHART_WIDTH;// 5000.0;

            //    foreach (var extraInfo in dtb.ExtraInfo)
            //    {
            //        switch (extraInfo.Key.VarName.ToLower())
            //        {
            //            case "recordcount":
            //                RecordCount = Convert.ToInt16(extraInfo.Value.VarName);
            //                break;
            //            default:
            //                break;
            //        }
            //    }

            //    AreaSeries areaSeries = new AreaSeries()
            //    {
            //        Id = dtb.ColumnNameList.ElementAt<MyString>(seriesCounter).VarName.FromCamelCase(), //     "S" + seriesCounter,
            //        LineKind = ComponentArt.Silverlight.DataVisualization.Charting.LineKind.Step,
            //        DataSource = chartDataValuesList,
            //        YPath = "DependentValue",
            //        XPath = "IndependentValue",
            //        SeriesLineVisible = false,
            //        EnableAnimation = true,
            //        Texture = TextureKind.BrushedMetal,
            //        Animator = asa
            //    };

            //    compositeSeries.SubSeries.Add(areaSeries);
            //}

            //seriesTrackerText = seriesTrackerText.Substring(0, seriesTrackerText.Length - 1);
            //SeriesTracker st = new SeriesTracker();
            //st.SeriesId = seriesTrackerText;

            //SeriesAnnotationTracker sat = new SeriesAnnotationTracker();
            //sat.SeriesIdsCSS = seriesTrackerText;

            //epiCurveChart.XYChartMainArea.Add(compositeSeries);
            //epiCurveChart.XYChartMainArea.Add(st);
            //epiCurveChart.XYChartMainArea.Add(sat);

            //pnlChartContainer.Visibility = System.Windows.Visibility.Visible;

            //pnlChartContainer.Children.Clear();
            //if (chartColsList.Count > 1)
            //{
            //    epiCurveChart.Legend = EpiLegend;
            //}

            //dbp.Content = epiCurveChart;

            //long x = 7;
            
            //pnlChartContainer.Children.Add(dbp);
            
            //if (XAxisLabel != "")
            //    textBlockX.Text = XAxisLabel;
            //if (YAxisLabel != "")
            //    textBlockY.Text = YAxisLabel;
            //if (dbp != null)
            //    dbp.Title = ChartTitle;
            
            //RenderFinish();
        }

        void epiCurveWorker_RunWorkerCompleted()
        {
            if (databag != null)
            {

                RenderFinishEpiCurve(databag, dataValues);
            }
        }

        private void RenderFinishEpiCurve(DatatableBag data, List<List<StringDataValue>> dataValues)
        {
            waitCursor.Visibility = System.Windows.Visibility.Collapsed;

            // dpb XYChart chart = new XYChart();
            chart.BorderThickness = new Thickness(0);
            chart.Loaded += new RoutedEventHandler(chart_Loaded);
            chart.Height = 500;
            pnlChartContainer.Children.Clear();
            pnlChartContainer.Children.Add(chart);

            SetChartLabels(ChartTitle, LegendTitle, XAxisLabel, YAxisLabel);
        }


        private List<StringDataValue> ConvertToPct(List<StringDataValue> list)
        {
            List<StringDataValue> values = new List<StringDataValue>();
            foreach (StringDataValue value in list)
            {
                values.Add(new StringDataValue() { IndependentValue = value.IndependentValue, DependentValue = value.DependentValue / 31 * 100 });
            }
            return values;
        }

        private bool IsBooleanWithNoStratas
        {
            get
            {
                return this.isBooleanWithNoStratas;
            }
            set
            {
                this.isBooleanWithNoStratas = value;
            }
        }

        public void ClearResults()
        {
            txtStatus.Text = string.Empty;
            pnlStatus.Visibility = Visibility.Collapsed;
            waitCursor.Visibility = Visibility.Visible;

            IsBooleanWithNoStratas = false;

            pnlChartContainer.Children.Clear();
            pnlChartContainer.Visibility = System.Windows.Visibility.Collapsed;
        }

        #region IGadget Members

        public bool IsProcessing { get; set; }

        /// <summary>
        /// Updates the variable names available in the gadget's properties
        /// </summary>
        public void UpdateVariableNames()
        {
            //FillComboboxes(true);
        }

        public StringBuilder HtmlBuilder { get; set; }

        public void RefreshResults()
        {
            if (!LoadingCanvas && !loadingCombos && gadgetOptions != null && ((cbxDateField.SelectedIndex > -1)))//|| (cbxColumnXAxisField.SelectedIndex > -1 && cbxColumnYAxisField.SelectedIndex > -1) || (cbxScatterXAxisField.SelectedIndex > -1 && cbxScatterYAxisField.SelectedIndex > -1) || (cbxSingleField.SelectedIndex > -1)))
            {
                waitCursor.Visibility = Visibility.Visible;


                gadgetOptions.MainVariableName = string.Empty;
                gadgetOptions.WeightVariableName = string.Empty;
                gadgetOptions.StrataVariableNames = new List<string>();
                gadgetOptions.CrosstabVariableName = string.Empty;
                gadgetOptions.InputVariableList = new Dictionary<string, string>();
                gadgetOptions.ShouldSortHighToLow = false;
                gadgetOptions.TableName = applicationViewModel.EWAVSelectedDatasource.TableName;

                gadgetOptions.ShouldUseAllPossibleValues = false;


                if (!string.IsNullOrEmpty(datePicker1.Text))
                {
                    gadgetOptions.InputVariableList.Add("xaxisstart", datePicker1.Text);
                }
                if (!string.IsNullOrEmpty(datePicker2.Text))
                {
                    gadgetOptions.InputVariableList.Add("xaxisend", datePicker2.Text);
                }
                gadgetOptions.InputVariableList.Add("isdatecolumnnumeric", numericColumnNames.Contains(cbxDateField.SelectedItem.ToString()).ToString().ToLower());
                gadgetOptions.InputVariableList.Add("dateinterval", ((ComboBoxItem)cbxDateInterval.SelectedItem).Content.ToString());
                gadgetOptions.MainVariableName = ((EWAVColumn)cbxDateField.SelectedItem).Name.ToString();
                if (cbxCaseStatusField.SelectedIndex >= 0 && ((EWAVColumn)cbxCaseStatusField.SelectedItem).Name.ToString().Trim() != "")
                {
                    gadgetOptions.CrosstabVariableName = ((EWAVColumn)cbxCaseStatusField.SelectedItem).Name.ToString();
                }
            }
        }

        void chart_Loaded(object sender, RoutedEventArgs e)
        {
            SetChartLabels(ChartTitle, LegendTitle, XAxisLabel, YAxisLabel);
        }

        /// <summary>
        /// Sets the gadget to its 'processing' state
        /// </summary>
        public void SetGadgetToProcessingState()
        {
            cbxCaseStatusField.IsEnabled = false;
            cbxDateInterval.IsEnabled = false;
            cbxDateField.IsEnabled = false;
            datePicker1.IsEnabled = false;
            datePicker2.IsEnabled = false;

            this.IsProcessing = true;
        }

        /// <summary>
        /// Sets the gadget to its 'finished' state
        /// </summary>
        public void SetGadgetToFinishedState()
        {
            cbxCaseStatusField.IsEnabled = true;
            cbxDateInterval.IsEnabled = true;


            datePicker1.IsEnabled = true;
            datePicker2.IsEnabled = true;

            this.IsProcessing = false;

            if (GadgetProcessingFinished != null)
            {
                GadgetProcessingFinished(this);
            }
        }

        /// <summary>
        /// Serializes the gadget into Xml
        /// </summary>
        /// <param name="doc">The Xml docment</param>
        XNode IGadget.Serialize(XDocument doc)
        {
            string caseStatusField = string.Empty;
            string dateField = string.Empty;
            string singleField = string.Empty;
            string weightField = string.Empty;
            string strataField = string.Empty;
            string columnAggregateFunction = string.Empty;
            string xAxisField = string.Empty;
            string yAxisField = string.Empty;
            string xAxisFieldScatter = string.Empty;
            string yAxisFieldScatter = string.Empty;
            string chartType = string.Empty;
            string chartSize = "Medium";
            string xAxisRotation = "90";

            chartType = "EpiCurve";
            
            if (cbxCaseStatusField.SelectedIndex > -1)
            {
                caseStatusField = ((EWAVColumn)cbxCaseStatusField.SelectedItem).Name.ToString().Replace("<", "&lt;");
            }
            if (cbxDateField.SelectedIndex > -1)
            {
                dateField = ((EWAVColumn)cbxDateField.SelectedItem).Name.ToString().Replace("<", "&lt;");
            }

            LoadViewModel();

            XElement element = new XElement("chart",
                new XAttribute("top", Canvas.GetTop(this).ToString("F0")),
                new XAttribute("left", Canvas.GetLeft(this).ToString("F0")),
                new XAttribute("collapsed", "false"),
                new XAttribute("gadgetType", "EWAV.EpiCurve"),
                new XElement("chartType", chartType),
                new XElement("chartSize", chartSize),
                new XElement("chartLegendTitle", LegendTitle),
                new XElement("chartTitle", ChartTitle),
                new XElement("columnAggregateFunction", columnAggregateFunction),
                new XElement("caseStatusVariable", caseStatusField),
                new XElement("dateVariable", dateField),
                new XElement("singleVariable", singleField),
                new XElement("weightVariable", weightField),
                new XElement("strataVariable", strataField),
                new XElement("yAxisVariable", yAxisField),
                new XElement("xAxisVariable", xAxisField),
                new XElement("yAxisLabel", textBlockY.Text),
                new XElement("xAxisLabel", textBlockX.Text),
                new XElement("dateInterval", ((ComboBoxItem)cbxDateInterval.SelectedItem).Content),
                new XElement("xAxisStartValue", datePicker1.Text),
                new XElement("xAxisEndValue", datePicker2.Text),

                new XElement("gadgetName", viewModel.GadgetName),
                // dpb new XElement("gadgetDescription", Convert.ToBase64String(System.Text.ASCIIEncoding.Unicode.GetBytes(viewModel.GadgetDescription))),
                new XElement("colorPalette", viewModel.CollorPallet),
                new XElement("useDiffColors", viewModel.UseDifferentBarColors),
                new XElement("spacesBetweenBars", viewModel.SpacesBetweenBars),
                new XElement("showLegend", viewModel.ShowLegend),
                new XElement("showVariableNames", viewModel.ShowVariableNames),
                new XElement("legendPosition", viewModel.LegendPostion),
                new XElement("width", viewModel.Width),
                new XElement("height", viewModel.Height)
                );

            if (this.GadgetFilters != null)
            {
                this.GadgetFilters.Serialize(element);
            }
            
            return element;
        }


        /// <summary>
        /// Converts the gadget's output to Html
        /// </summary>
        /// <returns></returns>
        public string ToHTML(bool ForDash = false, string htmlFileName = "", int count = 0)
        {
            //// Check to see if a chart has been created.
            //if (pnlChartContainer.ActualHeight == 0 || pnlChartContainer.ActualWidth == 0)
            //{
            //    return string.Empty;
            //}

            //StringBuilder htmlBuilder = new StringBuilder();

            //if (string.IsNullOrEmpty(CustomOutputHeading))
            //{
            //    htmlBuilder.AppendLine("<h2 class=\"gadgetHeading\">Chart</h2>");
            //}
            //else if (CustomOutputHeading != "(none)")
            //{
            //    htmlBuilder.AppendLine(string.Format("<h2 class=\"gadgetHeading\">{0}</h2>", CustomOutputHeading));
            //}

            //if (!string.IsNullOrEmpty(CustomOutputDescription))
            //{
            //    htmlBuilder.AppendLine(string.Format("<p class=\"gadgetsummary\">{0}</p>", CustomOutputDescription));
            //}

            //string imageFileName = string.Empty;

            //if (htmlFileName.EndsWith(".html"))
            //{
            //    imageFileName = htmlFileName.Remove(htmlFileName.Length - 5, 5);
            //}
            //else if (htmlFileName.EndsWith(".htm"))
            //{
            //    imageFileName = htmlFileName.Remove(htmlFileName.Length - 4, 4);
            //}

            //imageFileName = string.Format("{0}_{1}.png", imageFileName, count.ToString());



            //htmlBuilder.AppendLine(string.Format("<img src=\"{0}\" />", imageFileName));

            HtmlBuilder = new StringBuilder("<h2>EpiCurve HTML not Implemented </h2>");

            return " ";    //   htmlBuilder.ToString();
        }

        public string CustomOutputHeading { get; set; }

        public string CustomOutputDescription { get; set; }

        public string CustomOutputCaption { get; set; }

        public string ChartTitle { get; set; }

        public string LegendTitle { get; set; }

        public string XAxisLabel { get; set; }

        public string YAxisLabel { get; set; }

        #endregion

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            DoEpi();
        }

        private void ResizeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (spContent.Visibility == System.Windows.Visibility.Visible)
            {
                spContent.Visibility = System.Windows.Visibility.Collapsed;
                ResizeButton.Template = (ControlTemplate)Application.Current.Resources["resizebtn2"];
            }
            else
            {
                spContent.Visibility = System.Windows.Visibility.Visible;
                ResizeButton.Template = (ControlTemplate)Application.Current.Resources["resizebtn"];
            }
        }

        private void DoEpi()
        {
            if (!LoadingDropDowns && !LoadingCanvas)
            {
                if (gadgetOptions != null)
                {
                    RefreshResults();
                    IsUserDefindVariableInUse();
                    gadgetOptions.DatasourceName = applicationViewModel.EWAVDatasources[applicationViewModel.EWAVDatasourceSelectedIndex].DatasourceName;
                    gadgetOptions.UseAdvancedDataFilter = applicationViewModel.UseAdvancedFilter;
                    gadgetOptions.GadgetFilters = GadgetFilters;

                    bool byEpiWeek = false;
                    if (gadgetOptions.InputVariableList == null)
                    {
                        return;
                    }

                    if (gadgetOptions.InputVariableList.ContainsKey("isdatecolumnnumeric"))
                    {
                        byEpiWeek = bool.Parse(gadgetOptions.InputVariableList["isdatecolumnnumeric"]);
                    }
                    eCrvViewModel = (EpiCurveViewModel)this.DataContext;
                    eCrvViewModel.GetEpiCurve(gadgetOptions, byEpiWeek, gadgetOptions.MainVariableName, gadgetOptions.CrosstabVariableName);
                    //eCrvViewModel.
                    //epiCurveWorker_DoWork(dtb, gadgetOptions);
                }
                this.gadgetExpander.IsExpanded = false;
            }
        }

        /// <summary>
        /// Use to verify if Defined Variables are in Use
        /// </summary>
        private void IsUserDefindVariableInUse()
        {
            EWAVColumn Col2 = (cbxCaseStatusField.SelectedIndex > -1) ? (EWAVColumn)cbxCaseStatusField.SelectedItem : null;

            if (Col2 != null && Col2.IsUserDefined == true)
            {
                Col2.IsInUse = true;
                DFInUse = Col2;
            }
        }
        void IGadget.CloseGadget()
        {
            CloseGadget();
        }
        /// <summary>
        /// Closes the gadget on click;
        /// </summary>
        void IGadget.CloseGadgetOnClick()
        {
            this.CloseGadgetOnClick();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            CloseGadgetOnClick();
        }

        private void LayoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void LayoutRoot_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClientCommon.Common cmnClass = new ClientCommon.Common();
            Point p = e.GetSafePosition(cmnClass.GetParentObject<Grid>(this, "LayoutRoot"));
            ((EWAV.DragCanvas)VisualTreeHelper.GetParent(this)).GadgetNameOnRightClick = MyControlName;
            ((EWAV.DragCanvas)VisualTreeHelper.GetParent(this)).StrataList = null;
            ((EWAV.DragCanvas)VisualTreeHelper.GetParent(this)).SelectedGadget = this;
            cmnClass.UpdateZOrder(this, true, cmnClass.GetParentObject<Grid>(this, "LayoutRoot"));
        }

        public string MyControlName
        {
            get
            {
                return "EpiCurve";
            }
        }

        public string MyUIName
        {
            get
            {
                return "Epi Curve";
            }
        }

        public ApplicationViewModel ApplicationViewModel
        {
            get
            {
                return this.applicationViewModel;
            }
        }

        private void datePicker1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        public void CreateFromXml(XElement element)
        {
            ClientCommon.Common cmnClass = new ClientCommon.Common();

            LoadingCanvas = true;
            viewModel = new SetLabelsViewModel();
            viewModel.GadgetName = MyUIName.ToString();
            this.GadgetFilters = new List<EWAVDataFilterCondition>();
            List<EWAVColumn> caseColList = cmnClass.GetItemsSource(GetFieldStatusDataType);

            List<EWAVColumn> dateColList = cmnClass.GetItemsSource(GetFieldDateDataType);

            foreach (XElement child in element.Descendants())
            {
                switch (child.Name.ToString().ToLower())
                {
                    case "casestatusvariable":
                        cbxCaseStatusField.SelectedIndex = cmnClass.FindIndexToSelect(caseColList, child.Value.ToString().Replace("&lt;", "<"));
                        break;
                    case "datevariable":
                        cbxDateField.SelectedIndex = cmnClass.FindIndexToSelect(dateColList, child.Value.ToString().Replace("&lt;", "<"));
                        break;
                    case "dateinterval":
                        for (int i = 0; i < cbxDateInterval.Items.Count; i++)
                        {
                            if ((((ComboBoxItem)cbxDateInterval.Items[i]).Content).ToString() == child.Value.ToString())
                            {
                                cbxDateInterval.SelectedIndex = i;
                                break;
                            }
                        }
                        break;

                    case "charttitle":
                        ChartTitle = child.Value;
                        viewModel.ChartTitle = ChartTitle;
                        break;
                    case "chartlegendtitle":
                        LegendTitle = child.Value;
                        break;
                    case "xaxislabel":
                        XAxisLabel = child.Value;
                        break;
                    case "yaxislabel":
                        YAxisLabel = child.Value;
                        break;
                    case "xaxisstartvalue":
                        datePicker1.Text = child.Value;

                        break;
                    case "xaxisendvalue":
                        datePicker2.Text = child.Value;

                        break;
                    case "gadgetname":

                        if (!string.IsNullOrEmpty(child.Value.ToString()))
                        {
                            viewModel.GadgetName = child.Value.ToString();
                        }
                        else
                        {
                            viewModel.GadgetName = this.MyUIName;
                        }
                        break;
                    case "gadgetdescription":
                        if (!string.IsNullOrEmpty(child.Value.ToString()))
                        {
                            byte[] encodedDataAsBytes = System.Convert.FromBase64String(child.Value.ToString());
                            // dpb viewModel.GadgetDescription = System.Text.ASCIIEncoding.Unicode.GetString(encodedDataAsBytes);
                        }
                        else
                        {
                            viewModel.GadgetDescription = "";
                        }

                        break;
                    case "colorpalette":
                        if (!string.IsNullOrEmpty(child.Value.ToString()))
                        {
                            viewModel.CollorPallet = child.Value.ToString();
                        }
                        else
                        {
                            viewModel.CollorPallet = Defaults.COLOR_PALETTE;
                        }

                        break;
                    case "usediffcolors":
                        if (!string.IsNullOrEmpty(child.Value.ToString()))
                        {
                            viewModel.UseDifferentBarColors = Convert.ToBoolean(child.Value.ToString());
                        }
                        else
                        {
                            viewModel.UseDifferentBarColors = Defaults.USE_DIFFERENT_BAR_COLORS;
                        }

                        break;
                    case "spacesbetweenbars":
                        if (!string.IsNullOrEmpty(child.Value.ToString()))
                        {
                            viewModel.SpacesBetweenBars = child.Value.ToString();
                        }
                        else
                        {
                            viewModel.SpacesBetweenBars = Defaults.SPACE_BETWEEN_BARS;
                        }

                        break;
                    case "showlegend":
                        if (!string.IsNullOrEmpty(child.Value.ToString()))
                        {
                            viewModel.ShowLegend = Convert.ToBoolean(child.Value.ToString());
                        }
                        else
                        {
                            viewModel.ShowLegend = Defaults.SHOW_CHART_LEGEND;
                        }

                        break;
                    case "showvariablenames":
                        if (!string.IsNullOrEmpty(child.Value.ToString()))
                        {
                            viewModel.ShowVariableNames = Convert.ToBoolean(child.Value.ToString());
                        }
                        else
                        {
                            viewModel.ShowVariableNames = Defaults.SHOW_CHART_VAR_NAMES;
                        }

                        break;
                    case "legendposition":
                        if (!string.IsNullOrEmpty(child.Value.ToString()))
                        {
                            viewModel.LegendPostion = child.Value.ToString();
                        }
                        else
                        {
                            viewModel.LegendPostion = Defaults.LEGEND_POSITION;
                        }

                        break;
                    case "width":
                        if (!string.IsNullOrEmpty(child.Value.ToString()))
                        {
                            viewModel.Width = Convert.ToDouble(child.Value.ToString());
                        }
                        else
                        {
                            viewModel.Width = Defaults.CHART_WIDTH;
                        }

                        break;
                    case "height":
                        if (!string.IsNullOrEmpty(child.Value.ToString()))
                        {
                            viewModel.Height = Convert.ToDouble(child.Value.ToString());
                        }
                        else
                        {
                            viewModel.Height = Defaults.CHART_HEGHT;
                        }

                        break;
                    case "ewavdatafiltercondition":
                        EWAVDataFilterCondition condition = new EWAVDataFilterCondition();
                        condition.FieldName = new MyString();
                        condition.FieldName.VarName = child.Attribute("fieldName").Value.ToString();

                        condition.FriendlyOperand = new MyString();
                        condition.FriendlyOperand.VarName = child.Attribute("friendlyOperand").Value.ToString();

                        if (child.Attribute("friendlyValue").Value.ToString() != "null")
                        {
                            condition.FriendlyValue = new MyString();
                            condition.FriendlyValue.VarName = child.Attribute("friendlyValue").Value.ToString();
                        }

                        if (child.Attribute("friendLowValue").Value.ToString() != "null")
                        {
                            condition.FriendLowValue = new MyString();
                            condition.FriendLowValue.VarName = child.Attribute("friendLowValue").Value.ToString();
                        }

                        if (child.Attribute("friendHighValue").Value.ToString() != "null")
                        {
                            condition.FriendHighValue = new MyString();
                            condition.FriendHighValue.VarName = child.Attribute("friendHighValue").Value.ToString();
                        }

                        condition.JoinType = new MyString();
                        condition.JoinType.VarName = child.Attribute("joinType").Value.ToString();

                        this.GadgetFilters.Add(condition);
                        break;
                }
            }
            LoadingCanvas = false;

            double mouseVerticalPosition = 0.0, mouseHorizontalPosition = 0.0;
            foreach (XAttribute attribute in element.Attributes())
            {
                switch (attribute.Name.ToString().ToLower())
                {
                    case "top":
                        //mouseVerticalPosition = double.Parse(element.Attribute("top").Value.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                        double.TryParse(element.Attribute("top").Value.ToString(), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.CurrentCulture, out mouseVerticalPosition);
                        break;
                    case "left":
                        //mouseHorizontalPosition = double.Parse(element.Attribute("left").Value.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                        double.TryParse(element.Attribute("left").Value.ToString(), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.CurrentCulture, out mouseHorizontalPosition);
                        break;
                }
            }

            DoEpi();

            cmnClass.AddControlToCanvas(this, mouseVerticalPosition, mouseHorizontalPosition, applicationViewModel.LayoutRoot);
        }


        public ClientCommon.XYControlChartTypes GetChartTypeEnum()
        {


            return ClientCommon.XYControlChartTypes.Ignore;

        }


        public void Reload()
        {





          //   XAxisLabel = YAxisLabel = ChartTitle = "";


            DoEpi();






        }

        private void HeaderButton_Click(object sender, RoutedEventArgs e)
        {
            //SetLabels sl = new SetLabels();
            //sl.Show();
            SetChartLabels();
        }
        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            GadgetFilterControl gadgetFiltersWindow = null;

            if (GadgetFilters != null)
            {
                gadgetFiltersWindow = new GadgetFilterControl(GadgetFilters);
            }
            else
            {
                gadgetFiltersWindow = new GadgetFilterControl();
            }

            gadgetFiltersWindow.Show();
            gadgetFiltersWindow.Closed += new EventHandler(gadgetFiltersWindow_Closed);
        }

        void gadgetFiltersWindow_Closed(object sender, EventArgs e)
        {
            GadgetFilterControl GadgetFilter = ((GadgetFilterControl)sender);
            if (GadgetFilter.DialogResult == true)
            {
                GadgetFilters = GadgetFilter.GadgetFilters;
                DoEpi();
            }
        }

    }
}

namespace EWAV.Web.Services
{
    public partial class EpiCurveDomainContext
    {
        //This is the place to set RIA Services query timeout. 
        //TimeSpan(0, 5, 0) means five minutes vs the 
        //default 60 sec
        partial void OnCreated()
        {
            if (!DesignerProperties.GetIsInDesignMode(Application.Current.RootVisual))
            {
                ((WebDomainClient<IEpiCurveDomainServiceContract>)DomainClient).ChannelFactory.Endpoint.Binding.SendTimeout =
                    new TimeSpan(0, 120, 0);
            }
        }
    }
}