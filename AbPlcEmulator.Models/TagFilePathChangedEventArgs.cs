using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbPlcEmulator.Models
{
    public class TagFilePathChangedEventArgs : EventArgs
    {
        public string TagFilePath { get; set; }

        public TagFilePathChangedEventArgs(string tagFilePath)
        {
            TagFilePath = tagFilePath;
        }
    }
}
