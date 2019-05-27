using System;
using System.Collections.Generic;
using System.Text;

namespace OopLearning.BL
{
    class Account
    {
        private string accountNumber;
        private string departmentNumber;
        private decimal balance;

        public string AccountNumber { get => accountNumber; set => accountNumber = value; }
        public string DepartmentNumber { get => departmentNumber; set => departmentNumber = value; }
        public decimal Balance { get => balance; set => balance = value; }

        private (bool isValid, string errMsg) ValidateAccountNumber(string accountNumber)
        {
            if (accountNumber is null)
                return (false, "Account number is null");

            if (accountNumber.Length == 10 && ValidateDigits(accountNumber))
                return (false, "Account number must be 10 characters");

            return (true, "");
        }

        private bool ValidateDigits(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
