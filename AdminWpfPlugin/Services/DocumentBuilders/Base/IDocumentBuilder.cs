namespace AdminWpfPlugin.Services.DocumentBuilders.Base
{
    public interface IDocumentBuilder
    {
        void CreateDocument();
        bool SaveDocument(string path);
        void InsertData(object data);
    }
}
