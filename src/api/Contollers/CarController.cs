using Microsoft.AspNetCore.Mvc;
using TeslaCarSharing.Application.Contracts.Application;
using TeslaCarSharing.Core;
using AutoMapper;

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
    public async Task<ActionResult<Car>> GetCar(int id)
    {
        var car = await _carService.Get(id);
        if (car == null)
        {
            return NotFound();
        }
        return Ok(car);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Car>>> GetCars()
    {
        var cars = await _carService.GetAll();
        return Ok(cars);
    }

    [HttpPost]
    public async Task<ActionResult<Car>> AddCar(Car car)
    {
        var addedCar = await _carService.Add(car);
        return CreatedAtAction(nameof(GetCar), new { id = addedCar.Id }, addedCar);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCar(int id, Car car)
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
        var car = await _carService.Get(id);
        if (car == null)
        {
            return NotFound();
        }

        await _carService.Delete(car);

        return NoContent();
    }
}

