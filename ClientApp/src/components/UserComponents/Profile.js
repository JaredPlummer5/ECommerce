import React from 'react';
import { useNavigate } from 'react-router-dom';
import './Profile.css';
import Cookies from 'js-cookie';

export default function Profile(props) {
    const navigate = useNavigate();

    function logout() {
        // Clear the userLoggedIn cookie
        Cookies.remove('userLoggedIn');
        // Navigate to the login page
        props.setUserData(null);
        props.setDecodeUserData(null);
        
        navigate('/login');
        props.setLoggedIn(false);
        // Optionally, clear the user data from localStorage on logout

        localStorage.removeItem('userData');
        // localStorage.removeItem('decodedUser');
    }

    return (
        <div className="profile-container">
            <div className="profile-sidebar">
                <h2>Your Account</h2>
                <ul>
                    <li>Profile</li>
                    <li>Orders</li>
                    <li>Addresses</li>
                    <li>Payment Options</li>
                    <li>Account Settings</li>
                </ul>
            </div>

            <div className="profile-content">
                <div className="profile-header">
                    {/* <img src={userData?.ProfileImage || "default-profile-image.png"} alt="Profile" className="profile-image" /> */}
                    <h1>Hello, {props.email || "User Name"}</h1>
                </div>
                <div className="profile-roles">
                    <h2>Your Roles</h2>
                    <ul>
                        {props.roles?.map((role, index) => (
                            <li key={index}>{role}</li>
                        ))}
                    </ul>
                </div>
                <div className="profile-orders">
                    <h2>Your Orders</h2>
                    {props.userData?.Orders?.map(order => (
                        <div key={order.id} className="order-item">
                            <p><strong>Order ID:</strong> {order.id}</p>
                            <p><strong>Date:</strong> {new Date(order.date).toLocaleDateString()}</p>
                            <p><strong>Total:</strong> ${order.total}</p>
                        </div>
                    ))}
                </div>

                <div className="profile-address">
                    <h2>Your Addresses</h2>
                    <p>{props.userData?.Address?.Street}</p>
                    <p>{props.userData?.Address?.City}, {props.userData?.Address?.State} {props.userData?.Address?.Zip}</p>
                    <p>{props.userData?.Address?.Country}</p>
                </div>

                <hr className="profile-separator" />

                <div className="profile-actions">
                    <button className="edit-profile-btn">Edit Profile</button>
                    <button
                        type='button'
                        onClick={logout}
                        className="logout-btn">Logout</button>
                </div>
            </div>
        </div>
    );
}
