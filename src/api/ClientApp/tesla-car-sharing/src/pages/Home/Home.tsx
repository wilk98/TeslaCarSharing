import React from "react";
import { Link } from "react-router-dom";
import HomeImage from "../../assets/HomeImage.png"
import TeslaS from "../../assets/TeslaS.png";
import Tesla3 from "../../assets/Tesla3.png";
import TeslaX from "../../assets/TeslaX.png";
import TeslaY from "../../assets/TeslaY.png";
import "./Home.css";

const Home: React.FC = () => {
  return (
    <div className="home">
      <div className="hero">
        <img src={HomeImage} alt="Tesla" className="hero-image" /> 
        <div className="hero-text">
          <h1>Rent a Tesla in Mallorca</h1>
          <p>Experience the future of driving today.</p>
          <Link to="/reservation" className="cta">
            Book Now
          </Link>
        </div>
      </div>
      <div className="models">
        <div className="model">
          <img src={TeslaS} alt="Tesla Model S" />
          <h2>Tesla Model S</h2>
          <p>
            The Model S combines performance, safety, and efficiency like no
            other sedan. With its long range and advanced features, it’s the
            ultimate electric luxury car.
          </p>
        </div>
        <div className="model">
          <img src={Tesla3} alt="Tesla Model 3" />
          <h2>Tesla Model 3</h2>
          <p>
            The Model 3 is designed for electric-powered performance, with a
            sleek, modern design that conveys speed and agility.
          </p>
        </div>
        <div className="model">
          <img src={TeslaX} alt="Tesla Model X" />
          <h2>Tesla Model X</h2>
          <p>
            The Model X combines the space and functionality of a sport utility
            vehicle with the uncompromised performance of a Tesla. With its
            Falcon Wing doors, it’s the ultimate family car.
          </p>
        </div>
        <div className="model">
          <img src={TeslaY} alt="Tesla Model Y" />
          <h2>Tesla Model Y</h2>
          <p>
            The Model Y is a mid-size SUV that’s both practical and fun to
            drive. With its long range and spacious interior, it’s the perfect
            vehicle for exploring Mallorca.
          </p>
        </div>
      </div>
    </div>
  );
};

export default Home;
