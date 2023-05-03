import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { Navbar } from './layout/Navbar/Navbar';
import Home from './pages/Home/Home';
import About from './pages/About/About';
import Cars from './pages/Cars/Cars';
import Reservation from './pages/Reservation/Reservation';
import PriceList from './pages/PriceList/PriceList';
import Contact from './pages/Contact/Contact';
import Footer from './layout/Footer/Footer';
import './App.css';

function App() {
  return (
    <div className="app-container">
      <Router>
        <Navbar />
        <div className="main-content">
          <Routes>
            <Route path="/" element={<Home/>} />
            <Route path="/about" element={<About/>} />
            <Route path="/cars" element={<Cars/>} />
            <Route path="/reservation" element={<Reservation/>} />
            <Route path="/price-list" element={<PriceList/>} />
            <Route path="/contact" element={<Contact/>} />
          </Routes>
        </div>
        <Footer/>
      </Router>
    </div>
  );
}

export default App;
