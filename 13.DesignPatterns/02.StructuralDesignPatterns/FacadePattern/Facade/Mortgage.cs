using System;

using FacadePattern.Contracts;

namespace FacadePattern.Models
{
    /// <summary>
    /// The 'Facade' class
    /// </summary>
    public class Mortgage
    {
        private Bank bank;
        private Loan loan;
        private Credit credit;

        public Mortgage(Bank bank, Loan loan, Credit credit)
        {
            if (bank == null)
            {
                throw new NullReferenceException();
            }

            if (loan == null)
            {
                throw new NullReferenceException();
            }

            if (credit == null)
            {
                throw new NullReferenceException();
            }

            this.bank = bank;
            this.loan = loan;
            this.credit = credit;
        }

        public bool IsEligible(ICustomer currentCustomer, int amount)
        {
            Console.WriteLine("{0} applies for {1:C} loan\n",
              currentCustomer.Name, amount);

            bool eligible = true;

            // Check creditworthyness of applicant
            if (!bank.HasSufficientSavings(currentCustomer, amount))
            {
                eligible = false;
            }
            else if (!loan.HasNoBadLoans(currentCustomer))
            {
                eligible = false;
            }
            else if (!credit.HasGoodCredit(currentCustomer))
            {
                eligible = false;
            }

            return eligible;
        }
    }
}
