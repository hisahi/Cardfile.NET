using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardfileDotNet.IO
{
    public class OleObject
    {
        public OleType Format;
        public string ClassString;
        public byte[] Data;
        public byte[] StaticData;
        public string NetworkName;
        public uint NetworkType;
        public uint LinkOption;
    }

    public enum OleType
    {
        Unknown = 0,
        Linked = 1,
        Embedded = 2,
        Static = 3
    }
}
