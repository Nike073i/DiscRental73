using AdminWpfPlugin.Services.DocumentBuilders.Base;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System.Collections.Generic;

namespace AdminWpfPlugin.Services.DocumentBuilders.PdfBuilders.Base
{
    public abstract class PdfReportBuilder : IDocumentBuilder
    {
        public string Title { get; set; }
        public string DataInfoFormat { get; set; } = "с {0} по {1} число";
        protected List<string> Headers { get; set; }
        protected List<string> HeaderColumns { get; set; }
        public int HeaderTextSize { get; set; } = 12;
        public int DataTextSize { get; set; } = 10;
        public double TitleSpaceAfterCm { get; set; } = 1;
        public double DataSpaceAfterCm { get; set; } = 0.25;

        protected Document _Document { get; set; }
        public void CreateDocument()
        {
            _Document = new Document();
            _Document.AddSection();
        }

        public bool SaveDocument(string path)
        {
            if (string.IsNullOrEmpty(path) || _Document is null) return false;
            if (!path.EndsWith(".pdf")) path += ".pdf";
            var renderer = new PdfDocumentRenderer(true,
                    PdfSharp.Pdf.PdfFontEmbedding.Always)
            { Document = _Document };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(path);
            return true;
        }

        public abstract void InsertData(object data);

        protected ParagraphFormat CreateTextFormat(int size, double spaceAfterCm, bool bold = false, bool italic = false, bool underline = false)
        {
            var font = new Font()
            {
                Bold = bold,
                Italic = italic,
                Underline = underline ? Underline.Single : Underline.None,
                Size = size
            };
            var format = new ParagraphFormat
            {
                Font = font,
                SpaceAfter = Unit.FromCentimeter(spaceAfterCm)
            };
            return format;
        }

        protected Row CreateRow(IEnumerable<string> line, ParagraphFormat format)
        {
            var row = new Row();
            var i = 0;
            foreach (var cell in line)
            {
                var newParagraph = row.Cells[i].AddParagraph(cell);
                newParagraph.Format = format.Clone();
                newParagraph.Format.Alignment = ParagraphAlignment.Center;
                i++;
            }

            return row;
        }
    }
}
