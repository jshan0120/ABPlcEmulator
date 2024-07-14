using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbPlcEmulator.Models
{
    public class TagInfo
    {
        public string Name { get; set; }
        public TagTypes Type { get; set; }
        public int Size { get; set; }
        public object Value { get; set; }

        public TagInfo(string name, TagTypes type, int size) 
        {
            Name = name;
            Type = type;
            Size = size;
            SetDefaultValue();
        }

        public TagInfo(string name, string type, string size)
        {
            Name = name;
            Type = GetTagType(type);
            if (int.TryParse(size, out int size_out))
            {
                Size = size_out;
            }
            else
            {
                Size = 0;
            }
            SetDefaultValue();
        }

        private void SetDefaultValue()
        {
            switch (Type)
            {
                case TagTypes.Sint:
                case TagTypes.Int:
                case TagTypes.Dint:
                case TagTypes.Lint:
                    Value = 0;
                    break;
                case TagTypes.Real:
                case TagTypes.Lreal:
                    Value = 0.0;
                    break;
                case TagTypes.String:
                    Value = string.Empty;
                    break;
                case TagTypes.Bool:
                    Value = false;
                    break;
            }
        }

        public void SetValue(string value)
        {
            switch (Type)
            {
                case TagTypes.Sint:
                    Value = sbyte.Parse(value);
                    break;
                case TagTypes.Int:
                    Value = short.Parse(value);
                    break;
                case TagTypes.Dint:
                    Value = int.Parse(value);
                    break;
                case TagTypes.Lint:
                    Value = long.Parse(value);
                    break;
                case TagTypes.Real:
                    Value = float.Parse(value);
                    break;
                case TagTypes.Lreal:
                    Value = double.Parse(value);
                    break;
                case TagTypes.String:
                    Value = value;
                    break;
                case TagTypes.Bool:
                    Value = bool.Parse(value.ToLower());
                    break;
            }
        }

        private TagTypes GetTagType(string name)
        {
            if (name == "SINT")
            {
                return TagTypes.Sint;
            }
            else if (name == "INT")
            {
                return TagTypes.Int;
            }
            else if (name == "DINT")
            {
                return TagTypes.Dint;
            }
            else if (name == "LINT")
            {
                return TagTypes.Lint;
            }
            else if (name == "REAL")
            {
                return TagTypes.Real;
            }
            else if (name == "LREAL")
            {
                return TagTypes.Lreal;
            }
            else if (name == "STRING")
            {
                return TagTypes.String;
            }
            else if (name == "BOOL")
            {
                return TagTypes.Bool;
            }
            else
            {
                return TagTypes.None;
            }
        }
    }
}
