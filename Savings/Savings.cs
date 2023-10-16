using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
public class Savings : Account
{
    public Savings(double StartBalance, double Interest) : base(StartBalance, Interest) { }

    public override UserActivity HandleActivity()
    {
        this.Activity = this.Balance >= 25 ? UserActivity.Active : UserActivity.Inactive;

        return this.Activity;
    }

    public override void Withdraw(double Amount)
    {
        if (HandleActivity() == UserActivity.Active)
        {
            base.Withdraw(Amount);
        }
    }

    public override void Deposit(double Amount)
    {
        if (HandleActivity() == UserActivity.Inactive)
        {
            base.Deposit(Amount);
        }
    }

    public override String CloseAndReport()
    {
        if (this.TotalWithdrawls > 4)
        {
            for (int i = 0; i < this.TotalWithdrawls; i++)
            {
                if (4 % i == 0)
                {
                    this.ServiceCharge++;
                }
            }
        }

        return base.CloseAndReport();
    }
}

