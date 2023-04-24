using Microsoft.AspNetCore.Mvc;
using TeslaCarSharing.Application.Contracts.Application;
using TeslaCarSharing.Application.DTOs.Car;
using TeslaCarSharing.Core;
using AutoMapper;

namespace TeslaCarSharing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDto>> GetCar(int id)
        {
            var car = await _carService.Get(id);
            if (car == null)
            {
                return NotFound();
            }
            var carDto = _mapper.Map<CarDto>(car);
            return Ok(carDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCars()
        {
            var cars = await _carService.GetAll();
            var carsDto = _mapper.Map<IEnumerable<CarDto>>(cars);
            return Ok(carsDto);
        }

        [HttpPost]
        public async Task<ActionResult<CarDto>> AddCar(Car car)
        {
            var addedCar = await _carService.Add(car);
            var carDto = _mapper.Map<CarDto>(addedCar);
            return CreatedAtAction(nameof(GetCar), new { id = carDto.Id }, carDto);
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
}

