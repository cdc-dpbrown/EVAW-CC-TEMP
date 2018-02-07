namespace EWAV.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using EpiDashboard;
    using EWAV.BAL;

    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class MxNDomainService : DomainService
    {
        private DashboardHelper dh;

        [Query(IsComposable = false)]
        public EWAVRule_Base Getrule(int id)
        {
            return new EWAVRule_Base();

        }


        private TwoxTwoAndMxNResultsSet resultSet;
        /// <summary>
        /// Get a list of columns    
        /// </summary>
        /// <param name="DataSourceName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public List<EWAVColumn> GetColumns(string DataSourceName, string TableName)
        {
            return BAL.Common.GetColumns(DataSourceName, TableName);
        }


            [Invoke]  
        public TwoxTwoAndMxNResultsSet SetupGadget(GadgetParameters clientGadgetOptions, List<EWAVDataFilterCondition> ewavDataFilters, List<EWAVRule_Base>   rules)
        {
            TwoxTwoManager twoxTwoManager = new TwoxTwoManager();
            TwoxTwoAndMxNResultsSet twoxTwoResultsSet = twoxTwoManager.SetupGadget(clientGadgetOptions, ewavDataFilters, rules);
            return twoxTwoResultsSet;
        
            
            
            
            
            
            
            
            
            }
    }
}