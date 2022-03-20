import React, { Component } from 'react';
import axios from 'axios';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/UpdateProductImage';

class UpdateProductImage extends Component {
    componentDidMount() {
        // This method is called when the component is first updateed to the document
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
        this.props.requestUpdateCategories(page);*/
    }

    render() {
        return (
            <div>
                <h1>Update Product</h1>
                {renderUpdateProductFormat(this.props)}
            </div>
        );
    }
}

function renderUpdateProductFormat(props) {
    return <div className="mb-3">
        <p>Id</p>
        <input type="text" id="id" />

        <p>Title</p>
        <input type="text" id="title" />

        <p>ImageUrl</p>
        <input type="text" id="imageUrl" />

        <p>ProductId</p>
        <input type="text" id="productId" />

        <br />
        <button className="btn btn-dark mt-3"
            onClick={() => props.updateProductImage(
                document.getElementById("id").value,
                document.getElementById("imageUrl").value,
                document.getElementById("title").value,
                document.getElementById("productId").value,
            )}
        >Update Product Image</button>
    </div>
}


export default connect(
    state => state.updateProductImage,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(UpdateProductImage);