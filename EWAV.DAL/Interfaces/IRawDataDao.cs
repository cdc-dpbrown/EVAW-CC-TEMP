using System.Data;

namespace EWAV.DAL.Interfaces
{
    public interface IRawDataDao
    {
        DataTable GetColumnsForDatasource(DataRow[] dr);

        string GetRecordsCount(string datasourceName, string tableName, string FilterCriteria);

        DataTable GetTable(string Datasoucename, string connStr, string tableName);

        DataTable GetTopTwoTable(string Datasoucename, string connStr, string tableName);


        int CountRecords(string connStr, string sqlOrTableName);

        string GetTotalRecordsCount(string externalConnStr, string datasourceName);
    }
}

