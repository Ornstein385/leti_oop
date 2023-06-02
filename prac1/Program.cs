using System;

public abstract class Duck
{
    protected IFlyBehavior flyBehavior;
    protected IQuackBehavior quackBehavior;

    public void PerformFly()
    {
        flyBehavior.Fly();
    }

    public void PerformQuack()
    {
        quackBehavior.DoQuack();
    }

    public void Swim()
    {
        Console.WriteLine("All ducks float, even decoys!");
    }

    public abstract void Display();
}

public class MallardDuck : Duck
{
    public MallardDuck()
    {
        quackBehavior = new Quack();
        flyBehavior = new FlyWithWings();
    }

    public override void Display()
    {
        Console.WriteLine("I'm a real Mallard duck");
    }
}

public interface IFlyBehavior
{
    void Fly();
}

public class FlyWithWings : IFlyBehavior
{
    public void Fly()
    {
        Console.WriteLine("I'm flying!!");
    }
}

public class FlyNoWay : IFlyBehavior
{
    public void Fly()
    {
        Console.WriteLine("I can't fly");
    }
}
public interface IQuackBehavior
{
    void DoQuack();
}

public class Quack : IQuackBehavior
{
    public void DoQuack()
    {
        Console.WriteLine("Quack");
    }
}

public class Squeak : IQuackBehavior
{
    public void DoQuack()
    {
        Console.WriteLine("Squeak");
    }
}

public class RubberDuck : Duck
{
    public RubberDuck()
    {
        quackBehavior = new Squeak();
        flyBehavior = new FlyNoWay();
    }

    public override void Display()
    {
        Console.WriteLine("I'm a rubber duckie");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Duck mallard = new MallardDuck();
        mallard.PerformQuack();
        mallard.PerformFly();

        Duck rubberDuckie = new RubberDuck();
        rubberDuckie.PerformQuack();
        rubberDuckie.PerformFly();

        Console.ReadKey();
    }
}
