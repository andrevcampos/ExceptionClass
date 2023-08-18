namespace ExceptionClass
{
    using System;
    using System.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Inverstiment(10, 500);
            try
            {
                int withdrawAmount = 700;
                account.Withdrawal(withdrawAmount);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine(ex.ToString());

            }

        }
    }
}