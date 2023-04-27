import React from "react";
import "./About.css";

const AboutPage: React.FC = () => {
  return (
    <div>
      <h1 className="about-header">About Us</h1>
      <div className="about-container">
        <p className="about-paragraph">
          We are a car rental company specialized in electric vehicles, with a
          focus on Tesla cars. Our mission is to provide high-quality and
          eco-friendly transportation options to our customers while promoting
          sustainable practices and reducing the carbon footprint of the tourism
          industry.
        </p>
        <p className="about-paragraph">
          Our fleet consists of the latest Tesla models, including the Model S,
          Model 3, Model X, and Model Y. All of our cars are equipped with the
          latest technology and safety features, ensuring a comfortable and
          secure driving experience.
        </p>
        <p className="about-paragraph">
          We are located in Mallorca, one of the most beautiful islands in the
          Mediterranean, and we offer delivery and pick-up services to any
          location on the island, including the airport and hotels. Our team of
          professionals is dedicated to providing exceptional customer service
          and making sure that your experience with us is hassle-free and
          enjoyable.
        </p>
        <p className="about-paragraph">
          Contact us today to book your Tesla rental and start exploring Mallorca
          in style and comfort!
        </p>
      </div>
    </div>
  );
};

export default AboutPage;
