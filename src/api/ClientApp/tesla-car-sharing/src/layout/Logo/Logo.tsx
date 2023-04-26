import React from "react";
import logoImg from "./logo.png";

interface LogoProps {
  width?: number;
}

const Logo: React.FC<LogoProps> = ({ width = 150 }) => {
  return <img src={logoImg} alt="Logo" style={{ width: width }} />;
};

export default Logo;
