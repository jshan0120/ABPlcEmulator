using AbPlcEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbPlcEmulator.View
{
    public class ChangedTagsEventArgs : EventArgs
    {
        public Dictionary<string, TagInfo> Tags { get; set; }

        public ChangedTagsEventArgs(Dictionary<string, TagInfo> tags)
        {
            Tags = tags;
        }
    }
}
