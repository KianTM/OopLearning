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

        public Account(string accountNumber, string departmentNumber, decimal balance)
        {
            AccountNumber = accountNumber;
            DepartmentNumber = departmentNumber;
            Balance = balance;
        }

        public string AccountNumber
        {
            get => accountNumber;
            set
            {
                (bool isValid, string errMsg) = ValidateAccountNumber(value);
                if (isValid)
                    accountNumber = value;
                else
                    throw new ArgumentException(errMsg, nameof(AccountNumber));
            }
        }
        public string DepartmentNumber
        {
            get => departmentNumber;
            set
            {
                (bool isValid, string errMsg) = ValidateDepartmentNumber(value);
                if (isValid)
                    departmentNumber = value;
                else
                    throw new ArgumentException(errMsg, nameof(DepartmentNumber));
            }
        }
        public decimal Balance
        {
            get => balance;
            set
            {
                (bool isValid, string errMsg) = ValidateBalance(value);
                if (isValid)
                    balance = value;
                else
                    throw new ArgumentException(errMsg, nameof(Balance));
            }
        }

        private (bool isValid, string errMsg) ValidateAccountNumber(string accountNumber)
        {
            if (accountNumber is null)
                return (false, "Account number is null");

            if (accountNumber.Length == 10 && ValidateDigits(accountNumber))
                return (false, "Account number must be 10 characters");

            return (true, "");
        }

        private (bool isValid, string errMsg) ValidateDepartmentNumber(string departmentNumber)
        {
            if (departmentNumber is null)
                return (false, "Department number is null");

            if (departmentNumber.Length == 4 && ValidateDigits(departmentNumber))
                return (false, "Department number must be 4 characters");

            if (departmentNumber[0] == '0')
                return (false, "Department number cannot start with 0");

            return (true, "");
        }

        private (bool isValid, string errMsg) ValidateBalance(decimal balance)
        {
            if (balance < 0)
            {
                return (false, "Balance cannot be negative");
            }

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
