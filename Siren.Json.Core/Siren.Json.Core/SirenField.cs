using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siren.Json.Core
{
    public class SirenField
    {
        public SirenField(string name, SirenFieldType type = SirenFieldType.Text, string value = null)
        {
            Name = name;
            Type = type;
            Value = value;
        }

        public string Name { get; private set; }
        public SirenFieldType Type { get; private set; }
        public string Value { get; private set; }
    }
}
