// Contact.tsx

import "./Contact.css";

const locations = [
  {
    name: "Palma Airport",
    address: "Ctra. de l'Aeroport, s/n, 07611 Palma, Illes Balears, Spain",
    phone: "+34 902 40 47 04",
    email: "palmaairport@mallorcateslarental.info",
  },
  {
    name: "Palma City Center",
    address: "Carrer del Sindicat, 14, 07002 Palma, Illes Balears, Spain",
    phone: "+34 971 71 67 46",
    email: "palmacitycenter@mallorcateslarental.info",
  },
  {
    name: "Alcudia",
    address: "Carrer del Rector Vives, 5, 07400 Alcúdia, Illes Balears, Spain",
    phone: "+34 971 89 02 12",
    email: "alcudia@mallorcateslarental.info",
  },
  {
    name: "Manacor",
    address: "Carrer de la Lluna, 11, 07500 Manacor, Illes Balears, Spain",
    phone: "+34 971 55 35 35",
    email: "manacor@mallorcateslarental.info",
  },
];

const Contact: React.FC = () => {
  return (
    <div className="contact-container">
      <h1>Contact Us</h1>
      <div className="contact">
      <ul className="locations">
        {locations.map((location) => (
          <li key={location.name}>
            <h3>{location.name}</h3>
            <p>{location.address}</p>
            <p>Phone: {location.phone}</p>
            <p>Email: {location.email}</p>
          </li>
        ))}
      </ul>
    </div>
    </div>
  );
};

export default Contact;
