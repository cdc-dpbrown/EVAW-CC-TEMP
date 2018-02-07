using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace EWAV.Web.EpiDashboard
{
    public interface IGadget
    {
      //   event GadgetClosingHandler GadgetClosing;
     //    event GadgetProcessingFinishedHandler GadgetProcessingFinished;

        void RefreshResults();
        XmlNode Serialize(XmlDocument doc);
        //void CreateFromXml(XmlElement element);
        string ToHTML(string htmlFileName = "", int count = 0);
        bool IsProcessing { get; set; }
        void SetGadgetToProcessingState();
        void SetGadgetToFinishedState();
        void UpdateVariableNames();
        //void UpdateStatusMessage(string statusMessage);
        string CustomOutputHeading { get; set; }
        string CustomOutputDescription { get; set; }
        string CustomOutputCaption { get; set; }
    }
}