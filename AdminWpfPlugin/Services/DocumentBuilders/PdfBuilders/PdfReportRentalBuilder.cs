using AdminWpfPlugin.Models;
using AdminWpfPlugin.Services.DocumentBuilders.PdfBuilders.Base;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using System;
using System.Collections.Generic;

namespace AdminWpfPlugin.Services.DocumentBuilders.PdfBuilders
{
    public class PdfReportRentalBuilder : PdfReportBuilder
    {
        public override void InsertData(object input)
        {
            if (_Document is null || input is null || input is not CreateRentalReportReqDto reqDto) return;

            Title = "Отчет по прокатам";
            Headers = new List<string> { "Дата выдачи", "Диск", "Залог", "Возврат", "Клиент", "Сотрудник", };
            HeaderColumns = new List<string> { "2.5cm", "3.5cm", "2cm", "2cm", "3cm", "4cm" };

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

        private void InsertTable(ParagraphFormat dataFormat, ParagraphFormat headerFormat, List<RentalReportData> data)
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
                var rowHeader = CreateRow(new List<string> { line.DateOfIssue.ToShortDateString(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty }, dataFormat);
                tableSells.Rows.Add(rowHeader);

                foreach (var sell in line.Rentals)
                {
                    var texts = new List<string>
                    {
                        string.Empty,
                        sell.DiscTitle,
                        sell.PledgeSum.ToString(),
                        sell.ReturnSum.HasValue ? sell.ReturnSum.Value.ToString() : "в прокате",
                        sell.ClientCNumber,
                        sell.EmployeeFName
                    };
                    var row = CreateRow(texts, dataFormat);
                    tableSells.Rows.Add(row);
                }

                var totalGeneral = CreateRow(new List<string>
                {
                    string.Empty,
                    "Кол-во прокатов",
                    line.CountRentals.ToString(),
                    string.Empty,
                    "Выручка общая",
                    line.GeneralIncome.ToString()
                }, headerFormat);
                tableSells.Rows.Add(totalGeneral);

                var totalReturns = CreateRow(new List<string>
                {
                    string.Empty,
                    "Кол-во возвратов",
                    line.CountReturn.ToString(),
                    string.Empty,
                    "Выручка по возрату",
                    line.IncomeFromReturns.ToString()
                }, headerFormat);
                tableSells.Rows.Add(totalReturns);
            }

            tableSells.Rows.Alignment = RowAlignment.Center;
            tableSells.Format.SpaceAfter = Unit.FromCentimeter(TitleSpaceAfterCm);

            _Document.LastSection.Add(tableSells);
        }
    }
}
