using System;

interface IDepositWithdraw

{

    void Deposit(double amount);
    void Withdraw(double amount);

}

interface ITransfer

{

    void Transfer(BankAccount toAccount, double amount);

}

class BankAccount : IDepositWithdraw, ITransfer
{

    private string owner;
    private double balance;

    public BankAccount(string owner, double balance)
    {

        this.owner = owner;
        this.balance = balance;

    }

    public void Deposit(double amount)
    {

        if (amount <= 0)

        {

            Console.WriteLine($"{owner}: Ошибка — сумма должна быть больше 0.");
            return;

        }

        balance += amount;
        Console.WriteLine($"{owner}: Пополнение на {amount}. Текущий баланс: {balance}");

    }

    public void Withdraw(double amount)
    {

        if (amount <= 0)

        {

            Console.WriteLine($"{owner}: Ошибка — сумма должна быть больше 0.");
            return;

        }

        if (amount > balance)

        {

            Console.WriteLine($"{owner}: Недостаточно средств для снятия {amount}. Баланс: {balance}");
            return;

        }

        balance -= amount;
        Console.WriteLine($"{owner}: Снятие {amount}. Текущий баланс: {balance}");

    }

    public void Transfer(BankAccount toAccount, double amount)

    {

        if (amount <= 0)

        {

            Console.WriteLine($"{owner}: Ошибка перевода — сумма должна быть больше 0.");
            return;

        }

        if (amount > balance)

        {

            Console.WriteLine($"{owner}: Ошибка перевода — недостаточно средств.");
            return;

        }

        Withdraw(amount);
        toAccount.Deposit(amount);
        Console.WriteLine($"{owner} перевёл {amount} на счёт {toAccount.owner}");

    }

    public void ShowBalance()

    {

        Console.WriteLine($"{owner}: текущий баланс = {balance}");

    }

}

class Program

{

    static void Main(string[] args)

    {

        BankAccount acc1 = new BankAccount("Иван", 1000);
        BankAccount acc2 = new BankAccount("Анна", 500);

        acc1.Transfer(acc2, 300);  
        acc2.Transfer(acc1, 200);  

        Console.WriteLine();
        acc1.ShowBalance();
        acc2.ShowBalance();

        Console.ReadLine();

    }

}