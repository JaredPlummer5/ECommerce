import React, { useState } from 'react'
import axios from 'axios';
import { Form, Button } from 'react-bootstrap';
export default function AddCategory(props) {
    const [postCategeory, setPostCategory] = useState({
        name: "",
        description: ""
    });
    async function AddCategory() {
        let response = await axios.post(`https://localhost:7223/categeories/CreateCategory`, postCategeory);
        if (response.status === 200 || response.status === 201) { // Check if the POST request was successful
            setPostCategory({
                name: "",
                description: ""
            }); // Clear the form
            props.populateCategeoryData();
            console.log(response);
        } else {
            // Handle any errors or issues here
            console.error("Error adding category:", response);
        }
    }


    return (
        <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', flexDirection: 'column', height: '600px' }}>
            <Form style={{ width: "900px", flexDirection: 'column', padding: '30px', boxShadow: '0 4px 6px rgba(0, 0, 0, 0.1)', borderRadius: '8px', fontSize: '18px' }}>
                <Form.Group className="mb-4">
                    <Form.Label style={{ fontWeight: '500', marginBottom: '10px' }}>Category Name</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="Name"
                        style={{ marginBottom: '20px', height: '45px' }}
                        value={postCategeory.name} // Bind the value attribute to the state
                        onChange={(event) => {
                            setPostCategory({ ...postCategeory, name: event.target.value });
                        }}
                    />
                    <Form.Label style={{ fontWeight: '500', marginBottom: '10px' }}>Category Description</Form.Label>
                    <Form.Control
                        type="text"
                        as="textarea"
                        placeholder="Description"
                        value={postCategeory.description} // Bind the value attribute to the state
                        rows={5}
                        style={{ marginBottom: '25px' }}
                        onChange={(event) => {
                            setPostCategory({ ...postCategeory, description: event.target.value });
                        }}
                    />

                </Form.Group>
                <Button variant="primary" size="lg" onClick={() => {
                    AddCategory();
                }}>
                    Add
                </Button>
            </Form>
        </div>


    )
}
