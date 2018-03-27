namespace CDC.ISB.EIDEV.DAL.MySqlLayer
{
    using System;
    using System.Linq;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class Ext
    {
        public static bool SQLTest(this string s)
        {
            if (s.ToLower().Contains("select"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}