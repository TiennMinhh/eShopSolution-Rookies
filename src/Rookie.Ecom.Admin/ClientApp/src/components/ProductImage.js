import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/ProductImage';


class ProductImage extends Component {
    componentDidMount() {
        // This method is called when the component is first added to the document
        this.ensureDataFetched();
    }

    componentDidUpdate() {
        // This method is called when the route parameters change
        this.ensureDataFetched();
    }

    ensureDataFetched() {
        console.log(this.props.match.params.page);
        const page = parseInt(this.props.match.params.page, 5) || 0;
        console.log(page);
        this.props.requestProductImages(page);
    }

    render() {
        return (
            <div>
                <h1>Product Image</h1>
                {renderProductImageTable(this.props)}
                {renderPagination(this.props)}
            </div>
        );
    }
}

function renderProductImageTable(props) {
    console.log(props);
    return (
        <table className='table table-striped'>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Title</th>
                    <th>ProductId</th>
                    <th>ImageId</th>
                    <th>CreatedDate</th>
                    <th>UpdateDate</th>
                </tr>
            </thead>
            <tbody>
                {props.productimages.map(prod =>
                    <tr key={prod.id}>
                        <td>{prod.id}</td>
                        <td>{prod.title}</td>
                        <td>{prod.productId}</td>
                        <td>{prod.imageUrl}</td>
                        <td>{prod.createdDate}</td>
                        <td>{prod.updatedDate}</td>
                    </tr>
                )}
            </tbody>
        </table>
    );
}

function renderPagination(props) {
    const prevStartDateIndex = (props.page || 0) - 1;
    const nextStartDateIndex = (props.page || 0) + 1;

    return <p className='clearfix text-center'>
        <Link className='btn btn-default pull-left' to={`/productimage/${prevStartDateIndex}`}>Previous</Link>
        <Link className='btn btn-default pull-right' to={`/productimage/${nextStartDateIndex}`}>Next</Link>
        {props.isLoading ? <span>Loading...</span> : []}
    </p>;
}

export default connect(
    state => state.productimages,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(ProductImage);