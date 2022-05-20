using AdminWpfPlugin.Services.DocumentBuilders.Base;
using System;

namespace AdminWpfPlugin.Services.DocumentBuilders.PdfBuilders.Base
{
    public abstract class PdfReportBuilder : IDocumentBuilder
    {
        public void CreateDocument()
        {
            throw new NotImplementedException();
        }

        public void SaveDocument(string path)
        {
            throw new NotImplementedException();
        }

        public abstract void InsertData(object data);
    }
}
