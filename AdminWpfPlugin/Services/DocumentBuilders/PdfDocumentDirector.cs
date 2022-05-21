using AdminWpfPlugin.Services.DocumentBuilders.Base;

namespace AdminWpfPlugin.Services.DocumentBuilders
{
    public class PdfDocumentDirector : DocumentDirector
    {
        public override bool Construct(string path, object data)
        {
            if (!CanConstruct()) return false;
            DocumentBuilder.CreateDocument();
            DocumentBuilder.InsertData(data);
            return DocumentBuilder.SaveDocument(path);
        }
    }
}
