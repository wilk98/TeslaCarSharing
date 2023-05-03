import { useState } from 'react';
import { api_path } from '../../utils/api';
import "./Reservation.css"

type Car = {
  id: number;
  registrationNumber: string;
  model: string;
  color: string;
  year: number;
  location: string;
  pricePerDay: number;
};

const Reservation = () => {
  const [startDate, setStartDate] = useState<Date | null>(null);
  const [endDate, setEndDate] = useState<Date | null>(null);
  const [bookingCar, setBookingCar] = useState<Car | null>(null);

  const [cars, setCars] = useState<Car[]>([]);

  const [clientForm, setClientForm] = useState({
    firstName: "",
    lastName: "",
    email: "",
    phoneNumber: "",
    endLocation: "PalmaAirport",
  });

  
  const handleSearch = async () => {
    if (startDate && endDate) {
      const response = await fetch(`${api_path}/api/Car/available?startDate=${startDate.toISOString()}&endDate=${endDate.toISOString()}`);
      const data = await response.json();
      setCars(data);
      console.log(data);
    }
  };
  
  const handleStartDateChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const selectedStartDate = new Date(e.target.value);
    setStartDate(selectedStartDate);
    if (!endDate || selectedStartDate > endDate) {
      const selectedEndDate = new Date(selectedStartDate.getTime() + 86400000);
      setEndDate(selectedEndDate);
    }
};

  const today = new Date();
  const tomorrow = new Date(today);
  tomorrow.setDate(today.getDate() + 1);

  const handleEndDateChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setEndDate(new Date(e.target.value));
  };

  const minEndDate = startDate ? new Date(startDate.getTime() + 86400000).toISOString().slice(0, 10) : '';

  const handleBookNow = (car: Car) => {
    setBookingCar(car);
  };

  const handleClientFormChange = (
    event: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value } = event.target;
    setClientForm((prevForm) => ({ ...prevForm, [name]: value }));
  };

  const handleClientFormSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    if (!bookingCar) return;
  
    const reservationData = {
      carId: bookingCar.id,
      customer: {
        firstName: clientForm.firstName,
        lastName: clientForm.lastName,
        email: clientForm.email,
        phoneNumber: clientForm.phoneNumber
      },
      startDate: startDate?.toISOString(),
      endDate: endDate?.toISOString(),
      startLocation: bookingCar.location,
      endLocation: clientForm.endLocation
    };
  
    try {
      const response = await fetch(`${api_path}/api/reservation`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(reservationData)
      });
  
      if (response.ok) {
        const addedReservation = await response.json();
        console.log('Reservation added:', addedReservation);
      } else {

        console.error('Failed to add reservation:', response.status);
      }
    } catch (error) {
      console.error('Network error:', error);
    }
  };
  
  return (
    <div className="reservation-container">
      <h1>Reservation</h1>
      <form className="reservation-form">
        <div className="reservation-form-input">
          <label htmlFor="start-date">Start Date:</label>
          <input type="date" id="start-date" value={startDate?.toISOString().slice(0, 10)} onChange={handleStartDateChange} min={tomorrow.toISOString().slice(0, 10)} />
        </div>
  
        <div className="reservation-form-input">
          <label htmlFor="end-date">End Date:</label>
          <input type="date" id="end-date" value={endDate?.toISOString().slice(0, 10)} onChange={handleEndDateChange} min={minEndDate} />
        </div>
  
        <button className="reservation-form-button" type="button" onClick={handleSearch}>Search</button>
      </form>
  
      {cars.length > 0 ? (
      <table className="cars-table">
        <thead>
          <tr>
            <th>Registration Number</th>
            <th>Model</th>
            <th>Color</th>
            <th>Year</th>
            <th>Location</th>
            <th>Price Per Day</th>
            <th>Book Now</th>
          </tr>
        </thead>
        <tbody>
          {cars.map((car) => (
            <tr key={car.registrationNumber}>
              <td>{car.registrationNumber}</td>
              <td>{car.model.slice(-1)}</td>
              <td>{car.color}</td>
              <td>{car.year}</td>
              <td>{car.location.replace(/([A-Z])/g, ' $1')}</td>
              <td>{car.pricePerDay.toFixed(2)} €</td>
              <td><button className="reservation-table-button" onClick={() => handleBookNow(car)}>Book Now</button></td>
            </tr>
          ))}
        </tbody>
      </table>
      ) : (
        <p className="reservation-no-cars">No available cars found.</p>
      )}
      {bookingCar && (
        <div className="client-form-container">
          <h2 style={{ textAlign: "center" }}>Add Client Information</h2>
          <div className="client-form-selext" style= {{textAlign: "center", marginBottom: "10px"}}>
            <label htmlFor="end-location">End Location: </label>
            <select id="end-location" name="endLocation" value={clientForm.endLocation} onChange={handleClientFormChange}>
              <option value="PalmaAirport">Palma Airport</option>
              <option value="PalmaCityCenter">Palma City Center</option>
              <option value="Alcudia">Alcudia</option>
              <option value="Manacor">Manacor</option>
            </select>
          </div>
          <form className="client-form" onSubmit={handleClientFormSubmit}>
            <div className="client-form-input">
              <label htmlFor="first-name">First Name:</label>
              <input type="text" id="first-name" name="firstName" value={clientForm.firstName} onChange={handleClientFormChange} />
            </div>
            <div className="client-form-input">
              <label htmlFor="last-name">Last Name:</label>
              <input type="text" id="last-name" name="lastName" value={clientForm.lastName} onChange={handleClientFormChange} />
            </div>
            <div className="client-form-input">
              <label htmlFor="email">Email:</label>
              <input type="email" id="email" name="email" value={clientForm.email} onChange={handleClientFormChange} />
            </div>
            <div className="client-form-input">
              <label htmlFor="phone-number">Phone Number:</label>
              <input type="tel" id="phone-number" name="phoneNumber" value={clientForm.phoneNumber} onChange={handleClientFormChange} />
            </div>
            <button className="client-form-button" type="submit">
              Confirm Reservation
            </button>
          </form>
        </div>
        )}
      </div>
    );
  };

export default Reservation;