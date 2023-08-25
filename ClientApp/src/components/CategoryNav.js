import React, { useEffect } from 'react'
import CategoryModal from './CategoryModal';
import { Link } from 'react-router-dom';


export default function CategoryNav(props) {
    return (
        <div style={{ display: "flex", justifyContent: "center" }}>
            <ul className="breadcrumb">
                {
                    props.categeories.map((categeory, index) => {




                        return (
                            <p className="breadcrumb-item" key={categeory.id}>

                                <button type="button" className="btn btn-outline-primary btn-sm" onClick={() => {
                                    
                                    props.setCategoeryInfo(categeory);
                                    props.setProducts(categeory.products);
                                    
                                    
                                }}>
                                    <Link to={"/Products"} style={{textDecoration: 'none'}}>
                                        {categeory.name}
                                    </Link>
                                </button>


                                <CategoryModal
                                    
                                    products={categeory.products}
                                    setProducts={props.setProducts}
                                    categeory={props.categoeryInfo}
                                    setShow={props.setShow}
                                    show={props.show}
                                />
                            </p>


                        )

                    })
                }
            </ul>
        </div>
    )
}
