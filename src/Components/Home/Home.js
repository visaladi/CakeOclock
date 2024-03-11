import React, { useEffect } from "react";
import Header from "../Header/Header";
import catimg1 from "./img/Rectangle 19.png";
import catimg2 from "./img/Rectangle 21.png";
import catimg3 from "./img/Rectangle 23.png";
import catimg4 from "./img/Rectangle 24.png";
import seaimg1 from "./img/Rectangle 13.png";
import seaimg2 from "./img/Rectangle 14.png";
import seaimg3 from "./img/Rectangle 15.png";
import seaimg4 from "./img/Rectangle 16.png";
import collectionimg from "./img/product.png";
import about from "./img/about.png";
import outlet from "./img/outlet.png";
import { FaBagShopping } from "react-icons/fa6";
import { FaArrowRight } from "react-icons/fa";
import Footer from "../Footer/Footer";
import "./home.css";

function Home() {
  useEffect(() => {
    const radioButtons = document.querySelectorAll("input[type=radio]");
    let currentIndex = 0;

    const slideShow = () => {
      setInterval(() => {
        radioButtons[currentIndex].checked = true;
        currentIndex = (currentIndex + 1) % radioButtons.length;
      }, 5000); // Change the interval to 5000 milliseconds (5 seconds)
      
    };

    slideShow();
  }, []);

  return (
    <div>
      <div className="background2">
        <Header />
        <br/> <br/> <br/> <br/>
        <div className="full-bdy">
          {/* {Slider Section } */}
          <div className="slider">
            <section id="slider">
              <input type="radio" name="slider" id="s1" checked className="slider-input"/>
              <input type="radio" name="slider" id="s2" className="slider-input" />
              <input type="radio" name="slider" id="s3" className="slider-input" />
              <input type="radio" name="slider" id="s4" className="slider-input" />
              <input type="radio" name="slider" id="s5"  className="slider-input"/>

              <label className="slider-label"  for="s1" id="slide1">
             
              </label>
              <label className="slider-label"  for="s2" id="slide2">
                
              </label>
              <label className="slider-label"  for="s3" id="slide3">
                
              </label>
              <label className="slider-label"  for="s4" id="slide4">
                
              </label>
              <label className="slider-label"  for="s5" id="slide5">
                
              </label>
            </section>
          </div>
          <br/> <br/> <br/> <br/><br/> <br/> <br/> <br/>
          {/* {CATEGORIES Section } */}
          <div className="catagoris">
            <div>
              <h1 className="cat-topic">CATEGORIES</h1>
              <div className="cat-box">
                <div>
                  <img src={catimg1} alt="logo" className="catimg" />
                  <p className="cat-img-name">Category</p>
                </div>
                <div>
                  <img src={catimg2} alt="logo" className="catimg" />
                  <p className="cat-img-name">Category</p>
                </div>
                <div>
                  <img src={catimg3} alt="logo" className="catimg" />
                  <p className="cat-img-name">Category</p>
                </div>
                <div>
                  <img src={catimg4} alt="logo" className="catimg" />
                  <p className="cat-img-name">Category</p>
                </div>
              </div>
            </div>
          </div>
          {/* {Collections Section } */}
          <div className="collection">
            <div className="collection-colum1">
              <h1 className="coletion-topic">Collections</h1>
              <p className="coletion-para">
                you can explore ans shop many differnt collection <br></br> from
                various barands here.
              </p>
              <button
                className="btnshop"
                onClick={() => {
                  window.location.href = "/productlist";
                }}
              >
                <FaBagShopping className="shop-icon" />
                Shop Now
              </button>
            </div>
            <div className="collection-colum2">
              <img src={collectionimg} alt="logo" className="img-coll"></img>
            </div>
          </div>
          {/* {About Us Section } */}
          <div className="about-bk">
            <div className="collection">
              <div className="collection-colum1">
                <h1 className="about-topic">About Us</h1>
                <p className="about-para">
                  Coconuts are tropical fruits with a hard outer <br></br> husk,
                  a tough shell, and a deliciously sweet <br></br> , creamy
                  flesh inside. They are widely known <br></br> for their
                  versatility, providing coconut water, milk,<br></br> oil, and
                  grated coconut for culinary use. <br></br> Coconuts are a rich
                  source of healthy fats,<br></br> fiber, and essential
                  minerals, making them a <br></br> nutritious addition to
                  various dishes and<br></br>
                  beverages.
                </p>
                <button className="btnabout">Taste Drive</button>
              </div>
              <div className="collection-colum2">
                <img src={about} alt="logo" className="img-coll"></img>
              </div>
            </div>
          </div>
          {/* {Everyone Section } */}
          <div className="everyone">
            <h1 className="everyone-topic">A Price To Suit Everyone</h1>
            <p className="everyone-para">
              Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean
              commodo ligula eget dolor. Aenean massa. Cum sociis natoque
              penatibus et magnis dis parturient montes, nascetur ridiculus{" "}
            </p>
          </div>
          {/* {Outlets Section } */}
          <div className="Outlets-bk">
            <div className="collection">
              <div className="outlet-colum2">
                <img src={outlet} alt="logo" className="img-outlet"></img>
              </div>
              <div className="outlet-colum1">
                <h1 className="Outlets-topic">Outlets</h1>
                <p className="Outlets-para">
                  Coconuts are tropical fruits with a hard outer husk, a tough
                  shell, and a deliciously sweet , creamy flesh inside. They are
                  widely known for their versatility, providing coconut water,
                  milk, oil, and grated coconut for culinary use. Coconuts are a
                  rich source of healthy fats fiber, and essential minerals,
                  making them a nutritious addition to various dishes an
                  beverages.
                </p>
                <button className="btnOutlets">Taste Drive</button>
              </div>
            </div>
          </div>
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
        <Footer />
      </div>
    </div>
  );
}

export default Home;
