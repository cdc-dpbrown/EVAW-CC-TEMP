using System;
using System.Collections.Generic;
using System.ServiceModel.DomainServices.Client;

using EWAV.ViewModels;
using EWAV.Web.Services;
using EWAV.DTO;

namespace EWAV.Services
{
    public interface IMapControlControlServiceAgent
    {


        void LoadMapData(EWAV.Web.EpiDashboard.GadgetParameters gp, Action<List<PointDTOCollection >, Exception> completed);

     

    }
}