public class Car
{
    public int Id { get; set; }
    public required string Make { get; set; }
    public required string Model { get; set; }
    public int Year { get; set; }
    public int StockLevel { get; set; } = 0;
    public Boolean IsDeleted {get; set;}
}
