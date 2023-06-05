using System;
using System.Collections.Generic;
using System.IO;

public class Tester
{
    public static void Main(string[] args)
    {
        int a = 5, b = 10, c = 15, d = 10, e = 30, f = 20, g = 60, h = 40;

        Port port = Port.GetInstance();
        Random random = new Random();
        int time = 0;
        for (int i = 0; i < 50; i++)
        {
            time += (int)(a + random.NextDouble() * b);
            double x = random.NextDouble();
            if (x < 0.6)
            {
                port.AddShip(new SmallShip("sml_" + i, time, (int)(c + random.NextDouble() * d)));
            }
            else if (x < 0.9)
            {
                port.AddShip(new MiddleShip("mdl_" + i, time, (int)(e + random.NextDouble() * f)));
            }
            else
            {
                port.AddShip(new LargeShip("lrg_" + i, time, (int)(g + random.NextDouble() * h)));
            }
        }
        port.Simulate();
    }
}

//диаграма деятельности, состояния, gpss нотация для изобр очередей в СМО (сист масс обслуж)