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
using System.Xml.Linq;

namespace EWAV
{
    public interface IEWAVDashboardRule
    {
        /// <summary>
        /// Creates from Xml e
        /// </summary>
        /// <param name="element">The Xml element</param>
        void CreateFromXml(XElement element);
    }
}