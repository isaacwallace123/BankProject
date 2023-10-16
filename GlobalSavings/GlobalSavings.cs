using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface IExchangeable
{
    double USValue(double rate);
}

public class GlobalSavings : Savings, IExchangeable
{
    public GlobalSavings(double StartBalance, double Interest) : base(StartBalance, Interest) { }

    public double USValue(double rate)
    {
        return this.Balance * rate;
    }
}
