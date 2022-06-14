import React, { Component } from 'react';
import axios from 'axios';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/AddProductImage';

class AddProductImage extends Component {
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
        <p>Title</p>
        <input type="text" id="title" />

        <p>ImageUrl</p>
        <input type="text" id="imageUrl" />

        <p>ProductId</p>
        <input type="text" id="productId" />

        <br />
        <button className="btn btn-dark mt-3"
            onClick={() => props.addProductImage(
                document.getElementById("imageUrl").value,
                document.getElementById("title").value,
                document.getElementById("productId").value,
            )}
        >Add Product Image</button>
    </div>
}


export default connect(
    state => state.addProductImage,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(AddProductImage);