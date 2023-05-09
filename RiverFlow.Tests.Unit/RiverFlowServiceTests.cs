using CsvHelper;
using FakeItEasy;
using FluentAssertions;
using RiverFlow.Models;
using RiverFlow.Services;

namespace RiverFlow.Tests.Unit;

public class RiverFlowServiceTests
{
    private static readonly IDataImportService _dataImportService = A.Fake<IDataImportService>();
    
    private static IEnumerable<TestCaseData> RiverFlowService_TestCases()
        {
            var sectionMeasurements = new List<SectionMeasurement>
            {
                new SectionMeasurement
                {
                    Depth = 1.25,
                    Distance = 3.25,
                    Velocity = 4.15
                },
                new SectionMeasurement
                {
                    Depth = 2.25,
                    Distance = 2.1514,
                    Velocity = 7.75466526
                }
            };

            yield return new TestCaseData(sectionMeasurements, 54.396995390819001);
            yield return new TestCaseData(new List<SectionMeasurement>(), 0);
        }
    
    [TestCaseSource(nameof(RiverFlowService_TestCases))]
    public void CalculateRiverFlow_calculates_flow_correctly(List<SectionMeasurement> sectionMeasurements, double expectedResult)
    {
        // Arrange
        var riverFlowService = new RiverFlowService(_dataImportService);

        A.CallTo(() => _dataImportService.ImportCsv(A<string>._)).Returns(sectionMeasurements);

        // Act
        var result = riverFlowService.CalculateRiverFlow("Test.csv");
        
        // Assert
        result.Should().Be(expectedResult);
    }

    [Test]
    public void CalculateRiverFlow_throws_exception_if_data_import_throws_exception()
    {
        // Arrange
        A.CallTo(() => _dataImportService.ImportCsv(A<string>._)).Throws(new Exception("Some exception"));
        
        var riverFlowService = new RiverFlowService(_dataImportService);

        // Act & Assert
        Assert.That(() => riverFlowService.CalculateRiverFlow("Test.csv"), Throws.Exception);
    }
}