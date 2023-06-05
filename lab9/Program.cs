using System;

interface IMovable
{
    void Move(int x, int y, int z);
}

abstract class Furniture
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int Length { get; set; }
    public string Material { get; set; }

    protected Furniture(int width, int height, int length, string material)
    {
        Width = width;
        Height = height;
        Length = length;
        Material = material;
    }
}

class Table : Furniture, IMovable
{
    public int NumberOfLegs { get; set; }

    public Table(int width, int height, int length, string material, int numberOfLegs)
        : base(width, height, length, material)
    {
        NumberOfLegs = numberOfLegs;
    }

    public void Move(int x, int y, int z)
    {
        Console.WriteLine($"Стол передвинули в точку ({x}, {y}, {z})");
    }
}

class Chair : Furniture, IMovable
{
    public bool HasBackrest { get; set; }

    public Chair(int width, int height, int length, string material, bool hasBackrest)
        : base(width, height, length, material)
    {
        HasBackrest = hasBackrest;
    }

    public void Move(int x, int y, int z)
    {
        Console.WriteLine($"Стул передвинули в точку ({x}, {y}, {z})");
    }
}

class Cupboard : Furniture, IMovable
{
    public int NumberOfDoors { get; set; }

    public Cupboard(int width, int height, int length, string material, int numberOfDoors)
        : base(width, height, length, material)
    {
        NumberOfDoors = numberOfDoors;
    }

    public void Move(int x, int y, int z)
    {
        Console.WriteLine($"Шкаф передвинули в точку ({x}, {y}, {z})");
    }
}

class Sofa : Furniture, IMovable
{
    public int NumberOfSeats { get; set; }

    public Sofa(int width, int height, int length, string material, int numberOfSeats)
        : base(width, height, length, material)
    {
        NumberOfSeats = numberOfSeats;
    }

    public void Move(int x, int y, int z)
    {
        Console.WriteLine($"Диван передвинули в точку ({x}, {y}, {z})");
    }
}

class Tester
{
    static void Main(string[] args)
    {
        // Создаем объекты мебели
        Table table = new Table(140, 80, 120, "дерево", 4);
        Chair chair = new Chair(50, 60, 50, "металл", true);
        Cupboard cupboard = new Cupboard(150, 220, 60, "пластик", 2);
        Sofa sofa = new Sofa(250, 120, 80, "ткань", 3);

        // Выводим информацию о мебели
        Console.WriteLine($"Ширина стола: {table.Width}");
        Console.WriteLine($"Высота стола: {table.Height}");
        Console.WriteLine($"Длина стола: {table.Length}");
        Console.WriteLine($"Материал стола: {table.Material}");
        Console.WriteLine($"Количество ножек у стола: {table.NumberOfLegs}");
        Console.WriteLine();

        Console.WriteLine($"Ширина стула: {chair.Width}");
        Console.WriteLine($"Высота стула: {chair.Height}");
        Console.WriteLine($"Длина стула: {chair.Length}");
        Console.WriteLine($"Материал стула: {chair.Material}");
        Console.WriteLine($"Наличие спинки у стула: {chair.HasBackrest}");
        Console.WriteLine();

        Console.WriteLine($"Ширина шкафа: {cupboard.Width}");
        Console.WriteLine($"Высота шкафа: {cupboard.Height}");
        Console.WriteLine($"Длина шкафа: {cupboard.Length}");
        Console.WriteLine($"Материал шкафа: {cupboard.Material}");
        Console.WriteLine($"Количество дверей у шкафа: {cupboard.NumberOfDoors}");
        Console.WriteLine();

        Console.WriteLine($"Ширина дивана: {sofa.Width}");
        Console.WriteLine($"Высота дивана: {sofa.Height}");
        Console.WriteLine($"Длина дивана: {sofa.Length}");
        Console.WriteLine($"Материал дивана: {sofa.Material}");
        Console.WriteLine($"Количество мест на диване: {sofa.NumberOfSeats}");
        Console.WriteLine();

        // Перемещаем мебель
        table.Move(10, 25, 0);
        chair.Move(-5, 150, 0);
        cupboard.Move(30, -15, 0);
        sofa.Move(120, -10, 0);
    }
}