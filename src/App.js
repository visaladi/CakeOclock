import React from "react";
import { Route, Routes } from "react-router";
import "./App.css";
import Home from "./Components/Home/Home";
import Login from "./Components/Login/Login";
import SignUp from "./Components/SignUp/SignUp";
import Cart from "./Components/Cart/Cart";
import ProductList from "./Components/ProductList/ProductList";
import Payment from "./Components/Payment/Payment";
import ItemDetails from "./Components/ItemDetails/ItemDetails";
import Request from "./Components/Request/Request";

function App() {
  return (
    <div>
      <React.Fragment>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route path="/signup" element={<SignUp />} />
          <Route path="/cart" element={<Cart />} />
          <Route path="/itemDetails" element={<ItemDetails />} />
          <Route path="/productlist" element={<ProductList />} />
          <Route path="/request" element={<Request />} />
          <Route path="/payment" element={<Payment />} />
        </Routes>
      </React.Fragment>
    </div>
  );
}

export default App;
