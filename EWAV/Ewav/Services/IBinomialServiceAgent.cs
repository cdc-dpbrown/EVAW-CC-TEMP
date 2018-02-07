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
using EWAV.Web.Services;

namespace EWAV.Services
{
    public interface IBinomialServiceAgent
    {
        void GetBinomialStatCalc(string txtNumerator, string txtObserved, string txtExpected, Action<BinomialStatCalcDTO, Exception> completed);
         
    }
}