using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeslaCarSharing.Application.Contracts.Application;
using TeslaCarSharing.Application.DTOs.Customer;
using TeslaCarSharing.Application.DTOs.Reservation;
using TeslaCarSharing.Application.Services;
using TeslaCarSharing.Core;

namespace TeslaCarSharing.Api.Contollers;

[Route("api/[controller]")]
[ApiController]
public class ReservationController : ControllerBase
{
    private readonly IReservationService _reservationService;
    private readonly IMapper _mapper;

    public ReservationController(IReservationService reservationService, IMapper mapper)
    {
        _reservationService = reservationService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReservationDto>> GetReservation(int id)
    {
        var reservation = await _reservationService.Get(id);
        if (reservation == null)
        {
            return NotFound();
        }
        var reservationDto = _mapper.Map<ReservationDto>(reservation);
        return Ok(reservationDto);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReservationDto>>> GetReservations()
    {
        var reservations = await _reservationService.GetAll();
        var reservationsDto = _mapper.Map<IEnumerable<ReservationDto>>(reservations);
        return Ok(reservationsDto);
    }

    [HttpPost]
    public async Task<ActionResult<ReservationDto>> AddReservation(Reservation reservation)
    {
        var addedReservation = await _reservationService.Add(reservation);
        var reservationDto = _mapper.Map<ReservationDto>(addedReservation);
        return CreatedAtAction(nameof(GetReservation), new { id = reservationDto.Id }, reservationDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReservation(int id, Reservation reservation)
    {
        if (id != reservation.Id)
        {
            return BadRequest();
        }

        await _reservationService.Update(reservation);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReservation(int id)
    {
        var reservation = await _reservationService.Get(id);
        if (reservation == null)
        {
            return NotFound();
        }

        await _reservationService.Delete(reservation);

        return NoContent();
    }
}
