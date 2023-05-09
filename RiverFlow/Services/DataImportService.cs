using System.Globalization;
using CsvHelper;
using RiverFlow.Models;

namespace RiverFlow.Services;

public class DataImportService : IDataImportService
{
    public IReadOnlyCollection<SectionMeasurement> ImportCsv(string filePath)
    {
        using var reader = new StreamReader(filePath);
        
        using var csv = new CsvReader(reader, CultureInfo.CurrentCulture);
        
        var records = csv.GetRecords<SectionMeasurement>();
        
        return records.ToArray();
    }
}