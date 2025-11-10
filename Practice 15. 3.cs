using System;

interface IPrice

{

    double GetPrice();

}

interface IWarranty

{

    int GetWarranty();

}

class Phone : IPrice, IWarranty

{

    private double price;
    private int warranty;

    public Phone(double price, int warranty)

    {

        this.price = price;
        this.warranty = warranty;

    }

    public double GetPrice() => price;
    public int GetWarranty() => warranty;

}

class Laptop : IPrice

{

    private double price;

    public Laptop(double price)

    {

        this.price = price;

    }

    public double GetPrice() => price;

}

class Program

{

    static void Main(string[] args)

    {

        IPrice[] items = { new Phone(1980, 24   ), new Laptop(2000), new Phone(900, 12) };

        double total = 0;

        foreach (var item in items)

        {

            total += item.GetPrice();
            Console.WriteLine($"Цена товара: {item.GetPrice()}");

           
            if (item is IWarranty w)
                Console.WriteLine($"Гарантия: {w.GetWarranty()} месяцев");

        }

        Console.WriteLine($"Общая стоимость: {total}");
        Console.ReadLine();

    }

}