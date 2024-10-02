using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("v1/public/[controller]")]
public class CarController : ControllerBase
{
    private readonly CarService _carService;

    public CarController(CarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public IActionResult GetAllCars()
    {
        var cars = _carService.GetCars();
        return Ok(cars);
    }

    [HttpPost]
    [Authorize]
    public IActionResult AddCar([FromBody] Car car)
    {
        if (car == null)
        {
            return BadRequest("Car data is null.");
        }

        _carService.AddCar(car);
        return Ok();
    }

    [HttpPost("remove")]
    [Authorize]
    public IActionResult RemoveCar([FromBody] int carId)
    {
        _carService.RemoveCar(carId);
        return Ok();
    }

    [HttpGet("search")]
    public IActionResult SearchCars([FromQuery] string make, [FromQuery] string model)
    {
        var cars = _carService.SearchCars(make, model);

        if (!cars.Any()) 
        {
            return NotFound("No cars found matching the search criteria.");
        }

        return Ok(cars);
    }
}
