using System;
using System.Collections.Generic;

interface IWeatherObserver
{
    void Update(WeatherData weatherData);
}

class WeatherObserver1 : IWeatherObserver
{
    public void Update(WeatherData weatherData)
    {
        Console.WriteLine("Weather Observer 1:");
        Console.WriteLine("Temperature: " + weatherData.Temperature + "C");
        Console.WriteLine("Humidity: " + weatherData.Humidity + "%");
        Console.WriteLine("Pressure: " + weatherData.Pressure + "mmHg\n");
    }
}

class WeatherObserver2 : IWeatherObserver
{
    public void Update(WeatherData weatherData)
    {
        Console.WriteLine("Weather Observer 2:");
        Console.WriteLine("Temperature: " + weatherData.Temperature + "C");
        Console.WriteLine("Humidity: " + weatherData.Humidity + "%\n");
    }
}

class WeatherObserver3 : IWeatherObserver
{
    public void Update(WeatherData weatherData)
    {
        Console.WriteLine("Weather Observer 3:");
        Console.WriteLine("Temperature: " + weatherData.Temperature + "C");
        Console.WriteLine("Pressure: " + weatherData.Pressure + "mmHg\n");
    }
}

class WeatherData
{
    private float temperature;
    private float humidity;
    private float pressure;

    private List<IWeatherObserver> observers = new List<IWeatherObserver>();

    public float Temperature
    {
        get { return temperature; }
        set
        {
            temperature = value;
            NotifyObservers();
        }
    }

    public float Humidity
    {
        get { return humidity; }
        set
        {
            humidity = value;
            NotifyObservers();
        }
    }

    public float Pressure
    {
        get { return pressure; }
        set
        {
            pressure = value;
            NotifyObservers();
        }
    }

    public void AddObserver(IWeatherObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IWeatherObserver observer)
    {
        observers.Remove(observer);
    }

    private void NotifyObservers()
    {
        foreach (IWeatherObserver observer in observers)
        {
            observer.Update(this);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        WeatherData weatherData = new WeatherData();

        IWeatherObserver observer1 = new WeatherObserver1();
        IWeatherObserver observer2 = new WeatherObserver2();
        IWeatherObserver observer3 = new WeatherObserver3();

        weatherData.AddObserver(observer1);
        weatherData.AddObserver(observer2);
        weatherData.AddObserver(observer3);

        weatherData.Temperature = 20;
        weatherData.Humidity = 65;
        weatherData.Pressure = 760;

        weatherData.RemoveObserver(observer2);

        weatherData.Temperature = 22;
        weatherData.Humidity = 70;
        weatherData.Pressure = 755;

        Console.ReadLine();
    }
}
