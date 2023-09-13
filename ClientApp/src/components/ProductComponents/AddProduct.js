import React from 'react'
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import axios from 'axios';

export default function  AddProduct(props) {
    async function AddProduct() {
        //console.log('User data:', props.userData?.token);
        try {
            let finalizeImageUrl = await props.uploadImageToCloudinary();
            //props.setSelectedImage(imageUrl);
            const headers = {
                "Authorization": `Bearer ${props.userData.token}`,
                "Content-Type": "application/json"
            }
            let response = await axios.post(`https://localhost:7223/api/Products`, { ...props.postProduct, imageUrl:finalizeImageUrl, categoryId:props.category.id }, {headers: headers} );
            if(response.status === 200 || response.status === 201) {
                console.log("Adding Product", response.data);
                props.GetProductsById();
            }
        } catch(error) {
            console.error("There was an error posting the product:", error);
            // Optionally: Display a user-friendly error message here
        }
    }

    

    return (
        <div>
            <Modal show={props.show} onHide={() => { props.setShowAddProductForm(false) }} size="xl"> {/* Set size to "lg" for larger modal */}
                <Modal.Dialog className="custom-modal-width">
                    <Modal.Header closeButton>
                        <Modal.Title>Add A Product</Modal.Title>
                    </Modal.Header>

                    <Modal.Body>
                        <Form style={{ fontSize: '18px', padding: '20px' }}>  {/* Adjusted styles for a larger form */}
                            <Form.Group className="mb-4">
                                <Form.Label style={{ fontWeight: '500', marginBottom: '10px' }}>Product Name</Form.Label>
                                <Form.Control type="text" placeholder="Name" style={{ height: '45px' }} onChange={(event) => {
                                    props.setPostProduct({ ...props.postProduct, name: event.target.value });
                                }} />
                                <Form.Label style={{ fontWeight: '500', marginBottom: '10px' }}>Product Description</Form.Label>
                                <Form.Control type="text" as="textarea" rows={5} placeholder="Description" style={{ marginBottom: '20px' }} onChange={(event) => {
                                    props.setPostProduct({ ...props.postProduct, description: event.target.value });
                                }} />
                                <Form.Label style={{ fontWeight: '500', marginBottom: '10px' }}>Product Price</Form.Label>
                                <Form.Control type="number" placeholder="Price" style={{ height: '45px', marginBottom: '20px' }} onChange={(event) => {
                                    props.setPostProduct({ ...props.postProduct, price: parseFloat(event.target.value) });
                                }} />
                                <Form.Label style={{ fontWeight: '500', marginBottom: '10px' }}>Product Image Url</Form.Label>
                                <Form.Control type="file" placeholder="Image Url" style={{ height: '45px', marginBottom: '20px' }} onChange={(event) => {
                                    props.handleImageChange(event)
                                    //props.setPostProduct({ ...props.postProduct, imageUrl: event.target.value });
                                }} />
                                <div style={{display:"flex", justifyContent:'center'}}>
                                    
                                {props.previewImageUrl != null && <img style={{ width: "550px", height:"550px"}} src={props.previewImageUrl} alt='Preview of your selected file'/>}
                                </div>
                            </Form.Group>
                        </Form>
                    </Modal.Body>

                    <Modal.Footer>
                        <Button variant="secondary" onClick={() => { props.setShowAddProductForm(false) }}>Cancel</Button>
                        <Button variant="secondary" onClick={() => { props.setShowAddProductForm(false); AddProduct(); }}>Add</Button>
                    </Modal.Footer>
                </Modal.Dialog>
            </Modal>
        </div>
    )
}
