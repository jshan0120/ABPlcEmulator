using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbPlcEmulator.Models;

namespace AbPlcEmulator.View
{
    public class SetTagValueEventArgs : EventArgs
    {
        public TagInfo Tag;
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }

        public SetTagValueEventArgs(TagInfo tag, int columnIndex, int rowIndex)
        {
            this.Tag = tag;
            this.RowIndex = rowIndex;
            this.ColumnIndex = columnIndex;
        }
    }
}
