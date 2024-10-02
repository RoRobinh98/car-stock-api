using Microsoft.Data.Sqlite;

public static class DatabaseInitializer
{
    public static void InitializeDatabase()
    {
        using (var connection = new SqliteConnection("Data Source=CarStock.db"))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Cars (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Make TEXT NOT NULL,
                    Model TEXT NOT NULL,
                    Year INTEGER NOT NULL,
                    StockLevel INTEGER NOT NULL,
                    IsDeleted BOOLEAN NOT NULL DEFAULT false
                )";
            command.ExecuteNonQuery();

             var insertDataCommand = connection.CreateCommand();
                insertDataCommand.CommandText = @"
                    INSERT INTO Cars (Make, Model, Year, StockLevel) VALUES
                    ('Audi', 'A4', 2018, 10),
                    ('BMW', '3 Series', 2020, 5),
                    ('Tesla', 'Model S', 2019, 7),
                    ('Ford', 'Mustang', 2015, 4),
                    ('Toyota', 'Corolla', 2021, 12)
                ";
                insertDataCommand.ExecuteNonQuery();
        }
    }
}
