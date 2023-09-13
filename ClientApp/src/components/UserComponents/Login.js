import React from 'react';
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Button from 'react-bootstrap/Button';
import axios from 'axios';
import { useNavigate } from 'react-router-dom'; // Import useNavigate
import Cookies from 'js-cookie';

export default function Login(props) {

   
    const navigate = useNavigate(); // Initialize the useNavigate hook
    
    
    async function userLogin() {
        try {
            const response = await axios.post('https://localhost:7223/api/Users/Login', props.user);
            props.setUserData({ ...props.user,...response.data });
            props.setLoggedIn(true);
    
            // Set a cookie after successful login
            Cookies.set('userLoggedIn', 'true', { expires: 7 }); // This cookie will expire in 7 days
    
            navigate('/'); // Redirect to home page
    
        } catch (error) { 
            console.log(error);
        }
    }


    
 
    
    return (
        <div style={{
            display: 'flex',
            justifyContent: 'center',
            alignItems: 'center',
            height: '100vh',
            background: 'linear-gradient(135deg, #84FAB0 0%, #8FD3F4 100%)',
            flexDirection: 'column'
        }}>
            <h1 style={{
                color: 'white',
                textAlign: 'center',
                fontSize: '40px',
                fontWeight: '600',
                fontFamily: 'Roboto',
                marginBottom: '70px'
            }}>
                Login
            </h1>
            <Form style={{
                padding: '50px',
                borderRadius: '20px',
                boxShadow: '0 4px 6px rgba(0, 0, 0, 0.1)',
                background: 'white',
                width: '500px',  // Increased the width here
                height: '500px',
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                flexDirection: 'column'
            }}>
                <Form.Group as={Row} className="mb-5" controlId="formPlaintextEmail">
                    <Form.Label column sm="3" style={{ fontWeight: '600', fontSize: '20px' }}>
                        Email
                    </Form.Label>
                    <Col sm="9">
                        <Form.Control 
                            style={{ 
                                borderRadius: '10px',
                                boxShadow: '0 2px 4px rgba(0, 0, 0, 0.1)',
                                fontSize: '18px',  // Increased the font size here
                                height: '50px'     // Increased the height here
                            }}
                            
                            onChange={(e) => {
                                const email = e.target.value;
                                const userName = email.split('@')[0].toUpperCase(); // Split the email and take the first part, then convert to uppercase
                                props.setUser({
                                    ...props.user,
                                    UserName: userName,
                                    Email: email
                                });
                                // console.log(props.user);
                            }}
                            type="email"
                            placeholder="Email"
                        />
                    </Col>
                </Form.Group>

                <Form.Group as={Row} className="mb-5" controlId="formPlaintextPassword">
                    <Form.Label column sm="3" style={{ fontWeight: '600', fontSize: '20px' }}>
                        Password
                    </Form.Label>
                    <Col sm="9">
                        <Form.Control 
                            onChange={(e) => {
                                props.setUser({ ...props.user, Password: e.target.value });
                                // console.log(props.user);
                            }}
                            style={{ 
                                borderRadius: '10px',
                                boxShadow: '0 2px 4px rgba(0, 0, 0, 0.1)',
                                fontSize: '18px',  // Increased the font size here
                                height: '50px'     // Increased the height here
                            }}
                            type="password" 
                            placeholder="Password" 
                        />
                    </Col>
                </Form.Group>

                <div style={{ display: 'flex', justifyContent: 'center' }}>
                    <Button 
                        variant="primary"
                        style={{
                            background: 'linear-gradient(135deg, #84FAB0, #8FD3F4)',
                            borderColor: '#8FD3F4',
                            color: 'white',
                            transition: 'background 0.3s ease',
                            fontSize: '18px',     // Increased the font size here
                            padding: '10px 20px'  // Increased padding here
                        }}
                        onMouseOver={e => {
                            e.currentTarget.style.background = 'linear-gradient(105deg, #84FAB0, #8FD3F4)';
                        }}
                        onMouseOut={e => {
                            e.currentTarget.style.background = 'linear-gradient(135deg, #84FAB0, #8FD3F4)';
                        }}
                        onClick={userLogin}
                    >
                        Login
                    </Button>
                </div>
            </Form>
        </div>
    )
}
