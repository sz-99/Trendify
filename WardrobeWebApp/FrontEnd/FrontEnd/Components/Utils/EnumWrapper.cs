using System.ComponentModel;

namespace FrontEnd.Components.Utils
{
    [TypeConverter(typeof(StringConverter))]
    public class EnumWrapper<T> where T : Enum
    {
        public T Value { get; set; }
        public EnumWrapper(T enumValue) 
        { 
            Value = enumValue;
        }

        public int AsInt { get => Convert.ToInt32(Value); }

        public override string ToString()
        {
            return Value.ToString();
        }

    }
}
