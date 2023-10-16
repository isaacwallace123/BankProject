using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum UserActivity
{
    Active,
    Inactive,
}
interface IUserInterface
{
    void Withdraw(double amount);
    void Deposit(double amount);
    void CalculateInterest();
    string CloseAndReport();
}

public abstract class Account : IUserInterface
{
    public double StartBalance = 0;
    public double Balance = 0;
    public int TotalDeposits = 0;
    public int TotalWithdrawls = 0;
    public double Interest = 0;
    public double ServiceCharge = 0;
    public UserActivity Activity = UserActivity.Inactive;

    protected Account(double StartBalance, double Interest)
    {
        this.StartBalance = StartBalance;
        this.Balance = StartBalance;
        this.Interest = Interest;
    }

    public abstract UserActivity HandleActivity();

    public void Withdraw(double amount)
    {
        this.Balance -= amount;
        this.TotalWithdrawls++;
    }
    public void Deposit(double amount)
    {
        this.Balance += amount;
        this.TotalDeposits++;
    }
    public void CalculateInterest()
    {
        this.Balance += this.Balance * (this.Interest / 12);
    }
    public string CloseAndReport()
    {
        this.Balance -= this.ServiceCharge;
        this.CalculateInterest();
        this.TotalWithdrawls = 0;
        this.TotalDeposits = 0;
        this.ServiceCharge = 0;
        return ($"Previous Balance: {this.StartBalance}\nNew Balance: {this.Balance}\nPercentage: {(this.Balance / this.StartBalance) * 100}%\n=============\n");
    }
    public override string ToString()
    {
        return $"Initial Balance: ${this.StartBalance}\nBalance: ${this.Balance}\nDeposits: {this.TotalDeposits}\nWithdrawls: {this.TotalWithdrawls}\nInterest: {this.Interest}%\nService Charge: ${this.ServiceCharge}\n===============";
    }
}