import React, { useState, useEffect } from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import ProductEditForm from './ProductEditForm';
import { Card, Button } from 'react-bootstrap'
import axios from 'axios';
import "./AddProduct.css"
import AddProduct from './AddProduct';
import { InputGroup, Form } from 'react-bootstrap';


export default function ProductCard(props) {
    const [showProductEditForm, setShowProductEditForm] = useState(false);
    const [product, setProduct] = useState({});
    const [showAddProductForm, setShowAddProductForm] = useState(false);
    const [searchQuery, setSearchQuery] = useState("");
    const [selectedImage, setSelectedImage] = useState();
    const [previewImageUrl, setPreviewImageUrl] = useState("");
    const [finalizeImageUrl, setFinalizeImageUrl] = useState('');

    useEffect(() => {
        // On component mount, retrieve products data from localStorage
        const savedProducts = localStorage.getItem('products');
        console.log("decodedUser", props.decodedUser);
        if (savedProducts) {
            props.setProducts(JSON.parse(savedProducts));
        }
    }, []);

    useEffect(() => {
        // Whenever products state changes, save it to localStorage
        if (props.products && props.products.length > 0) {
            localStorage.setItem('products', JSON.stringify(props.products));
        }
    }, [props.products]);

    const handleImageChange = (event) => {
        const file = event.target.files[0];
        setSelectedImage(file);

        // Create an object URL for the file
        const imageToUrl = URL.createObjectURL(file);
        setPreviewImageUrl(imageToUrl); // Assuming you have a useState for imageUrl
    };
    // console.log('Cloudinary Url: https://api.cloudinary.com/v1_1/' + `${process.env.REACT_APP_CLOUDINARY_URL}`.split('@')[0].split('//')[1] + "/image/upload")
    const uploadImageToCloudinary = async () => {
        const formData = new FormData();
        formData.append('file', selectedImage);
        formData.append('upload_preset', process.env.REACT_APP_CLOUDINARY_PRESET_NAME);  // replace with your upload preset
        formData.append('cloud_name', process.env.REACT_APP_CLOUDINARY_CLOUD_NAME);  // replace with your cloud name

        try {
            const response = await axios.post('https://api.cloudinary.com/v1_1/dcrnncysg/image/upload', formData);

            console.log(response.data.url);  // This will contain the public_id and the URL of the uploaded image
            return response.data.secure_url
        } catch (error) {
            console.error("Error uploading image", error);
        }
    };
    const headers = {
        "Authorization": `Bearer ${props.userData?.token}`
    }
    //Get Products by Id
    async function GetProductById(id) {
        let response = await axios.get(`https://localhost:7223/api/Products/${id}`);
        // console.log(response);
        setProduct(response.data)
    }

    // Delete Products
    async function DeleteProduct(id) {
        await axios.delete(`https://localhost:7223/api/Products/${id}`, { headers: headers });
        // console.log(response.data)
        GetProductsById()
    }
    //Update Product
    async function UpdateProduct(id) {

        await axios.put(`https://localhost:7223/api/Products/${id}`, props.updatedProduct, { headers: headers });
        GetProductsById()
    }
    // Get Products by Category Id 
    async function GetProductsById() {
        let response = await axios.get(`https://localhost:7223/categeories/${props.category.id}`);
        // console.log(response.data)
        props.setProducts(response.data.products)
    }



    // Filtered Products by name
    let filteredProducts = props.products.filter(product =>
        product.name.toLowerCase().includes(searchQuery.toLowerCase())
    );

    // console.log("Roles do exist:", props?.decodedUser?.role?.includes("admin"))

    // Array of products filtered
    let products = filteredProducts.map((product, index) => {
        let imgSrc = product.imageUrl != null ? product.imageUrl : "https://placehold.co/600x400"
        return (
            <div key={`${product.id}-${index}`} style={{ margin: "10px" }}>
                <Card style={{ width: '18rem' }}>
                    <Card.Img variant="top" src={imgSrc} style={{ width: '100%', height: '250px', objectFit: 'cover' }} />
                    <Card.Body>
                        <Card.Title>{product.name}</Card.Title>
                        <Card.Text>
                            {product.description}
                        </Card.Text>

                        <div style={{ display: "flex", justifyContent: "space-evenly" }}>
                            <Button >
                                Add to Cart
                            </Button>
                            {
                                props?.decodedUser?.roles?.includes("Editor") &&
                                <Button onClick={() => {
                                    // Set the state of showProductEditForm to true to show the edit form
                                    setShowProductEditForm(true);
                                    // Set the state of product to the product that was clicked on
                                    props.setUpdatedProduct(product);
                                    // Get the Product from the selected Categeory
                                    GetProductById(product.id);
                                }}
                                    style={{ margin: "10px" }} variant="primary">
                                    Edit
                                </Button>
                            }

                            {
                                props?.decodedUser?.roles?.includes("Admin") &&
                                <Button
                                    onClick={() => { DeleteProduct(product.id); }}
                                    style={{ margin: "10px" }}
                                    variant="primary">
                                    Delete
                                </Button>
                            }
                        </div>
                    </Card.Body>
                </Card>

            </div>
        )
    });






    return (
        <div>
            <div style={{ display: "flex", justifyContent: "center", alignItems: "center", flexDirection: "column", margin: "20px" }}>


                <h1>
                    Products
                </h1>


                {/* Search Bar */}
                <InputGroup className="mb-3">
                    <InputGroup.Text id="basic-addon1">🔍</InputGroup.Text>
                    <Form.Control
                        className='search-bar'
                        placeholder="Search for products..."
                        aria-label="Search for products..."
                        aria-describedby="basic-addon1"
                        onChange={(e) => setSearchQuery(e.target.value)}
                    />
                </InputGroup>

                <div style={{ display: "flex", justifyContent: "space-evenly", margin: "20px" }}>
                    {props.renderAddProductsButton ?
                        <Button
                            style={{ marginRight: "20px" }}
                            onClick={() => { props.setShow(true); }}>
                            View Details
                        </Button> : ""
                    }

                    {props.renderAddProductsButton && props ?
                        <Button
                            style={{ marginLeft: "20px" }}
                            onClick={() => { setShowAddProductForm(true); }}>
                            Add Product to {props.category.name}
                        </Button> : ""}
                </div>
            </div>

            <div style={{ display: "flex", justifyContent: "space-evenly", flexWrap: "wrap" }}>

                {products}

            </div>
            <ProductEditForm
                handleImageChange={handleImageChange}
                uploadImageToCloudinary={uploadImageToCloudinary}
                show={showProductEditForm}
                product={product}
                setShow={setShowProductEditForm}
                updatedProduct={props.updatedProduct}
                UpdateProduct={UpdateProduct}
                setUpdatedProduct={props.setUpdatedProduct}
                previewImageUrl={previewImageUrl}
            />

            <AddProduct
                previewImageUrl={previewImageUrl}
                handleImageChange={handleImageChange}
                uploadImageToCloudinary={uploadImageToCloudinary}
                selectedImage={selectedImage}
                setSelectedImage={setSelectedImage}
                finalizeImageUrl={finalizeImageUrl}
                show={showAddProductForm}
                setShowAddProductForm={setShowAddProductForm}
                category={props.category}
                setPostProduct={props.setPostProduct}
                postProduct={props.postProduct}
                GetProductsById={GetProductsById}
                userData={props.userData}
            />
        </div>
    )
}

