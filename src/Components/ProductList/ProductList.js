import React from "react";
import Footer from "../Footer/Footer";
import Header from "../Header/Header";
import item1 from "./img/item1.png";
import item2 from "./img/item2.png";
import item3 from "./img/item3.png";
import item4 from "./img/item4.png";

import { FaArrowRight } from "react-icons/fa";
import { FaSearch } from "react-icons/fa";
import "./productlist.css";

function ProductList() {
  return (
    <div>
      <div className="background-details">
        <Header />
        <div>
          <div className="main-colum-set">
            <div className="left-colum-list">
              <div className="nav-itemset">
                <h1 className="seli-nav-item activ-nav-seli">CELEBRATION</h1>
                <h1 className="seli-nav-item">Category</h1>
                <h1 className="seli-nav-item">Category</h1>
                <h1 className="seli-nav-item">Category</h1>
              </div>
            </div>
            <div className="right-colum-list">
              <div className="first-row-left">
                <h1 className="seltopic">Celebration</h1>
                <input
                  type="text"
                  className="search-cake"
                  placeholder="Search For Cakes"
                  required
                ></input>

                <span className="searchicon-bk">
                  <FaSearch className="searchicon" />
                </span>
              </div>

              <div>
                <div className="item-displyaset">
                  <div
                    className="card-set-item"
                    onClick={() => {
                      window.location.href = "/itemDetails";
                    }}
                  >
                    <div className="card-item">
                      <img src={item1} alt="logo" className="itemimg" />
                      <div className="item-card-body">
                        <p className="item-para">
                          Red Velvet & Cream Cheese ( 500g )
                        </p>
                        <p className="item-price">2000.00</p>
                      </div>
                    </div>
                  </div>
                  <div
                    className="card-set-item"
                    onClick={() => {
                      window.location.href = "/itemDetails";
                    }}
                  >
                    <div className="card-item">
                      <img src={item2} alt="logo" className="itemimg" />
                      <div className="item-card-body">
                        <p className="item-para">
                          Red Velvet & Cream Cheese ( 800g )
                        </p>
                        <p className="item-price">2000.00</p>
                      </div>
                    </div>
                  </div>
                  <div
                    className="card-set-item"
                    onClick={() => {
                      window.location.href = "/itemDetails";
                    }}
                  >
                    <div className="card-item">
                      <img src={item3} alt="logo" className="itemimg" />
                      <div className="item-card-body">
                        <p className="item-para">
                          Red Velvet & Cream Cheese ( 900g )
                        </p>
                        <p className="item-price">2800.00</p>
                      </div>
                    </div>
                  </div>
                  <div
                    className="card-set-item"
                    onClick={() => {
                      window.location.href = "/itemDetails";
                    }}
                  >
                    <div className="card-item">
                      <img src={item4} alt="logo" className="itemimg" />
                      <div className="item-card-body">
                        <p className="item-para">
                          Red Velvet & Cream Cheese ( 550g )
                        </p>
                        <p className="item-price">2000.00</p>
                      </div>
                    </div>
                  </div>
                </div>
                <br></br>
                <div className="item-displyaset">
                  <div
                    className="card-set-item"
                    onClick={() => {
                      window.location.href = "/itemDetails";
                    }}
                  >
                    <div className="card-item">
                      <img src={item1} alt="logo" className="itemimg" />
                      <div className="item-card-body">
                        <p className="item-para">
                          Red Velvet & Cream Cheese ( 500g )
                        </p>
                        <p className="item-price">2000.00</p>
                      </div>
                    </div>
                  </div>
                  <div
                    className="card-set-item"
                    onClick={() => {
                      window.location.href = "/itemDetails";
                    }}
                  >
                    <div className="card-item">
                      <img src={item2} alt="logo" className="itemimg" />
                      <div className="item-card-body">
                        <p className="item-para">
                          Red Velvet & Cream Cheese ( 800g )
                        </p>
                        <p className="item-price">2000.00</p>
                      </div>
                    </div>
                  </div>
                  <div
                    className="card-set-item"
                    onClick={() => {
                      window.location.href = "/itemDetails";
                    }}
                  >
                    <div className="card-item">
                      <img src={item3} alt="logo" className="itemimg" />
                      <div className="item-card-body">
                        <p className="item-para">
                          Red Velvet & Cream Cheese ( 900g )
                        </p>
                        <p className="item-price">2800.00</p>
                      </div>
                    </div>
                  </div>
                  <div
                    className="card-set-item"
                    onClick={() => {
                      window.location.href = "/itemDetails";
                    }}
                  >
                    <div className="card-item">
                      <img src={item4} alt="logo" className="itemimg" />
                      <div className="item-card-body">
                        <p className="item-para">
                          Red Velvet & Cream Cheese ( 550g )
                        </p>
                        <p className="item-price">2000.00</p>
                      </div>
                    </div>
                  </div>
                </div>
              </div>

              <div className="pagenumberset">
                <button className="btnactive btnnumberpg">1</button>
                <button className="btnnumberpg">2</button>
                <button className="btnnumberpg">3</button>
                <button className="btnnumberpg">4</button>
                <button className="btn-view">
                  View More
                  <FaArrowRight className="btn-view-icon" />
                </button>
              </div>
            </div>
          </div>
        </div>
        <div className="contactus-section">
          <h1 className="contactus-section-topic">For Cake Orders above 3KG</h1>
          <p className="contactus-section-para">
            Please visit our nearest store or call us on +91 00 00 00 00 00 (10
            AM to 7 PM) <br></br>to place your orders.
          </p>
          <button className="contactus-section-btn">Contact Us Now</button>
        </div>
        <Footer />
      </div>
    </div>
  );
}

export default ProductList;
