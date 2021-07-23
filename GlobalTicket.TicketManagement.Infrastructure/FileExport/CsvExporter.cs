﻿using CsvHelper;
using GlobalTicket.TicketManagement.Application.Contracts.Infrastructure;
using GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace GlobalTicket.TicketManagement.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportVm> eventExportVms)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                csvWriter.WriteRecords(eventExportVms);
            }

            return memoryStream.ToArray();
        }
    }
}