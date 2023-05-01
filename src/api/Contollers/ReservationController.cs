using Microsoft.AspNetCore.Mvc;
using TeslaCarSharing.Application.Contracts.Application;
using TeslaCarSharing.Core;

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
    public async Task<ActionResult<Reservation>> GetReservation(int id)
    {
        var reservation = await _reservationService.Get(id);
        if (reservation == null)
        {
            return NotFound();
        }
        return Ok(reservation);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
    {
        var reservations = await _reservationService.GetAll();
        return Ok(reservations);
    }

    [HttpPost]
    public async Task<ActionResult<Reservation>> AddReservation(Reservation reservation)
    {
        var addedReservation = await _reservationService.Add(reservation);
        return CreatedAtAction(nameof(GetReservation), new { id = addedReservation.Id }, addedReservation);
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
