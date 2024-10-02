public class CarService
{
    private readonly CarRepository _carRepository;

    public CarService(CarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public IEnumerable<Car> GetCars()
    {
        return _carRepository.GetAllCars();
    }

    public void AddCar(Car car)
    {
        _carRepository.AddCar(car);
    }

    public void UpdateCarStock(int carId, int stockLevel)
    {
        _carRepository.UpdateCarStock(carId, stockLevel);
    }

    public void RemoveCar(int carId)
    {
        _carRepository.RemoveCar(carId);
    }

    public IEnumerable<Car> SearchCars(string make, string model)
    {
        return _carRepository.SearchCars(make, model);
    }
}
