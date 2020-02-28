using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace vuelingDomain.Entities
{
    public enum Divisa
    {
        [EnumMember(Value = "EUR")]
        EUR,
        [EnumMember(Value = "CAD")]
        CAD,
        [EnumMember(Value = "USD")]
        USD,
        [EnumMember(Value = "AUD")]
        AUD
    }
}