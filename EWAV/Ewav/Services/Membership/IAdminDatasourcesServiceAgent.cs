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
using EWAV.DTO;
using System.Collections.Generic;
using EWAV.BAL;

namespace EWAV.Services
{
    public interface IAdminDatasourcesServiceAgent
    {
        void TestDBConnection(Connection con, Action<bool, Exception> completed);

        void TestData(Connection connectionInfo, Action<bool, Exception> completed);

        void Add(DatasourceDto dto, Action<bool, Exception> completed);

        void Delete(int dsId, Action<bool, Exception> completed);

        void Update(DatasourceDto dto,  Action<bool, Exception> completed);

        void Read(int orgId, Action<List<DatasourceDto>, Exception> completed);

        void ReadAssociatedUsers(int dsId, int orgId, Action<List<UserDTO>, Exception> completed);

        void GetAllDatasourceUser(Action<IEnumerable<DatasourceUserDto>, Exception> completed);

        void CopyDashboard(string OldCanvasName, string NewCanvasName,
                                    string OldDatasourceName, string NewDatasourceName, Action<string, Exception> completed);
        void ReadEWEDatasourceFormId(EWEDatasourceDto EWEDsDto, Action<string, Exception> completed);
    }
}