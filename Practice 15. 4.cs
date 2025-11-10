using System;

interface IAttack

{

    void Attack();

}

interface IHeal

{

    void Heal();

}

class Warrior : IAttack

{

    public void Attack()
    {

        Console.WriteLine("Воин атакует мечом!");

    }

}

class Mage : IAttack, IHeal
{

    public void Attack()

    {

        Console.WriteLine("Маг атакует заклинанием!");

    }

    public void Heal()

    {

        Console.WriteLine("Маг лечит союзников!");

    }

}

class Program
{

    static void Main(string[] args)

    {

        object[] players = { new Warrior(), new Mage() };

        Console.WriteLine(" Атакующие игроки ");
        foreach (var p in players)
            if (p is IAttack a) a.Attack();

        Console.WriteLine("\n Лечащие игроки ");
        foreach (var p in players)
            if (p is IHeal h) h.Heal();

        Console.ReadLine();

    }

}