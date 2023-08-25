import React from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';

import { Card, Button } from 'react-bootstrap'
import axios from 'axios';


export default function ProductCard(props) {
    async function DeleteProduct() {
        let response = axios.delete("https://localhost:7223/Products");
    }

    async function UpdateProduct() {
        let response = axios.put("https://localhost:7223/Products", 
            {
            
        });
    }

    let products = props.products.map(product => {

        return (
            <Card style={{ width: '18rem' }}>
                <Card.Img variant="top" src="https://placehold.co/600x400" />
                <Card.Body>
                    <Card.Title>{product.name}</Card.Title>
                    <Card.Text>
                        {product.description}
                    </Card.Text>
                    <div style={{ display: "flex", justifyContent: "space-evenly" }}>
                        <Button style={{ margin: "10px" }} variant="primary">Edit</Button>
                        <Button style={{ margin: "10px" }} variant="primary">Delete</Button>
                    </div>
                </Card.Body>
            </Card>

        )
    });






    return (
        <div style={{display:"flex", justifyContent:"space-evenly"}}>
            {products}
        </div>
    )
}

