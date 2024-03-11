import React from "react";
import Header from "../Header/Header";
import Footer from "../Footer/Footer";
import seaimg1 from "../Home/img/Rectangle 13.png";
import seaimg2 from "../Home/img/Rectangle 14.png";
import seaimg3 from "../Home/img/Rectangle 15.png";
import seaimg4 from "../Home/img/Rectangle 16.png";
import one from "./img/one.png";
import three from "./img/three.png";
import two from "./img/two.png";
import { MdCancelPresentation } from "react-icons/md";
import { FaArrowRight } from "react-icons/fa";
import "./cart.css";
function Cart() {
  return (
    <div>
      <div className="background-details">
        <Header />
        <br></br>
        <br></br>
        <div>
          {/* {Celebration Section } */}
          <div className="Full-Box-cel">
            <div className="cel-box">
              <h1 className="cart-box-topic">Cart</h1>
            </div>
            <br></br> <br></br>
            <div className="dis-section-cart">
              <div className="left-colum-dis">
                <div className="cart-item-card">
                  <div className="cart-item-header">
                    <label class="container-check">
                      <input type="checkbox" checked className="input-check" />
                      <span class="checkmark"></span>
                    </label>
                  </div>
                  <div className="cart-item-body">
                    <img src={one} alt="Product" className="cart-item-image" />
                  </div>
                  <div className="cart-item-footer">
                    <div className="title-cancel">
                      <h3 className="cart-item-title">
                        Dark Harlem Square Cake
                      </h3>
                      <MdCancelPresentation className="cart-item-cancel" />
                    </div>
                    <p className="cart-item-description">
                      Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                      Suspendisse varius enim in eros elementum tristique. Duis
                      cursus, mi quis viverra ornare, eros dolor interdum nulla,
                      ut commodo diam libero vitae erat.
                    </p>
                    <h6 className="cart-item-title-sub">Variant</h6>
                    <div className="buttonset">
                      <button className="optionbtn option1">Option One</button>
                      <button className="optionbtn option2">Option Two</button>
                      <button className="optionbtn option3">
                        Option Three
                      </button>
                    </div>
                    <div className="title-cancel-qunt">
                      <div>
                        <h6 className="cart-item-title-sub">Quantity</h6>
                        <p className="optioncount">1</p>
                      </div>
                      <div>
                        <p className="right-colum-price">6500.00</p>
                      </div>
                    </div>
                  </div>
                </div>
                <div className="cart-item-card">
                  <div className="cart-item-header">
                    <label class="container-check">
                      <input type="checkbox" checked className="input-check" />
                      <span class="checkmark"></span>
                    </label>
                  </div>
                  <div className="cart-item-body">
                    <img src={two} alt="Product" className="cart-item-image" />
                  </div>
                  <div className="cart-item-footer">
                    <div className="title-cancel">
                      <h3 className="cart-item-title">
                        velvert Harlem Square Cake
                      </h3>
                      <MdCancelPresentation className="cart-item-cancel" />
                    </div>
                    <p className="cart-item-description">
                      Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                      Suspendisse varius enim in eros elementum tristique. Duis
                      cursus, mi quis viverra ornare, eros dolor interdum nulla,
                      ut commodo diam libero vitae erat.
                    </p>
                    <h6 className="cart-item-title-sub">Variant</h6>
                    <div className="buttonset">
                      <button className="optionbtn option1">Option One</button>
                      <button className="optionbtn option2">Option Two</button>
                      <button className="optionbtn option3">
                        Option Three
                      </button>
                    </div>
                    <div className="title-cancel-qunt">
                      <div>
                        <h6 className="cart-item-title-sub">Quantity</h6>
                        <p className="optioncount">1</p>
                      </div>
                      <div>
                        <p className="right-colum-price">6500.00</p>
                      </div>
                    </div>
                  </div>
                </div>
                <div className="cart-item-card">
                  <div className="cart-item-header">
                    <label class="container-check">
                      <input type="checkbox" checked className="input-check" />
                      <span class="checkmark"></span>
                    </label>
                  </div>
                  <div className="cart-item-body">
                    <img
                      src={three}
                      alt="Product"
                      className="cart-item-image"
                    />
                  </div>
                  <div className="cart-item-footer">
                    <div className="title-cancel">
                      <h3 className="cart-item-title">
                        Butterfly Harlem Square Cake
                      </h3>
                      <MdCancelPresentation className="cart-item-cancel" />
                    </div>
                    <p className="cart-item-description">
                      Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                      Suspendisse varius enim in eros elementum tristique. Duis
                      cursus, mi quis viverra ornare, eros dolor interdum nulla,
                      ut commodo diam libero vitae erat.
                    </p>
                    <h6 className="cart-item-title-sub">Variant</h6>
                    <div className="buttonset">
                      <button className="optionbtn option1">Option One</button>
                      <button className="optionbtn option2">Option Two</button>
                      <button className="optionbtn option3">
                        Option Three
                      </button>
                    </div>
                    <div className="title-cancel-qunt">
                      <div>
                        <h6 className="cart-item-title-sub">Quantity</h6>
                        <p className="optioncount">1</p>
                      </div>
                      <div>
                        <p className="right-colum-price">6500.00</p>
                      </div>
                    </div>
                  </div>
                </div>
                <p className="paraempty">
                  Cart feels empty?{" "}
                  <span className="paraempty-shop"> Shop More</span>
                </p>
              </div>
              <div className="right-colum-dis">
                <div>
                  <div className="box1">
                    <div className="right-colum-price-details">
                      <p className="right-colum-price-name">
                        Sub Total Amount:
                      </p>
                      <p className="right-colum-price">19500.00</p>
                    </div>
                    <div className="right-colum-price-details">
                      <p className="right-colum-price-name">Discounts:</p>
                      <p className="right-colum-price">1500.00</p>
                    </div>
                    <div className="right-colum-price-details">
                      <p className="right-colum-price-name">Coupons:</p>
                      <p className="right-colum-price">00.00</p>
                    </div>
                    <hr className="hr-cart" />
                  </div>
                  <br></br>
                  <div className="box2">
                    <div className="right-colum-price-details">
                      <p className="right-colum-price-name">
                        Sub Total Amount:
                      </p>
                      <p className="right-colum-price">18000.00</p>
                    </div>
                  </div>
                  <div className="box">
                    <form className="box-form">
                      <p className="aoupon">Apply Coupon</p>
                      <input
                        type="text"
                        className="inputbox"
                        placeholder="Enter coupon here"
                      ></input>
                      <br></br>
                    </form>
                    <div className="box-btn">
                      <button
                        className="inputtn"
                        onClick={() => {
                          window.location.href = "/payment";
                        }}
                      >
                        CHECKOUT
                      </button>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
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
    </div>
  );
}

export default Cart;
