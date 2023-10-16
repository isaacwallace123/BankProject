using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace BankProject2
{
    internal class Program
    {
        static bool Running = true;

        static void Main(string[] args)
        {
            try
            {
                HandleCommands();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Main(args);
            }
        }

        public static string Kill()
        {
            Running = false;

            Console.WriteLine("Killing the program...");

            return "Finsihed Running! ~Kill~";
        }

        public static string Test()
        {
            Console.WriteLine("This is a test command to basically test run!");

            return "Finsihed Running! ~Test~";
        }

        public static string Clear()
        {
            Console.Clear();

            return "Finished Running! ~Clear~";
        }

        public static string SavingsMenu()
        {
            Savings account = new Savings(5.0, 0.0);

            bool RunningBanking = true;

            String Exit()
            {
                RunningBanking = false;
                return "Return to menu...";
            }

            String Deposit()
            {
                double amount;

                Console.Write("Amount: ");

                while (!double.TryParse(Console.ReadLine(), out amount))
                {
                    Console.Write("Amount: ");
                }

                account.Deposit(amount);

                return $"Depositing ${amount}!";
            }

            String Withdrawal()
            {
                double amount;

                Console.Write("Amount: ");

                while (!double.TryParse(Console.ReadLine(), out amount))
                {
                    Console.Write("Amount: ");
                }

                account.Withdraw(amount);

                return $"Withdrawing ${amount}!";
            }

            String CloseAndReport()
            {
                return account.CloseAndReport();
            }

            String Display()
            {
                return account.ToString();
            }

            var Options = new Dictionary<string, Delegate>();

            Options["a"] = new Func<string>(Deposit);
            Options["b"] = new Func<string>(Withdrawal);
            Options["c"] = new Func<string>(CloseAndReport);
            Options["d"] = new Func<string>(Display);
            Options["r"] = new Func<string>(Exit);

            while (RunningBanking)
            {
                Console.WriteLine($"==============\nSavings Menu:\n\nA: Deposit\nB: Withdrawal\nC: Close + Report\nD: Display Account Info\nR: Return To Bank Menu\n==============");

                string command = "";

                while (!Options.ContainsKey(command))
                {
                    Console.Write("run: ");
                    command = Console.ReadLine().ToLower();
                }

                try
                {
                    Console.WriteLine(Options[command].DynamicInvoke());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"There was a problem with the command handler...\n\n{e}");
                }
            }

            return "Finished Running! ~Savings~";
        }

        public static string ChequingsMenu()
        {
            Chequing account = new Chequing(5.0, 0.0);

            bool RunningBanking = true;

            String Exit()
            {
                RunningBanking = false;
                return "Return to menu...";
            }

            String Deposit()
            {
                double amount;

                Console.Write("Amount: ");

                while (!double.TryParse(Console.ReadLine(), out amount))
                {
                    Console.Write("Amount: ");
                }

                account.Deposit(amount);

                return $"Depositing ${amount}!";
            }

            String Withdrawal()
            {
                double amount;

                Console.Write("Amount: ");

                while (!double.TryParse(Console.ReadLine(), out amount))
                {
                    Console.Write("Amount: ");
                }

                account.Withdraw(amount);

                return $"Withdrawing ${amount}!";
            }

            String CloseAndReport()
            {
                return account.CloseAndReport();
            }

            String Display()
            {
                return account.ToString();
            }

            var Options = new Dictionary<string, Delegate>();

            Options["a"] = new Func<string>(Deposit);
            Options["b"] = new Func<string>(Withdrawal);
            Options["c"] = new Func<string>(CloseAndReport);
            Options["d"] = new Func<string>(Display);
            Options["r"] = new Func<string>(Exit);

            while (RunningBanking)
            {
                Console.WriteLine($"==============\nChequing Menu:\n\nA: Deposit\nB: Withdrawal\nC: Close + Report\nD: Display Account Info\nR: Return To Bank Menu\n==============");

                string command = "";

                while (!Options.ContainsKey(command))
                {
                    Console.Write("run: ");
                    command = Console.ReadLine().ToLower();
                }

                try
                {
                    Console.WriteLine(Options[command].DynamicInvoke());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"There was a problem with the command handler...\n\n{e}");
                }
            }

            return "Finished Running! ~Chequings~";
        }

        public static string GlobalSavingsMenu()
        {
            GlobalSavings account = new GlobalSavings(5.0, 0.0);

            bool RunningBanking = true;

            String Exit()
            {
                RunningBanking = false;
                return "Return to menu...";
            }

            String Deposit()
            {
                double amount;

                Console.Write("Amount: ");

                while (!double.TryParse(Console.ReadLine(), out amount))
                {
                    Console.Write("Amount: ");
                }

                account.Deposit(amount);

                return $"Depositing ${amount}!";
            }

            String Withdrawal()
            {
                double amount;

                Console.Write("Amount: ");

                while (!double.TryParse(Console.ReadLine(), out amount))
                {
                    Console.Write("Amount: ");
                }

                account.Withdraw(amount);

                return $"Withdrawing ${amount}!";
            }

            String CloseAndReport()
            {
                return account.CloseAndReport();
            }

            String ReportInUSD()
            {
                return $"${account.USValue(0.77)}";
            }

            String Display()
            {
                return account.ToString();
            }

            var Options = new Dictionary<string, Delegate>();

            Options["a"] = new Func<string>(Deposit);
            Options["b"] = new Func<string>(Withdrawal);
            Options["c"] = new Func<string>(CloseAndReport);
            Options["d"] = new Func<string>(Display);
            Options["e"] = new Func<string>(ReportInUSD);
            Options["r"] = new Func<string>(Exit);

            while (RunningBanking)
            {
                Console.WriteLine($"==============\nGlobal Savings Menu:\n\nA: Deposit\nB: Withdrawal\nC: Close + Report\nD: Display Account Info\nE: Balance In USD\nR: Return To Bank Menu\n==============");

                string command = "";

                while (!Options.ContainsKey(command))
                {
                    Console.Write("run: ");
                    command = Console.ReadLine().ToLower();
                }

                try
                {
                   Console.WriteLine(Options[command].DynamicInvoke());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"There was a problem with the command handler...\n\n{e}");
                }
            }

            return "Finished Running! ~Global Savings~";
        }

        public static string Banking()
        {
            bool RunningBanking = true;

            String Exit()
            {
                RunningBanking = false;
                return "Exiting...";
            }

            var Options = new Dictionary<string, Delegate>();

            Options["a"] = new Func<string>(SavingsMenu);
            Options["b"] = new Func<string>(ChequingsMenu);
            Options["c"] = new Func<string>(GlobalSavingsMenu);
            Options["q"] = new Func<string>(Exit);

            while (RunningBanking)
            {
                Console.WriteLine($"==============\nBanking Menu:\n\nA: Savings\nB: Chequing\nC: Global Savings\nQ: Exit\n==============");

                string command = "";

                while (!Options.ContainsKey(command))
                {
                    Console.Write("run: ");
                    command = Console.ReadLine().ToLower();
                }

                try
                {
                    Console.WriteLine(Options[command].DynamicInvoke());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"There was a problem with the command handler...\n\n{e}");
                }
            }

            return "Finished Running! ~Banking~";
        }

        public static void HandleCommands()
        {
            var CommandList = new Dictionary<string, Delegate>();

            CommandList["kill"] = new Func<string>(Kill);
            CommandList["test"] = new Func<string>(Test);
            CommandList["clear"] = new Func<string>(Clear);
            CommandList["banking"] = new Func<string>(Banking);

            while (Running)
            {
                string command = "";

                while (!CommandList.ContainsKey(command))
                {
                    Console.Write("run: ");
                    command = Console.ReadLine().ToLower();
                }

                try
                {
                    Console.WriteLine(CommandList[command].DynamicInvoke());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"There was a problem with the command handler...\n\n{e}");
                }
            }

            Console.WriteLine("Command Handler Has Finished!");
        }
    }
}
