import React, { useState, useEffect } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import ProductCard from "./components/ProductCard";
import axios from 'axios';
import './custom.css';

export default function App() {

    const [categeories, setCategeories] = useState([]);
    const [show, setShow] = useState(false);
    const [categoeryInfo, setCategoeryInfo] = useState({});

    const [products, setProducts] = useState([]);


    async function populateCategeoryData() {
        const response = await axios.get('https://localhost:7223/categeories');
        // const data = await response.json();
        console.log("Response", response.data);
        setCategeories(response.data);
        console.log("Categeories: ", categeories);

    }
   

    useEffect(() => {
        populateCategeoryData();
    }, []);

    return (
        <div>
            <Layout
                categeories={categeories}
                show={show}
                setShow={setShow}
                categoeryInfo={categoeryInfo}
                setCategoeryInfo={setCategoeryInfo}
                setProducts={setProducts}
                products={products}

            />
            <Routes>
                {AppRoutes.map((route, index) => {
                    const { element, ...rest } = route;
                    return <Route key={index} {...rest} element={element} />;
                })}

                <Route key={98989} path={`/Products`} element={<ProductCard products={products} />} />;

            </Routes>


        </div>
    );
}

