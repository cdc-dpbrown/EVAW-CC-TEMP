using System.Text;
using System.Xml;
using System.Xml.Linq;
namespace EWAV
{
    public interface IGadget
    {
        //event GadgetClosingHandler GadgetClosing;
        //event GadgetProcessingFinishedHandler GadgetProcessingFinished;

        StringBuilder HtmlBuilder { get; set; }
        void RefreshResults();
        XNode Serialize(XDocument doc);
        void CreateFromXml(XElement element);
        string ToHTML(bool ForDash = false, string htmlFileName = "", int count = 0);
        bool IsProcessing { get; set; }
        void SetGadgetToProcessingState();
        void SetGadgetToFinishedState();
        void UpdateVariableNames();
        //void UpdateStatusMessage(string statusMessage);
        string CustomOutputHeading { get; set; }
        string CustomOutputDescription { get; set; }
        string CustomOutputCaption { get; set; }
        void CloseGadget();
        void CloseGadgetOnClick();
    }
}