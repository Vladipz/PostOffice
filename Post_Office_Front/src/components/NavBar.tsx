import React, { ReactNode } from "react";

interface NavBarProps {
  button: ReactNode;
}

const NavBar: React.FC<NavBarProps> = ({ button }) => {
  return (
    <nav className="  navbar navbar-expand navbar-expand-lg navbar-light bg-light">
      <div className="container-fluid">
        <a className="navbar-brand" href="#">
          📦
        </a>
        <button
          className="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarNavAltMarkup"
          aria-controls="navbarNavAltMarkup"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span className="navbar-toggler-icon"></span>
        </button>

        <div className="collapse navbar-collapse" id="navbarNavAltMarkup">
          <div className="navbar-nav"></div>
        </div>
        <div className="d-flex flex-row">{button}</div>
      </div>
    </nav>
  );
};

export default NavBar;
