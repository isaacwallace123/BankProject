using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

public class Chequing : Account
{
    public Chequing(double StartBalance, double Interest) : base(StartBalance, Interest) { }

    public override UserActivity HandleActivity()
    {
        throw new NotImplementedException();
    }

    public override void Withdraw(double Amount)
    {
        this.ServiceCharge += this.Balance - Amount == 0 ? 15 : 0;

        if (this.Balance - Amount > 0)
        {
            base.Withdraw(Amount);
        }
    }

    public override String CloseAndReport()
    {
        this.ServiceCharge += 5;

        for (int i = 0; i < this.TotalWithdrawls; i++)
        {
            this.ServiceCharge += 0.1;
        }

        return base.CloseAndReport();
    }
}