namespace DataAccess.SQL
{
    internal static class NoteSQL
    {
        public const string CreateTableIfNotExists = 
        @"CREATE TABLE IF NOT EXISTS Note(
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Content TEXT NOT NULL,
            LastUpdated DATETIME NOT NULL
        );";

        public const string InsertData =
        @"INSERT INTO Note
        (Content, LastUpdated ) VALUES
        (@Content, @LastUpdated);";

        public const string QueryAll =
        @"SELECT * FROM Note;";

        public const string QueryOne =
        @"SELECT * FROM Note
        WHERE Id = @Id;";

        public const string QueryLastInsert = "SELECT * FROM Note ORDER BY Id DESC LIMIT 1;";

        public const string Update =
        @"UPDATE Note
        SET Content = @Content, LastUpdated = @LastUpdated
        WHERE Id = @Id;";
    }
}