using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbPlcEmulator.View
{
    public class CellChangedEventArgs : EventArgs
    {
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
        public Type Type { get; set; }
        public object Value { get; set; }

        public CellChangedEventArgs(int columnIndex, int rowIndex, object value)
        {
            ColumnIndex = columnIndex;
            RowIndex = rowIndex;
            Value = value;
        }
    }
}
