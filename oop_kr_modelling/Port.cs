using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class Port
{
    private Port()
    {
        writer = new StreamWriter("log.txt", false);
        for (int i = 0; i < piers.Length; i++)
        {
            piers[i] = new Pier();
        }
    }

    private StreamWriter writer;

    private static Port port;

    public static Port GetInstance()
    {
        if (port == null)
        {
            port = new Port();
        }
        return port;
    }

    private Pier[] piers = new Pier[4];
    private int currentTime = 0;
    private int freeSlots = 4;

    private Queue<Ship> shipQueue = new Queue<Ship>();

    public void AddShip(Ship ship)
    {
        shipQueue.Enqueue(ship);
        Console.WriteLine("в расписание добавлен : " + ship + " " + ship.Name);
        writer.WriteLine("в расписание добавлен : " + ship + " " + ship.Name);
    }

    public void Simulate()
    {
        while (shipQueue.Count > 0)
        {
            Ship ship = shipQueue.Peek();
            if (ship.ArriveTime > currentTime)
            {
                currentTime = ship.ArriveTime;
            }
            if (ship.NumOfSlots <= freeSlots)
            {
                AddToService(ship);
                shipQueue.Dequeue();
            }
            else
            {
                RemoveToService();
            }
        }
        while (freeSlots < piers.Length)
        {
            RemoveToService();
        }
        writer.Close();
    }

    private void AddToService(Ship ship)
    {
        Console.Write("корабль " + ship.Name + " приплывает в " + currentTime + " ед. времени и занимает причалы:");
        writer.Write("корабль " + ship.Name + " приплывает в " + currentTime + " ед. времени и занимает причалы:");
        int cnt = 0;
        for (int i = 0; i < piers.Length; i++)
        {
            if (piers[i].GetServicedShip() == null)
            {
                piers[i].SetData(ship, currentTime, currentTime + ship.TimeToService);
                cnt++;
                Console.Write(" " + i);
                writer.Write(" " + i);
            }
            if (cnt == ship.NumOfSlots)
            {
                freeSlots -= cnt;
                Console.WriteLine(". он будет обслуживаться " + ship.TimeToService + " ед. времени");
                writer.WriteLine(". он будет обслуживаться " + ship.TimeToService + " ед. времени");
                break;
            }
        }
    }

    private void RemoveToService()
    {
        int min = int.MaxValue;
        int ind = -1;
        for (int i = 0; i < piers.Length; i++)
        {
            if (piers[i].GetServicedShip() != null && piers[i].GetFinishTime() < min)
            {
                min = piers[i].GetFinishTime();
                ind = i;
            }
        }
        if (ind < 0)
        {
            return;
        }
        currentTime = piers[ind].GetFinishTime();
        string cur = piers[ind].GetServicedShip().Name;
        freeSlots += piers[ind].GetServicedShip().NumOfSlots;
        Console.WriteLine("корабль " + piers[ind].GetServicedShip().Name + " отплывает в " + currentTime + " ед. времени");
        writer.WriteLine("корабль " + piers[ind].GetServicedShip().Name + " отплывает в " + currentTime + " ед. времени");
        for (int i = 0; i < piers.Length; i++)
        {
            if (piers[i].GetServicedShip() != null && piers[i].GetServicedShip().Name.Equals(cur))
            {
                Console.WriteLine("причал " + i + " освобождается в " + currentTime + " ед. времени");
                writer.WriteLine("причал " + i + " освобождается в " + currentTime + " ед. времени");
                piers[i].SetServicedShip(null);
            }
        }
    }
}