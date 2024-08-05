using CoPick.Logging;
using libplctag;
using libplctag.DataTypes.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AbPlcEmulator.Models
{
    public class TagWriter
    {
        public string IP { get; set; }

        private string _path = "1,0";
        private PlcType _plc = PlcType.ControlLogix;
        private Protocol _protocol = Protocol.ab_eip;

        public TagWriter(string ip) 
        { 
            IP = ip;
        }

        public void TagWrite(TagTypes type, string name, object value)
        {
            try
            {
                switch (type)
                {
                    case TagTypes.Sint:
                        WriteSintTag(name, value);
                        break;
                    case TagTypes.Int:
                        WriteIntTag(name, value);
                        break;
                    case TagTypes.Dint:
                        WriteDintTag(name, value);
                        break;
                    case TagTypes.Lint:
                        WriteLintTag(name, value);
                        break;
                    case TagTypes.Real:
                        WriteRealTag(name, value);
                        break;
                    case TagTypes.Lreal:
                        WriteLrealTag(name, value);
                        break;
                    case TagTypes.String:
                        WriteStringTag(name, value);
                        break;
                    case TagTypes.Bool:
                        WriteBoolTag(name, value);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Logger.Warning($"Write Value To Tag Failed: {ex}");
            }
        }

        private void WriteSintTag(string name, object value)
        {
            TagSint tag = new TagSint()
            {
                Gateway = IP,
                Path = _path,
                PlcType = _plc,
                Name = name,
                Protocol = _protocol,
                AllowPacking = true
            };
            tag.Initialize();
            tag.Write((sbyte)value);
        }

        private void WriteIntTag(string name, object value)
        {
            TagInt tag = new TagInt()
            {
                Gateway = IP,
                Path = _path,
                PlcType = _plc,
                Name = name,
                Protocol = _protocol,
                AllowPacking = true
            };
            tag.Initialize();
            tag.Write((short)value);
        }

        private void WriteDintTag(string name, object value)
        {
            TagDint tag = new TagDint()
            {
                Gateway = IP,
                Path = _path,
                PlcType = _plc,
                Name = name,
                Protocol = _protocol,
                AllowPacking = true
            };
            tag.Initialize();
            tag.Write((int)value);
        }

        private void WriteLintTag(string name, object value)
        {
            TagLint tag = new TagLint()
            {
                Gateway = IP,
                Path = _path,
                PlcType = _plc,
                Name = name,
                Protocol = _protocol,
                AllowPacking = true
            };
            tag.Initialize();
            tag.Write((long)value);
        }

        private void WriteRealTag(string name, object value)
        {
            TagReal tag = new TagReal()
            {
                Gateway = IP,
                Path = _path,
                PlcType = _plc,
                Name = name,
                Protocol = _protocol,
                AllowPacking = true
            };
            tag.Initialize();
            tag.Write((float)value);
        }

        private void WriteLrealTag(string name, object value)
        {
            TagLreal tag = new TagLreal()
            {
                Gateway = IP,
                Path = _path,
                PlcType = _plc,
                Name = name,
                Protocol = _protocol,
                AllowPacking = true
            };
            tag.Initialize();
            tag.Write((double)value);
        }

        private void WriteStringTag(string name, object value)
        {
            TagString tag = new TagString()
            {
                Gateway = IP,
                Path = _path,
                PlcType = _plc,
                Name = name,
                Protocol = _protocol,
                AllowPacking = true
            };
            tag.Initialize();
            tag.Write((string)value);
        }

        private void WriteBoolTag(string name, object value)
        {
            TagBool tag = new TagBool()
            {
                Gateway = IP,
                Path = _path,
                PlcType = _plc,
                Name = name,
                Protocol = _protocol,
                AllowPacking = true
            };
            tag.Initialize();
            tag.Write((bool)value);
        }
    }
}
