using System;
using System.Collections.Generic;
using System.Text;

namespace OopLearning.BL
{
    class Field
    {
        private double width;
        private double length;
        private double area;
        private string crop;
        private double yield;

        public double Width
        {
            get => width;
            set
            {
                (bool isValid, string errMsg) = ValidateWidth(value);
                if (isValid)
                    width = value;
                else
                    throw new ArgumentException(errMsg, nameof(Width));
            }
        }
        public double Length
        {
            get => length;
            set
            {
                (bool isValid, string errMsg) = ValidateLength(value);
                if (isValid)
                    length = value;
                else
                    throw new ArgumentException(errMsg, nameof(Length));
            }
        }
        public double Area
        {
            get
            {
                return width * length;
            }
        }
        public string Crop
        {
            get => crop;
            set
            {
                (bool isValid, string errMsg) = ValidateCrop(value);
                if (isValid)
                    crop = value;
                else
                    throw new ArgumentException(errMsg, nameof(Crop));
            }
        }
        public double Yield
        {
            get
            {
                switch (crop.ToLower())
                {
                    case "potatoes":
                        return (area / 100) * 2;
                    case "wheat":
                        return (area / 100) * 4;
                    case "oak":
                        return (area / 200) * 3;
                    case "carrots":
                        return (area / 30) * 2;
                    default:
                        return 0;
                }
            }
        }

        private (bool isValid, string errMsg) ValidateWidth(double width)
        {
            if (width <= 0)
                return (false, "Width must be more than 0");

            return (true, "");
        }

        private (bool isValid, string errMsg) ValidateLength(double length)
        {
            if (length <= 0)
                return (false, "Length must be more than 0");

            return (true, "");
        }

        private (bool isValid, string errMsg) ValidateCrop(string crop)
        {
            if (crop is null)
                return (false, "Crop is null");

            List<string> validCrops = new List<string>() { "potatoes", "wheat", "oak", "carrots" };
            if (!validCrops.Contains(crop.ToLower()))
                return (false, "Crop is not valid");

            return (true, "");
        }
    }
}
