using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CDC.ISB.EIDEV.DTO;
using CDC.ISB.EIDEV.Web.EpiDashboard;
using CDC.ISB.EIDEV.Web.Services;
using System.Data;

namespace CDC.ISB.EIDEV.Web
{
    public class MapManager
    {
        public List<PointDTOCollection> GetMapValues(GadgetParameters gadgetParameters,
               IEnumerable<EWAVDataFilterCondition> ewavDataFilters, List<EWAVRule_Base> rules, string filterString = "")
        {
            try
            {


                DashboardHelper dh;

                if (gadgetParameters.UseAdvancedDataFilter)
                {
                    dh = new DashboardHelper(gadgetParameters, filterString, rules);
                    gadgetParameters.UseAdvancedDataFilter = true;
                    gadgetParameters.AdvancedDataFilterText = filterString;
                }
                else
                {
                    dh = new DashboardHelper(gadgetParameters, ewavDataFilters, rules);
                }

                List<DatatableBag> datatableBagList = new List<DatatableBag>();

                List<DataTable> dtList = dh.GenerateLineList(gadgetParameters);

                List<DataTable> dtListFiltered = dtList.Where(t => !t.TableName.Contains("null")).ToList();

                List<PointDTOCollection> ListOfCollection = new List<PointDTOCollection>();

              //    List<PointDTOCollection> ListOfCollection = new List<PointDTOCollection>();

                string LatFieldName = "", LngFieldName = "", MapTipFieldName = "";

                LatFieldName = gadgetParameters.InputVariableList["laty"];
                LngFieldName = gadgetParameters.InputVariableList["lonx"];

                foreach (DataTable dt in dtListFiltered)
                {

                    dt.DefaultView.RowFilter = LatFieldName + " is not null   or  " + LngFieldName + " is not null ";  // or " +

                    PointDTO dto = null;
                    //List<PointDTO> list = new List<PointDTO>();
                    PointDTOCollection pList = new PointDTOCollection();

                    pList.Collection = new List<PointDTO>();

                    for (int i = 0; i < dt.DefaultView.Count; i++)
                    {

                        dto = new PointDTO()
                        {
                            LonX = Convert.ToDouble(dt.DefaultView[i][LngFieldName].ToString()),
                            LatY = Convert.ToDouble(dt.DefaultView[i][LatFieldName].ToString()),
                            StrataValue = dt.TableName

                        };


                        pList.Collection.Add(dto);
                    }
                    ListOfCollection.Add(pList);

                }


                return ListOfCollection;


            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}