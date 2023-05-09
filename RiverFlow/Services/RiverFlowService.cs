namespace RiverFlow.Services;

public class RiverFlowService : IRiverFlowService
{
    private readonly IDataImportService _dataImportService;
    
    public RiverFlowService(IDataImportService dataImportService)
    {
        _dataImportService = dataImportService;
    }
    
    public double CalculateRiverFlow(string filePath)
    {
        var records = _dataImportService.ImportCsv(filePath);

        var result = records.Sum(record => record.Flow);

        return result;
    }
}