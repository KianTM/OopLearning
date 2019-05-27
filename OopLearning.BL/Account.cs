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
    }

    public (bool isValid, string errMsg) ValidateAccountNumber(string accountNumber)
    {

    }
}
