using System.Collections.Generic;
using System.ServiceModel.DomainServices.Hosting;
using System.ServiceModel.DomainServices.Server;
using EWAV.BAL;
using EWAV.DTO;
using EWAV.Web.EpiDashboard;
using System;
using System.Reflection;
using System.Data;

namespace EWAV.Web.Services
{
    [EnableClientAccess()]
    public class DatasourceDomainService : DomainService
    {

        [Query(IsComposable = false)]
        public EWAVRule_Base Getrule(int id)
        {
            return new EWAVRule_Base();

        }


        public void PortToClient(EWAVRuleType d) { }



        public List<EWAVColumn> GetColumnsForDatasource(string datasourceName)
        {
            try
            {

                EntityManager em = new EntityManager();
                List<EWAVColumn> allCols = em.GetColumnsForDatasource(datasourceName);

                return allCols;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " -- " + ex.StackTrace);
            }
        }

        /// <summary>
        /// Gets the datasources as I enumerble2.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EWAVDatasourceDto> GetDatasourcesAsIEnumerble2(string userName)
        {
            try
            {
                EWAVDatasourceListManager datasourceList = new EWAVDatasourceListManager();

                IEnumerable<EWAVDatasourceDto> result = datasourceList.GetDatasourcesAsIEnumerable2(userName);

                return result;
            }
            catch (Exception ex)
            {



                throw new Exception("Error with GetDatasourcesAsIEnumerble2 (top level ) ==== " + ex.Message + ex.StackTrace);


            }
        }





        //public IEnumerable<DatasourceUserDto> GetAllDatasourceUser()
        //{
        //    try
        //    {

        //        EntityManager em = new EntityManager();
        //        List<DatasourceUserDto> datasourceUserDtoList = em.GetAllDatasourceUser();


        //        return datasourceUserDtoList as IEnumerable<DatasourceUserDto>;


        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message + " -- " + ex.StackTrace);
        //    }

        //}

        /// <summary>
        /// Gets the Record Count.
        /// </summary>
        /// <returns></returns>
        [Invoke]
        public string GetRecordCount(List<EWAVDataFilterCondition> filterList, List<EWAVRule_Base> rules, string tableName, string dsName)
        {

            Assembly assembly = Assembly.GetExecutingAssembly();
            String version = assembly.FullName.Split(',')[1];
            String fullversion = version.Split('=')[1];

            try
            {
                string result;

                if (filterList.Count == 0 && rules.Count == 0)
                {
                    EntityManager em = new EntityManager();
                    int recordCount = em.GetRawDataTableRecordCount(dsName, tableName);

                    result = recordCount.ToString() + "," + recordCount.ToString();
                }
                else
                {
                    EpiDashboard.GadgetParameters inputs = new EpiDashboard.GadgetParameters();
                    inputs.TableName = tableName;
                    inputs.DatasourceName = dsName;
                    EpiDashboard.DashboardHelper dashboardHelper = new EpiDashboard.DashboardHelper(inputs, filterList, rules);
                    dashboardHelper.EWAVConstructTableColumnNames(inputs);
                    dashboardHelper.CreateDataFilters(filterList);
                    dashboardHelper.GenerateView(inputs);


                    string totalRecords = dashboardHelper.DataSet.Tables[0].Rows.Count.ToString();
                    string filteredRecords = dashboardHelper.DataSet.Tables[0].DefaultView.Count.ToString();

                    result = totalRecords + "," + filteredRecords;
                }

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " -- " + ex.StackTrace);
            }


        }

        [Invoke]
        public string GetRecordCountByString(List<EWAVRule_Base> rules, string s, string tableName, string dsName)
        {
            try
            {
                EpiDashboard.GadgetParameters inputs = new EpiDashboard.GadgetParameters();
                inputs.TableName = tableName;
                inputs.DatasourceName = dsName;
                EpiDashboard.DashboardHelper dashboardHelper = new EpiDashboard.DashboardHelper(inputs, s, rules);
                dashboardHelper.UseAdvancedUserDataFilter = true;
                dashboardHelper.AdvancedUserDataFilter = s;

                //EntityManager em = new EntityManager();

                //return em.GetRecordsCount(dsName, tableName, s);
                dashboardHelper.EWAVConstructTableColumnNames(inputs);
                dashboardHelper.GenerateView(inputs);

                string totalRecords = dashboardHelper.DataSet.Tables[0].Rows.Count.ToString();
                string filteredRecords = dashboardHelper.DataSet.Tables[0].DefaultView.Count.ToString();

                string result = totalRecords + "," + filteredRecords;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " -- " + ex.StackTrace);
            }


        }

        /// <summary>
        /// Reads the filter string
        /// </summary>
        /// <param name="filterList"></param>
        /// <param name="dsName"></param>
        /// <returns></returns>
        [Invoke]
        public string ReadFilterString(List<EWAVDataFilterCondition> filterList, List<EWAVRule_Base> rules, string tableName, string dsName)
        {
            try
            {
                EpiDashboard.GadgetParameters inputs = new EpiDashboard.GadgetParameters();
                inputs.TableName = tableName;
                inputs.DatasourceName = dsName;
                EpiDashboard.DashboardHelper dashboardHelper = new EpiDashboard.DashboardHelper(inputs, filterList, rules);
                dashboardHelper.EWAVConstructTableColumnNames(inputs);
                dashboardHelper.CreateDataFilters(filterList);

                return dashboardHelper.GenerateDataFilterString();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " -- " + ex.StackTrace);
            }

        }


    }
}