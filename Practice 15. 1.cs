using System;

interface IWorkable

{

    void Work();

}

interface IRechargeable

{

    void Recharge();

}

class Robot : IWorkable, IRechargeable
{
    private string name;
    private int energy;

    public Robot(string name, int energy)

    {

        this.name = name;
        this.energy = energy;

    }

    public void Work()
    {

        if (energy > 0)

        {

            energy -= 20;
            if (energy < 0)
                energy = 0;
            Console.WriteLine($"{name} работает. Энергия: {energy}%");

        }
        else

        {

            Console.WriteLine($"{name} не может работать — нужна зарядка!");

        }

    }

    public void Recharge()

    {

        energy += 50;
        if (energy > 100)
            energy = 100;
        Console.WriteLine($"{name} заряжается. Энергия: {energy}%");

    }
}

class Program
{
    static void Main(string[] args)
    {

        
        Robot r1 = new Robot("Бэймакс", 80);

        r1.Work();
        r1.Work();

        r1.Recharge();

        r1.Work();

        Console.ReadLine();

    }
}