using Microsoft.AspNetCore.Mvc;
using TeslaCarSharing.Application.Contracts.Application;
using TeslaCarSharing.Core;
using TeslaCarSharing.Application.DTOs.Car;

namespace TeslaCarSharing.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CarDto>> GetCar(int id)
    {
        var car = await _carService.GetCarAsync(id);
        if (car == null)
        {
            return NotFound();
        }
        return Ok(car);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CarDto>>> GetCars()
    {
        var cars = await _carService.GetAllCarsAsync();
        return Ok(cars);
    }

    [HttpPost]
    public async Task<ActionResult<CarDto>> AddCar(CarDto car)
    {
        var addedCar = await _carService.Add(car);
        return CreatedAtAction(nameof(GetCar), new { id = addedCar.Id }, addedCar);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCar(int id, CarDto car)
    {
        if (id != car.Id)
        {
            return BadRequest();
        }

        await _carService.Update(car);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        var car = await _carService.GetCarAsync(id);
        if (car == null)
        {
            return NotFound();
        }

        await _carService.Delete(car.Id);

        return NoContent();
    }

    [HttpGet("available")]
    public async Task<ActionResult<IReadOnlyList<Car>>> GetAvailableCars(DateTime startDate, DateTime endDate)
    {
        var availableCars = await _carService.GetAvailableCarsAsync(startDate, endDate);
        return Ok(availableCars);
    }
}

