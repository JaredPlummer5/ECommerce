import React, { useState } from 'react'
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';


function CategoryModal(props) {


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
                        <Form.Control type="text" placeholder="Name" />
                        <Form.Label>Category Description</Form.Label>
                        <Form.Control type="text" as="textarea" placeholder="Description" />
                    </Form.Group>

                </Form>

                <Modal.Footer>
                    <Button variant="secondary" onClick={() => { props.setShow(false) }}>Close</Button>
                    <Button variant="secondary" onClick={() => { props.setShow(false) }}>Edit</Button>
                </Modal.Footer>
            </Modal.Dialog>
        </Modal>)
}

export default CategoryModal