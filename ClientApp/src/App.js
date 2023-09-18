import React, { useState, useEffect } from 'react';
import { Route, Routes, useLocation, useNavigate } from 'react-router-dom';
import { Layout } from './components/Layout';
import ProductCard from "./components/ProductComponents/ProductCard";
import axios from 'axios';
import './custom.css';
import AddCategory from './components/CategoryComponents/AddCategory';
import Home from "./components/HomeComponents/Home";
import Login from './components/UserComponents/Login';
import Profile from './components/UserComponents/Profile';
import Register from './components/UserComponents/Register';
import Cart from './components/UserComponents/Cart';
import Cookies from 'js-cookie';


export default function App() {
    const location = useLocation();
    const navigate = useNavigate(); // Initialize the useNavigate hook
    const [isAppInitialized, setIsAppInitialized] = useState(false);



    const [show, setShow] = useState(false);

    //Category State Varibles
    const [categeories, setCategeories] = useState([]);
    const [categoeryInfo, setCategoeryInfo] = useState({});
    const [updatedCategory, setUpdatedCategory] = useState({ name: "", description: "" });

    //Product State Variables
    const [products, setProducts] = useState([]);
    const [updatedProduct, setUpdatedProduct] = useState({ name: "", description: "" });
    const [postProduct, setPostProduct] = useState({ name: "", description: "",price: 0 });
    const [renderAddProductsButton, setRenderAddProductsButton] = useState(true);

    // User State Variables
    const [loggedIn, setLoggedIn] = useState(false);
    const [user, setUser] = useState({});
    const [token, setToken] = useState("");
    const [userData, setUserData] = useState(null);
    const [decodedUser, setDecodedUser] = useState({});
    // Create state variables for the data you want to extract from the JWT
    const [email, setEmail] = useState(null);
    const [roles, setRoles] = useState([]);

    // Get All Categories
    async function populateCategeoryData() {
        try {
            
            const response = await axios.get('https://localhost:7223/categeories');
            setCategeories(response.data);
            
            if (Cookies.get('userLoggedIn') === 'true') {
                // User is logged in
                setLoggedIn(true);
            }
        } catch (error) {
            console.error(error)
        }
    }

    // Function to decoded the JWT
    function decodeJWT(token) {
        const base64Url = token.split('.')[1];
        const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        const jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
            let result = "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
            return result;
        }).join(''));

        return JSON.parse(jsonPayload);
    }


    useEffect(() => {

        populateCategeoryData();

        if (!isAppInitialized) {
            const lastVisitedPath = localStorage.getItem('lastVisitedPath');
            if (lastVisitedPath && location.pathname !== '/') {
                navigate(lastVisitedPath);
            }
            setIsAppInitialized(true);
        }

        if (userData != null && userData.token) {
            const decoded = decodeJWT(userData.token);
            // console.log(decoded);
            setDecodedUser({
                email: decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"] || null,
                roles: decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] || [],
                permissions: decoded["permissions"] || [],
            });
            // Set the state variables with the extracted data
            setEmail(decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"]);
            setRoles(decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]);
            // setPermissions(decoded["permissions"]);
        }

        // Whenever userData changes, save it to localStorage
        if (userData) {
            localStorage.setItem('userData', JSON.stringify(userData));
            localStorage.setItem('decodedUser', JSON.stringify(decodedUser));
        }


        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [userData, isAppInitialized, location, navigate]);


    useEffect(() => {
        // On component mount, retrieve user data from localStorage
        const savedUserData = localStorage.getItem('userData');
        const savedDecodedUser = localStorage.getItem('decodedUser');
        if (savedUserData) {
            setUserData(JSON.parse(savedUserData));
            setDecodedUser(JSON.parse(savedDecodedUser));
        }
    }, [setUserData]);



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
                setUpdatedCategory={setUpdatedCategory}
                updatedCategory={updatedCategory}
                populateCategeoryData={populateCategeoryData}
                renderAddProductsButton={renderAddProductsButton}
                setRenderAddProductsButton={setRenderAddProductsButton}
                loggedIn={loggedIn}
                setLoggedIn={setLoggedIn}
                setDecodedUser={setDecodedUser}
                decodedUser={decodedUser}
                userData={userData}
                setUserData={setUserData}
                
            />

            <Routes>

                <Route
                    key={111}
                    path='/'
                    element={<Home />}
                />

                <Route
                    key={98989}
                    path={`/Products`}
                    element={
                        <ProductCard
                            userData={userData}
                            renderAddProductsButton={renderAddProductsButton}
                            setRenderAddProductsButton={setRenderAddProductsButton}
                            products={products}
                            updatedProduct={updatedProduct}
                            setUpdatedProduct={setUpdatedProduct}
                            setShow={setShow}
                            setProducts={setProducts}
                            category={categoeryInfo}
                            postProduct={postProduct}
                            setPostProduct={setPostProduct}
                            decodedUser={decodedUser}

                        />}
                />

                {
                    decodedUser?.roles?.includes("Admin") && <Route
                        key={934639}
                        path={`/AddCategory`}
                        element={
                            <AddCategory
                                populateCategeoryData={populateCategeoryData}
                                userData={userData}
                            />
                        }
                    />
                }

                {!loggedIn ?
                    <>
                        <Route
                            key={934639}
                            path={`/Login`}
                            element={
                                <Login
                                    loggedIn={loggedIn}
                                    setLoggedIn={setLoggedIn}
                                    user={user}
                                    setUser={setUser}
                                    userData={userData}
                                    setUserData={setUserData}
                                    token={token}
                                    setToken={setToken}
                                />}
                        />
                        <Route
                            key={934639}
                            path={`/Register`}
                            element={
                                <Register
                                    loggedIn={loggedIn}
                                    setLoggedIn={setLoggedIn}
                                    user={user}
                                    setUser={setUser}
                                    userData={userData}
                                    setUserData={setUserData}
                                    token={token}
                                    setToken={setToken}
                                />}
                        />
                    </>
                    :
                    <Route
                        key={934639}
                        path={`/Profile`}
                        element={
                            <Profile
                                loggedIn={loggedIn}
                                setLoggedIn={setLoggedIn}
                                email={email}
                                roles={roles}
                                decodedUser={decodedUser}
                                setDecodedUser={setDecodedUser}
                                userData={userData}
                                setUserData={setUserData}
                            />}
                    />}
                
                <Route
                    key={1235}
                    path={'/Cart'}
                    element={
                        <Cart
                            
                    
                        />
                    }
                />

            </Routes>


        </div>
    );
}

