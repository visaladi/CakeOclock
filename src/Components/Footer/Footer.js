import React from "react";
import "./footer.css";
import { IoIosMail } from "react-icons/io";
import { FaPhoneAlt } from "react-icons/fa";
import { FiMapPin } from "react-icons/fi";
import { ImInstagram } from "react-icons/im";
import { FaFacebook } from "react-icons/fa";
import { FaTwitter } from "react-icons/fa";
import { FaYoutube } from "react-icons/fa";
function Footer() {
  return (
    <div>
      <div className="foter-full">
        <div className="footer-nav-set">
          <h1 className="footer-nav-topic">Home</h1>
          <h1 className="footer-nav-topic">About Us</h1>
          <h1 className="footer-nav-topic">Contact Us</h1>
          <h1 className="footer-nav-topic">Help</h1>
        </div>
        <div className="footer-bottom">
          <div className="footer-left-bottom">
            <p className="footer-left-bottom footer-left-bottom-name">
              <IoIosMail className="footer-left-bottom-icon" />{" "}
              furnito@gmail.com
            </p>
            <p className="footer-left-bottom footer-left-bottom-name">
              <FaPhoneAlt className="footer-left-bottom-icon" />
              +65678253
            </p>
            <p className="footer-left-bottom footer-left-bottom-name">
              <FiMapPin className="footer-left-bottom-icon" />
              Suntec City Mall Tower 3 <br></br>East Wing, #02-728/729/730
            </p>
          </div>
          <div className="footer-right-bottom">
            <h2 className="icon-footer-topic">Follow Us:</h2>
            <div className="icon-set-footer">
              <div className="icon-footer">
                <ImInstagram />
              </div>
              <div className="icon-footer">
                <FaFacebook />
              </div>
              <div className="icon-footer">
                <FaTwitter />
              </div>
              <div className="icon-footer">
                <FaYoutube />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Footer;
