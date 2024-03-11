import React, { useState } from "react";
import Header from "../Header/Header";
import Footer from "../Footer/Footer";
import seaimg1 from "../Home/img/Rectangle 13.png";
import seaimg2 from "../Home/img/Rectangle 14.png";
import seaimg3 from "../Home/img/Rectangle 15.png";
import seaimg4 from "../Home/img/Rectangle 16.png";
import cake1 from "./img/cake1.jpeg";
import cake2 from "./img/cake2.jpg";
import cake3 from "./img/cake3.jpg";
import cake4 from "./img/cake4.jpeg";
import { FaArrowRight } from "react-icons/fa";
import { IoIosArrowForward } from "react-icons/io";
import "./ItemDetails.css";
function ItemDetails() {
  const imgs = [
    { id: 0, value: cake1 },
    { id: 1, value: cake2 },
    { id: 2, value: cake3 },
    { id: 3, value: cake4 },
  ];

  const [sliderData, setSliderData] = useState(imgs[0]);
  const handlClick = (index) => {
    console.log(index);
    const slider = imgs[index];
    setSliderData(slider);
  };
  return (
    <div className="background-details">
      <Header />
      <br></br>
      <br></br>
      <div>
        {/* {Celebration Section } */}
        <div className="Full-Box-cel">
          <div className="cel-box">
            <h1 className="cel-box-topic">Celebration</h1>

            <p className="cel-box-para">
              <span className="cel-box-para-cat">Category</span>
              <span className="cel-box-para-icon">
                <IoIosArrowForward />
              </span>
              <span className="cel-box-para-path">Dark Harlem Squre Cake</span>
            </p>
          </div>
          <br></br> <br></br> <br></br>
          <br></br>
          <br></br>
          <div className="dis-section">
            <div className="left-colum-dis">
              <div className="slider-container">
                <img src={sliderData.value} className="mainimg" alt="img" />
                <div className="flex_row">
                  {imgs.map((data, i) => (
                    <div className="subnimg">
                      <img
                        className={sliderData.id === i ? "clicked" : ""}
                        key={data.id}
                        src={data.value}
                        onClick={() => handlClick(i)}
                        width="100px"
                        height="100px"
                        alt="img"
                      ></img>
                    </div>
                  ))}
                </div>
              </div>
            </div>
            <div className="right-colum-dis">
              <h1 className="right-colum-dis-topic">Dark Harlem Square Cake</h1>
              <h4 className="right-colum-dis-price">Rs. 6500.00</h4>
              <div>
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
                  <label className="rating-star-para">
                    (3.5 stars . 10 reviews)
                  </label>
                </div>
              </div>
              <p className="rating-star-para-new">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                Suspendisse varius enim in eros elementum tristique. Duis
                cursus, mi quis viverra ornare, eros dolor interdum nulla, ut
                commodo diam libero vitae erat.
              </p>
              <br></br>
              <form>
                <label className="rating-star-para-label">Variant</label>
                <br></br>
                <select
                  className="rating-star-para-input"
                  id="variant"
                  name="variant"
                  required
                >
                  <option value="variant1">Variant 1</option>
                  <option value="variant2">Variant 2</option>
                  <option value="variant3">Variant 3</option>
                  <option value="variant4">Variant 4</option>
                </select>
                <br></br>
                <br></br>
                <label className="rating-star-para-label">Variant</label>
                <br></br>
                <div className="btn-set-details">
                  <button className="rating-star-para-btn1">Option One</button>
                  <button className="rating-star-para-btn2">Option Two</button>
                  <button className="rating-star-para-btn3">
                    Option Three
                  </button>
                </div>
                <br></br>
                <label className="rating-star-para-label">Quantity</label>
                <br></br>
                <input
                  type="text"
                  className="rating-star-para-input-qty"
                  name="quentity"
                  required
                />
                <br></br>
                <button
                  className="Add-To-Cart-btn"
                  onClick={() => {
                    window.location.href = "/cart";
                  }}
                >
                  Add To Cart
                </button>
                <br></br>
                <button
                  className="Buy-Now-btn"
                  onClick={() => {
                    window.location.href = "/payment";
                  }}
                >
                  Buy Now
                </button>
              </form>
            </div>
          </div>
        </div>
        <br></br>
        <br></br> <br></br>
        <br></br>
        <br></br>
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
      </div>
      <br></br>
      <br></br> <br></br>
      <br></br>
      <div></div>
      <Footer />
    </div>
  );
}

export default ItemDetails;
