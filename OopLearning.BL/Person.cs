using System;
using System.Collections.Generic;
using System.Text;

namespace OopLearning.BL
{
    public class Person
    {
        private string name;
        private string cpr;
        private bool isWoman;

        public Person()
        {
        }

        public Person(string name, string cpr)
        {
            Name = name;
            Cpr = cpr;
        }

        public string Name {
            get => name;
            set
            {
                (bool isValid, string errMsg) = ValidateName(value);
                if (isValid)
                    name = value;
                else
                    throw new ArgumentException(errMsg, nameof(Name));
            }
        }
        public DateTime Birthday
        {
            get
            {
                (bool isValid, string errMsg) = ValidateCpr(cpr);
                if (isValid)
                {
                    string shortenedCpr = cpr.Remove(6);

                    string dateFormattedCpr = shortenedCpr.Insert(2, "-");
                    dateFormattedCpr = dateFormattedCpr.Insert(5, "-");

                    bool validateConversion = DateTime.TryParse(dateFormattedCpr, out DateTime dateFromCpr);

                    if (validateConversion)
                        return dateFromCpr;  
                }
                throw new InvalidOperationException("Could not convert CPR to valid DateTime");
            }
        }
        public string Cpr
        {
            get => cpr;
            set
            {
                (bool isValid, string errMsg) = ValidateCpr(value);
                if (isValid)
                    cpr = value;
                else
                    throw new ArgumentException(errMsg, nameof(Cpr));
            }
        }
        public bool IsWoman
        {
            get
            {
                int.TryParse(cpr.Remove(0, 6), out int shortenedCpr);

                if (shortenedCpr % 2 == 0)
                    return true;
                return false;
            }
        }

        public static (bool isValid, string errorMsg) ValidateName(string name)
        {
            if (name is null)
                return (false, "Name is null");

            name = name.Trim();
            if (string.IsNullOrWhiteSpace(name))
                return (false, "Name only contains white space");

            if (name.Length <= 1)
                return (false, "Name must be longer than one character");

            if (!name.Contains(" "))
                return (false, "Name must contain at least one space");

            return (true, "");
        }

        public static (bool isValid, string errMsg) ValidateCpr(string cpr)
        {
            if (cpr is null)
                return (false, "CPR is null");

            if (cpr.Length != 10 && ValidateDigits(cpr))
                return (false, "CPR must be 10 characters");

            if (!ValidateCprDate(cpr))
                return (false, "CPR is not a valid date or is in the future");

            return (true, "");
        }

        public static bool ValidateDigits(string cpr)
        {
            foreach (char c in cpr)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ValidateCprDate(string cpr)
        {
            string shortenedCpr = cpr.Remove(6);

            string dateFormattedCpr = shortenedCpr.Insert(2, "-");
            dateFormattedCpr = dateFormattedCpr.Insert(5, "-");

            bool validateConversion = DateTime.TryParse(dateFormattedCpr, out DateTime dateFromCpr);

            if (dateFromCpr > DateTime.Today)
                return false;

            return validateConversion;
        }
    }
}
