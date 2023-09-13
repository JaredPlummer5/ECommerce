import React from 'react';
import NavMenu  from './NavComponents/NavMenu';
import axios from 'axios';


import CategoryNav from './CategoryComponents/CategoryNav';

export function Layout(props) {

    async function GetProducts() {
        const response = await axios.get('https://localhost:7223/api/Products');
        props.setProducts(response.data);
        props.setRenderAddProductsButton(false)
        
    }


    return (
        <div>
            <NavMenu
                GetProducts={GetProducts}
                loggedIn={props.loggedIn}
                setDecodedUser={props.setDecodedUser}
                decodedUser={props.decodedUser}
                renderAddProductsButton={props.renderAddProductsButton}
                setRenderAddProductsButton={props.setRenderAddProductsButton}
                setLoggedIn={props.setLoggedIn}
                setUserData={props.setUserData}
            />
            
            <CategoryNav
                renderAddProductsButton={props.renderAddProductsButton}
                setRenderAddProductsButton={props.setRenderAddProductsButton}
                populateCategeoryData={props.populateCategeoryData}
                GetProducts={GetProducts}
                categeories={props.categeories}
                show={props.show}
                setShow={props.setShow}
                categoeryInfo={props.categoeryInfo}
                setCategoeryInfo={props.setCategoeryInfo}
                setProducts={props.setProducts}
                products={props.products}
                setUpdatedCategory={props.setUpdatedCategory}
                updatedCategory={props.updatedCategory}
                userData={props.userData}
            />
                

        </div>
    );
}

