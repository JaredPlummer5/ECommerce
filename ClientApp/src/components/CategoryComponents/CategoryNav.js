import React from 'react'
import CategoryModal from './EditCategoryModal';
import { Link } from 'react-router-dom';


export default function CategoryNav(props) {
   
    return (
        <div style={{ display: "flex", justifyContent: "center" }}>
            <ul className="breadcrumb">
                <p className="breadcrumb-item" >

                    <button type="button" className="btn btn-sm"
                        style={{
                            background: 'linear-gradient(135deg, #84FAB0, #8FD3F4)',
                            border: 'none',
                            color: 'white',
                            transition: 'background 0.3s ease'
                        }}
                        onClick={() => {
                            props.GetProducts();
                            props.setRenderAddProductsButton(false);
                        }}
                        onMouseOver={e => {
                            e.currentTarget.style.background = 'linear-gradient(105deg, #84FAB0, #8FD3F4)';
                        }}
                        onMouseOut={e => {
                            e.currentTarget.style.background = 'linear-gradient(135deg, #84FAB0, #8FD3F4)';
                        }}
                    >
                        <Link

                            to={"/Products"}
                            style={{ textDecoration: 'none' }}
                        >
                            All
                        </Link>
                    </button>
                </p>
                {
                    props.categeories.map((categeory, index) => {




                        return (
                            <p className="breadcrumb-item" key={categeory.id}>

                                <button type="button" className="btn btn-sm" onClick={() => {

                                    props.setCategoeryInfo(categeory);
                                    props.setProducts(categeory.products);
                                    props.setRenderAddProductsButton(true);

                                }}

                                    style={{
                                        background: 'linear-gradient(135deg, #84FAB0, #8FD3F4)',
                                        border: 'none',
                                        color: 'white',
                                        transition: 'background 0.3s ease'
                                    }}

                                    onMouseOver={e => {
                                        e.currentTarget.style.background = 'linear-gradient(105deg, #84FAB0, #8FD3F4)';
                                    }}
                                    onMouseOut={e => {
                                        e.currentTarget.style.background = 'linear-gradient(135deg, #84FAB0, #8FD3F4)';
                                    }}




                                >
                                    <Link

                                        to={"/Products"}
                                        style={{ textDecoration: 'none' }}>
                                        {categeory.name}
                                    </Link>
                                </button>


                                <CategoryModal
                                    populateCategeoryData={props.populateCategeoryData}
                                    setCategoeryInfo={props.setCategoeryInfo}
                                    setUpdatedCategory={props.setUpdatedCategory}
                                    updatedCategory={props.updatedCategory}
                                    products={categeory.products}
                                    setProducts={props.setProducts}
                                    categeory={props.categoeryInfo}
                                    setShow={props.setShow}
                                    show={props.show}
                                    userData={props.userData}
                                />
                            </p>


                        )

                    })
                }
            </ul>
        </div>
    )
}
