namespace AdminWpfPlugin.Services.DocumentBuilders.Base
{
    public interface IDocumentBuilder
    {
        void CreateDocument();
        void SaveDocument(string path);
        void InsertData(object data);
    }
}
