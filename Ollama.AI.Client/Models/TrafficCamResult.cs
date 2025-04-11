public record TrafficCamResult
{
    public string CameraName { get; set; }
    public string CameraDescription { get; set; }
    public TrafficStatus Status { get; set; }
    public int NumberOfCars { get; set; }
    public int NumberOfTrucks { get; set; }
    public int NumberOfRedCars { get; set; }
    public int NumberOfPedestrians { get; set; }
}