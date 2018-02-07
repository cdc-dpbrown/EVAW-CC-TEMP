namespace EWAV.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using EpiDashboard;
    using EWAV.BAL;
    using EWAV.DTO;

    using System.Data;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class LineListDomainService : DomainService
    {
        [Query(IsComposable = false)]
        public EWAVRule_Base Getrule(int id)
        {
            return new EWAVRule_Base();

        }

        [Invoke]
        public List<DatatableBag> GetLineList(GadgetParameters gadgetParameters,
               IEnumerable<EWAVDataFilterCondition> ewavDataFilters, List<EWAVRule_Base> rules, string filterString = "")
        {



            LineListManager llm = new LineListManager();

            List<DatatableBag> datatableBagList = llm.GetLineList(gadgetParameters, ewavDataFilters, rules, filterString);


            return datatableBagList;

        }


    }
}