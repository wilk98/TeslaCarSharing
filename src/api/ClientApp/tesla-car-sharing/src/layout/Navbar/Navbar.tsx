import Logo from "../Logo/Logo";
import "./Navbar.css";
import { Link } from "react-router-dom";

const Menu = () => {
  return (
    <ul className="nav_container">
      <li>
        <Link to="/about" className="nav_button">About Us</Link>
      </li>
      <li>
        <Link to="/cars" className="nav_button">Our cars</Link>
      </li>
      <li>
        <Link to="/reservation" className="nav_button">Reservation</Link>
      </li>
      <li>
        <Link to="/price-list" className="nav_button">Price list</Link>
      </li>
      <li>
        <Link to="/contact" className="nav_button">Contact</Link>
      </li>
    </ul>
  );
};

export const Navbar = () => {
  return (
    <nav>
      <Link to="/">
        <Logo />
      </Link>
      <Menu />
    </nav>
  );
};
