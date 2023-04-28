// PriceList.tsx

import "./PriceList.css";
import teslaXImg from "../../assets/TeslaX.png";
import teslaYImg from "../../assets/TeslaY.png";
import teslaSImg from "../../assets/TeslaS.png";
import tesla3Img from "../../assets/Tesla3.png";

const carList = [
  {
    name: "Tesla Model X",
    image: teslaXImg,
    price: 250,
  },
  {
    name: "Tesla Model Y",
    image: teslaYImg,
    price: 180,
  },
  {
    name: "Tesla Model S",
    image: teslaSImg,
    price: 200,
  },
  {
    name: "Tesla Model 3",
    image: tesla3Img,
    price: 150,
  },
];

const PriceList: React.FC = () => {
  return (
    <div className="container">
      <h1>Price List</h1>
      <div className="price-list-container">
        <table className="price-list">
          <thead>
            <tr>
              <th>Car</th>
              <th>Price per day (EUR)</th>
            </tr>
          </thead>
          <tbody>
            {carList.map((car) => (
              <tr key={car.name}>
                <td>
                  <img src={car.image} alt={car.name} />
                  <h3>{car.name}</h3>
                </td>
                <td>{car.price}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default PriceList;
