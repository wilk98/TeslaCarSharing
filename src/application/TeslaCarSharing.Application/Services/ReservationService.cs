using AutoMapper;
using TeslaCarSharing.Application.Contracts.Application;
using TeslaCarSharing.Application.Contracts.Infrastructure;
using TeslaCarSharing.Application.DTOs.Reservation;
using TeslaCarSharing.Core;

namespace TeslaCarSharing.Application.Services;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly ICarRepository _carRepository;
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public ReservationService(IReservationRepository reservationRepository, ICustomerService customerService, IMapper mapper, ICarRepository carRepository)
    {
        _carRepository = carRepository;
        _reservationRepository = reservationRepository;
        _customerService = customerService;
        _mapper = mapper;
    }

    public async Task<int> AddReservationAsync(CreateReservationDto reservationDto)
    {
        var customer = reservationDto.Customer;
        var newCustomer = await _customerService.Add(customer);

        var reservation = _mapper.Map<Reservation>(reservationDto);
        reservation.CustomerId = newCustomer.Id;

        var car = await _carRepository.Get(reservationDto.CarId);
        reservation.UpdateTotalPrice(car);

        var addedReservation = await _reservationRepository.Add(reservation);
        return addedReservation.Id;
    }


    public async Task<IReadOnlyList<ReservationDto>> GetAllReservationsAsync()
    {
        var reservations = await _reservationRepository.GetAll();
        var reservationDtos = _mapper.Map<IReadOnlyList<ReservationDto>>(reservations);
        return reservationDtos;
    }


    public async Task<ReservationDto> GetReservationAsync(int reservationId)
    {
        var reservation = await _reservationRepository.Get(reservationId);
        var reservationDto = _mapper.Map<ReservationDto>(reservation);
        return reservationDto;
    }

    public async Task<IReadOnlyList<int>> GetUnavailableCarIdsAsync(DateTime startDate, DateTime endDate)
    {
        var unavailableCarIds = await _reservationRepository.GetUnavailableCarIdsAsync(startDate, endDate);
        return unavailableCarIds;
    }


}

