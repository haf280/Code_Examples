using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuxiliaryLibrary
{
    public class NamedParameter
    {
        public string Name { get; set; }
        public dynamic Value { get; set; }
        public Type ValueType { get; set; }

        public NamedParameter(string name, dynamic value, Type valueType)
        {
            Name = name;
            Value = value;
            ValueType = valueType;
        }
    }
}
