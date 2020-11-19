using System;

class A
{
    public void GetA()
    {
        Console.WriteLine("A");
    }
}

class B : A
{
    public void GetB()
    {
        Console.WriteLine("B");
    }
}

class Program
{
    static void Main()
    {
        A[] array = new A[10];
        Random rand = new Random();

        for (int i = 0; i < array.Length; i++)
        {
            int cntr = rand.Next(0, 2);
            if (cntr == 0) array[i] = new A();
            else array[i] = new B();
        }

        foreach (var obj in array)
        {
            obj.GetA();
        }

        Console.WriteLine(Environment.NewLine + "Объекты класса В:");
        foreach (var obj in array)
        {
            if (obj is B) obj.GetA();
        }

        Console.WriteLine(Environment.NewLine + "Объекты класса А:");
        foreach (var obj in array)
        {
            if (obj is A) obj.GetA();
        }
    }
}