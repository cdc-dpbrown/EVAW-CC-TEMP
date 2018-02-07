using System;
using EWAV.DTO;
using System.Collections.Generic;
using EWAV.Web.EpiDashboard;
using EWAV.Web.Services;
using EWAV.BAL;

namespace EWAV.Services
{
    public interface IEpiCurveServiceAgent
    {
        /// <summary>
        /// GetEpiCurveResults method that will be implemented in the ServiceAgentClass
        /// </summary>
        /// <param name="DataSourceName"></param>
        /// <param name="TableName"></param>
        /// <param name="gadgetParameters"></param>
        /// <param name="completed"></param>
        void GetEpiCurveResults( GadgetParameters gadgetParameters, bool byEpiWeek, string dateVar, string caseStatusVar, Action<DatatableBag, Exception> completed);
         
        /// <summary>
        /// CheckColumnType that needs to be implemented in ServiceAgentClass
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        string CheckColumnType(string p);

        /// <summary>
        /// GetColumnsMethod that needs to be implemented in the ServiceAgentClass
        /// </summary>
        /// <param name="DataSourceName"></param>
        /// <param name="TableName"></param>
        /// <param name="completed"></param>
        void GetColumns(string DataSourceName, String TableName, Action<List<EWAVColumn>, Exception> completed);

    }
}