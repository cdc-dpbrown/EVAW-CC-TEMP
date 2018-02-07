namespace EWAV.Web.Services.MapCluster
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using EWAV.DTO;
    using EpiDashboard;
    using EWAV.BAL;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class MapClusterDomainService : DomainService
    {
        [Query(IsComposable = false)]
        public EWAVRule_Base Getrule(int id)
        {
            return new EWAVRule_Base();

        }

        [Invoke]
        public List<PointDTOCollection> GetMapValues(GadgetParameters gadgetParameters,
               IEnumerable<EWAVDataFilterCondition> ewavDataFilters, List<EWAVRule_Base> rules, string filterString = "")
        {



            try
            {
                MapManager mmanager = new MapManager();

                List<PointDTOCollection> MapList = mmanager.GetMapValues(gadgetParameters, ewavDataFilters, rules, filterString);

                return MapList;
            }
            catch (Exception e   )
            {
                throw new Exception(e.Message + "\n" + e.StackTrace);

            }

        }
    }
}