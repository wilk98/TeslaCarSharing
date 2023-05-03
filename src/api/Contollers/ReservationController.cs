using Microsoft.AspNetCore.Mvc;
using TeslaCarSharing.Application.Contracts.Application;
using TeslaCarSharing.Application.DTOs.Customer;
using TeslaCarSharing.Application.DTOs.Reservation;
using TeslaCarSharing.Application.Services;

namespace TeslaCarSharing.Api.Contollers;

[Route("api/[controller]")]
[ApiController]
public class ReservationController : ControllerBase
{
    private readonly IReservationService _reservationService;

    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReservationDto>> GetReservation(int id)
    {
        var reservation = await _reservationService.GetReservationAsync(id);
        if (reservation == null)
        {
            return NotFound();
        }
        return Ok(reservation);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReservationDto>>> GetReservations()
    {
        var reservations = await _reservationService.GetAllReservationsAsync();
        return Ok(reservations);
    }

    [HttpPost]
    public async Task<ActionResult<CreateReservationDto>> AddReservation(CreateReservationDto reservationDto)
    { 
        var addedReservation = await _reservationService.AddReservationAsync(reservationDto);
        return CreatedAtAction(nameof(GetReservation), new { id = addedReservation}, addedReservation);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReservation(int id, CreateReservationDto reservation)
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
        var reservation = await _reservationService.GetReservationAsync(id);
        if (reservation == null)
        {
            return NotFound();
        }

        await _reservationService.Delete(reservation.Id);

        return NoContent();
    }
}
