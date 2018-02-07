using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using EWAV.Web.Services;
using System.Collections.Generic;
using System.ServiceModel.DomainServices.Client;
using EWAV.ViewModels;
using EWAV.Web.Services.MapCluster;
using EWAV.DTO;

namespace EWAV.Services
{
    public class MapControlServiceAgent : IMapControlControlServiceAgent
    {
        #region Variables
        MapClusterDomainContext mmCtx = null;
        private Action<List<PointDTOCollection>, Exception> _completed;
        #endregion

        #region Constructor
        public MapControlServiceAgent()
        {
        }
        #endregion

        #region Helper Method

        public void LoadMapData(EWAV.Web.EpiDashboard.GadgetParameters gp, Action<List<PointDTOCollection>, Exception> completed)
        {
            try
            {
                _completed = completed;
                MapClusterDomainContext mmCtx = new MapClusterDomainContext();
                InvokeOperation<List<PointDTOCollection>> MapControlResutls =
                    mmCtx.GetMapValues(gp, ApplicationViewModel.Instance.EWAVDatafilters,
                        ApplicationViewModel.Instance.EWAVDefinedVariables,
                        ApplicationViewModel.Instance.AdvancedDataFilterString);
                MapControlResutls.Completed += new EventHandler(MapControlResutls_Completed);               




            }
            catch (Exception ex)
            {
                throw new Exception();     
            }
        }

        #endregion

        #region Completion Callbacks

        public void MapControlResutls_Completed(object sender, EventArgs e)
        {
            InvokeOperation<List<PointDTOCollection>> result =
                (InvokeOperation<List<PointDTOCollection>>)sender;

            Exception ex = null;
            if (result.HasError)
            {
                result.MarkErrorAsHandled();
                ex = result.Error;
            }
            List<PointDTOCollection> returnedData = ((InvokeOperation<List<PointDTOCollection>>)sender).Value;
            _completed(returnedData, ex);
        }
        #endregion
    }
}