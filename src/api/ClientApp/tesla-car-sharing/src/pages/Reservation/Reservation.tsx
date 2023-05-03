import { useState } from 'react';
import { api_path } from '../../utils/api';
import "./Reservation.css"

type Car = {
  registrationNumber: string;
  model: string;
  color: string;
  year: number;
  location: string;
  pricePerDay: number;
};

const Reservation = () => {
  const [startDate, setStartDate] = useState<Date | null>(new Date());
  const [endDate, setEndDate] = useState<Date | null>(null);

  const [cars, setCars] = useState<Car[]>([]);

  const handleSearch = async () => {
    if (startDate && endDate) {
      const response = await fetch(`${api_path}/api/Car/available?startDate=${startDate.toISOString()}&endDate=${endDate.toISOString()}`);
      const data = await response.json();
      setCars(data);
    }
  };

  const handleStartDateChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const selectedStartDate = new Date(e.target.value);
    setStartDate(selectedStartDate);
    if (!endDate || selectedStartDate > endDate) {
      const selectedEndDate = new Date(selectedStartDate.getTime() + 86400000); // 86400000 ms = 1 day
      setEndDate(selectedEndDate);
    }
  };

  const handleEndDateChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setEndDate(new Date(e.target.value));
  };

  const minEndDate = startDate ? new Date(startDate.getTime() + 86400000).toISOString().slice(0, 10) : '';


  return (
    <div className="reservation-container">
      <h1>Reservation</h1>
      <form className="reservation-form">
        <div className="reservation-form-input">
          <label htmlFor="start-date">Start Date:</label>
          <input type="date" id="start-date" value={startDate?.toISOString().slice(0, 10)} onChange={handleStartDateChange} min={new Date().toISOString().slice(0, 10)} />
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
              <td>{car.model}</td>
              <td>{car.color}</td>
              <td>{car.year}</td>
              <td>{car.location}</td>
              <td>{car.pricePerDay.toFixed(2)} €</td>
              <td><button className="reservation-table-button">Book Now</button></td>
            </tr>
          ))}
        </tbody>
      </table>
      ) : (
        <p className="reservation-no-cars">No available cars found.</p>
      )}
    </div>
  );
};

export default Reservation;
