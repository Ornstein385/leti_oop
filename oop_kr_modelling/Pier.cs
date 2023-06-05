using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Pier
{
    private Ship ServicedShip;
    private int StartTime, FinishTime;

    public Ship GetServicedShip()
    {
        return ServicedShip;
    }

    public void SetServicedShip(Ship servicedShip)
    {
        ServicedShip = servicedShip;
    }

    public int GetStartTime()
    {
        return StartTime;
    }

    public void SetStartTime(int startTime)
    {
        StartTime = startTime;
    }

    public int GetFinishTime()
    {
        return FinishTime;
    }

    public void SetFinishTime(int finishTime)
    {
        FinishTime = finishTime;
    }

    public void SetData(Ship servicedShip, int startTime, int finishTime)
    {
        ServicedShip = servicedShip;
        StartTime = startTime;
        FinishTime = finishTime;
    }
}
