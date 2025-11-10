using System;

interface ISwitchable

{

    void TurnOn();
    void TurnOff();

}

interface IAdjustable

{

    void SetLevel(int level);

}

class Lamp : ISwitchable, IAdjustable

{

    private int level;
    private bool isOn;

    public void TurnOn()
    {

        isOn = true;
        level = 100;
        Console.WriteLine($"Лампа включена. Уровень освещения: {level}%");

    }

    public void TurnOff()

    {

        isOn = false;
        level = 0;
        Console.WriteLine("Лампа выключена.");

    }

    public void SetLevel(int level)

    {

        if (level < 0) level = 0;
        if (level > 100) level = 100;
        this.level = level;
        Console.WriteLine($"Установлен уровень освещения: {this.level}%");

    }

}

class Fan : ISwitchable

{

    private bool isOn;

    public void TurnOn()

    {

        isOn = true;
        Console.WriteLine("Вентилятор включен.");

    }

    public void TurnOff()

    {

        isOn = false;
        Console.WriteLine("Вентилятор выключен.");

    }

}

class Program
{

    static void Main(string[] args)

    {

        ISwitchable[] devices = { new Lamp(), new Fan() };

      
        foreach (var d in devices)
            d.TurnOn();

        
        Lamp lamp = new Lamp();
        lamp.TurnOn();
        lamp.SetLevel(30);

        
        foreach (var d in devices)
            d.TurnOff();

        Console.ReadLine();

    }

}
