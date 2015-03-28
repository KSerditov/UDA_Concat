using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace CustomConcat
{
    [Serializable]
    [Microsoft.SqlServer.Server.
    SqlUserDefinedAggregate(
    Format.UserDefined,
    IsInvariantToNulls = true,
    IsInvariantToDuplicates = true,
    IsInvariantToOrder = false,
    MaxByteSize = 8000)]

    public struct CustomConcat : IBinarySerialize
    {
        private StringBuilder str;

        public void Init()
        {
            str = new StringBuilder();
        }

        public void Accumulate ( SqlString value)
        {
            this.str.Append(value);
        }

        public void Merge(CustomConcat group)
        {
            this.str.Append(group);
        }

        public SqlString Terminate()
        {
            return new SqlString(str.ToString());
        }

        public void Read(System.IO.BinaryReader r)
        {
            str = new StringBuilder(r.ReadString());
        }

        public void Write(System.IO.BinaryWriter w)
        {
            w.Write(str.ToString());
        }
    }
}
