import { useEffect, useState } from "react";
import { api_path } from "../../utils/api";
import "./Cars.css";

interface CarData {
  id: number;
  registrationNumber: string;
  model: string;
  color: string;
  year: number;
  location: string;
  pricePerDay: number;
}

const Car = ({ car }: { car: CarData }) => {
  const formattedLocation = car.location
    .replace(/([A-Z])/g, " $1")
    .replace(/^./, (str) => str.toUpperCase())
    .trim();

  return (
    <tr>
      <td>{car.registrationNumber}</td>
      <td>{car.model.slice(-1)}</td>
      <td>{car.color}</td>
      <td>{car.year}</td>
      <td>{formattedLocation}</td>
      <td>{car.pricePerDay} $</td>
    </tr>
  );
};

const Cars = () => {
  const [cars, setCars] = useState<CarData[]>([]);

  useEffect(() => {
    fetch(`${api_path}/api/car`)
      .then((response) => response.json())
      .then((data) => setCars(data))
      .catch((error) => console.error(error));
  }, []);

  return (
    <div className="cars-container">
      <h1>Cars</h1>
      <table className="cars-table">
        <thead>
          <tr>
            <th>Registration Number</th>
            <th>Model</th>
            <th>Color</th>
            <th>Year</th>
            <th>Location</th>
            <th>Price Per Day</th>
          </tr>
        </thead>
        <tbody>
          {cars.map((car) => (
            <Car key={car.id} car={car} />
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Cars;
