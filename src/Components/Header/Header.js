import React from "react";
import "./header.css";
import { FaHeart } from "react-icons/fa";
import { FaBagShopping } from "react-icons/fa6";
import { FaUser } from "react-icons/fa";
import { MdArrowDropDown } from "react-icons/md";
import Logo from "./img/logo.png";
import NavName from "./img/name.png";
function Header() {
  return (
    <div>
      <div className="navbar">
        <div className="logo">
          <img src={Logo} alt="logo" className="cakelogo" />
        </div>

        <div className="nav-names">
          <a
            href="#home"
            className="nav-item"
            onClick={() => {
              window.location.href = "/";
            }}
          >
            Home
          </a>
          <a href="/" className="nav-item">
            Cake <MdArrowDropDown className="nav-item-drop" />
          </a>
          <a href="/" className="nav-item">
            About
          </a>
          <a href="/" className="nav-item">
            Contact
          </a>
        </div>
        <div className="cart-icon">
          <span className="iconmain">
            <FaHeart className="left-icon" />
          </span>
          <span className="iconmain">
            <FaBagShopping className="left-icon" />
          </span>
          <span className="iconmain">
            <FaUser
              className="left-icon"
              onClick={() => {
                window.location.href = "/Login";
              }}
            />
          </span>
        </div>
      </div>
      <div className="nav-body">
        <div>
          <img src={NavName} alt="Nav Name" className="nav-name-logo" />
          <br></br>
          <button
            className="bake-btn"
            onClick={() => {
              window.location.href = "/request";
            }}
          >
            Bake It..
          </button>
        </div>
      </div>
    </div>
  );
}

export default Header;
