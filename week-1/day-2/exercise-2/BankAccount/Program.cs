namespace BankAccount
{
    internal class BankAccount
    { 

    private string accountNumber;
    protected double balance;

    public BankAccount(string accountNumber)
    {
        this.accountNumber = accountNumber;
        balance = 0;
    }

    public virtual void Deposit(double amount)
    {
        balance += amount;
        Console.WriteLine("Deposit: $" + amount);
    }

    public virtual void Withdraw(double amount)
    {
        if (balance >= amount)
        {
            balance -= amount;
            Console.WriteLine("Withdrawal: $" + amount);
        }
        else
        {
            Console.WriteLine("Insufficient funds!");
        }
    }

    public void DisplayBalance()
    {
        Console.WriteLine("Account Number: " + accountNumber);
        Console.WriteLine("Current Balance: $" + balance);
    }
}

internal class SavingsAccount : BankAccount
{
    private double interestRate;

    public SavingsAccount(string accountNumber, double interestRate) : base(accountNumber)
    {
        this.interestRate = interestRate;
    }

    public void CalculateInterest()
    {
        double interestAmount = balance * interestRate / 100;
        balance += interestAmount;
        Console.WriteLine("Interest Calculated: $" + interestAmount);
    }
}

internal class CheckingAccount : BankAccount
{
    private double overdraftLimit;

    public CheckingAccount(string accountNumber, double overdraftLimit) : base(accountNumber)
    {
        this.overdraftLimit = overdraftLimit;
    }

    public override void Withdraw(double amount)
    {
        if (balance + overdraftLimit >= amount)
        {
            balance -= amount;
            Console.WriteLine("Withdrawal: $" + amount);
        }
        else
        {
            Console.WriteLine("Insufficient funds! You have reached the overdraft limit.");
        }
    }
}

internal class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount savingsAccount = new SavingsAccount("SA001", 5);

            
            savingsAccount.Deposit(1000);

            
            savingsAccount.CalculateInterest();

            
            savingsAccount.DisplayBalance();

            Console.WriteLine();

            CheckingAccount checkingAccount = new CheckingAccount("CA001", 500);

            
            checkingAccount.Deposit(800);

            
            checkingAccount.Withdraw(1200);

            
            checkingAccount.DisplayBalance();

            Console.ReadLine();
        }
    }
}
