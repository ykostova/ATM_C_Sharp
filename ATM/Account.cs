using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
    /*
     *   The Account class encapusulates all features of a simple bank account
     */
    public class Account
    {
        //the attributes for the account
        private int balance;
        private int pin;
        private int accountNum;

        // a constructor that takes initial values for each of the attributes
        public Account(int balance, int pin, int accountNum)
        {
            this.balance = balance;
            this.pin = pin;
            this.accountNum = accountNum;
        }

        //Accessor method for the Balance
        public int getBalance()
        {
            return balance;
        }


        //Mutator method for the Balance
        public void setBalance(int newBalance)
        {
            this.balance = newBalance;
        }

        /*
         *   Decrements the balance if possible and returns if transaction performed or not.
         *   
         *   returns:
         *   true - if the transactions if possible
         *   false - if there are insufficent funds in the account
         */
        public Boolean decrementBalance(int amount)
        {
            if (this.balance > amount)
            {
                balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         *   Increments the balance if possible and returns if transaction performed or not.
         *   
         *   returns:
         *      NONE
         */
        public void incrementBalance(int amount)
        {
            balance += amount;
        }

        /*
         * This function checks the account pin against the parameter passed
         *
         * returns:
         *      true - if they match
         *      false - if they do not
         */
        public Boolean checkPin(int pinEntered)
        {
            if (pinEntered == pin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Accessor for the Account Number
        public int getAccountNum()
        {
            return accountNum;
        }

    }
}
