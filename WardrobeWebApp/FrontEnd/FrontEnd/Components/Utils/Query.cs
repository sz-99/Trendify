namespace FrontEnd.Components.Utils
{
    public class Query
    {
        string Category { get; set; } = "";
        string Size { get; set; } = "";
        string Occasion { get; set; } = ""; 
        string Season { get; set; } = "";
        public string CombinedQuery { get => String.Join("&", Values.Where(value => value != "" && value is not null)); }

        public bool IsEmpty { get => CombinedQuery == ""; }

        public string GetQueryParameter (string key)
        {
            switch (key)
            {
                case "Category":
                    return Category;
                case "Size":
                    return Size;
                case "Occasion":
                    return Occasion;
                case "Season":
                    return Season;
                default:
                    throw new ArgumentException($"No key {key}");
            }
        }

        public void SetQueryParameter (string key, string? value)
        {
            switch (key)
            {
                case "Category":
                    Category = value is null ? "" : value;
                    break;
                case "Size":
                    Size = value is null ? "" : value; ;
                    break;
                case "Occasion":
                    Occasion = value is null ? "" : value; 
                    break;
                case "Season":
                    Occasion = value is null ? "" : value;
                    break;
                default:
                    throw new ArgumentException($"No key {key}");
            }
        }

        public IEnumerable<string> Values { get => [Category, Size, Occasion, Season]; }
    }
}
