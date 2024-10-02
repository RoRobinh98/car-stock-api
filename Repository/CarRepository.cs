using Dapper;
using Microsoft.Data.Sqlite;

public class CarRepository
{
    private string _connectionString = "Data Source=CarStock.db";

    public IEnumerable<Car> GetAllCars()
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            return connection.Query<Car>("SELECT * FROM Cars WHERE IsDeleted = false").ToList();
        }
    }

    public void AddCar(Car car)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            string sql = "INSERT INTO Cars (Make, Model, Year, StockLevel) VALUES (@Make, @Model, @Year, @StockLevel)";
            connection.Execute(sql, car);
        }
    }

    public void UpdateCarStock(int carId, int stockLevel)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            string sql = "UPDATE Cars SET StockLevel = @StockLevel WHERE Id = @Id";
            connection.Execute(sql, new { Id = carId, StockLevel = stockLevel });
        }
    }

    public void RemoveCar(int carId)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            string sql = "UPDATE Cars SET isDeleted = true WHERE Id = @Id";
            connection.Execute(sql, new { Id = carId });  
        }
    }

    public IEnumerable<Car> SearchCars(string make, string model)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            var sql = "SELECT * FROM Cars WHERE IsDeleted = false";
            if (!string.IsNullOrEmpty(make))
            {
                sql += " AND Make = @Make";
            }
            if (!string.IsNullOrEmpty(model))
            {
                sql += " AND Model = @Model";
            }
            return connection.Query<Car>(sql, new { Make = make, Model = model }).ToList();
        }
    }
}
