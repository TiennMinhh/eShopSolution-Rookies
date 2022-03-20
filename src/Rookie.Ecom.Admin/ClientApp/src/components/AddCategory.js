import React, { Component } from 'react';
import axios from 'axios';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/AddCategory';

class AddCategory extends Component {
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
                <h1>Add Category</h1>
                {renderAddCategoryFormat(this.props)}
            </div>
        );
    }
}

function renderAddCategoryFormat(props) {
    return <div className="mb-3">
        <div className="row">
            <div className="form-group col-md-8">
                <label for="name">Category name</label>
                <input type="text" className="form-control" id="name" placeholder="Category name"/>
            </div>
        </div>
        <div className="row">
            <div className="form-group col-md-6">
                <label for="parentId">Parent category</label>
                <input type="text" className="form-control" id="parentId" placeholder="Parent Cateogry Id"/>
            </div>
            <div className="form-group col-md-2">
                <label for="sortOrder">Sort order</label>
                <input type="number" min={0} placeholder="0" className="form-control" id="sortOrder" />
            </div>
        </div>
        <div className="row">

            <div className="form-group col-md-8">
                <label for="desc">Description</label>
                <textarea id="desc" cols="30" rows="5" className="form-control" placeholder="Description for category"></textarea>
            </div>
        </div>
        <button className="btn btn-primary"
            onClick={() => props.addCategory(
                document.getElementById("name").value,
                document.getElementById("parentId").value,
                document.getElementById("sortOrder").value,
                document.getElementById("desc").value

            )}
        >Add Category</button>
    </div>
}


export default connect(
    state => state.addCategory,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(AddCategory);