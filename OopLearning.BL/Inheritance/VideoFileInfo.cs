using System;
using System.Collections.Generic;
using System.Text;

namespace OopLearning.BL.Inheritance
{
    public class VideoFileInfo : ImageFileInfo
    {
        private int duration;

        public VideoFileInfo(int duration, int width, int height, string fileName, int fileSize, DateTime creationTime) : base(width, height, fileName, fileSize, creationTime)
        {
            Duration = duration;
        }

        public int Duration { get => duration; set => duration = value; }

        public override string ToString()
        {
            return $"Video: {FileName}";
        }
    }
}
