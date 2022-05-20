using AdminWpfPlugin.Models;
using AdminWpfPlugin.Services.DocumentBuilders.PdfBuilders.Base;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using System;
using System.Collections.Generic;

namespace AdminWpfPlugin.Services.DocumentBuilders.PdfBuilders
{
    public class PdfReportSellBuilder : PdfReportBuilder
    {
        public override void InsertData(object input)
        {
            if (_Document is null || input is null || input is not CreateSellReportReqDto reqDto) return;

            Title = "Отчет по продажам";
            Headers = new List<string> { "Дата", "Диск", "Стоимость", "Сотрудник" };
            HeaderColumns = new List<string> { "2.5cm", "5cm", "4cm", "4cm" };

            var dateStart = reqDto.DateStart ?? new DateTime(1900, 1, 1);
            var dateEnd = reqDto.DateEnd ?? DateTime.Now;
            var data = reqDto.Data;

            var headerFormat = CreateTextFormat(HeaderTextSize, DataSpaceAfterCm, bold: true);
            var dataFormat = CreateTextFormat(DataTextSize, DataSpaceAfterCm);
            var titleFormat = CreateTextFormat(HeaderTextSize, TitleSpaceAfterCm, bold: true);

            InsertTitleAndCaption(titleFormat, dateStart, dateEnd);
            InsertTable(dataFormat, headerFormat, data);
        }

        private void InsertTitleAndCaption(ParagraphFormat titleFormat, DateTime dateStart, DateTime dateEnd)
        {
            Paragraph titleParagraph = new Paragraph();
            titleParagraph.AddText(Title);
            titleParagraph.Format = titleFormat.Clone();
            titleParagraph.Format.Alignment = ParagraphAlignment.Center;

            _Document.LastSection.Add(titleParagraph);

            Paragraph DateInfoParagraph = new Paragraph();
            DateInfoParagraph.AddText(string.Format(DataInfoFormat, dateStart.ToShortDateString(), dateEnd.ToShortDateString()));
            DateInfoParagraph.Format = titleFormat.Clone();
            DateInfoParagraph.Format.Alignment = ParagraphAlignment.Center;

            _Document.LastSection.Add(DateInfoParagraph);
        }

        private void InsertTable(ParagraphFormat dataFormat, ParagraphFormat headerFormat, List<SellReportData> data)
        {
            var borders = new Borders { Width = 1 };
            var tableSells = new Table
            {
                Borders = borders
            };

            foreach (var header in HeaderColumns)
            {
                tableSells.AddColumn(header);
            }

            var headerRow = CreateRow(Headers, headerFormat);
            tableSells.Rows.Add(headerRow);

            foreach (var line in data)
            {
                var rowHeader = CreateRow(new List<string> { line.DateOfSell.ToShortDateString(), string.Empty, string.Empty, string.Empty }, dataFormat);
                tableSells.Rows.Add(rowHeader);

                foreach (var sell in line.Sells)
                {
                    var texts = new List<string>
                    {
                        string.Empty,
                        sell.DiscTitle,
                        sell.Price.ToString(),
                        sell.EmployeeFName
                    };
                    var row = CreateRow(texts, dataFormat);
                    tableSells.Rows.Add(row);
                }
                var totalCount = CreateRow(new List<string> {
                    string.Empty,
                    string.Empty,
                    "Кол-во продаж",
                    line.Sells.Count.ToString(),
                }, headerFormat);
                tableSells.Rows.Add(totalCount);
                var totalIncome = CreateRow(new List<string> {
                    string.Empty,
                    string.Empty,
                    "Выручка",
                    line.Income.ToString(),
                }, headerFormat);
                tableSells.Rows.Add(totalIncome);
            }

            tableSells.Rows.Alignment = RowAlignment.Center;
            tableSells.Format.SpaceAfter = Unit.FromCentimeter(TitleSpaceAfterCm);

            _Document.LastSection.Add(tableSells);
        }
    }
}
