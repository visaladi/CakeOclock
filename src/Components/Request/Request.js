import React from "react";
import Header from "../Header/Header";
import seaimg1 from "../Home/img/Rectangle 13.png";
import seaimg2 from "../Home/img/Rectangle 14.png";
import seaimg3 from "../Home/img/Rectangle 15.png";
import seaimg4 from "../Home/img/Rectangle 16.png";
import "./Request.css"; // Use the appropriate CSS file for your request page
import Footer from "../Footer/Footer";
import { FaArrowRight } from "react-icons/fa";
function Request() {
  return (
    <div className="backgroundnewrt">
      <Header />
      <br></br>
      <br></br>
      <div className="payment-content">
        <h1 className="payment-heading">Bake your cake</h1>
        <hr className="payment-hr" />
        <div className="req-row">
          <div className="request-section-left">
            <label htmlFor="request-type" className="payment-label">
              Category
            </label>
            <select id="request-type" className="request-dropdownnew">
              <option value="none">Select One</option>
              <option value="Birthday">Birdthday</option>
              <option value="party">Party</option>
            </select>
            <input
              type="date"
              id="request-date"
              className="request-date-input"
            />
            <textarea
              id="request-message"
              className="request-message-input"
              placeholder="Enter your message..."
            ></textarea>

            <div class="container">
              <div class="content">
                <div class="box">
                  <input
                    type="file"
                    name="file-7[]"
                    id="file-7"
                    class="inputfile inputfile-6"
                    data-multiple-caption="{count} files selected"
                    multiple
                  />
                  <label className="inputlbl" for="file-7">
                    <span className="inptspan"></span>
                    <strong>
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        width="20"
                        height="17"
                        viewBox="0 0 20 17"
                        className="inptsvg"
                      >
                        <path d="M10 0l-5.2 4.9h3.3v5.1h3.8v-5.1h3.3l-5.2-4.9zm9.3 11.5l-3.2-2.1h-2l3.4 2.6h-3.5c-.1 0-.2.1-.2.1l-.8 2.3h-6l-.8-2.2c-.1-.1-.1-.2-.2-.2h-3.6l3.4-2.6h-2l-3.2 2.1c-.4.3-.7 1-.6 1.5l.6 3.1c.1.5.7.9 1.2.9h16.3c.6 0 1.1-.4 1.3-.9l.6-3.1c.1-.5-.2-1.2-.7-1.5z" />
                      </svg>{" "}
                      Choose a file&hellip;
                    </strong>
                  </label>
                </div>
              </div>
            </div>
          </div>

          <div className="request-section-right">
            <div className="request-pickup-radio">
              <input
                type="radio"
                id="pickup-option"
                name="delivery-option"
                className="request-radio"
              />
              <label htmlFor="pickup-option" className="request-radio-label">
                Pickup from Outlet
              </label>
            </div>

            <select id="delivery-option" className="request-dropdown">
              <option value="fixed">101 Hapugala Branch</option>
              <option value="variable">101 Hapugala Branch</option>
            </select>
            <div className="request-pickup-radio">
              <input
                type="radio"
                id="pickup-option"
                name="delivery-option"
                className="request-radio"
              />
              <label htmlFor="pickup-option" className="request-radio-label">
                Home Delivery
              </label>
            </div>

            <div className="request-address-box">
              <p>
                No 59,
                <br />
                Hapugala road,
                <br />
                Wakwalla,
                <br />
                Galle.
                <br />
                0773084850
              </p>
              <a href="#ddd" className="request-edit-link">
                Edit
              </a>
            </div>

            <div className="contact-number-box">
              <p>
                Contact Numbers:
                <br />
                0773084850
                <br />
                0773084851
              </p>
            </div>
            <div className="cent">
              <p className="cent-para">
                We will contact you and approve your order within 24 Hours
              </p>
              <button className="cent-btn">Add a Request</button>
            </div>
          </div>
        </div>
        <br></br> <br></br> <br></br> <br></br> <br></br> <br></br> <br></br>{" "}
        <br></br> <br></br> <br></br> <br></br> <br></br> <br></br> <br></br>{" "}
        <br></br> <br></br>
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
      </div>
      <br></br>
      <br></br> <br></br>
      <br></br>
      <Footer />
    </div>
  );
}

export default Request;
