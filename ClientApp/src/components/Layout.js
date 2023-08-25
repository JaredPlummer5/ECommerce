import React, { useState, useEffect } from 'react';
import NavMenu  from './NavMenu';
import axios from 'axios';


import CategoryNav from './CategoryNav';

export function Layout(props) {

    async function GetProducts() {
        const response = await axios.get('https://localhost:7223/api/Products');
        // const data = await response.json();
        console.log("Response", response.data);
        props.setProducts(response.data);
        // console.log("Categeories: ", props.categeories);
    }


    return (
        <div>
            <NavMenu GetProducts={GetProducts}/>
            
            <CategoryNav
                 GetProducts={GetProducts}
                categeories={props.categeories}
                show={props.show}
                setShow={props.setShow}
                categoeryInfo={props.categoeryInfo}
                setCategoeryInfo={props.setCategoeryInfo}
                setProducts={props.setProducts}
                products={props.products}
            />
                

        </div>
    );
}

