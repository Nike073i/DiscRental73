using AdminWpfPlugin.Services.DocumentBuilders.Base;

namespace AdminWpfPlugin.Services.DocumentBuilders
{
    public class PdfDocumentDirector : DocumentDirector
    {
        public override void Construct()
        {
            if (!CanConstruct()) return;
            DocumentBuilder.CreateDocument();
            DocumentBuilder.InsertData(null);
            DocumentBuilder.SaveDocument("");
        }
    }
}
