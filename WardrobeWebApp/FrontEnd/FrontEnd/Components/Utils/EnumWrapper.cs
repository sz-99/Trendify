using System.ComponentModel;

namespace FrontEnd.Components.Utils
{
    [TypeConverter(typeof(StringConverter))]
    public class EnumWrapper<T> where T : Enum
    {
        public T? Value { get; set; }
        public string? Label { get; set; }   
        public bool IsEmpty { get; set; }   

        public EnumWrapper()
        {
            Value = default(T);
            IsEmpty = true;
        }

        public EnumWrapper(T enumValue) 
        { 
            Value = enumValue;
        }


        public EnumWrapper(string label, string strValue)
        {
            Label = label;
            if (strValue == "-")
            {
                Value = default(T);
                IsEmpty = true;
                return;
            }
            Value = (T)Enum.Parse(typeof(T), strValue);
            IsEmpty = false;
        }

        public int AsInt { get => Convert.ToInt32(Value); }

        public override string ToString()
        {
            if (IsEmpty) return "-";
            return Value.ToString();
        }

        public List<string> StringValues { get => Values.Select(value => value.ToString()).Append("-").ToList(); }

        public string QueryString { get => IsEmpty ? "" : $"{Label}={AsInt}"; }

        public List<T> Values { get => Enum.GetValues(typeof(T)).Cast<T>().ToList(); }

    }
}
