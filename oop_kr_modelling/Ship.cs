public abstract class Ship
{
    public readonly string Name;
    public readonly int ArriveTime;
    public readonly int TimeToService;
    public readonly int NumOfSlots;

    protected Ship(string name, int arriveTime, int timeToService, int numOfSlots)
    {
        Name = name;
        ArriveTime = arriveTime;
        TimeToService = timeToService;
        NumOfSlots = numOfSlots;
    }
}
