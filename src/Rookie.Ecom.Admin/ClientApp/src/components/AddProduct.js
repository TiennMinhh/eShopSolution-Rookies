import React, { Component } from 'react';
import axios from 'axios';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/AddProduct';

class AddProduct extends Component {
    componentDidMount() {
        // This method is called when the component is first added to the document
        this.ensureDataFetched();
    }

    componentDidUpdate() {
        // This method is called when the route parameters change
        this.ensureDataFetched();
    }

    ensureDataFetched() {
        /*console.log(this.props.match.params.page);
        const page = parseInt(this.props.match.params.page, 5) || 0;
        console.log(page);
        this.props.requestAddCategories(page);*/
    }

    render() {
        return (
            <div>
                <h1>Add Product</h1>
                {renderAddProductFormat(this.props)}
            </div>
        );
    }
}

function renderAddProductFormat(props) {
    return <div className="mb-3">
        <div className="row">
            <div className="form-group col-md-8">
                <label for="name">Product name</label>
                <input type="text" className="form-control" id="name" placeholder="product name" />
            </div>
        </div>
        <div className="row">
            <div className="form-group col-md-4">
                <label for="categoryId">Category Id</label>
                <input type="text" className="form-control" id="categoryId" placeholder="Cateogry Id" />
            </div>
            <div className="form-group col-md-2">
                <label for="price">Price</label>
                <input type="number" min={0} placeholder="0" className="form-control" id="price" />
            </div>
            <div className="form-group col-md-2">
                <label for="quantity">Quantity</label>
                <input type="number" min={0} className="form-control" id="quantity1" placeholder="" />
            </div>
        </div>
        <div className="row">
            <div className="form-group col-md-8">
                <label for="desc">Description</label>
                <textarea id="desc" cols="30" rows="5" className="form-control" placeholder="Description for category"></textarea>
            </div>
        </div>
        <div className="row ml-2 mb-2">
            <div class="form-check">
                <label class="form-check-label">
                    <input type="checkbox" class="form-check-input" value="true" id="isHome"/>IsHome
                </label>
            </div>
            <div class="form-check ml-2">
                <label class="form-check-label">
                    <input type="checkbox" class="form-check-input" value="true" id="isFeatured"/>IsFeature
                </label>
            </div>
        </div>        
        <button className="btn btn-primary"
            onClick={() => props.addProduct(
                document.getElementById("name").value,
                document.getElementById("desc").value,
                document.getElementById("price").value,
                document.getElementById("quantity").value,
                document.getElementById("categotyId").value,
                document.getElementById("isHome").checked,
                document.getElementById("isFeatured").checked
            )}
        >Add Product</button>
    </div>
}


export default connect(
    state => state.addProduct,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(AddProduct);