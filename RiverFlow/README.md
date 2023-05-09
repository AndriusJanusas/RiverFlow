In `SectionMeasurement` class I've assumed that we don't need super precise calculations (like dealing with currency) therefore I've used `double` type instead of `decimal` because it's much more performant.
Also I've assumed that property `Distance` in `SectionMeasurement` is the length of the segment and not the distance from the river bank.
Also assumed that all the values are in meters.

Due to time constraints I've only wrote couple tests for RiverFlowService and omitted tests for DataImportService.
One of the negative test scenario I've wrote is testing that river flow calculation method throws an exception if the data import throws exception. 
While it's not ideal to throw and not handle exceptions I just wanted to show that I didn't forget to add negative test scenario. 
In real production code we should handle exceptions and only throw them if really necessary.