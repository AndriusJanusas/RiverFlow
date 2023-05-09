namespace RiverFlow.Models;

public class SectionMeasurement
{
    public double Depth { get; set; }
    
    public double Distance { get; set; }

    public double Velocity { get; set; }
    
    public double Flow => Depth * Distance * Velocity;
}