import React, { Component } from 'react';
import axios from 'axios';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/UpdateProduct';

class UpdateProduct extends Component {
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

        <p>Name</p>
        <input type="text" id="name" />

        <p className="mt-3">Description</p>
        <textarea id="desc" name="desc" cols="30" rows="5" className="form-control"></textarea>

        <p className="mt-3">Price</p>
        <input type="number" id="price" />

        <p className="mt-3">InStock</p>
        <input type="number" id="inStock" />

        <p className="mt-3">CategoryId</p>
        <input type="text" id="categotyId" />
        <br />
        <button className="btn btn-dark mt-3"
            onClick={() => props.updateProduct(
                document.getElementById("id").value,
                document.getElementById("name").value,
                document.getElementById("desc").value,
                document.getElementById("price").value,
                document.getElementById("inStock").value,
                document.getElementById("categotyId").value,
            )}
        >Update Product</button>
    </div>
}


export default connect(
    state => state.updateProduct,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(UpdateProduct);