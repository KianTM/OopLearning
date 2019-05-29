using System;
using System.Collections.Generic;
using System.Text;

namespace OopLearning.BL.Inheritance
{
    public class ImageFileInfo : CustomFileInfo
    {
        protected int width;
        protected int height;

        public ImageFileInfo(int width, int height, string fileName, int fileSize, DateTime creationTime) : base(fileName, fileSize, creationTime)
        {
            Width = width;
            Height = height;
        }

        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }

        public override bool IsSizeTooLarge()
        {
            if (FileSize > 45)
                return true;
            else if (Width > 1920 || Height > 1080)
                return true;
            return false;
        }
    }
}
