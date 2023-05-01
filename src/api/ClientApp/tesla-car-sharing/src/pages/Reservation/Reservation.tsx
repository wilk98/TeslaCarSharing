import { useState } from 'react';
import { api_path } from '../../utils/api';

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
  const [endDate, setEndDate] = useState<Date | null>(new Date());

  const [cars, setCars] = useState<Car[]>([]);

  const handleSearch = async () => {
    if (startDate && endDate) {
      const response = await fetch(`${api_path}/api/Car/available?startDate=${startDate.toISOString()}&endDate=${endDate.toISOString()}`);
      const data = await response.json();
      setCars(data);
    }
    console.log(startDate);
  };

  return (
    <div>
      <h1>Reservation</h1>
      <form>
        <label htmlFor="start-date">Start Date:</label>
        <input type="date" id="start-date" value={startDate?.toISOString().slice(0, 10)} onChange={(e) => setStartDate(new Date(e.target.value))} />

        <label htmlFor="end-date">End Date:</label>
        <input type="date" id="end-date" value={endDate?.toISOString().slice(0, 10)} onChange={(e) => setEndDate(new Date(e.target.value))} />

        <button type="button" onClick={handleSearch}>Search</button>
      </form>

      {cars.length > 0 ? (
        <table>
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
                <td>{car.pricePerDay}</td>
                <td><button>Book Now</button></td>
              </tr>
            ))}
          </tbody>
        </table>
      ) : (
        <p>No available cars found.</p>
      )}
    </div>
  );
};

export default Reservation;
