import React from 'react'
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import axios from 'axios';


function CategoryModal(props) {
    async function UpdateCategory(id) {
        try {
            const headers = {
                "Authorization": `Bearer ${props.userData.token}`
            }
            
            let response = await axios.put(`https://localhost:7223/categeories/${id}`, props.updatedCategory, { headers: headers });
            props.populateCategeoryData()
            props.setCategoeryInfo(response.data);
            console.log("Update Category", response.data);
        }
        catch (err) {
        console.error(err);
        }

    }


    return (
        <Modal show={props.show} onHide={() => { props.setShow(false) }}>
            <Modal.Dialog>
                <Modal.Header closeButton>
                    <Modal.Title>{props.categeory.name}</Modal.Title>
                </Modal.Header>

                <Modal.Body>
                    <h4>{props.categeory.description}</h4>


                </Modal.Body>
                <Form>
                    <Form.Group className="mb-3">
                        <Form.Label>Category Name</Form.Label>
                        <Form.Control type="text" placeholder="Name" onChange={(event) => {
                            props.setUpdatedCategory({ ...props.updatedCategory, name: event.target.value });
                            // updatedCategory={props.updatedCategory}
                        }} />
                        <Form.Label>Category Description</Form.Label>
                        <Form.Control type="text" as="textarea" placeholder="Description" onChange={(event) => {
                            props.setUpdatedCategory({ ...props.updatedCategory, description: event.target.value });
                            // updatedCategory={props.updatedCategory}
                        }} />
                    </Form.Group>

                </Form>

                <Modal.Footer>
                    <Button variant="secondary" onClick={() => { props.setShow(false) }}>Cancel</Button>
                    <Button variant="secondary" onClick={() => { props.setShow(false); UpdateCategory(props.categeory.id); }}>Save Changes</Button>
                </Modal.Footer>
            </Modal.Dialog>
        </Modal>)
}

export default CategoryModal