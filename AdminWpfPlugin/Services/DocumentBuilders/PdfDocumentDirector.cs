using AdminWpfPlugin.Services.DocumentBuilders.Base;

namespace AdminWpfPlugin.Services.DocumentBuilders
{
    public class PdfDocumentDirector : DocumentDirector
    {
        public override void Construct(string path, object data)
        {
            if (!CanConstruct()) return;
            DocumentBuilder.CreateDocument();
            DocumentBuilder.InsertData(data);
            DocumentBuilder.SaveDocument(path);
        }
    }
}
