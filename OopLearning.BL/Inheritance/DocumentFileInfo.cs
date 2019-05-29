using System;
using System.Collections.Generic;
using System.Text;

namespace OopLearning.BL.Inheritance
{
    public class DocumentFileInfo : CustomFileInfo
    {
        public DocumentFileInfo(string fileName, int fileSize, DateTime creationTime) : base(fileName, fileSize, creationTime)
        {
        }
    }
}
