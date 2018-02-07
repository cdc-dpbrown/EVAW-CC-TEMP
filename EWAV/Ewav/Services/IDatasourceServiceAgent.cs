using System;
using EWAV.BAL;
using EWAV.DTO;
using System.Collections.Generic;
using EWAV.Web.Services;

namespace EWAV.Services
{
    public interface IDatasourceServiceAgent
    {
        /// <summary>
        /// Gets the datasources2.
        /// </summary>
        /// <param name="datasourcesCompleted2">The datasources completed2.</param>
        void GetDatasources2(Action<IEnumerable<EWAVDatasourceDto>, Exception> completed);

    


        void DatasetRecordCount(string DatasetName, Action<long, Exception> completed);

        void DatasetFilteredRecordCount(string DatasetName, object Filter, Action<long, Exception> completed);

        void GetRecordCount(List<EWAVDataFilterCondition> filterList, List<EWAVRule_Base> rules, string tableName, string dsName, Action<string, Exception> completed);

        void GetRecordCount(List<EWAVRule_Base> rules,string s, string tableName, string dsName, Action<string, Exception> completed);

        void ReadFilterString(List<EWAVDataFilterCondition> filterList, List<EWAVRule_Base> rules, string tableName, string dsName, Action<string, Exception> completed);


        void ReadAllDatasourcesInMyOrg(int orgId, Action<List<DTO.DatasourceDto>, Exception> completed);
    }
}