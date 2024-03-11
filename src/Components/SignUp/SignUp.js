import React from "react";
import Header from "../Header/Header";
import Logo from "../Header/img/logo.png";
import "./SignUp.css";
import Footer from "../Footer/Footer";
import seaimg1 from "../Home/img/Rectangle 13.png";
import seaimg2 from "../Home/img/Rectangle 14.png";
import seaimg3 from "../Home/img/Rectangle 15.png";
import seaimg4 from "../Home/img/Rectangle 16.png";
import { FaArrowRight } from "react-icons/fa";
function SingUp() {
  return (
    <div>
      <div className="background">
        <Header /> <br></br>
        <br></br> <br></br>
        <br></br> <br></br>
        <div className="login-container">
          <div className="login-box">
            <img src={Logo} alt="Logo" className="login-logo" />
            <h2 className="login-heading">Sign Up</h2>

            <div className="login-form-group">
              <form className="signup-form">
                <table className="signup-table">
                  <tbody>
                    <tr>
                      <td>
                        <div className="signup-form-group">
                          <label htmlFor="first-name" className="signup-label">
                            First Name
                          </label>
                          <input
                            type="text"
                            id="first-name"
                            placeholder="First Name"
                            className="signup-form-input"
                          />
                        </div>
                      </td>
                      <td>
                        <div className="signup-form-group">
                          <label htmlFor="last-name" className="signup-label">
                            Last Name
                          </label>
                          <input
                            type="text"
                            id="last-name"
                            placeholder="Last Name"
                            className="signup-form-input"
                          />
                        </div>
                      </td>
                    </tr>
                    <tr>
                      <td>
                        <div className="signup-form-group">
                          <label htmlFor="location" className="signup-label">
                            Location
                          </label>
                          <input
                            type="text"
                            id="location"
                            placeholder="Location"
                            className="signup-form-input"
                          />
                        </div>
                      </td>
                      <td>
                        <div className="signup-form-group">
                          <label
                            htmlFor="contact-number"
                            className="signup-label"
                          >
                            Contact No
                          </label>
                          <input
                            type="text"
                            id="contact-number"
                            placeholder="Contact Number"
                            className="signup-form-input"
                          />
                        </div>
                      </td>
                    </tr>
                    <tr>
                      <td>
                        <div className="signup-form-group">
                          <label htmlFor="username" className="signup-label">
                            Username/Email
                          </label>
                          <input
                            type="text"
                            id="username"
                            placeholder="Username"
                            className="signup-form-input"
                          />
                        </div>
                      </td>
                      <td>
                        <div className="signup-form-group">
                          <label htmlFor="password" className="signup-label">
                            Password
                          </label>
                          <input
                            type="password"
                            id="password"
                            placeholder="Password"
                            className="signup-form-input"
                          />
                        </div>
                      </td>
                    </tr>
                  </tbody>
                </table>
                <div className="signup-btn">
                  <button type="submit" className="login-button">
                    Create
                  </button>
                </div>
              </form>
            </div>
          </div>
        </div>
        <br></br>
        <br></br> <br></br>
        <br></br> <br></br>
        <br></br> <br></br>
        <br></br>
        <br></br>
        <br></br> <br></br>
        <br></br> <br></br>
        <br></br> <br></br>
        <br></br>
        <br></br>
        <br></br> <br></br>
        <br></br>
        <br></br>
        <br></br> <br></br>
        <br></br>
        <br></br>
        <br></br> <br></br>
        <br></br>
        <br></br>
        <br></br> <br></br>
        <br></br>
        {/* {Seasons Section } */}
        <div>
          <h1 className="seasons-topic">
            Seasons Special
            <span className="seasons-sub-topic"> From Our Bakers</span>
          </h1>
          <div className="seasons">
            <div>
              <div className="sea-box">
                <div className="seasons-card">
                  <img src={seaimg1} alt="seasons-img" className="seaimg" />
                  <p className="sea-img-name">Brownie mousse cake</p>
                  <div class="rating">
                    <label className="rating-star" for="star5">
                      ★
                    </label>
                    <label className="rating-star" for="star4">
                      ★
                    </label>
                    <label className="rating-star" for="star3">
                      ★
                    </label>
                    <label className="rating-star" for="star2">
                      ★
                    </label>

                    <label className="rating-star" for="star1">
                      ★
                    </label>
                  </div>
                </div>
                <div className="seasons-card">
                  <img src={seaimg2} alt="seasons-img" className="seaimg" />
                  <p className="sea-img-name">Layered strwberry delight</p>
                  <div class="rating">
                    <label className="rating-star" for="star5">
                      ★
                    </label>
                    <label className="rating-star" for="star4">
                      ★
                    </label>
                    <label className="rating-star" for="star3">
                      ★
                    </label>
                    <label className="rating-star" for="star2">
                      ★
                    </label>

                    <label className="rating-star" for="star1">
                      ★
                    </label>
                  </div>
                </div>
                <div className="seasons-card">
                  <img src={seaimg3} alt="seasons-img" className="seaimg" />
                  <p className="sea-img-name">choco cheese brownie</p>
                  <div class="rating">
                    <label className="rating-star" for="star5">
                      ★
                    </label>
                    <label className="rating-star" for="star4">
                      ★
                    </label>
                    <label className="rating-star" for="star3">
                      ★
                    </label>
                    <label className="rating-star" for="star2">
                      ★
                    </label>

                    <label className="rating-star" for="star1">
                      ★
                    </label>
                  </div>
                </div>
                <div className="seasons-card">
                  <img src={seaimg4} alt="seasons-img" className="seaimg" />
                  <p className="sea-img-name">caramel brownie</p>
                  <div class="rating">
                    <label className="rating-star" for="star5">
                      ★
                    </label>
                    <label className="rating-star" for="star4">
                      ★
                    </label>
                    <label className="rating-star" for="star3">
                      ★
                    </label>
                    <label className="rating-star" for="star2">
                      ★
                    </label>

                    <label className="rating-star" for="star1">
                      ★
                    </label>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div className="btn-view-more">
            <button className="btn-view">
              View More
              <FaArrowRight className="btn-view-icon" />
            </button>
          </div>
        </div>
        <br></br>
        <br></br> <br></br>
        <br></br>
        <br></br>
        <br></br> <br></br>
        <br></br>
        <div></div>
        <Footer />
      </div>
    </div>
  );
}

export default SingUp;
