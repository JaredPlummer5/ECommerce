// eslint-disable-next-line
import React from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';


export default function EditForm(props) {


    return (

        <Modal show={props.show} onHide={() => { props.setShow(false);  }}>
            <Modal.Dialog>
                <Modal.Header closeButton>
                    <Modal.Title>{props.product.name}</Modal.Title>
                </Modal.Header>

                <Modal.Body>
                    <h4>{props.product.description}</h4>


                </Modal.Body>
                <Form>
                    <Form.Group className="mb-3">
                        <Form.Label>Product Name</Form.Label>
                        <Form.Control type="text" placeholder="Name" onChange={(event) => {
                            props.setUpdatedProduct({ ...props.updatedProduct, name: event.target.value });
                            // updatedCategory={props.updatedCategory}
                        }} />
                        <Form.Label>Product Description</Form.Label>
                        <Form.Control type="text" as="textarea" placeholder="Description" onChange={(event) => {
                            props.setUpdatedProduct({ ...props.updatedProduct, description: event.target.value });
                            // updatedCategory={props.updatedCategory}
                        }} />
                    </Form.Group>

                </Form>

                <Modal.Footer>
                    <Button variant="secondary" onClick={() => { props.setShow(false) }}>Cancel</Button>
                    <Button variant="secondary" onClick={() => { props.setShow(false); props.UpdateProduct(props.updatedProduct.id) }}>Save Changes</Button>
                </Modal.Footer>
            </Modal.Dialog>
        </Modal>)

}



