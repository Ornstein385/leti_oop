using System;

public class SingletonCounter
{
    private static SingletonCounter instance;
    private static int count = 0;

    private SingletonCounter() { }

    public static SingletonCounter Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SingletonCounter();
            }
            return instance;
        }
    }

    public int GetCount()
    {
        return count++;
    }
}


public class Counter
{
    private static int count = 0;

    public int GetCount()
    {
        return count++;
    }
}


public class Tester {
    static void Main(string[] args)
    {
        // использование паттерна Одиночка
        SingletonCounter singletonCounter = SingletonCounter.Instance;
        for (int i = 0; i <= 10; i++)
        {
            Console.WriteLine("SingletonCounter: " + singletonCounter.GetCount());
        }

        Console.WriteLine();

        // без использования паттерна Одиночка
        Counter counter = new Counter();
        for (int i = 0; i <= 10; i++)
        {
            Console.WriteLine("Counter: " + counter.GetCount());
        }

        Console.ReadLine();
    }
}