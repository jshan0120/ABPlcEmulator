using libplctag;
using libplctag.DataTypes.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbPlcEmulator.Models
{
    public class TagReader
    {
        public string IP { get; set; }

        private string _path = "1,0";
        private PlcType _plc = PlcType.ControlLogix;
        private Protocol _protocol = Protocol.ab_eip;

        public TagReader(string ip)
        {
            IP = ip;
        }

        public string TagRead(TagTypes type, string name)
        {
            switch (type)
            {
                case TagTypes.Sint:
                    return ReadSintTag(name);
                case TagTypes.Int:
                    return ReadIntTag(name);
                case TagTypes.Dint:
                    return ReadDintTag(name);
                case TagTypes.Lint:
                    return ReadLintTag(name);
                case TagTypes.Real:
                    return ReadRealTag(name);
                case TagTypes.Lreal:
                    return ReadLrealTag(name);
                case TagTypes.String:
                    return ReadStringTag(name);
                case TagTypes.Bool:
                    return ReadBoolTag(name);
                default:
                    return "";
            }
        }

        private string ReadSintTag(string name)
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
            return tag.Read().ToString();
        }

        private string ReadIntTag(string name)
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
            return tag.Read().ToString();
        }

        private string ReadDintTag(string name)
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
            return tag.Read().ToString();
        }

        private string ReadLintTag(string name)
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
            return tag.Read().ToString();
        }

        private string ReadRealTag(string name)
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
            return tag.Read().ToString();
        }

        private string ReadLrealTag(string name)
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
            return tag.Read().ToString();
        }

        private string ReadStringTag(string name)
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
            return tag.Read().ToString();
        }

        private string ReadBoolTag(string name)
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
            return tag.Read().ToString();
        }
    }
}
