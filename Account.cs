using System;
using System.Collections.Generic;
using System.Text;

namespace Part_C
{
    class Account
    {

        static int nextAccountID = 1;
        protected int accountID;
        protected string typeName;
        protected decimal balance;
        protected string lastTransaction;

        public Account()
        {
            accountID = nextAccountID;
            nextAccountID++;
            balance = 0;
            lastTransaction = "There are no transactions.";
        }

        public string NameAndBalance()
        {
            return (accountID + " " + typeName + " : $" + balance);
        }

        public virtual string Details()
        {
            return (accountID + " " + typeName + ", Balance: " + balance);
        }

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public string GetLastTransaction()
        {
            return lastTransaction;
        }

        public void Deposit(decimal depositAmount)
        {
            balance = (balance + depositAmount);
            lastTransaction = (typeName + " " + accountID.ToString() + ", Deposited: " + depositAmount + ", Balance: " + balance);
        }

        public virtual void Withdraw(decimal withdrawAmount)
        {
            if ((balance - withdrawAmount) >= 0)
            {
                balance = (balance - withdrawAmount);
                lastTransaction = ("Investment " + accountID.ToString() + ", Withdrawn: " + withdrawAmount + ", Balance: " + balance);
            }
            else
            {
                lastTransaction = ("Investment " + accountID.ToString() + ", Withdrawal failure - Not enough balance ");
            }
        }
    }

    class Everyday : Account
    {
        public Everyday()
        {
            typeName = "Everyday";
        }
    }

    class Investment : Account
    {
        protected decimal interestRate;
        protected decimal failedTransFee;

        public Investment(decimal newInterestRate, decimal newFailedTransFee)
        {
            typeName = "Investment";
            interestRate = newInterestRate;
            failedTransFee = newFailedTransFee;
        }

        public override string Details()
        {
            return (typeName + " " + accountID.ToString() + ", Interest Rate: " + interestRate);
        }
    }

    class Omni : Account
    {
        protected decimal interestRate;
        protected decimal failedTransFee;
        protected decimal overdraftLimit;

        public Omni(decimal newInterestRate, decimal newFailedTransFee, decimal newOverdraftLimit)
        {
            typeName = "Omni";
            interestRate = newInterestRate;
            failedTransFee = newFailedTransFee;
            overdraftLimit = newOverdraftLimit;
        }

        public override string Details()
        {
            return (typeName + " " + accountID.ToString() + ", Interest Rate: " + interestRate);
        }
    }
}
