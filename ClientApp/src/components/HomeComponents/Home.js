import React from "react";
import "./Home.css";  // Continue using the Home.css
import BamazonParticles from "./BamazonParticles";

export default function Home() {
    return (
        <div className="homeContainer">
            <BamazonParticles/>
            {/* <div className="stars"></div>
            <div className="stars2"></div>
            <div className="stars3"></div>
            <h1 className="homeTitle">Bamazon</h1> */}
        </div>
    )
}
