import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/User';

class User extends Component {
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
        this.props.requestUsers(page);
    }

    render() {
        return (
            <div>
                <h1>User</h1>
                {renderUserTable(this.props)}
                {renderPagination(this.props)}
            </div>
        );
    }
}

function renderUserTable(props) {
    console.log(props);
    return (
        <table className='table table-striped'>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>FirstName</th>
                    <th>LastName</th>
                    <th>Gender</th>
                    <th>Email</th>
                    <th>PhoneNumber</th>
                    <th>CreatedDate</th>
                    <th>UpdateDate</th>
                </tr>
            </thead>
            <tbody>
                {props.users.map(user =>
                    <tr key={user.id}>
                        <td>{user.id}</td>
                        <td>{user.firstName}</td>
                        <td>{user.lastName}</td>
                        <td>{user.gender}</td>
                        <td>{user.email}</td>
                        <td>{user.phoneNumber}</td>
                        <td>{user.createdDate}</td>
                        <td>{user.updatedDate}</td>
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
        <Link className='btn btn-default pull-left' to={`/user/${prevStartDateIndex}`}>Previous</Link>
        <Link className='btn btn-default pull-right' to={`/user/${nextStartDateIndex}`}>Next</Link>
        {props.isLoading ? <span>Loading...</span> : []}
    </p>;
}

export default connect(
    state => state.users,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(User);