namespace Backend
{
    static class DbTypeExtensions
    {
        public static DbType ToDbType(this string? dbTypeValue)
        {
            return dbTypeValue switch
            {
                "InMemory" => DbType.InMemory,
                "SqlServer" => DbType.SqlServer,
                null => throw new NotSupportedException("DbType cannot be null"),
                _ => throw new NotSupportedException($"{dbTypeValue} is not a known database type")
            };
        }
    }
}
