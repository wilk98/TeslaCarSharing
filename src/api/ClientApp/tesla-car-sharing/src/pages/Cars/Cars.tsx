import {  FormEvent, useEffect, useState } from "react";
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

interface AddCarFormData {
  registrationNumber: string;
  model: string;
  color: string;
  year: number;
  location: string;
}

const Car = ({ car, onDelete }: { car: CarData; onDelete: () => void }) => {
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
      <td>{car.pricePerDay} €</td>
      <td>
        <button onClick={onDelete}>Delete</button>
      </td>
    </tr>
  );
};

interface AddCarFormProps {
  onSubmit: (carData: AddCarFormData) => void;
}


const AddCarForm = ({ onSubmit }: AddCarFormProps) => {
  const [registrationNumber, setRegistrationNumber] = useState("");
  const [model, setModel] = useState("ModelX");
  const [color, setColor] = useState("");
  const [year, setYear] = useState("");
  const [location, setLocation] = useState("PalmaAirport");

  const handleSubmit = (e: FormEvent) => {
    e.preventDefault();

    onSubmit({
      registrationNumber,
      model,
      color,
      year: parseInt(year),
      location,
    });

    setRegistrationNumber("");
    setColor("");
    setYear("");
  };

  return (
    <form onSubmit={handleSubmit}>
      <table className="add-car-table">
        <thead>
          <tr>
            <th>Registration Number</th>
            <th>Model</th>
            <th>Color</th>
            <th>Year</th>
            <th>Location</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>
              <input
                type="text"
                placeholder="Registration number"
                value={registrationNumber}
                onChange={(e) => setRegistrationNumber(e.target.value)}
              />
            </td>
            <td>
              <select value={model} onChange={(e) => setModel(e.target.value)}>
                <option value="ModelX">Model X</option>
                <option value="ModelY">Model Y</option>
                <option value="ModelS">Model S</option>
                <option value="Model3">Model 3</option>
              </select>
            </td>
            <td>
              <input
                type="text"
                placeholder="Color"
                value={color}
                onChange={(e) => setColor(e.target.value)}
              />
            </td>
            <td>
              <input
                type="number"
                placeholder="Year"
                value={year}
                onChange={(e) => setYear(e.target.value)}
              />
            </td>
            <td>
              <select
                value={location}
                onChange={(e) => setLocation(e.target.value)}
              >
                <option value="PalmaAirport">Palma Airport</option>
                <option value="PalmaCityCenter">Palma City Center</option>
                <option value="Alcudia">Alcudia</option>
                <option value="Manacor">Manacor</option>
              </select>
            </td>
            <td>
              <button type="submit">Add Car</button>
            </td>
          </tr>
        </tbody>
      </table>
    </form>
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

  const handleAddCar = async (carData : any) => {
    try {
      const response = await fetch(`${api_path}/api/car`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(carData),
      });
  
      if (!response.ok) {
        throw new Error("Error adding car");
      }
  
      const addedCar = await response.json();
      setCars([...cars, addedCar]);
    } catch (error) {
      console.error("Error adding car:", error);
    }
  };
  

  const handleDeleteCar = async (carId: number) => {
    try {
      await fetch(`${api_path}/api/car/${carId}`, {
        method: "DELETE",
      });
      setCars(cars.filter((car) => car.id !== carId));
    } catch (error) {
      console.error("Error deleting car:", error);
    }
  };

  return (
    <div className="cars-container">
      <h1>Cars</h1>
      <AddCarForm onSubmit={handleAddCar} />
      <table className="cars-table">
        <thead>
          <tr>
            <th>Registration Number</th>
            <th>Model</th>
            <th>Color</th>
            <th>Year</th>
            <th>Location</th>
            <th>Price Per Day</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {cars.map((car) => (
            <Car
              key={car.id}
              car={car}
              onDelete={() => handleDeleteCar(car.id)}
            />
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Cars;
