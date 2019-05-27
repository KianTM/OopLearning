using System;
using System.Collections.Generic;
using System.Text;

namespace OopLearning.BL
{
    class Person
    {
        private string name;
        private string cpr;
        private bool isWoman;

        public Person(string name, string cpr, bool isWoman)
        {
            Name = name;
            Cpr = cpr;
            IsWoman = isWoman;
        }

        public string Name { get => name; set => name = value; }
        public DateTime Birthday
        {
            get
            {
                string shortenedCpr = cpr.Remove(6);

                string dateFormattedCpr = shortenedCpr.Insert(2, "-");
                dateFormattedCpr = dateFormattedCpr.Insert(5, "-");

                bool validateConversion = DateTime.TryParse(dateFormattedCpr, out DateTime dateFromCpr);

                if (validateConversion)
                    return dateFromCpr;
                else
                    throw new InvalidOperationException("Could not convert CPR to valid DateTime");
            }
        }
        public string Cpr { get => cpr; set => cpr = value; }
        public bool IsWoman { get => isWoman; set => isWoman = value; }

        public (bool isValid, string errorMsg) ValidateName(string name)
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
    }
}
