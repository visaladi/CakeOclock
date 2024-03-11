import React from "react";
import Header from "../Header/Header";
import Logo from "../Header/img/logo.png";
import "./Login.css";
import Footer from "../Footer/Footer";
import seaimg1 from "../Home/img/Rectangle 13.png";
import seaimg2 from "../Home/img/Rectangle 14.png";
import seaimg3 from "../Home/img/Rectangle 15.png";
import seaimg4 from "../Home/img/Rectangle 16.png";
import { FaArrowRight } from "react-icons/fa";
function Login() {
  return (
    <div>
      <div className="background">
        <Header /> <br></br>
        <br></br> <br></br>
        <br></br> <br></br>
        <div className="login-container">
          <div className="login-box">
            <img src={Logo} alt="Logo" className="login-logo" />
            <h2 className="login-heading">Log in</h2>
            <form className="login-form">
              <div className="login-form-group">
                <label htmlFor="email" className="login-label">
                  USER NAME/ EMAIL
                </label>
                <input
                  type="email"
                  id="email"
                  placeholder="Email"
                  className="login-form-input"
                />
              </div>
              <div className="login-form-group">
                <label htmlFor="password" className="login-label">
                  PASSWORD
                </label>
                <input
                  type="password"
                  id="password"
                  placeholder="Password"
                  className="login-form-input"
                />
              </div>
              <a href="/Forgotpass" className="login-forgot-password">
                Forgot Your Password?
              </a>
              <div className="login-btn">
                <button type="submit" className="login-button">
                  Login
                </button>
                <br></br>
              </div>
            </form>
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

export default Login;
