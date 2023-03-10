using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Represents a single customers bank account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Creates an account with a specific owner and a balance of 0
        /// </summary>
        /// <param name="accOwner"> The customer full name that owns the account</param>
        public Account(string accOwner)
        {
            Owner = accOwner;
      
        }
        /// <summary>
        /// The account holders full name (first and last)
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// The amount of money currently in the account
        /// </summary>

        public double Balance { get; private set; }

        /// <summary>
        /// Adds a specified amount of money to the account.
        /// </summary>
        /// <param name="amount">The positive amount to deposit</param>
        
        public double Deposit(double amount)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(amount)} must be more than 0");
            }

            Balance += amount;
            return Balance;
        }

        /// <summary>
        /// Withdraws an amount of money from the balance
        /// </summary>
        /// <param name="amount">The positive amount of money to be taken from the balance.</param>
        

        public double Withdraw(double amount)
        { 
            if(amount >= Balance) 
            {
                throw new ArgumentOutOfRangeException($"The {nameof(amount)} must be less than the {Balance}");
            }

            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(amount)} must be greater than 0");
            }


            Balance -= amount;
            return Balance;
        }
    }
}
