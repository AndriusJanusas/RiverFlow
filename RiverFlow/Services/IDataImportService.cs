using RiverFlow.Models;

namespace RiverFlow.Services;

public interface IDataImportService
{
    IReadOnlyCollection<SectionMeasurement> ImportCsv(string filePath);
}