import React, { useState } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import Cookies from 'js-cookie';
import './NavMenu.css';

export default function NavMenu(props) {
    const [collapsed, setCollapsed] = useState(true);

    const toggleNavbar = () => {
        setCollapsed(!collapsed);
    };
    function logout() {
        // Clear the userLoggedIn cookie
        Cookies.remove('userLoggedIn');
        props.setUserData(null);
        props.setDecodedUser(null);
        props.setLoggedIn(false);
    }


    return (
        <>
            <header>
                <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
                    <NavbarBrand tag={Link} to="/">ECommerce</NavbarBrand>
                    <NavbarToggler onClick={toggleNavbar} className="mr-2" />
                    <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!collapsed} navbar>
                        <ul className="navbar-nav flex-grow">
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink onClick={props.GetProducts} tag={Link} className="text-dark" to="/Products">Products</NavLink>
                            </NavItem>

                            {
                                props.decodedUser?.roles?.includes("Admin") && props.loggedIn ?
                                    < NavItem >
                                        <NavLink tag={Link} className="text-dark" to="/AddCategory">Add a Category</NavLink>
                                    </NavItem> : null
                            }


                            {
                                !props.loggedIn ?
                                    <>
                                        <NavItem>
                                            <NavLink tag={Link} className="text-dark" to="/Login">Login</NavLink>
                                        </NavItem>

                                        <NavItem>
                                            <NavLink tag={Link} className="text-dark" to="/Register">Register</NavLink>
                                        </NavItem>
                                    </>
                                    :
                                    <>
                                        <NavItem>
                                            <NavLink tag={Link} className="text-dark" to="/Profile">Profile</NavLink>
                                        </NavItem>
                                        <NavItem>
                                            <NavLink tag={Link} onClick={logout} className="text-dark" to="/">Logout</NavLink>
                                        </NavItem>
                                    </>
                            }
                        </ul>
                    </Collapse>

                </Navbar>
            </header >
        </>
    );
}


