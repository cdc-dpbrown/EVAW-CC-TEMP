using System.Data;

namespace Ewav.Cache
{
    public interface ICacheEnabledDao
    {
        DataTable Refresh(string key);
    }
}