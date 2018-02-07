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

namespace EWAV
{
    /// <summary>
    /// interface used to check the type. gadget or chart.
    /// </summary>
    public interface IMapMetaData
    {
        string type { get; }
        string tabindex { get; }
    }
}